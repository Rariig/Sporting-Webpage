using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Aids;
using SportEU.Data;
using SportEU.Domain;
using SportEU.Domain.Common;

namespace SportEU.Tests.Domain.Common
{
    [TestClass]
    public class PersonTests : AbstractClassTests<Person<AthleteData>, BaseEntity<AthleteData>>
    {
        private class testClass : Person<AthleteData>
        {
            public testClass(AthleteData d = null) : base(d) { }
        }

        protected override Person<AthleteData> getObject() => new testClass(GetRandom.ObjectOf<AthleteData>());

        [TestMethod] public void LastNameTest() => isReadOnlyProperty(obj.Data.LastName);
        [TestMethod] public void FirstMidNameTest() => isReadOnlyProperty(obj.Data.FirstMidName);
        [TestMethod] public void FullNameTest() => isReadOnlyProperty($"{obj.LastName}, {obj.FirstMidName}");
        [TestMethod] public void AgeTest() => isReadOnlyProperty(obj.Data.Age);
    }
}
