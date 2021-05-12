using SportEU.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.Aids
{
    [TestClass]
    public class CopyTests : StaticClassTests
    {
        private class testClass1
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public DateTime DoB { get; set; }
        }
        private class testClass2
        {
            public string AdministratorId { get; set; }
            public string Name { get; set; }
            public DateTime DoB { get; set; }
        }
        [TestInitialize] public void TestInitialize() => type = typeof(Copy);
        [TestMethod]
        public void MemberTest()
        {
            var x = GetRandom.ObjectOf<testClass1>();
            var y = new testClass2();
            y = Copy.Members(x, y);
            Assert.AreEqual(x.Name, y.Name);
            Assert.AreEqual(x.DoB, y.DoB);
        }
    }
}
