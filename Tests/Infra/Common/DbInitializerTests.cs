using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Infra.Common;

namespace SportEU.Tests.Infra.Common
{
    [TestClass]
    public class DbInitializerTests : StaticClassTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            type = typeof(DbInitializer);
        }
    }
}
