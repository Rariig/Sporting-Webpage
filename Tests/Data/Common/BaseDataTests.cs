using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Aids;
using SportEU.Core;
using SportEU.Data.Common;

namespace SportEU.Tests.Data.Common
{
    [TestClass]
    public class BaseDataTests : AbstractClassTests<BaseData, UniqueItem>
    {
        private class testClass : BaseData { }
        protected override BaseData getObject() => GetRandom.ObjectOf<testClass>();
        [TestMethod] public void RowVersionTest() => isReadWriteProperty<byte[]>();

    }
}
