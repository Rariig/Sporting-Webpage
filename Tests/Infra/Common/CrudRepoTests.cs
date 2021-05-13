using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Aids;
using SportEU.Data;
using SportEU.Domain;
using SportEU.Infra;
using SportEU.Infra.Common;

namespace SportEU.Tests.Infra.Common
{
    [TestClass]
    public class CrudRepoTests : AbstractClassTests<CrudRepo<Group, GroupData>
          , BaseRepo<GroupData>>
    {
        private class testRepo : CrudRepo<Group, GroupData>
        {
            public testRepo(ApplicationDbContext c = null)
                : base(c, c?.Groups) { }
            protected internal override Group toEntity(GroupData d) => new(d);
            protected internal override GroupData toData(Group e) => e.Data;
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj.dbSet.RemoveRange(obj.dbSet);
            obj.db.SaveChanges();
        }
        protected override CrudRepo<Group, GroupData> getObject()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDb").Options;
            var c = new ApplicationDbContext(options);
            return new testRepo(c);
        }
        [TestMethod]
        public async Task GetTest()
        {
            //pre condition
            var d = GetRandom.ObjectOf<GroupData>();
            var o = await obj.GetAsync(d.Id);
            arePropertiesNotEqual(d, o.Data);

            await obj.dbSet.AddAsync(d);
            await obj.db.SaveChangesAsync();

            //do something
            o = await obj.GetAsync(d.Id);

            //post condition
            arePropertiesEqual(d, o.Data, nameof(d.RowVersion));
        }
        [TestMethod]
        public async Task DeleteTest()
        {

            //pre condition
            var d = GetRandom.ObjectOf<GroupData>();
            await obj.dbSet.AddAsync(d);
            await obj.db.SaveChangesAsync();
            var o = await obj.GetAsync(d.Id);
            arePropertiesEqual(d, o.Data, nameof(d.RowVersion));

            //do something
            await obj.DeleteAsync(new Group(d));

            //post condition
            o = await obj.GetAsync(d.Id);
            arePropertiesNotEqual(d, o.Data);
        }
        [TestMethod]
        public async Task AddTest()
        {

            //pre condition
            var d = GetRandom.ObjectOf<GroupData>();
            var o = await obj.GetAsync(d.Id);
            Assert.IsNotNull(o);
            arePropertiesNotEqual(d, o.Data);

            //do something
            await obj.AddAsync(new Group(d));

            //post condition
            o = await obj.GetAsync(d.Id);
            Assert.IsInstanceOfType(o, typeof(Group));
            arePropertiesEqual(d, o.Data, nameof(d.RowVersion));
        }
        [TestMethod]
        public async Task UpdateTest()
        {
            //pre condition
            var d = GetRandom.ObjectOf<GroupData>();
            await obj.dbSet.AddAsync(d);
            await obj.db.SaveChangesAsync();
            var o = await obj.GetAsync(d.Id);
            arePropertiesEqual(d, o.Data, nameof(d.RowVersion));
            var d1 = GetRandom.ObjectOf<GroupData>();
            d1.Id = o.Id;
            d1.RowVersion = o.RowVersion;
            //do something
            await obj.UpdateAsync(new Group(d1));
            //post condition
            o = await obj.GetAsync(d.Id);
            arePropertiesEqual(d1, o.Data, nameof(d.RowVersion));
            arePropertiesEqual(d, d1);
        }
        [TestMethod]
        public async Task EntityInDbTest()
        {
            Assert.Inconclusive();
            //pre condition
            var d = GetRandom.ObjectOf<GroupData>();
            await obj.dbSet.AddAsync(d);
            await obj.db.SaveChangesAsync();
            var o = await obj.GetAsync(d.Id);
            arePropertiesEqual(d, o.Data, nameof(d.RowVersion));
            var d1 = GetRandom.ObjectOf<GroupData>();
            d1.Id = o.Id;
            //do something
            areEqual(false, await obj.UpdateAsync(new Group(d1)));
            //post condition
            arePropertiesEqual(d, obj.EntityInDb.Data, nameof(d.RowVersion));
        }
        [TestMethod]
        public async Task GetListTest()
        {
            var l = await obj.GetAsync();
            areEqual(0, l.Count);
            var count = GetRandom.UInt8(10, 20);
            for (var i = 1; i <= count; i++)
                await obj.dbSet.AddAsync(GetRandom.ObjectOf<GroupData>());
            await obj.db.SaveChangesAsync();
            l = await obj.GetAsync();
            areEqual((int)count, l.Count);

        }
        [TestMethod]
        public async Task GetByIdTest()
        {
            //pre condition
            var d = GetRandom.ObjectOf<GroupData>();
            var o = obj.Get(d.Id);
            arePropertiesNotEqual(d, o.Data);

            await obj.dbSet.AddAsync(d);
            await obj.db.SaveChangesAsync();

            //do something
            o = obj.Get(d.Id);

            //post condition
            arePropertiesEqual(d, o.Data, nameof(d.RowVersion));

        }
    }
}
