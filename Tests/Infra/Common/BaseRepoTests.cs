using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Data;
using SportEU.Infra.Common;

namespace SportEU.Tests.Infra.Common
{
    [TestClass]
    public class BaseRepoTests : AbstractClassTests<BaseRepo<GroupData>, object>
    {
        [TestMethod] public void ErrorMessageTest() => isProperty<string>();
        [TestMethod] public void EntityInDbTest() => isProperty<GroupData>();
    }
}
