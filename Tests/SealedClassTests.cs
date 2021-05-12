using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SportEU.Tests
{
    public abstract class SealedClassTests<TClass, TBaseClass>
        : ClassTests<TClass, TBaseClass>
        where TClass : class, new()
        where TBaseClass : class
    {

        [TestMethod] public override void IsSealedTest() => isTrue(type.IsSealed);
    }
}
