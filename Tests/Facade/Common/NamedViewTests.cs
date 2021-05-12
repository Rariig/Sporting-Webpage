using SportEU.Aids;
using SportEU.Facade;
using SportEU.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace SportEU.Tests.Facade.Common
{
    [TestClass]
    public class NamedViewTests : AbstractClassTests<NamedView, BaseView>
    {
        private class testClass : NamedView { }

        protected override NamedView getObject() => GetRandom.ObjectOf<testClass>();
        [TestMethod] public void NameTest() => isReadWriteProperty<string>();

    }
}