using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Data;
using SportEU.Domain;
using SportEU.Infra;

namespace SportEU.Tests.Infra
{
    [TestClass]
    public class GroupAssignmentsRepoTests
        : InMemoryRepoTests<GroupAssignmentsRepo
            , GroupAssignment, GroupAssignmentData>
    {
        protected override GroupAssignment createEntity(GroupAssignmentData d) => new(d);
        protected override GroupAssignmentsRepo createRepo(ApplicationDbContext c) => new(c);
        [TestMethod]
        public void GetByGroupIdTest()
            => getListByIdTest(id => obj.GetByGroupId(id), (data, id) => data.GroupId = id);
        [TestMethod]
        public void GetByAthleteIdTest()
            => getListByIdTest(id => obj.GetByAthleteId(id), (data, id) => data.AthleteId = id);
    }
}
