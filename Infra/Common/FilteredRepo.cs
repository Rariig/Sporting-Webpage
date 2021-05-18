using System;
using System.Linq;
using System.Linq.Expressions;
using SportEU.Data.Common;
using Microsoft.EntityFrameworkCore;
using SportEU.Core;
using SportEU.Domain.Repos;

namespace SportEU.Infra.Common
{
    public abstract class FilteredRepo<TEntity, TData> : CrudRepo<TEntity, TData>, IFilteredRepo
        where TData : BaseData, IEntityData, new()
    {
        private string currentFilter;
        private string searchString;
        protected FilteredRepo(DbContext c = null, DbSet<TData> s = null) : base(c, s) { }
        protected internal override IQueryable<TData> createSql() => applyFilters(base.createSql());
        protected internal virtual IQueryable<TData> applyFilters(IQueryable<TData> query) => query;

        public virtual int? PageIndex { get; set; }

        public virtual string CurrentFilter
        {
            get => currentFilter;
            set => setFilter(value, searchString);
        }
        public virtual string SearchString
        {
            get => searchString;
            set => setFilter(currentFilter, value);
        }
        protected internal virtual void setFilter(string curFilter, string searchStr)
        {
            setPageIndex(searchStr);
            setSearchString(curFilter, searchStr);
            setCurrentFilter(searchStr);
        }
        protected internal virtual void setCurrentFilter(string searchStr)
            => currentFilter = searchStr;
        protected internal virtual void setSearchString(string curFilter, string searchStr)
            => searchString = searchStr ?? curFilter;
        protected internal virtual void setPageIndex(string searchStr)
            => PageIndex = (searchStr == null) ? PageIndex : 1;


        // TODO panna repod seda otsimismeetodit kasutama
        //internal Expression<Func<TData, bool>> createWhereExpression()
        //{
        //    var param = Expression.Parameter(typeof(TData), "s");
        //    Expression predicate = null;
        //    foreach (var p in typeof(TData).GetProperties())
        //    {
        //        Expression body = Expression.Property(param, p);
        //        if (p.PropertyType == typeof(bool)) continue;
        //        if (p.PropertyType.IsEnum) continue;
        //        if (p.PropertyType != typeof(string))
        //            body = Expression.Call(body, "ToString", null);
        //        body = Expression.Call(body, "Contains", null, Expression.Constant(SearchString));
        //        predicate = predicate is null ? body : Expression.Or(predicate, body);
        //    }
        //    return predicate is null ? null : Expression.Lambda<Func<TData, bool>>(predicate, param);
        //}
    }
}
