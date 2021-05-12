using SportEU.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SportEU.Tests.Facade
{
    [TestClass]
    public class GroupViewTests : SealedClassTests<GroupView, object>
    {
        [TestMethod] public void CoachIdTest() => isReadWriteProperty<string>();
        [TestMethod] public void CoachNameTest() => isReadWriteProperty<string>();
    }
}
