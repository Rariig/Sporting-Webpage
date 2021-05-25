using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Aids;
using SportEU.Data;
using SportEU.Domain;
using SportEU.Domain.Common;

namespace SportEU.Tests.Domain
{
    [TestClass]
    public class CoachTests : SealedClassTests<Coach, Person<CoachData>>
    {
        protected override Coach getObject() => new(GetRandom.ObjectOf<CoachData>());

        [TestMethod] public void SalaryTest() => isReadOnlyProperty(obj.Data.Salary);
        [TestMethod] public void SpecialityTest() => isReadOnlyProperty(obj.Data.Speciality);
        [TestMethod] public void PhoneNumberTest() => isReadOnlyProperty(obj.Data.PhoneNumber);
    }
}
