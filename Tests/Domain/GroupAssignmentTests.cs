using SportEU.Aids;
using SportEU.Data;
using SportEU.Domain;
using SportEU.Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Tests.Domain
{
    [TestClass]
    public class CourseAssignmentTests : SealedClassTests<GroupAssignment,
        Coach<GroupAssignmentData>>
    {

        protected override GroupAssignment getObject()
            => new(GetRandom.ObjectOf<GroupAssignmentData>());

        [TestMethod] public void CourseIdTest() => isReadOnlyProperty(obj.Data.GroupId);

        [TestMethod]
        public void CourseTest() => lazyTest(() => obj.Group.IsValueCreated,
            () => obj.Group);
    }
}
