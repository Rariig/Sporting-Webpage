using SportEU.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Facade.Common;

namespace SportEU.Tests.Facade
{
    [TestClass]
    public class GroupViewTests : SealedClassTests<GroupView, NamedView>
    {
        [TestMethod] public void CoachIdTest() => isReadWriteProperty<string>();
        [TestMethod] public void CoachNameTest() => isReadWriteProperty<string>();
        [TestMethod] public void SpecialityTest() => isReadWriteProperty<string>();
    }
}
