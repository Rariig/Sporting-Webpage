using SportEU.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SportEU.Tests.Facade
{
    [TestClass]
    public class CoachViewTests : SealedClassTests<CoachView, object>
    {
        [TestMethod] public void SalaryTest() => isReadWriteProperty<decimal>();
        [TestMethod] public void SpecialityTest() => isReadWriteProperty<string>();
    }
}