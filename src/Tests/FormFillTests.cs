using NUnit.Framework;
using System;
using System.IO;
using PDFtoImage.Tests;
using static PDFtoImage.Conversion;
using static PDFtoImage.Tests.TestUtils;

namespace Tests
{
    [TestFixture]
    public class FormFillTests
    {
        [SetUp]
        public void Initialize()
        {
#if NET6_0_OR_GREATER
            if (!OperatingSystem.IsWindows() && !OperatingSystem.IsLinux() && !OperatingSystem.IsMacOS())
                Assert.Ignore("This test must run on Windows, Linux or macOS.");
#endif
        }

        [Test]
        [TestCase(null, TestName = "Default (no form fill)")]
        [TestCase(true, TestName = "Form fill")]
        [TestCase(false, TestName = "No form fill")]
        public void SaveWebpPageNumber(bool? withFormFill)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), $"hundesteuer-anmeldung_{withFormFill ?? false}.webp");

            using var inputStream = GetInputStream(Path.Combine("Assets", "hundesteuer-anmeldung.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            if (withFormFill == null)
                SaveWebp(outputStream, inputStream, options: new(Dpi: 40));
            else
                SaveWebp(outputStream, inputStream, options: new(Dpi: 40, WithFormFill: withFormFill.Value));

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase(null, TestName = "Default (no form fill)")]
        [TestCase(true, TestName = "Form fill")]
        [TestCase(false, TestName = "No form fill")]
        public void SavePngPageNumber(bool? withFormFill)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), $"hundesteuer-anmeldung_{withFormFill ?? false}.png");

            using var inputStream = GetInputStream(Path.Combine("Assets", "hundesteuer-anmeldung.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            if (withFormFill == null)
                SavePng(outputStream, inputStream, options: new(Dpi: 40));
            else
                SavePng(outputStream, inputStream, options: new(Dpi: 40, WithFormFill: withFormFill.Value));

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase(null, TestName = "Default (no form fill)")]
        [TestCase(true, TestName = "Form fill")]
        [TestCase(false, TestName = "No form fill")]
        public void SaveJpegPageNumber(bool? withFormFill)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), $"hundesteuer-anmeldung_{withFormFill ?? false}.jpg");

            using var inputStream = GetInputStream(Path.Combine("Assets", "hundesteuer-anmeldung.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            if (withFormFill == null)
                SaveJpeg(outputStream, inputStream, options: new(Dpi: 40));
            else
                SaveJpeg(outputStream, inputStream, options: new(Dpi: 40, WithFormFill: withFormFill.Value));

            CompareStreams(expectedPath, outputStream);
        }
    }
}