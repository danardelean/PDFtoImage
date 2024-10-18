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
    public class BoundsTests : TestBase
    {
        [Test]
        [TestCase(null)]
        [TestCase(default)]
        public void NullOrDefault(RectangleF? bounds = null)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "Bounds", $"Wikimedia_Commons_web_{GetFileName(bounds, default, default, default, default)}.png");

            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            SavePng(outputStream, inputStream, options: new(Dpi: 300, Bounds: bounds));

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase(0f, 0f, 419.528f, 595.276f)]
        [TestCase(0f, 0f, 419.528f, 297.638f)]
        [TestCase(0f, 0f, 209.764f, 595.276f)]
        [TestCase(0f, 0f, 209.764f, 297.638f)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f)]
        [TestCase(0f, 0f, 200f, 200f)]
        [TestCase(219.528f, 0f, 200f, 200f)]
        [TestCase(0f, 395.276f, 200f, 200f)]
        [TestCase(219.528f, 395.276f, 200f, 200f)]
        public void Normal(float x, float y, float width, float height)
        {
            var bounds = new RectangleF(x, y, width, height);
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "Bounds", $"Wikimedia_Commons_web_{GetFileName(bounds, default, default, default, default)}.png");

            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            SavePng(outputStream, inputStream, options: new(Dpi: 300, Bounds: bounds));

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase(0f, 0f, 419.528f, 595.276f, default)]
        [TestCase(0f, 0f, 209.764f, 297.638f, default)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, default)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, default)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, default)]
        [TestCase(0f, 0f, 419.528f, 595.276f, PdfRotation.Rotate0)]
        [TestCase(0f, 0f, 209.764f, 297.638f, PdfRotation.Rotate0)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, PdfRotation.Rotate0)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, PdfRotation.Rotate0)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, PdfRotation.Rotate0)]
        [TestCase(0f, 0f, 419.528f, 595.276f, PdfRotation.Rotate180)]
        [TestCase(0f, 0f, 209.764f, 297.638f, PdfRotation.Rotate180)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, PdfRotation.Rotate180)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, PdfRotation.Rotate180)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, PdfRotation.Rotate180)]
        [TestCase(0f, 0f, 419.528f, 595.276f, PdfRotation.Rotate90)]
        [TestCase(0f, 0f, 209.764f, 297.638f, PdfRotation.Rotate90)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, PdfRotation.Rotate90)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, PdfRotation.Rotate90)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, PdfRotation.Rotate90)]
        [TestCase(0f, 0f, 419.528f, 595.276f, PdfRotation.Rotate270)]
        [TestCase(0f, 0f, 209.764f, 297.638f, PdfRotation.Rotate270)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, PdfRotation.Rotate270)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, PdfRotation.Rotate270)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, PdfRotation.Rotate270)]

        [TestCase(104.882f, 148.819f, 209.764f, 297.638f, default)]
        [TestCase(104.882f, 148.819f, 209.764f, 297.638f, PdfRotation.Rotate0)]
        [TestCase(104.882f, 148.819f, 209.764f, 297.638f, PdfRotation.Rotate90)]
        [TestCase(104.882f, 148.819f, 209.764f, 297.638f, PdfRotation.Rotate180)]
        [TestCase(104.882f, 148.819f, 209.764f, 297.638f, PdfRotation.Rotate270)]
        public void WithRotation(float x, float y, float width, float height, PdfRotation? rotation)
        {
            var bounds = new RectangleF(x, y, width, height);
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "Bounds", $"Wikimedia_Commons_web_{GetFileName(bounds, rotation, default, default, default)}.png");

            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            if (rotation != null)
                SavePng(outputStream, inputStream, options: new(Dpi: 300, Rotation: rotation.Value, Bounds: bounds));
            else
                SavePng(outputStream, inputStream, options: new(Dpi: 300, Bounds: bounds));

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase(0f, 0f, 419.528f, 595.276f, default)]
        [TestCase(0f, 0f, 209.764f, 297.638f, default)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, default)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, default)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, default)]
        [TestCase(0f, 0f, 419.528f, 595.276f, false)]
        [TestCase(0f, 0f, 209.764f, 297.638f, false)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, false)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, false)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, false)]
        [TestCase(0f, 0f, 419.528f, 595.276f, true)]
        [TestCase(0f, 0f, 209.764f, 297.638f, true)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, true)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, true)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, true)]
        public void WithAnnotations(float x, float y, float width, float height, bool? withAnnotations = null)
        {
            var bounds = new RectangleF(x, y, width, height);
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "Bounds", $"Wikimedia_Commons_web_{GetFileName(bounds, default, withAnnotations, default, default)}.png");

            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            if (withAnnotations != null)
                SavePng(outputStream, inputStream, options: new(Dpi: 300, WithAnnotations: withAnnotations.Value, Bounds: bounds));
            else
                SavePng(outputStream, inputStream, options: new(Dpi: 300, Bounds: bounds));

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase(0f, 0f, 595.56f, 842.04f, default)]
        [TestCase(0f, 0f, 297.78f, 421.02f, default)]
        [TestCase(297.78f, 0f, 297.78f, 421.02f, default)]
        [TestCase(0f, 421.02f, 297.78f, 421.02f, default)]
        [TestCase(297.78f, 421.02f, 297.78f, 421.02f, default)]
        [TestCase(0f, 0f, 595.56f, 842.04f, false)]
        [TestCase(0f, 0f, 297.78f, 421.02f, false)]
        [TestCase(297.78f, 0f, 297.78f, 421.02f, false)]
        [TestCase(0f, 421.02f, 297.78f, 421.02f, false)]
        [TestCase(297.78f, 421.02f, 297.78f, 421.02f, false)]
        [TestCase(0f, 0f, 595.56f, 842.04f, true)]
        [TestCase(0f, 0f, 297.78f, 421.02f, true)]
        [TestCase(297.78f, 0f, 297.78f, 421.02f, true)]
        [TestCase(0f, 421.02f, 297.78f, 421.02f, true)]
        [TestCase(297.78f, 421.02f, 297.78f, 421.02f, true)]
        public void WithFormFill(float x, float y, float width, float height, bool? withFormFill = null)
        {
            var bounds = new RectangleF(x, y, width, height);
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "Bounds", $"hundesteuer-anmeldung_{GetFileName(bounds, default, default, withFormFill, default)}.png");

            using var inputStream = GetInputStream(Path.Combine("Assets", "hundesteuer-anmeldung.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            if (withFormFill != null)
                SavePng(outputStream, inputStream, options: new(Dpi: 300, WithFormFill: withFormFill.Value, Bounds: bounds));
            else
                SavePng(outputStream, inputStream, options: new(Dpi: 300, Bounds: bounds));

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase(0f, 0f, 419.528f, 595.276f, default, default)]
        [TestCase(0f, 0f, 209.764f, 297.638f, default, default)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, default, default)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, default, default)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, default, default)]
        [TestCase(0f, 0f, 419.528f, 595.276f, 500, 500)]
        [TestCase(0f, 0f, 209.764f, 297.638f, 500, 500)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, 500, 500)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, 500, 500)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, 500, 500)]
        public void WithWidthAndHeight(float x, float y, float width, float height, int? outputWidth = null, int? outputHeight = null)
        {
            var bounds = new RectangleF(x, y, width, height);
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "Bounds", $"Wikimedia_Commons_web_{GetFileName(bounds, default, default, default, default)}_{outputWidth?.ToString() ?? "null"}x{outputHeight?.ToString() ?? "null"}.png");

            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            SavePng(outputStream, inputStream, options: new(Width: outputWidth, Height: outputHeight, Bounds: bounds));

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase(0f, 0f, 419.528f, 595.276f, default, default, default)]
        [TestCase(0f, 0f, 209.764f, 297.638f, default, default, default)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, default, default, default)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, default, default, default)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, default, default, default)]
        [TestCase(0f, 0f, 419.528f, 595.276f, 500, 500, default)]
        [TestCase(0f, 0f, 209.764f, 297.638f, 500, 500, default)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, 500, 500, default)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, 500, 500, default)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, 500, 500, default)]

        [TestCase(0f, 0f, 419.528f, 595.276f, default, default, PdfRotation.Rotate0)]
        [TestCase(0f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate0)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate0)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate0)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate0)]
        [TestCase(0f, 0f, 419.528f, 595.276f, 500, 500, PdfRotation.Rotate0)]
        [TestCase(0f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate0)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate0)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate0)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate0)]

        [TestCase(0f, 0f, 419.528f, 595.276f, default, default, PdfRotation.Rotate90)]
        [TestCase(0f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate90)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate90)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate90)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate90)]
        [TestCase(0f, 0f, 419.528f, 595.276f, 500, 500, PdfRotation.Rotate90)]
        [TestCase(0f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate90)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate90)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate90)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate90)]

        [TestCase(0f, 0f, 419.528f, 595.276f, default, default, PdfRotation.Rotate180)]
        [TestCase(0f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate180)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate180)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate180)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate180)]
        [TestCase(0f, 0f, 419.528f, 595.276f, 500, 500, PdfRotation.Rotate180)]
        [TestCase(0f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate180)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate180)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate180)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate180)]

        [TestCase(0f, 0f, 419.528f, 595.276f, default, default, PdfRotation.Rotate270)]
        [TestCase(0f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate270)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate270)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate270)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate270)]
        [TestCase(0f, 0f, 419.528f, 595.276f, 500, 500, PdfRotation.Rotate270)]
        [TestCase(0f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate270)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate270)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate270)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate270)]
        public void WithWidthAndHeightAndRotation(float x, float y, float width, float height, int? outputWidth = null, int? outputHeight = null, PdfRotation? rotation = null)
        {
            var bounds = new RectangleF(x, y, width, height);
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "Bounds", $"Wikimedia_Commons_web_{GetFileName(bounds, rotation, default, default, default)}_{outputWidth?.ToString() ?? "null"}x{outputHeight?.ToString() ?? "null"}.png");

            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            SavePng(outputStream, inputStream, options: new(Width: outputWidth, Height: outputHeight, Bounds: bounds, Rotation: rotation ?? default));

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase(0f, 0f, 419.528f, 595.276f, default, default, default, default)]
        [TestCase(0f, 0f, 209.764f, 297.638f, default, default, default, default)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, default, default, default, default)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, default, default, default, default)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, default, default, default, default)]
        [TestCase(0f, 0f, 419.528f, 595.276f, 500, 500, default, default)]
        [TestCase(0f, 0f, 209.764f, 297.638f, 500, 500, default, default)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, 500, 500, default, default)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, 500, 500, default, default)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, 500, 500, default, default)]

        [TestCase(0f, 0f, 419.528f, 595.276f, default, default, PdfRotation.Rotate0, default)]
        [TestCase(0f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate0, default)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate0, default)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate0, default)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate0, default)]
        [TestCase(0f, 0f, 419.528f, 595.276f, 500, 500, PdfRotation.Rotate0, default)]
        [TestCase(0f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate0, default)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate0, default)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate0, default)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate0, default)]

        [TestCase(0f, 0f, 419.528f, 595.276f, default, default, PdfRotation.Rotate90, default)]
        [TestCase(0f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate90, default)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate90, default)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate90, default)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate90, default)]
        [TestCase(0f, 0f, 419.528f, 595.276f, 500, 500, PdfRotation.Rotate90, default)]
        [TestCase(0f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate90, default)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate90, default)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate90, default)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate90, default)]

        [TestCase(0f, 0f, 419.528f, 595.276f, default, default, PdfRotation.Rotate180, default)]
        [TestCase(0f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate180, default)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate180, default)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate180, default)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate180, default)]
        [TestCase(0f, 0f, 419.528f, 595.276f, 500, 500, PdfRotation.Rotate180, default)]
        [TestCase(0f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate180, default)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate180, default)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate180, default)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate180, default)]

        [TestCase(0f, 0f, 419.528f, 595.276f, default, default, PdfRotation.Rotate270, default)]
        [TestCase(0f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate270, default)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate270, default)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate270, default)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate270, default)]
        [TestCase(0f, 0f, 419.528f, 595.276f, 500, 500, PdfRotation.Rotate270, default)]
        [TestCase(0f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate270, default)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate270, default)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate270, default)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate270, default)]

        [TestCase(0f, 0f, 419.528f, 595.276f, default, default, default, false)]
        [TestCase(0f, 0f, 209.764f, 297.638f, default, default, default, false)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, default, default, default, false)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, default, default, default, false)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, default, default, default, false)]
        [TestCase(0f, 0f, 419.528f, 595.276f, 500, 500, default, false)]
        [TestCase(0f, 0f, 209.764f, 297.638f, 500, 500, default, false)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, 500, 500, default, false)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, 500, 500, default, false)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, 500, 500, default, false)]

        [TestCase(0f, 0f, 419.528f, 595.276f, default, default, PdfRotation.Rotate0, false)]
        [TestCase(0f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate0, false)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate0, false)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate0, false)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate0, false)]
        [TestCase(0f, 0f, 419.528f, 595.276f, 500, 500, PdfRotation.Rotate0, false)]
        [TestCase(0f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate0, false)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate0, false)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate0, false)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate0, false)]

        [TestCase(0f, 0f, 419.528f, 595.276f, default, default, PdfRotation.Rotate90, false)]
        [TestCase(0f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate90, false)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate90, false)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate90, false)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate90, false)]
        [TestCase(0f, 0f, 419.528f, 595.276f, 500, 500, PdfRotation.Rotate90, false)]
        [TestCase(0f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate90, false)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate90, false)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate90, false)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate90, false)]

        [TestCase(0f, 0f, 419.528f, 595.276f, default, default, PdfRotation.Rotate180, false)]
        [TestCase(0f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate180, false)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate180, false)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate180, false)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate180, false)]
        [TestCase(0f, 0f, 419.528f, 595.276f, 500, 500, PdfRotation.Rotate180, false)]
        [TestCase(0f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate180, false)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate180, false)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate180, false)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate180, false)]

        [TestCase(0f, 0f, 419.528f, 595.276f, default, default, PdfRotation.Rotate270, false)]
        [TestCase(0f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate270, false)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate270, false)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate270, false)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate270, false)]
        [TestCase(0f, 0f, 419.528f, 595.276f, 500, 500, PdfRotation.Rotate270, false)]
        [TestCase(0f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate270, false)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate270, false)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate270, false)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate270, false)]

        [TestCase(0f, 0f, 419.528f, 595.276f, default, default, default, true)]
        [TestCase(0f, 0f, 209.764f, 297.638f, default, default, default, true)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, default, default, default, true)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, default, default, default, true)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, default, default, default, true)]
        [TestCase(0f, 0f, 419.528f, 595.276f, 500, 500, default, true)]
        [TestCase(0f, 0f, 209.764f, 297.638f, 500, 500, default, true)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, 500, 500, default, true)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, 500, 500, default, true)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, 500, 500, default, true)]

        [TestCase(0f, 0f, 419.528f, 595.276f, default, default, PdfRotation.Rotate0, true)]
        [TestCase(0f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate0, true)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate0, true)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate0, true)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate0, true)]
        [TestCase(0f, 0f, 419.528f, 595.276f, 500, 500, PdfRotation.Rotate0, true)]
        [TestCase(0f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate0, true)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate0, true)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate0, true)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate0, true)]

        [TestCase(0f, 0f, 419.528f, 595.276f, default, default, PdfRotation.Rotate90, true)]
        [TestCase(0f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate90, true)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate90, true)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate90, true)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate90, true)]
        [TestCase(0f, 0f, 419.528f, 595.276f, 500, 500, PdfRotation.Rotate90, true)]
        [TestCase(0f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate90, true)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate90, true)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate90, true)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate90, true)]

        [TestCase(0f, 0f, 419.528f, 595.276f, default, default, PdfRotation.Rotate180, true)]
        [TestCase(0f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate180, true)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate180, true)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate180, true)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate180, true)]
        [TestCase(0f, 0f, 419.528f, 595.276f, 500, 500, PdfRotation.Rotate180, true)]
        [TestCase(0f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate180, true)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate180, true)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate180, true)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate180, true)]

        [TestCase(0f, 0f, 419.528f, 595.276f, default, default, PdfRotation.Rotate270, true)]
        [TestCase(0f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate270, true)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, default, default, PdfRotation.Rotate270, true)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate270, true)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, default, default, PdfRotation.Rotate270, true)]
        [TestCase(0f, 0f, 419.528f, 595.276f, 500, 500, PdfRotation.Rotate270, true)]
        [TestCase(0f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate270, true)]
        [TestCase(209.764f, 0f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate270, true)]
        [TestCase(0f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate270, true)]
        [TestCase(209.764f, 297.638f, 209.764f, 297.638f, 500, 500, PdfRotation.Rotate270, true)]
        public void WithWidthAndHeightAndRotationAndDpiRelative(float x, float y, float width, float height, int? outputWidth = null, int? outputHeight = null, PdfRotation? rotation = null, bool? dpiRelativeToBounds = null)
        {
            var bounds = new RectangleF(x, y, width, height);
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "Bounds", $"Wikimedia_Commons_web_{GetFileName(bounds, rotation, default, default, dpiRelativeToBounds)}_{outputWidth?.ToString() ?? "null"}x{outputHeight?.ToString() ?? "null"}.png");

            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            if (dpiRelativeToBounds != null)
                SavePng(outputStream, inputStream, options: new(Width: outputWidth, Height: outputHeight, Bounds: bounds, Rotation: rotation ?? default, DpiRelativeToBounds: dpiRelativeToBounds.Value));
            else
                SavePng(outputStream, inputStream, options: new(Width: outputWidth, Height: outputHeight, Bounds: bounds, Rotation: rotation ?? default));

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase(0f, 0f, 419.528f, 595.276f, default)]
        [TestCase(0f, 0f, 419.528f, 595.276f, false)]
        [TestCase(0f, 0f, 419.528f, 595.276f, true)]

        [TestCase(0f, 0f, 200f, 200f, default)]
        [TestCase(0f, 0f, 200f, 200f, false)]
        [TestCase(0f, 0f, 200f, 200f, true)]

        [TestCase(200f, 0f, 200f, 200f, default)]
        [TestCase(200f, 0f, 200f, 200f, false)]
        [TestCase(200f, 0f, 200f, 200f, true)]

        [TestCase(0f, 200f, 200f, 200f, default)]
        [TestCase(0f, 200f, 200f, 200f, false)]
        [TestCase(0f, 200f, 200f, 200f, true)]

        [TestCase(200f, 200f, 200f, 200f, default)]
        [TestCase(200f, 200f, 200f, 200f, false)]
        [TestCase(200f, 200f, 200f, 200f, true)]
        public void WithDpiRelative(float x, float y, float width, float height, bool? dpiRelativeToBounds = null)
        {
            var bounds = new RectangleF(x, y, width, height);
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "Bounds", $"Wikimedia_Commons_web_{GetFileName(bounds, default, default, default, dpiRelativeToBounds)}.png");

            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            if (dpiRelativeToBounds != null)
                SavePng(outputStream, inputStream, options: new(Dpi: 300, Bounds: bounds, DpiRelativeToBounds: dpiRelativeToBounds.Value));
            else
                SavePng(outputStream, inputStream, options: new(Dpi: 300, Bounds: bounds));

            CompareStreams(expectedPath, outputStream);
        }

        private static string GetFileName(RectangleF? input, PdfRotation? rotation, bool? withAnnotations, bool? withFormFill, bool? dpiRelativeToBounds)
        {
            if (input == null)
                return "default";

            return $"{input.Value.X}-{input.Value.Y}-{input.Value.Width}-{input.Value.Height}{(rotation != null && rotation != PdfRotation.Rotate0 ? $"_{Enum.GetName(typeof(PdfRotation), rotation)}" : string.Empty)}{(withAnnotations == true ? "_annot" : string.Empty)}{(withFormFill == true ? "_form" : string.Empty)}{(dpiRelativeToBounds == true ? "_dpirelative" : string.Empty)}".Replace('.', ',');
        }
    }
}