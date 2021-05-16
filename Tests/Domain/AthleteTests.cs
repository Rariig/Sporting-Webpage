using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Aids;
using SportEU.Data;
using SportEU.Domain;
using SportEU.Domain.Common;

namespace SportEU.Tests.Domain
{
    [TestClass]
    public class AthleteTests : SealedClassTests<Athlete, Person<AthleteData>>
    {

        protected override Athlete getObject() => new(GetRandom.ObjectOf<AthleteData>());

        [TestMethod] public void NewlyAssignedGroupsTest() => isReadOnlyProperty(obj.NewlyAssignedGroups);

       // [TestMethod] public void StartingDateTest() => isReadOnlyProperty(obj.StartingDate);

        [TestMethod] public void StrengthTest() => isReadOnlyProperty(obj.Strength);

        [TestMethod]
        public void GroupsTest() => lazyTest(
            () => obj.groupAssignments.IsValueCreated, () => obj.Groups);
        [TestMethod]
        public void GroupAssignmentsTest() => lazyTest(
            () => obj.groupAssignments.IsValueCreated, () => obj.GroupAssignments);

        [TestMethod]
        public void AddGroupTest() => addToListTest(
            () => obj.NewlyAssignedGroups, x => obj.AddGroup(x));

        internal static void addToListTest<T>(Func<List<T>> getList, Action<T> addItem)
        {
            var s = (T)GetRandom.ValueOf<T>();
            isFalse(getList().Contains(s));
            addItem(s);
            isTrue(getList().Contains(s));
        }

    }
}
