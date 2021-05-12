using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Data;
using SportEU.Data.Common;


namespace SportEU.Tests.Data
{
    [TestClass]
    public class AthleteDataTests : SealedClassTests<AthleteData, PersonData>
    {
        [TestMethod] public void StrengthTest() => isReadWriteProperty<int>();
    }
}
