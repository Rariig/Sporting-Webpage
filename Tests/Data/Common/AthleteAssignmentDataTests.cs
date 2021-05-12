using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Aids;
using SportEU.Data.Common;

namespace SportEU.Tests.Data.Common
{
    [TestClass]
    public class AthleteAssignmentDataTests : AbstractClassTests<AthleteAssignmentData, BaseData>
    {
        private class testClass : AthleteAssignmentData { }
        protected override AthleteAssignmentData getObject() => GetRandom.ObjectOf<testClass>();
        [TestMethod] public void AthleteIdTest() => isReadWriteProperty<string>();
    }
}
