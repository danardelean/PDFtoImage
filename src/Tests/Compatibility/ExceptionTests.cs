using NUnit.Framework;
using PDFtoImage.Tests;
using System;
using System.IO;
using static PDFtoImage.Compatibility.Conversion;
using static PDFtoImage.Tests.TestUtils;

namespace Tests.Compatibility
{
    [TestFixture]
    public class ExceptionTests : TestBase
    {
        [Test]
        [TestCase("hundesteuer-anmeldung.pdf")]
        [TestCase("SocialPreview.pdf")]
        [TestCase("Wikimedia_Commons_web.pdf")]
        public void ThrowsPageNotFound(string inputFile)
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", inputFile));
            Assert.Throws<ArgumentOutOfRangeException>(() => ToImage(inputStream, page: 80085));
        }
    }
}