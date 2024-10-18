using NUnit.Framework;
using System;

namespace PDFtoImage.Tests
{
    public abstract class TestBase
    {
        public TestContext? TestContext { get; set; }

        public static bool SaveOutputInGeneratedFolder { get; private set; }

        [SetUp]
        public void Initialize()
        {
#if NET6_0_OR_GREATER
            if (!OperatingSystem.IsWindows() && !OperatingSystem.IsLinux() && !OperatingSystem.IsMacOS()
                && !OperatingSystem.IsAndroid() && !OperatingSystem.IsIOS())
                Assert.Ignore("This test must run on Windows, Linux or macOS.");
#endif

            //TODO: it is settings the value to true not using the older logic
            SaveOutputInGeneratedFolder = true /*bool.Parse(TestContext?.Properties["SaveOutputInGeneratedFolder"]?.ToString() ?? false.ToString())*/;
        }
    }
}