using SportEU.Aids;
using SportEU.Facade.Common;
using SportEU.Facade;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace SportEU.Tests.Facade.Common
{
    [TestClass]
    public class PersonViewTests : AbstractClassTests<PersonView, BaseView>
    {
        private class testClass : PersonView { }

        protected override PersonView getObject() => GetRandom.ObjectOf<testClass>();
        [TestMethod] public void LastNameTest() => isReadWriteProperty<string>();
        [TestMethod] public void FirstMidNameTest() => isReadWriteProperty<string>();
        [TestMethod] public void FullNameTest() => isReadWriteProperty<string>();
        [TestMethod] public void PhotoTest() => isProperty<IFormFile>();
        [TestMethod] public void PhotoAsStringTest() => isReadWriteProperty<string>();
        [TestMethod] public void ValidFromTest() => isReadWriteProperty<DateTime>();
    }
}