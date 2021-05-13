using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Infra;

namespace SportEU.Tests.Infra
{
    [TestClass]
    public class ApplicationDbContextTests
        : ClassTests<ApplicationDbContext, IdentityDbContext>
    {
    }
}
