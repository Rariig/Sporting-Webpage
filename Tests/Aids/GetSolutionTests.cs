//using System.Linq;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using SportEU.Aids;

//namespace SportEU.Tests.Aids
//{
//    [TestClass]
//    public class GetSolutionTests : BaseTests
//    {
//        [TestMethod]
//        public void ReferenceAssembliesTests()
//        {
//            var assemblies
//                = GetSolution
//                    .ReferenceAssemblies("SportEU.Tests")
//                    .Where(x => x.FullName?.StartsWith("SportEU") ?? false)
//                    .ToList();

//            areEqual(8, assemblies.Count);
//        }
//    }
//}
