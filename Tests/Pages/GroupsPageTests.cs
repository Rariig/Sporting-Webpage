using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Domain;
using SportEU.Domain.Repos;
using SportEU.Facade;
using SportEU.Pages;
using SportEU.Tests.Pages.Common;

namespace SportEU.Tests.Pages
{
    [TestClass]
    public class GroupsPageTests : BasePageTests<Group, GroupView>
    {

        private class testGroupsRepo : TestRepo<Group>, IGroupsRepo { }

        [TestInitialize]
        public void TestInitialize()
        {
            mockRepo = new testGroupsRepo();
            pageModel = new GroupsPage((IGroupsRepo)mockRepo);
        }
    }
}
