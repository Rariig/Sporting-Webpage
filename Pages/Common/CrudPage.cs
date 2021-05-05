using System.Collections.Generic;
using SportEU.Core;
using SportEU.Domain.Repos;
using SportEU.Infra;

namespace SportEU.Pages.Common
{
    public abstract class CrudPage<TEntity, TView> : BasePage<TEntity, TView>
        where TEntity : class, IBaseEntity, new()
        where TView : class, IEntityData, new()
    {
        protected CrudPage(IRepo<TEntity> r, ApplicationDbContext c = null) : base(r, c) { }

        public IList<TView> Items { get; set; }
    }
}
