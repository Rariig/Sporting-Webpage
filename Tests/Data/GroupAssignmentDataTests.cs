using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Data;
using SportEU.Data.Common;

namespace SportEU.Tests.Data
{
    [TestClass]
    public class GroupAssignmentDataTests : SealedClassTests<GroupAssignmentData, AthleteAssignmentData>
    {
        [TestMethod] public void GroupIdTest() => isReadWriteProperty<string>();
    }
}
