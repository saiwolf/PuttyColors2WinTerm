using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PuttyColors2WinTerm.Tests
{
    /// <summary>
    /// <para>
    /// From: https://matt.kotsenas.com/posts/ignoreif-mstest
    /// </para>
    /// <para>
    /// An extension of the [TestClass] attribute. If applied to a class, any [TestMethod] attributes
    /// are automatically upgraded to [TestMethodWithIgnoreIfSupport].
    /// </para>
    /// </summary>
    public class TestClassWithIgnoreIfSupportAttribute : TestClassAttribute
    {
        public override TestMethodAttribute GetTestMethodAttribute(TestMethodAttribute testMethodAttribute)
        {
            if (testMethodAttribute is TestMethodWithIgnoreIfSupportAttribute)
            {
                return testMethodAttribute;
            }
            return new TestMethodWithIgnoreIfSupportAttribute();
        }
    }

    /// <summary>
    /// <para>
    /// From: https://matt.kotsenas.com/posts/ignoreif-mstest
    /// </para>
    /// <para>
    /// An extension to the [TestMethod] attribute. It walks the method and class hierarchy looking
    /// for an [IgnoreIf] attribute. If one or more are found, they are each evaluated, if the attribute
    /// returns `true`, evaluation is short-circuited, and the test method is skipped.
    /// </para>
    /// </summary>
    public class TestMethodWithIgnoreIfSupportAttribute : TestMethodAttribute
    {
        public override TestResult[] Execute(ITestMethod testMethod)
        {
            var ignoreAttributes = FindAttributes(testMethod);

            // Evaluate each attribute, and skip if one returns `true`
            foreach (var ignoreAttribute in ignoreAttributes)
            {
                if (ignoreAttribute.ShouldIgnore(testMethod))
                {
                    var message = $"Test not executed. Conditional ignore method '{ignoreAttribute.IgnoreCriteriaMethodName}' evaluated to 'true'.";
                    return new[]
                    {
                    new TestResult
                    {
                        Outcome = UnitTestOutcome.Inconclusive,
                        TestFailureException = new AssertInconclusiveException(message)
                    }
                };
                }
            }
            return base.Execute(testMethod);
        }

        private IEnumerable<IgnoreIfAttribute> FindAttributes(ITestMethod testMethod)
        {
            // Look for an [IgnoreIf] on the method, including any virtuals this method overrides
            var ignoreAttributes = new List<IgnoreIfAttribute>();
            ignoreAttributes.AddRange(testMethod.GetAttributes<IgnoreIfAttribute>(inherit: true));

            // Walk the class hierarchy looking for an [IgnoreIf] attribute
            var type = testMethod.MethodInfo.DeclaringType;
            while (type != null)
            {
                ignoreAttributes.AddRange(type.GetCustomAttributes<IgnoreIfAttribute>(inherit: true));
                type = type.DeclaringType;
            }
            return ignoreAttributes;
        }
    }
}
