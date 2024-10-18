using NUnit.Framework;
using SkiaSharp;
using System;
using System.IO;
using PDFtoImage.Tests;
using static PDFtoImage.Conversion;
using static PDFtoImage.Tests.TestUtils;

namespace Tests
{
    [TestFixture]
    public class BackgroundColorTests
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
        [TestCase(null, TestName = "Default (White)")]
        [TestCase((uint)0xFFFFFFFF, TestName = "White")]
        [TestCase((uint)0x64FFFFFF, TestName = "White (100 alpha)")]
        [TestCase((uint)0xFFFF0000, TestName = "Red")]
        [TestCase((uint)0x64FF0000, TestName = "Red (100 alpha)")]
        [TestCase((uint)0xFF00FF00, TestName = "Green")]
        [TestCase((uint)0x6400FF00, TestName = "Green (100 alpha)")]
        [TestCase((uint)0xFF0000FF, TestName = "Blue")]
        [TestCase((uint)0x640000FF, TestName = "Blue (100 alpha)")]
        [TestCase((uint)0xFFFFFF00, TestName = "Yellow")]
        [TestCase((uint)0x64FFFF00, TestName = "Yellow (100 alpha)")]
        [TestCase((uint)0xFFFF00FF, TestName = "Magenta")]
        [TestCase((uint)0x64FF00FF, TestName = "Magenta (100 alpha)")]
        [TestCase((uint)0xFF00FFFF, TestName = "Cyan")]
        [TestCase((uint)0x6400FFFF, TestName = "Cyan (100 alpha)")]
        [TestCase((uint)0xFF000000, TestName = "Black")]
        [TestCase((uint)0x64000000, TestName = "Black (100 alpha)")]
        [TestCase((uint)0x00FFFFFF, TestName = "Transparent")]
        public void SaveJpegWithBackgroundColor(uint? backgroundColor)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "BackgroundColor", $"hundesteuer-anmeldung_{GetFileName(backgroundColor ?? SKColors.White)}.jpg");

            using var inputStream = GetInputStream(Path.Combine("Assets", "hundesteuer-anmeldung.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            if (backgroundColor == null)
                SaveJpeg(outputStream, inputStream, options: new(Dpi: 40));
            else
                SaveJpeg(outputStream, inputStream, options: new(Dpi: 40, BackgroundColor: backgroundColor.Value));

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase(null, TestName = "Default (White)")]
        [TestCase((uint)0xFFFFFFFF, TestName = "White")]
        [TestCase((uint)0x64FFFFFF, TestName = "White (100 alpha)")]
        [TestCase((uint)0xFFFF0000, TestName = "Red")]
        [TestCase((uint)0x64FF0000, TestName = "Red (100 alpha)")]
        [TestCase((uint)0xFF00FF00, TestName = "Green")]
        [TestCase((uint)0x6400FF00, TestName = "Green (100 alpha)")]
        [TestCase((uint)0xFF0000FF, TestName = "Blue")]
        [TestCase((uint)0x640000FF, TestName = "Blue (100 alpha)")]
        [TestCase((uint)0xFFFFFF00, TestName = "Yellow")]
        [TestCase((uint)0x64FFFF00, TestName = "Yellow (100 alpha)")]
        [TestCase((uint)0xFFFF00FF, TestName = "Magenta")]
        [TestCase((uint)0x64FF00FF, TestName = "Magenta (100 alpha)")]
        [TestCase((uint)0xFF00FFFF, TestName = "Cyan")]
        [TestCase((uint)0x6400FFFF, TestName = "Cyan (100 alpha)")]
        [TestCase((uint)0xFF000000, TestName = "Black")]
        [TestCase((uint)0x64000000, TestName = "Black (100 alpha)")]
        [TestCase((uint)0x00FFFFFF, TestName = "Transparent")]
        public void SavePngWithBackgroundColor(uint? backgroundColor)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "BackgroundColor", $"hundesteuer-anmeldung_{GetFileName(backgroundColor ?? SKColors.White)}.png");

            using var inputStream = GetInputStream(Path.Combine("Assets", "hundesteuer-anmeldung.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            if (backgroundColor == null)
                SavePng(outputStream, inputStream, options: new(Dpi: 40));
            else
                SavePng(outputStream, inputStream, options: new(Dpi: 40, BackgroundColor: backgroundColor.Value));

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase(null, TestName = "Default (White)")]
        [TestCase((uint)0xFFFFFFFF, TestName = "White")]
        [TestCase((uint)0x64FFFFFF, TestName = "White (100 alpha)")]
        [TestCase((uint)0xFFFF0000, TestName = "Red")]
        [TestCase((uint)0x64FF0000, TestName = "Red (100 alpha)")]
        [TestCase((uint)0xFF00FF00, TestName = "Green")]
        [TestCase((uint)0x6400FF00, TestName = "Green (100 alpha)")]
        [TestCase((uint)0xFF0000FF, TestName = "Blue")]
        [TestCase((uint)0x640000FF, TestName = "Blue (100 alpha)")]
        [TestCase((uint)0xFFFFFF00, TestName = "Yellow")]
        [TestCase((uint)0x64FFFF00, TestName = "Yellow (100 alpha)")]
        [TestCase((uint)0xFFFF00FF, TestName = "Magenta")]
        [TestCase((uint)0x64FF00FF, TestName = "Magenta (100 alpha)")]
        [TestCase((uint)0xFF00FFFF, TestName = "Cyan")]
        [TestCase((uint)0x6400FFFF, TestName = "Cyan (100 alpha)")]
        [TestCase((uint)0xFF000000, TestName = "Black")]
        [TestCase((uint)0x64000000, TestName = "Black (100 alpha)")]
        [TestCase((uint)0x00FFFFFF, TestName = "Transparent")]
        public void SaveWebpWithBackgroundColor(uint? backgroundColor)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "BackgroundColor", $"hundesteuer-anmeldung_{GetFileName(backgroundColor ?? SKColors.White)}.webp");

            using var inputStream = GetInputStream(Path.Combine("Assets", "hundesteuer-anmeldung.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            if (backgroundColor == null)
                SaveWebp(outputStream, inputStream, options: new(Dpi: 40));
            else
                SaveWebp(outputStream, inputStream, options: new(Dpi: 40, BackgroundColor: backgroundColor.Value));

            CompareStreams(expectedPath, outputStream);
        }

        private static string GetFileName(SKColor backgroundColor) => backgroundColor.ToString();
    }
}