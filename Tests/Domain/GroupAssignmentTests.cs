using SportEU.Aids;
using SportEU.Data;
using SportEU.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Domain.Common;

namespace SportEU.Tests.Domain
{
    [TestClass]
    public class GroupAssignmentTests : SealedClassTests<GroupAssignment,
        AthleteAssignment<GroupAssignmentData>>
    {

        protected override GroupAssignment getObject()
            => new(GetRandom.ObjectOf<GroupAssignmentData>());

        [TestMethod] public void GroupIdTest() => isReadOnlyProperty(obj.Data.GroupId);

        [TestMethod]
        public void GroupTest() => lazyTest(() => obj.group.IsValueCreated,
            () => obj.Group);
    }
}
