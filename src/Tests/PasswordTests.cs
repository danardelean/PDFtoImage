using NUnit.Framework;
using PDFtoImage.Exceptions;
using PDFtoImage.Tests;
using System.IO;
using NUnit.Framework.Legacy;
using static PDFtoImage.Conversion;
using static PDFtoImage.Tests.TestUtils;

namespace Tests
{
    [TestFixture]
    public class PasswordTests : TestBase
    {
        [Test]
        [TestCase("SocialPreview.pdf", null)]
        [TestCase("SocialPreview.pdf", "")]
        [TestCase("SocialPreview.pdf", "this doc needs no password")]
        [TestCase("SocialPreview with password 123456 (RC4-40).pdf", "123456")]
        [TestCase("SocialPreview with password 123456 (RC4-128).pdf", "123456")]
        [TestCase("SocialPreview with password 123456 (AES-128).pdf", "123456")]
        [TestCase("SocialPreview with password 123456 (AES-256).pdf", "123456")]
        public void WithCorrectPassword(string inputFile, string? password = null)
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", inputFile));
            var output = GetPageCount(inputStream, password: password);
            ClassicAssert.AreEqual(1, output, "Page count should be 1, if the password was correct.");
        }

        [Test]
        [TestCase("SocialPreview with password 123456 (RC4-40).pdf", "In noreni per ipe")]
        [TestCase("SocialPreview with password 123456 (RC4-128).pdf", "In noreni cora")]
        [TestCase("SocialPreview with password 123456 (AES-128).pdf", "Tira mine per ito")]
        [TestCase("SocialPreview with password 123456 (AES-256).pdf", "Ne domina")]
        public void ThrowsIncorrectPassword(string inputFile, string? password = null)
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", inputFile));
            Assert.Throws<PdfPasswordProtectedException>(() => GetPageCount(inputStream, password: password));
        }
    }
}