using SportEU.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
namespace Tests
{
    public abstract class BaseTests
    {
        protected static void areEqual<TExpected, TActual>(TExpected e, TActual a) => Assert.AreEqual(e, a);
        protected static void areEqual<TExpected, TActual>(TExpected e, TActual a, string s) => Assert.AreEqual(e, a, s);
        protected static void areNotEqual<TExpected, TActual>(TExpected e, TActual a) => Assert.AreNotEqual(e, a);
        protected static void exception<T>(Action a) where T : Exception => Assert.ThrowsException<T>(a);
        protected static void isNull(object o, string msg = null) => Assert.IsNull(o, msg ?? string.Empty);
        protected static void isNotNull(object o) => Assert.IsNotNull(o);
        protected static void isNotNull(object o, string message) => Assert.IsNotNull(o, message);
        protected static void isInstanceOfType<TType>(object o) => isInstanceOfType(o, typeof(TType));
        protected static void isInstanceOfType(object o, Type t) => Assert.IsInstanceOfType(o, t);
        protected static void isFalse(bool b) => Assert.IsFalse(b);
        protected static void isTrue(bool b, string s = null)
        {
            if (s is null) Assert.IsTrue(b);
            else Assert.IsTrue(b, s);
        }
        protected static void fail(string message) => Assert.Fail(message);
        protected static void notTested(string message) => Assert.Inconclusive(message);
        protected static void notTested(string message, params object[] parameters)
            => Assert.Inconclusive(message, parameters);
        protected static string getPropertyAfter(string methodName)
        {
            var stack = new StackTrace();
            int i = methodFrameIdx(stack, methodName);
            return nextPropertyName(stack, i);
        }
        private static string nextPropertyName(StackTrace s, int i)
        {
            for (i += 1; i < s.FrameCount - 1; i++)
            {
                var n = s.GetFrame(i)?.GetMethod()?.Name;
                if (n is "MoveNext" or "Start") continue;
                return n?.Replace("Test", string.Empty);
            }
            return string.Empty;
        }
        private static int methodFrameIdx(StackTrace s, string methodName)
        {
            int i;
            for (i = 0; i < s.FrameCount - 1; i++)
            {
                var n = s.GetFrame(i)?.GetMethod()?.Name;
                if (n == methodName) break;
            }
            return i;
        }
        protected static void htmlContains(IReadOnlyList<object> actual, IReadOnlyList<string> expected)
        {
            isInstanceOfType(actual, typeof(List<object>));
            areEqual(expected.Count, actual.Count);
            for (var i = 0; i < actual.Count; i++)
            {
                var a = actual[i].ToString();
                var e = expected[i];
                isTrue(a?.Contains(e) ?? false, $"{e} != {a}");
            }
        }
    }
}

