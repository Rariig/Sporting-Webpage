using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Aids;
using SportEU.Core;

namespace SportEU.Tests.Core
{
    [TestClass]
    public class UniqueItemTests : AbstractClassTests<UniqueItem, object>
    {
        private class testClass : UniqueItem { }
        protected override UniqueItem getObject() => GetRandom.ObjectOf<testClass>();
        [TestMethod] public void IdTest() => isReadWriteProperty<string>();
        [TestMethod]
        public void DefaultIdTest()
        {
            obj = new testClass();
            isFalse(string.IsNullOrWhiteSpace(obj.Id));
        }
        [TestMethod]
        public void DefaultIdIsGuidTest()
        {
            obj = new testClass();
            var guid = Guid.Parse(obj.Id);
            Assert.AreEqual(obj.Id, guid.ToString());
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void AnyStringIsNotGuidTest()
        {
            var s = GetRandom.String();
            var _ = Guid.Parse(s);
        }
    }
}
