using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Data;
using SportEU.Domain;
using SportEU.Infra;

namespace SportEU.Tests.Infra
{
    [TestClass]
    public class GroupsRepoTests
        : InMemoryRepoTests<GroupsRepo, Group, GroupData>
    {
        protected override Group createEntity(GroupData d) => new(d);
        protected override GroupsRepo createRepo(ApplicationDbContext c) => new(c);
    }
}
