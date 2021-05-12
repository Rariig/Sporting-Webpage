using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Domain.Common;
using SportEU.Domain.Repos;
using SportEU.Tests.Domain.Repos;

namespace SportEU.Tests.Domain.Common
{
    [TestClass]
    public class GetRepoTests : SealedClassTests<GetRepo, object>
    {
        private IServiceProvider provider { get; set; }
        protected override GetRepo getObject() => new(provider);
        [TestCleanup] public void TestCleanup() => GetRepo.SetProvider(null);
        [TestMethod] public void ProviderIsNullTest() => isNull(obj.provider);
        [TestMethod] public void InstanceIsNullTest() => isNull(GetRepo.instance);
        [TestMethod]
        public void CanCreateTest()
        {
            initMock();
            areNotEqual(provider, GetRepo.instance);
            areEqual(provider, obj.provider);
        }
        [TestMethod]
        public void SetProviderTest()
        {
            var p = new MockServiceProvider(null);
            GetRepo.SetProvider(p);
            isNull(obj.provider);
            areEqual(p, GetRepo.instance);
        }
        [TestMethod]
        public void CreateAfterSetTest()
        {
            var p = new MockServiceProvider(null);
            GetRepo.SetProvider(p);
            obj = new GetRepo();
            areEqual(p, GetRepo.instance);
            areEqual(p, obj.provider);
        }
        [TestMethod]
        public void InstanceWithTypeTest()
        {
            var repo = initMock();
            var r = obj.Instance(typeof(IGroupsRepo));
            areEqual(repo, r);
        }
        [TestMethod]
        public void InstanceTest()
        {
            var repo = initMock();
            var r = obj.Instance<IGroupsRepo>();
            areEqual(repo, r);
        }
        private MockGroupsRepo initMock()
        {
            var r = new MockGroupsRepo();
            provider = new MockServiceProvider(r);
            obj = getObject();
            return r;
        }
    }
}
