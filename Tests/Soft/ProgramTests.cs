using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Soft;

namespace SportEU.Tests.Soft
{
    [TestClass]
    public class ProgramTests : BaseTests
    {
        [TestMethod]
        public void MainTest()
        {
            var p = typeof(Program).GetMethod(nameof(Program.Main));
            Assert.IsNotNull(p);
            isTrue(p.IsStatic);
        }
    }
}
