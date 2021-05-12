using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Aids;
using SportEU.Data;
using SportEU.Domain;
using SportEU.Domain.Common;

namespace SportEU.Tests.Domain.Common
{
    [TestClass]
    public class AthleteAssignmentTests
        : AbstractClassTests<AthleteAssignment<GroupAssignmentData>, BaseEntity<GroupAssignmentData>>
    {
        private class testClass : AthleteAssignment<GroupAssignmentData>
        {
            public testClass(GroupAssignmentData d = null) : base(d) { }
        }

        protected override AthleteAssignment<GroupAssignmentData> getObject() => new testClass(GetRandom.ObjectOf<GroupAssignmentData>());

        [TestMethod] public void AthleteIdTest() => isReadOnlyProperty(obj.Data.AthleteId);
        [TestMethod]
        public void InstructorTest() => lazyTest(() => obj.athlete.IsValueCreated,
            () => obj.Athlete);
    }
}
