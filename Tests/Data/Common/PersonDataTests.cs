using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Aids;
using SportEU.Data.Common;

namespace SportEU.Tests.Data.Common
{
    [TestClass]
    public class PersonDataTests : AbstractClassTests<PersonData, BaseData>
    {
        private class testClass : PersonData { }
        protected override PersonData getObject() => GetRandom.ObjectOf<testClass>();
        [TestMethod] public void LastNameTest() => isReadWriteProperty<string>();
        [TestMethod] public void FirstMidNameTest() => isReadWriteProperty<string>();
        [TestMethod] public void PhotoTest() => isReadWriteProperty<byte[]>();
        [TestMethod] public void ValidFromTest() => isReadWriteProperty<DateTime?>();
    }
}
