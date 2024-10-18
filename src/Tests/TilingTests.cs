using NUnit.Framework;
using PDFtoImage;
using PDFtoImage.Tests;
using System;
using System.Drawing;
using System.IO;
using static PDFtoImage.Conversion;
using static PDFtoImage.Tests.TestUtils;

namespace Tests
{
    [TestFixture]
    public class TilingTests : TestBase
    {
        [Test]
        [TestCase("hundesteuer-anmeldung.pdf", 300, null)]
        [TestCase("hundesteuer-anmeldung.pdf", 300, false)]
        [TestCase("hundesteuer-anmeldung.pdf", 300, true)]
        [TestCase("SocialPreview.pdf", 300, null)]
        [TestCase("SocialPreview.pdf", 300, false)]
        [TestCase("SocialPreview.pdf", 300, true)]
        [TestCase("Wikimedia_Commons_web.pdf", 300, null)]
        [TestCase("Wikimedia_Commons_web.pdf", 300, false)]
        [TestCase("Wikimedia_Commons_web.pdf", 300, true)]

        [TestCase("hundesteuer-anmeldung.pdf", 600, null)]
        [TestCase("hundesteuer-anmeldung.pdf", 600, false)]
        [TestCase("hundesteuer-anmeldung.pdf", 600, true)]
        [TestCase("SocialPreview.pdf", 600, null)]
        [TestCase("SocialPreview.pdf", 600, false)]
        [TestCase("SocialPreview.pdf", 600, true)]
        [TestCase("Wikimedia_Commons_web.pdf", 600, null)]
        [TestCase("Wikimedia_Commons_web.pdf", 600, false)]
        [TestCase("Wikimedia_Commons_web.pdf", 600, true)]

        [TestCase("hundesteuer-anmeldung.pdf", 1200, null)]
        [TestCase("hundesteuer-anmeldung.pdf", 1200, false)]
        [TestCase("hundesteuer-anmeldung.pdf", 1200, true)]
        [TestCase("SocialPreview.pdf", 1200, null)]
        [TestCase("SocialPreview.pdf", 1200, false)]
        [TestCase("SocialPreview.pdf", 1200, true)]
        [TestCase("Wikimedia_Commons_web.pdf", 1200, null)]
        [TestCase("Wikimedia_Commons_web.pdf", 1200, false)]
        [TestCase("Wikimedia_Commons_web.pdf", 1200, true)]
        public void WithDpi(string fileName, int dpi, bool? useTiling = null)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "Tiling", useTiling == true ? "tiled" : "normal", GetExpectedFilename(fileName, "png", null, null, dpi, false, default, default));

            using var inputStream = GetInputStream(Path.Combine("Assets", fileName));
            using var outputStream = CreateOutputStream(expectedPath);

            if (useTiling != null)
                SavePng(outputStream, inputStream, options: new(Dpi: dpi, UseTiling: useTiling.Value, AntiAliasing: PdfAntiAliasing.None));
            else
                SavePng(outputStream, inputStream, options: new(Dpi: dpi, AntiAliasing: PdfAntiAliasing.None));

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase("hundesteuer-anmeldung.pdf", 1200, 1200, null)]
        [TestCase("hundesteuer-anmeldung.pdf", 1200, 1200, false)]
        [TestCase("hundesteuer-anmeldung.pdf", 1200, 1200, true)]
        [TestCase("SocialPreview.pdf", 1200, 1200, null)]
        [TestCase("SocialPreview.pdf", 1200, 1200, false)]
        [TestCase("SocialPreview.pdf", 1200, 1200, true)]
        [TestCase("Wikimedia_Commons_web.pdf", 1200, 1200, null)]
        [TestCase("Wikimedia_Commons_web.pdf", 1200, 1200, false)]
        [TestCase("Wikimedia_Commons_web.pdf", 1200, 1200, true)]

        [TestCase("hundesteuer-anmeldung.pdf", 4000, 4000, null)]
        [TestCase("hundesteuer-anmeldung.pdf", 4000, 4000, false)]
        [TestCase("hundesteuer-anmeldung.pdf", 4000, 4000, true)]
        [TestCase("SocialPreview.pdf", 4000, 4000, null)]
        [TestCase("SocialPreview.pdf", 4000, 4000, false)]
        [TestCase("SocialPreview.pdf", 4000, 4000, true)]
        [TestCase("Wikimedia_Commons_web.pdf", 4000, 4000, null)]
        [TestCase("Wikimedia_Commons_web.pdf", 4000, 4000, false)]
        [TestCase("Wikimedia_Commons_web.pdf", 4000, 4000, true)]

        [TestCase("hundesteuer-anmeldung.pdf", 6000, 6000, null)]
        [TestCase("hundesteuer-anmeldung.pdf", 6000, 6000, false)]
        [TestCase("hundesteuer-anmeldung.pdf", 6000, 6000, true)]
        [TestCase("SocialPreview.pdf", 6000, 6000, null)]
        [TestCase("SocialPreview.pdf", 6000, 6000, false)]
        [TestCase("SocialPreview.pdf", 6000, 6000, true)]
        [TestCase("Wikimedia_Commons_web.pdf", 6000, 6000, null)]
        [TestCase("Wikimedia_Commons_web.pdf", 6000, 6000, false)]
        [TestCase("Wikimedia_Commons_web.pdf", 6000, 6000, true)]
        public void WithWidthAndHeight(string fileName, int? width = null, int? height = null, bool? useTiling = null)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "Tiling", useTiling == true ? "tiled" : "normal", GetExpectedFilename(fileName, "png", width, height, null, false, default, default));

            using var inputStream = GetInputStream(Path.Combine("Assets", fileName));
            using var outputStream = CreateOutputStream(expectedPath);

            if (useTiling != null)
                SavePng(outputStream, inputStream, options: new(Width: width, Height: height, UseTiling: useTiling.Value, AntiAliasing: PdfAntiAliasing.None));
            else
                SavePng(outputStream, inputStream, options: new(Width: width, Height: height, AntiAliasing: PdfAntiAliasing.None));

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase("hundesteuer-anmeldung.pdf", null, null)]
        [TestCase("hundesteuer-anmeldung.pdf", null, false)]
        [TestCase("hundesteuer-anmeldung.pdf", null, true)]
        [TestCase("SocialPreview.pdf", null, null)]
        [TestCase("SocialPreview.pdf", null, false)]
        [TestCase("SocialPreview.pdf", null, true)]
        [TestCase("Wikimedia_Commons_web.pdf", null, null)]
        [TestCase("Wikimedia_Commons_web.pdf", null, false)]
        [TestCase("Wikimedia_Commons_web.pdf", null, true)]

        [TestCase("hundesteuer-anmeldung.pdf", PdfRotation.Rotate0, null)]
        [TestCase("hundesteuer-anmeldung.pdf", PdfRotation.Rotate0, false)]
        [TestCase("hundesteuer-anmeldung.pdf", PdfRotation.Rotate0, true)]
        [TestCase("SocialPreview.pdf", PdfRotation.Rotate0, null)]
        [TestCase("SocialPreview.pdf", PdfRotation.Rotate0, false)]
        [TestCase("SocialPreview.pdf", PdfRotation.Rotate0, true)]
        [TestCase("Wikimedia_Commons_web.pdf", PdfRotation.Rotate0, null)]
        [TestCase("Wikimedia_Commons_web.pdf", PdfRotation.Rotate0, false)]
        [TestCase("Wikimedia_Commons_web.pdf", PdfRotation.Rotate0, true)]

        [TestCase("hundesteuer-anmeldung.pdf", PdfRotation.Rotate90, null)]
        [TestCase("hundesteuer-anmeldung.pdf", PdfRotation.Rotate90, false)]
        [TestCase("hundesteuer-anmeldung.pdf", PdfRotation.Rotate90, true)]
        [TestCase("SocialPreview.pdf", PdfRotation.Rotate90, null)]
        [TestCase("SocialPreview.pdf", PdfRotation.Rotate90, false)]
        [TestCase("SocialPreview.pdf", PdfRotation.Rotate90, true)]
        [TestCase("Wikimedia_Commons_web.pdf", PdfRotation.Rotate90, null)]
        [TestCase("Wikimedia_Commons_web.pdf", PdfRotation.Rotate90, false)]
        [TestCase("Wikimedia_Commons_web.pdf", PdfRotation.Rotate90, true)]

        [TestCase("hundesteuer-anmeldung.pdf", PdfRotation.Rotate180, null)]
        [TestCase("hundesteuer-anmeldung.pdf", PdfRotation.Rotate180, false)]
        [TestCase("hundesteuer-anmeldung.pdf", PdfRotation.Rotate180, true)]
        [TestCase("SocialPreview.pdf", PdfRotation.Rotate180, null)]
        [TestCase("SocialPreview.pdf", PdfRotation.Rotate180, false)]
        [TestCase("SocialPreview.pdf", PdfRotation.Rotate180, true)]
        [TestCase("Wikimedia_Commons_web.pdf", PdfRotation.Rotate180, null)]
        [TestCase("Wikimedia_Commons_web.pdf", PdfRotation.Rotate180, false)]
        [TestCase("Wikimedia_Commons_web.pdf", PdfRotation.Rotate180, true)]

        [TestCase("hundesteuer-anmeldung.pdf", PdfRotation.Rotate270, null)]
        [TestCase("hundesteuer-anmeldung.pdf", PdfRotation.Rotate270, false)]
        [TestCase("hundesteuer-anmeldung.pdf", PdfRotation.Rotate270, true)]
        [TestCase("SocialPreview.pdf", PdfRotation.Rotate270, null)]
        [TestCase("SocialPreview.pdf", PdfRotation.Rotate270, false)]
        [TestCase("SocialPreview.pdf", PdfRotation.Rotate270, true)]
        [TestCase("Wikimedia_Commons_web.pdf", PdfRotation.Rotate270, null)]
        [TestCase("Wikimedia_Commons_web.pdf", PdfRotation.Rotate270, false)]
        [TestCase("Wikimedia_Commons_web.pdf", PdfRotation.Rotate270, true)]
        public void WithRotation(string fileName, PdfRotation? rotation = null, bool? useTiling = null)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "Tiling", useTiling == true ? "tiled" : "normal", GetExpectedFilename(fileName, "png", null, null, 600, false, rotation ?? default, default));

            using var inputStream = GetInputStream(Path.Combine("Assets", fileName));
            using var outputStream = CreateOutputStream(expectedPath);

            if (rotation != null)
                SavePng(outputStream, inputStream, options: new(Dpi: 600, Rotation: rotation.Value, UseTiling: useTiling == true, AntiAliasing: PdfAntiAliasing.None));
            else
                SavePng(outputStream, inputStream, options: new(Dpi: 600, UseTiling: useTiling == true, AntiAliasing: PdfAntiAliasing.None));

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase("hundesteuer-anmeldung.pdf", 0, 0, 500, 500, null, null)]
        [TestCase("hundesteuer-anmeldung.pdf", 0, 0, 500, 500, null, false)]
        [TestCase("hundesteuer-anmeldung.pdf", 0, 0, 500, 500, null, true)]
        [TestCase("SocialPreview.pdf", 0, 0, 500, 500, null, null)]
        [TestCase("SocialPreview.pdf", 0, 0, 500, 500, null, false)]
        [TestCase("SocialPreview.pdf", 0, 0, 500, 500, null, true)]
        [TestCase("Wikimedia_Commons_web.pdf", 0, 0, 500, 500, null, null)]
        [TestCase("Wikimedia_Commons_web.pdf", 0, 0, 500, 500, null, false)]
        [TestCase("Wikimedia_Commons_web.pdf", 0, 0, 500, 500, null, true)]

        [TestCase("hundesteuer-anmeldung.pdf", 0, 0, 500, 500, PdfRotation.Rotate0, null)]
        [TestCase("hundesteuer-anmeldung.pdf", 0, 0, 500, 500, PdfRotation.Rotate0, false)]
        [TestCase("hundesteuer-anmeldung.pdf", 0, 0, 500, 500, PdfRotation.Rotate0, true)]
        [TestCase("SocialPreview.pdf", 0, 0, 500, 500, PdfRotation.Rotate0, null)]
        [TestCase("SocialPreview.pdf", 0, 0, 500, 500, PdfRotation.Rotate0, false)]
        [TestCase("SocialPreview.pdf", 0, 0, 500, 500, PdfRotation.Rotate0, true)]
        [TestCase("Wikimedia_Commons_web.pdf", 0, 0, 500, 500, PdfRotation.Rotate0, null)]
        [TestCase("Wikimedia_Commons_web.pdf", 0, 0, 500, 500, PdfRotation.Rotate0, false)]
        [TestCase("Wikimedia_Commons_web.pdf", 0, 0, 500, 500, PdfRotation.Rotate0, true)]

        [TestCase("hundesteuer-anmeldung.pdf", 0, 0, 500, 500, PdfRotation.Rotate90, null)]
        [TestCase("hundesteuer-anmeldung.pdf", 0, 0, 500, 500, PdfRotation.Rotate90, false)]
        [TestCase("hundesteuer-anmeldung.pdf", 0, 0, 500, 500, PdfRotation.Rotate90, true)]
        [TestCase("SocialPreview.pdf", 0, 0, 500, 500, PdfRotation.Rotate90, null)]
        [TestCase("SocialPreview.pdf", 0, 0, 500, 500, PdfRotation.Rotate90, false)]
        [TestCase("SocialPreview.pdf", 0, 0, 500, 500, PdfRotation.Rotate90, true)]
        [TestCase("Wikimedia_Commons_web.pdf", 0, 0, 500, 500, PdfRotation.Rotate90, null)]
        [TestCase("Wikimedia_Commons_web.pdf", 0, 0, 500, 500, PdfRotation.Rotate90, false)]
        [TestCase("Wikimedia_Commons_web.pdf", 0, 0, 500, 500, PdfRotation.Rotate90, true)]

        [TestCase("hundesteuer-anmeldung.pdf", 0, 0, 500, 500, PdfRotation.Rotate180, null)]
        [TestCase("hundesteuer-anmeldung.pdf", 0, 0, 500, 500, PdfRotation.Rotate180, false)]
        [TestCase("hundesteuer-anmeldung.pdf", 0, 0, 500, 500, PdfRotation.Rotate180, true)]
        [TestCase("SocialPreview.pdf", 0, 0, 500, 500, PdfRotation.Rotate180, null)]
        [TestCase("SocialPreview.pdf", 0, 0, 500, 500, PdfRotation.Rotate180, false)]
        [TestCase("SocialPreview.pdf", 0, 0, 500, 500, PdfRotation.Rotate180, true)]
        [TestCase("Wikimedia_Commons_web.pdf", 0, 0, 500, 500, PdfRotation.Rotate180, null)]
        [TestCase("Wikimedia_Commons_web.pdf", 0, 0, 500, 500, PdfRotation.Rotate180, false)]
        [TestCase("Wikimedia_Commons_web.pdf", 0, 0, 500, 500, PdfRotation.Rotate180, true)]

        [TestCase("hundesteuer-anmeldung.pdf", 0, 0, 500, 500, PdfRotation.Rotate270, null)]
        [TestCase("hundesteuer-anmeldung.pdf", 0, 0, 500, 500, PdfRotation.Rotate270, false)]
        [TestCase("hundesteuer-anmeldung.pdf", 0, 0, 500, 500, PdfRotation.Rotate270, true)]
        [TestCase("SocialPreview.pdf", 0, 0, 500, 500, PdfRotation.Rotate270, null)]
        [TestCase("SocialPreview.pdf", 0, 0, 500, 500, PdfRotation.Rotate270, false)]
        [TestCase("SocialPreview.pdf", 0, 0, 500, 500, PdfRotation.Rotate270, true)]
        [TestCase("Wikimedia_Commons_web.pdf", 0, 0, 500, 500, PdfRotation.Rotate270, null)]
        [TestCase("Wikimedia_Commons_web.pdf", 0, 0, 500, 500, PdfRotation.Rotate270, false)]
        [TestCase("Wikimedia_Commons_web.pdf", 0, 0, 500, 500, PdfRotation.Rotate270, true)]

        [TestCase("hundesteuer-anmeldung.pdf", 200, 200, 700, 700, null, null)]
        [TestCase("hundesteuer-anmeldung.pdf", 200, 200, 700, 700, null, false)]
        [TestCase("hundesteuer-anmeldung.pdf", 200, 200, 700, 700, null, true)]
        [TestCase("SocialPreview.pdf", 200, 200, 700, 700, null, null)]
        [TestCase("SocialPreview.pdf", 200, 200, 700, 700, null, false)]
        [TestCase("SocialPreview.pdf", 200, 200, 700, 700, null, true)]
        [TestCase("Wikimedia_Commons_web.pdf", 200, 200, 700, 700, null, null)]
        [TestCase("Wikimedia_Commons_web.pdf", 200, 200, 700, 700, null, false)]
        [TestCase("Wikimedia_Commons_web.pdf", 200, 200, 700, 700, null, true)]

        [TestCase("hundesteuer-anmeldung.pdf", -200, -200, 700, 700, null, null)]
        [TestCase("hundesteuer-anmeldung.pdf", -200, -200, 700, 700, null, false)]
        [TestCase("hundesteuer-anmeldung.pdf", -200, -200, 700, 700, null, true)]
        [TestCase("SocialPreview.pdf", -200, -200, 700, 700, null, null)]
        [TestCase("SocialPreview.pdf", -200, -200, 700, 700, null, false)]
        [TestCase("SocialPreview.pdf", -200, -200, 700, 700, null, true)]
        [TestCase("Wikimedia_Commons_web.pdf", -200, -200, 700, 700, null, null)]
        [TestCase("Wikimedia_Commons_web.pdf", -200, -200, 700, 700, null, false)]
        [TestCase("Wikimedia_Commons_web.pdf", -200, -200, 700, 700, null, true)]
        public void WithBounds(string fileName, float x, float y, float width, float height, PdfRotation? rotation = null, bool? useTiling = null)
        {
            var bounds = new RectangleF(x, y, width, height);
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "Tiling", useTiling == true ? "tiled" : "normal", GetExpectedFilename(fileName, "png", null, null, 600, false, rotation ?? default, bounds));

            using var inputStream = GetInputStream(Path.Combine("Assets", fileName));
            using var outputStream = CreateOutputStream(expectedPath);

            if (rotation != null)
                SavePng(outputStream, inputStream, options: new(Dpi: 600, Bounds: bounds, Rotation: rotation.Value, UseTiling: useTiling == true, AntiAliasing: PdfAntiAliasing.None));
            else
                SavePng(outputStream, inputStream, options: new(Dpi: 600, Bounds: bounds, UseTiling: useTiling == true, AntiAliasing: PdfAntiAliasing.None));

            CompareStreams(expectedPath, outputStream);
        }

        private static string GetExpectedFilename(string fileName, string? fileExtension, int? width, int? height, int? dpi, bool withAspectRatio, PdfRotation rotation, RectangleF? bounds)
            => $"{fileName}_w={width?.ToString() ?? "null"}_h={height?.ToString() ?? "null"}_dpi={dpi?.ToString() ?? "null"}_aspectratio={withAspectRatio}_{Enum.GetName(typeof(PdfRotation), rotation)}{(bounds != null ? $"_{bounds.Value.X}-{bounds.Value.Y}-{bounds.Value.Width}-{bounds.Value.Height}" : string.Empty)}{(fileExtension != null ? $".{fileExtension}" : string.Empty)}";
    }
}