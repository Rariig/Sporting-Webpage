using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Aids;
using SportEU.Data;
using SportEU.Domain;
using SportEU.Domain.Common;

namespace SportEU.Tests.Domain
{
    [TestClass]
    public class GroupTests : SealedClassTests<Group, Named<GroupData>>
    {
        protected override Group getObject() => new(GetRandom.ObjectOf<GroupData>());

        [TestMethod]
        public void CoachTest() => lazyTest(() => obj.coach.IsValueCreated,
            () => obj.Coach);

        [TestMethod]
        public void GroupAssignmentsTest()
            => lazyTest(() => obj.groupAssignments.IsValueCreated, () => obj.GroupAssignments);
    }
}
