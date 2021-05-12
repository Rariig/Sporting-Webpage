using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Aids;
using SportEU.Tests;

namespace Tests
{
    public class EnumBaseTests<T> : BaseTests where T : Enum
    {
        protected T value;
        protected Type type;
        [TestInitialize]
        public void TestInitialize()
        {
            type = typeof(T);
            value = GetRandom.EnumOf<T>();
        }
    }
}
