using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportEU.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace SportEU.Infra.Common
{
    public abstract class FilteredRepo<TEntity, TData> : CrudRepo<TEntity, TData>
        where TData : BaseData, IEntityData, new()
    {
        private string currentFilter;
        private string searchString;
        protected FilteredRepo(DbContext c = null, DbSet<TData> s = null) : base(c, s) { }
        protected internal override IQueryable<TData> createSql() => applyFilters(base.createSql());
        protected internal virtual IQueryable<TData> applyFilters(IQueryable<TData> query) => query;
        public override string CurrentFilter
        {
            get => currentFilter;
            set => setFilter(value, searchString);
        }
        public override string SearchString
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
    }
}
