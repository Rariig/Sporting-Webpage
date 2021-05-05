using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportEU.Core;
using SportEU.Domain.Repos;
using SportEU.Infra;

namespace SportEU.Pages.Common
{
    public abstract class PagedPage<TEntity, TView> : OrderedPage<TEntity, TView>
        where TEntity : class, IBaseEntity, new()
        where TView : class, IEntityData, new()
    {
        protected PagedPage(IRepo<TEntity> r, ApplicationDbContext c = null) : base(r, c) { }
        public override bool HasNextPage => repo.HasNextPage;
        public override bool HasPreviousPage => repo.HasPreviousPage;
        public override int? PageIndex
        {
            get => repo.PageIndex;
            set => repo.PageIndex = value;
        }
    }
}
