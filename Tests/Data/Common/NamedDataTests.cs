using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Aids;
using SportEU.Data.Common;
using SportEU.Tests;

namespace Tests.Data.Common
{
    [TestClass]
    public class NamedDataTests : AbstractClassTests<NamedData, BaseData>
    {
        private class testClass : NamedData { }
        protected override NamedData getObject() => GetRandom.ObjectOf<testClass>();
        [TestMethod] public void NameTest() => isReadWriteProperty<string>();
    }
}
