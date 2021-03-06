using SportEU.Core;
using SportEU.Domain.Repos;
using SportEU.Infra;

namespace SportEU.Pages.Common
{
    public abstract class FilteredPage<TEntity, TView> : CrudPage<TEntity, TView>
        where TEntity : class, IBaseEntity, new()
        where TView : class, IEntityData, new()
    {
        protected FilteredPage(IRepo<TEntity> r, ApplicationDbContext c = null) : base(r, c) { }
        public override string CurrentFilter
        {
            get => repo.CurrentFilter;
            set => repo.CurrentFilter = value;
        }
        public override string SearchString
        {
            get => repo.SearchString;
            set => repo.SearchString = value;
        }
    }
}
