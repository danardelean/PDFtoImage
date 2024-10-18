using NUnit.Framework;
using PDFtoImage.Exceptions;
using PDFtoImage.Tests;
using System;
using System.IO;
using static PDFtoImage.Conversion;
using static PDFtoImage.Tests.TestUtils;

namespace Tests
{
    [TestFixture]
    public class ExceptionTests : TestBase
    {
        [Test]
        public void ThrowsInvalidFormat()
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "DummyImage.png"));
            Assert.Throws<PdfInvalidFormatException>(() => GetPageCount(inputStream));
        }

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