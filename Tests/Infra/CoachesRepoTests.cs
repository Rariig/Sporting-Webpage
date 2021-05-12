using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Data;
using SportEU.Domain;
using SportEU.Infra;

namespace SportEU.Tests.Infra
{
    [TestClass]
    public class CoachesRepoTests
        : InMemoryRepoTests<CoachesRepo, Coach, CoachData>
    {
        protected override Coach createEntity(CoachData d) => new(d);
        protected override CoachesRepo createRepo(ApplicationDbContext c) => new(c);
    }
}
