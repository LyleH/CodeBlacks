using System;
using CodeBlacks.BusinessRules;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeBlacks.Tests
{
    [TestClass]
    public sealed class CodeCoverageComparisonTests
    {
        [TestMethod]
        public void Test_CompareFileContent_ShouldReturnNullIfFilesAreIdentical()
        {
            CodeCoverageComparison.CompareFileContent("test", "test").Should().BeNull();
        }
    }
}
