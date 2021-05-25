using SportEU.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Facade.Common;

namespace SportEU.Tests.Facade
{
    [TestClass]
    public class CoachViewTests : SealedClassTests<CoachView, PersonView>
    {
        [TestMethod] public void SalaryTest() => isReadWriteProperty<decimal>();
        [TestMethod] public void SpecialityTest() => isReadWriteProperty<string>();

        [TestMethod] public void PhoneNumberTest() => isReadWriteProperty<string>();
    }
}