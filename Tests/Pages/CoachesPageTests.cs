using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Domain;
using SportEU.Domain.Repos;
using SportEU.Facade;
using SportEU.Pages;
using SportEU.Tests.Pages.Common;

namespace SportEU.Tests.Pages
{
    [TestClass]
    public class CoachesPageTests : BasePageTests<Coach, CoachView>
    {

        private class testCoachesRepo : TestRepo<Coach>, ICoachesRepo { }

        [TestInitialize]
        public void TestInitialize()
        {
            mockRepo = new testCoachesRepo();
            pageModel = new CoachesPage((ICoachesRepo)mockRepo);
        }
    }
}
