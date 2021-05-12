using SportEU.Aids;
using SportEU.Core;
using SportEU.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Common
{
    [TestClass]
    public class BaseViewTests : AbstractClassTests<BaseView, UniqueItem>
    {
        private class testClass : BaseView { }

        protected override BaseView getObject() => GetRandom.ObjectOf<testClass>();
        [TestMethod] public void RowVersionTest() => isReadWriteProperty<byte[]>();

    }
}