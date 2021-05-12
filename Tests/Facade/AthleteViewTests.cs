using System.Collections.Generic;
using SportEU.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportEU.Facade.Common;

namespace SportEU.Tests.Facade
{
    [TestClass]
    public class AthleteViewTests : SealedClassTests<AthleteView, PersonView>
    {
        [TestMethod] public void StrengthTest() => isReadWriteProperty<int>();
        [TestMethod] public void AthleteGroupsTest() => isReadWriteProperty<List<GroupAssignmentView>>();
    }
}
