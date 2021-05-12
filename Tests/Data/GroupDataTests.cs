using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Data;
using SportEU.Data.Common;

namespace SportEU.Tests.Data
{
    [TestClass]
    public class GroupDataTests : SealedClassTests<GroupData, NamedData>
    {
        [TestMethod] public void CoachIdTest() => isReadWriteProperty<string>();
    }
}
