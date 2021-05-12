using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Domain;
using SportEU.Domain.Repos;
using SportEU.Facade;
using SportEU.Pages;
using SportEU.Tests.Pages.Common;

namespace SportEU.Tests.Pages
{
    [TestClass]
    public class AthletesPageTests : BasePageTests<Athlete, AthleteView>
    {

        private class testAthletesRepo : TestRepo<Athlete>, IAthletesRepo{ }

        [TestInitialize]
        public void TestInitialize()
        {
            mockRepo = new testAthletesRepo();
            pageModel = new AthletesPage((IAthletesRepo)mockRepo);
        }
    }
}
