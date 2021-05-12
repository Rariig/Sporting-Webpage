using SportEU.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SportEU.Tests.Facade
{
    [TestClass]
    public class CourseAssignmentViewTests : SealedClassTests<GroupAssignmentView, object>
    {
        [TestMethod] public void NameTest() => isReadWriteProperty<string>();
        [TestMethod] public void NumberTest() => isReadWriteProperty<int?>();
        [TestMethod] public void GroupIdTest() => isReadWriteProperty<string>();
    }
}