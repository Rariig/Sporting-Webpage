using SportEU.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.Aids
{
    [TestClass]
    public class CreateNewTests : StaticClassTests
    {
        internal class testClassStr
        {
            public testClassStr(string s) { strField = s; }
            protected internal readonly string strField;
        }
        internal class testClassInt
        {
            public testClassInt(int i) { intField = i; }
            protected internal readonly int intField;
        }
        [TestInitialize] public void TestInitialize() => type = typeof(CreateNew);

        [TestMethod]
        public void InstanceTest()
        {
            testCreate<testClassStr>();
            testCreate<testClassInt>();
            testCreate<CreateNewTests>();
        }
        [DataRow(typeof(testClassStr))]
        [DataRow(typeof(testClassInt))]
        [DataRow(typeof(CreateNewTests))]
        [DataTestMethod]
        public void InstanceTestByType(Type t) => testCreate(t);
        private static void testCreate(Type t)
        {
            var o = CreateNew.Instance(t);
            Assert.IsNotNull(o);
            Assert.IsInstanceOfType(o, t);
        }
        private static void testCreate<T>()
        {
            var o = CreateNew.Instance<T>();
            Assert.IsNotNull(o);
            Assert.IsInstanceOfType(o, typeof(T));
        }
    }
}
