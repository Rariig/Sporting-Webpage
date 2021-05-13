using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Data;
using SportEU.Domain;
using SportEU.Infra.Common;

namespace SportEU.Tests.Infra.Common
{
    [TestClass]
    public class PagedRepoTests : AbstractClassTests<PagedRepo<Group, GroupData>
        , OrderedRepo<Group, GroupData>>
    {
    }
}
