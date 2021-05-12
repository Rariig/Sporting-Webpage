using SportEU.Domain;
using SportEU.Domain.Repos;
using Tests;

namespace SportEU.Tests.Domain.Repos
{
    public class MockAthletesRepo : TestRepo<Athlete>, IAthletesRepo
    {
    }
}
