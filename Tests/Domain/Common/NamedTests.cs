using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Aids;
using SportEU.Data;
using SportEU.Domain;
using SportEU.Domain.Common;

namespace SportEU.Tests.Domain.Common
{
    [TestClass]
    public class NamedEntityTests : AbstractClassTests<Named<GroupData>, BaseEntity<GroupData>>
    {
        private class testClass : Named<GroupData>
        {
            public testClass(GroupData d = null) : base(d) { }
        }

        protected override Named<GroupData> getObject() => new testClass(GetRandom.ObjectOf<GroupData>());

        [TestMethod] public void NameTest() => isReadOnlyProperty(obj.Data.Name);
    }
}
