using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Domain.Repos;
using Data;
using Microsoft.EntityFrameworkCore;
using SportEU.Core;

namespace Infra.Common
{
    public abstract class BaseRepo<TEntity, TData> : BaseRepo<TData>, IRepo<TEntity>
       where TData : BaseEntityData, IEntityData, new()
    {
        protected abstract TEntity toEntity(TData d);
        protected abstract TData toData(TEntity e);
        protected BaseRepo(DbContext c = null, DbSet<TData> s = null) : base(c, s) { }
        public new TEntity EntityInDb => toEntity(base.EntityInDb);
        public async new Task<List<TEntity>> Get() => (await base.Get()).Select(toEntity).ToList();
        public async new Task<TEntity> Get(string id) => toEntity(await base.Get(id));
        public virtual async Task<bool> Delete(TEntity e) => await Delete(toData(e));
        public virtual async Task<bool> Add(TEntity e) => await Add(toData(e));
        public virtual async Task<bool> Update(TEntity e) => await Update(toData(e));
        public new TEntity GetById(string id) => toEntity(base.GetById(id));
    }

    public abstract class BaseRepo<T> : IRepo<T> where T : BaseEntityData, IEntityData, new()
    {
        protected internal readonly DbSet<T> dbSet;
        protected internal readonly DbContext db;
        public string ErrorMessage { get; protected set; }
        public T EntityInDb { get; protected set; }

        protected BaseRepo(DbContext c = null, DbSet<T> s = null)
        {
            dbSet = s;
            db = c;
        }
        public async Task<List<T>> Get() => await createSql().ToListAsync();
        protected internal virtual IQueryable<T> createSql() => dbSet.AsNoTracking();

        public async Task<T> Get(string id)
        {
            if (id is null) return null;
            if (dbSet is null) return null;
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<bool> Delete(T obj)
        {
            var isOk = await isEntityOk(obj, ErrorMessages.ConcurrencyOnDelete);
            if (isOk) dbSet.Remove(obj);
            await db.SaveChangesAsync();
            return isOk;
        }

        public async Task<bool> Add(T obj)
        {
            var isOk = await isEntityOk(obj, true);
            if (isOk) await dbSet.AddAsync(obj);
            await db.SaveChangesAsync();
            return isOk;
        }

        public async Task<bool> Update(T obj)
        {
            var isOk = await isEntityOk(obj, ErrorMessages.ConcurrencyOnEdit);
            if (isOk) dbSet.Update(obj);
            await db.SaveChangesAsync();
            return isOk;
        }

        public T GetById(string id) => Get(id).GetAwaiter().GetResult();

        internal static bool byteArrayCompare(ReadOnlySpan<byte> a1, ReadOnlySpan<byte> a2)
            => a1.SequenceEqual(a2);

        private bool errorMessage(string msg)
        {
            ErrorMessage = msg;
            return false;
        }

        internal async Task<bool> isEntityOk(T obj,
            string concurrencyErrorMsg)
        {
            return await isEntityOk(obj, false)
                   && isCorrectVersion(obj, concurrencyErrorMsg);
        }

        private async Task<bool> isEntityOk(T obj, bool isNewItem)
        {
            if (obj is null) return errorMessage("Item is null");
            if (dbSet is null) return errorMessage("DbSet is null");
            EntityInDb = await Get(obj.Id);
            return (EntityInDb is null) == isNewItem
                   || errorMessage(
                       isNewItem
                           ? $"Item with id = <{obj.Id}> already in database"
                           : $"No item with id = <{obj.Id}> in database");
        }

        internal bool isCorrectVersion(T obj,
            string concurrencyErrorMsg)
        {
            return byteArrayCompare(obj?.RowVersion, EntityInDb?.RowVersion)
                   || errorMessage(concurrencyErrorMsg);
        }

        public abstract int PageIndex { get; set; }
        public abstract int TotalPages { get; }
        public abstract bool HasNextPage { get; }
        public abstract bool HasPreviousPage { get; }
        public abstract int PageSize { get; set; }
        public abstract string CurrentFilter { get; set; }
        public abstract string SearchString { get; set; }
    }
}
