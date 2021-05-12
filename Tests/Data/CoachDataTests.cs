using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Data;
using SportEU.Data.Common;

namespace SportEU.Tests.Data
{
    [TestClass]
    public class CoachDataTests : SealedClassTests<CoachData, PersonData>
    {
        [TestMethod] public void SalaryTest() => isReadWriteProperty<decimal?>();
        [TestMethod] public void SpecialityTest() => isReadWriteProperty<string>();
    }
}
