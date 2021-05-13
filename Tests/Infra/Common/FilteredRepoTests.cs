using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Data;
using SportEU.Domain;
using SportEU.Infra.Common;

namespace SportEU.Tests.Infra.Common
{
    [TestClass]
    public class FilteredRepoTests : AbstractClassTests<FilteredRepo<Group, GroupData>
        , CrudRepo<Group, GroupData>>
    {
    }
}
