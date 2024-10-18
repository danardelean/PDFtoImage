using NUnit.Framework;
using PDFtoImage;
using System;
using System.IO;
using System.Text;
using PDFtoImage.Tests;
using static PDFtoImage.Compatibility.Conversion;
using static PDFtoImage.Tests.TestUtils;

namespace Tests.Compatibility
{
    [TestFixture]
    public class AntiAliasingTests
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
        [TestCase(null, TestName = "Default (None)")]
        [TestCase(PdfAntiAliasing.None, TestName = "None")]
        [TestCase(PdfAntiAliasing.Text, TestName = "Text")]
        [TestCase(PdfAntiAliasing.Images, TestName = "Images")]
        [TestCase(PdfAntiAliasing.Paths, TestName = "Paths")]
        [TestCase(PdfAntiAliasing.Text | PdfAntiAliasing.Images, TestName = "Text | Images")]
        [TestCase(PdfAntiAliasing.Text | PdfAntiAliasing.Paths, TestName = "Text | Paths")]
        [TestCase(PdfAntiAliasing.Images | PdfAntiAliasing.Paths, TestName = "Images | Paths")]
        [TestCase(PdfAntiAliasing.Text | PdfAntiAliasing.Images | PdfAntiAliasing.Paths, TestName = "Text | Images | Paths")]
        [TestCase(PdfAntiAliasing.All, TestName = "All")]
        public void SaveJpegWithAntiAliasing(PdfAntiAliasing? antiAliasing)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "AntiAliasing", $"hundesteuer-anmeldung_{GetFileName(antiAliasing ?? PdfAntiAliasing.All)}.jpg");

            using var inputStream = GetInputStream(Path.Combine("Assets", "hundesteuer-anmeldung.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            if (antiAliasing == null)
                SaveJpeg(outputStream, inputStream, dpi: 40);
            else
                SaveJpeg(outputStream, inputStream, dpi: 40, antiAliasing: antiAliasing.Value);

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase(null, TestName = "Default (None)")]
        [TestCase(PdfAntiAliasing.None, TestName = "None")]
        [TestCase(PdfAntiAliasing.Text, TestName = "Text")]
        [TestCase(PdfAntiAliasing.Images, TestName = "Images")]
        [TestCase(PdfAntiAliasing.Paths, TestName = "Paths")]
        [TestCase(PdfAntiAliasing.Text | PdfAntiAliasing.Images, TestName = "Text | Images")]
        [TestCase(PdfAntiAliasing.Text | PdfAntiAliasing.Paths, TestName = "Text | Paths")]
        [TestCase(PdfAntiAliasing.Images | PdfAntiAliasing.Paths, TestName = "Images | Paths")]
        [TestCase(PdfAntiAliasing.Text | PdfAntiAliasing.Images | PdfAntiAliasing.Paths, TestName = "Text | Images | Paths")]
        [TestCase(PdfAntiAliasing.All, TestName = "All")]
        public void SavePngWithAntiAliasing(PdfAntiAliasing? antiAliasing)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "AntiAliasing", $"hundesteuer-anmeldung_{GetFileName(antiAliasing ?? PdfAntiAliasing.All)}.png");

            using var inputStream = GetInputStream(Path.Combine("Assets", "hundesteuer-anmeldung.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            if (antiAliasing == null)
                SavePng(outputStream, inputStream, dpi: 40);
            else
                SavePng(outputStream, inputStream, dpi: 40, antiAliasing: antiAliasing.Value);

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase(null, TestName = "Default (None)")]
        [TestCase(PdfAntiAliasing.None, TestName = "None")]
        [TestCase(PdfAntiAliasing.Text, TestName = "Text")]
        [TestCase(PdfAntiAliasing.Images, TestName = "Images")]
        [TestCase(PdfAntiAliasing.Paths, TestName = "Paths")]
        [TestCase(PdfAntiAliasing.Text | PdfAntiAliasing.Images, TestName = "Text | Images")]
        [TestCase(PdfAntiAliasing.Text | PdfAntiAliasing.Paths, TestName = "Text | Paths")]
        [TestCase(PdfAntiAliasing.Images | PdfAntiAliasing.Paths, TestName = "Images | Paths")]
        [TestCase(PdfAntiAliasing.Text | PdfAntiAliasing.Images | PdfAntiAliasing.Paths, TestName = "Text | Images | Paths")]
        [TestCase(PdfAntiAliasing.All, TestName = "All")]
        public void SaveWebpWithAntiAliasing(PdfAntiAliasing? antiAliasing)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "AntiAliasing", $"hundesteuer-anmeldung_{GetFileName(antiAliasing ?? PdfAntiAliasing.All)}.webp");

            using var inputStream = GetInputStream(Path.Combine("Assets", "hundesteuer-anmeldung.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            if (antiAliasing == null)
                SaveWebp(outputStream, inputStream, dpi: 40);
            else
                SaveWebp(outputStream, inputStream, dpi: 40, antiAliasing: antiAliasing.Value);

            CompareStreams(expectedPath, outputStream);
        }

        private static string GetFileName(PdfAntiAliasing antiAliasing)
        {
            if (antiAliasing == PdfAntiAliasing.None)
                return "aliasing_none";

            var sb = new StringBuilder("aliasing");

            if (antiAliasing.HasFlag(PdfAntiAliasing.Text))
                sb.Append("_text");

            if (antiAliasing.HasFlag(PdfAntiAliasing.Images))
                sb.Append("_images");

            if (antiAliasing.HasFlag(PdfAntiAliasing.Paths))
                sb.Append("_paths");

            return sb.ToString();
        }
    }
}