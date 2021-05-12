using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Aids;
using SportEU.Data;
using SportEU.Domain;

namespace SportEU.Tests.Domain.Common
{
    [TestClass]
    public class BaseEntityTests : AbstractClassTests<BaseEntity<GroupData>, object>
    {
        private class testClass : BaseEntity<GroupData>
        {
            public testClass(GroupData d = null) : base(d) { }
        }

        protected override BaseEntity<GroupData> getObject() => new testClass(GetRandom.ObjectOf<GroupData>());

        [TestMethod]
        public void DataTest()
        {
            isReadOnlyProperty<GroupData>();
            Assert.AreNotSame(obj.Data, obj.Data);
            Assert.AreNotEqual(obj.Data, obj.Data);
            arePropertiesEqual(obj.Data, obj.Data);
            var actual = obj.Data;
            var expected = GetRandom.ObjectOf<GroupData>();
            Copy.Members(expected, actual);
            arePropertiesEqual(expected, actual);
            arePropertiesNotEqual(expected, obj.Data);
        }
        [TestMethod] public void IdTest() => isReadOnlyProperty(obj.Data.Id);
        [TestMethod] public void RowVersionTest() => isReadOnlyProperty(obj.Data.RowVersion);
    }
}
