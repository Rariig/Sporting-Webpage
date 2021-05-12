using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Data;
using SportEU.Domain;
using SportEU.Infra;

namespace SportEU.Tests.Infra
{
    [TestClass]
    public class AthletesRepoTests
        : InMemoryRepoTests<AthletesRepo, Athlete, AthleteData>
    {
        protected override Athlete createEntity(AthleteData d) => new(d);
        protected override AthletesRepo createRepo(ApplicationDbContext c) => new(c);
    }
}
