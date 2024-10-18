using NUnit.Framework;
using PDFtoImage;
using PDFtoImage.Tests;
using System;
using System.IO;
using static PDFtoImage.Compatibility.Conversion;
using static PDFtoImage.Tests.TestUtils;

namespace Tests.Compatibility
{
    [TestFixture]
    public class RotationTests : TestBase
    {
        [Test]
        [TestCase(null, TestName = "Default (no rotation)")]
        [TestCase(PdfRotation.Rotate0, TestName = "No rotation")]
        [TestCase(PdfRotation.Rotate90, TestName = "Rotated 90 degrees clockwise")]
        [TestCase(PdfRotation.Rotate180, TestName = "Rotated 180 degrees")]
        [TestCase(PdfRotation.Rotate270, TestName = "Rotated 90 degrees counter-clockwise")]
        public void SaveWebpPageNumber(PdfRotation? rotation)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "Rotation", $"hundesteuer-anmeldung_{Enum.GetName(typeof(PdfRotation), rotation ?? PdfRotation.Rotate0)}.webp");

            using var inputStream = GetInputStream(Path.Combine("Assets", "hundesteuer-anmeldung.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            if (rotation == null)
                SaveWebp(outputStream, inputStream, dpi: 40);
            else
                SaveWebp(outputStream, inputStream, dpi: 40, rotation: rotation.Value);

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase(null, TestName = "Default (no rotation)")]
        [TestCase(PdfRotation.Rotate0, TestName = "No rotation")]
        [TestCase(PdfRotation.Rotate90, TestName = "Rotated 90 degrees clockwise")]
        [TestCase(PdfRotation.Rotate180, TestName = "Rotated 180 degrees")]
        [TestCase(PdfRotation.Rotate270, TestName = "Rotated 90 degrees counter-clockwise")]
        public void SavePngPageNumber(PdfRotation? rotation)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "Rotation", $"hundesteuer-anmeldung_{Enum.GetName(typeof(PdfRotation), rotation ?? PdfRotation.Rotate0)}.png");

            using var inputStream = GetInputStream(Path.Combine("Assets", "hundesteuer-anmeldung.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            if (rotation == null)
                SavePng(outputStream, inputStream, dpi: 40);
            else
                SavePng(outputStream, inputStream, dpi: 40, rotation: rotation.Value);

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase(null, TestName = "Default (no rotation)")]
        [TestCase(PdfRotation.Rotate0, TestName = "No rotation")]
        [TestCase(PdfRotation.Rotate90, TestName = "Rotated 90 degrees clockwise")]
        [TestCase(PdfRotation.Rotate180, TestName = "Rotated 180 degrees")]
        [TestCase(PdfRotation.Rotate270, TestName = "Rotated 90 degrees counter-clockwise")]
        public void SaveJpegPageNumber(PdfRotation? rotation)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "Rotation", $"hundesteuer-anmeldung_{Enum.GetName(typeof(PdfRotation), rotation ?? PdfRotation.Rotate0)}.jpg");

            using var inputStream = GetInputStream(Path.Combine("Assets", "hundesteuer-anmeldung.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            if (rotation == null)
                SaveJpeg(outputStream, inputStream, dpi: 40);
            else
                SaveJpeg(outputStream, inputStream, dpi: 40, rotation: rotation.Value);

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase(null, null, null, false)]
        [TestCase(PdfRotation.Rotate0, null, null, false)]
        [TestCase(PdfRotation.Rotate90, null, null, false)]
        [TestCase(PdfRotation.Rotate180, null, null, false)]
        [TestCase(PdfRotation.Rotate270, null, null, false)]
        [TestCase(null, null, null, true)]
        [TestCase(PdfRotation.Rotate0, null, null, true)]
        [TestCase(PdfRotation.Rotate90, null, null, true)]
        [TestCase(PdfRotation.Rotate180, null, null, true)]
        [TestCase(PdfRotation.Rotate270, null, null, true)]
        [TestCase(null, 200, null, false)]
        [TestCase(PdfRotation.Rotate0, 200, null, false)]
        [TestCase(PdfRotation.Rotate90, 200, null, false)]
        [TestCase(PdfRotation.Rotate180, 200, null, false)]
        [TestCase(PdfRotation.Rotate270, 200, null, false)]
        [TestCase(null, 200, null, true)]
        [TestCase(PdfRotation.Rotate0, 200, null, true)]
        [TestCase(PdfRotation.Rotate90, 200, null, true)]
        [TestCase(PdfRotation.Rotate180, 200, null, true)]
        [TestCase(PdfRotation.Rotate270, 200, null, true)]
        [TestCase(null, null, 200, false)]
        [TestCase(PdfRotation.Rotate0, null, 200, false)]
        [TestCase(PdfRotation.Rotate90, null, 200, false)]
        [TestCase(PdfRotation.Rotate180, null, 200, false)]
        [TestCase(PdfRotation.Rotate270, 200, null, false)]
        [TestCase(null, null, 200, true)]
        [TestCase(PdfRotation.Rotate0, null, 200, true)]
        [TestCase(PdfRotation.Rotate90, null, 200, true)]
        [TestCase(PdfRotation.Rotate180, null, 200, true)]
        [TestCase(PdfRotation.Rotate270, null, 200, true)]
        [TestCase(null, 200, 200, false)]
        [TestCase(PdfRotation.Rotate0, 200, 200, false)]
        [TestCase(PdfRotation.Rotate90, 200, 200, false)]
        [TestCase(PdfRotation.Rotate180, 200, 200, false)]
        [TestCase(PdfRotation.Rotate270, 200, 200, false)]
        [TestCase(null, 200, 200, true)]
        [TestCase(PdfRotation.Rotate0, 200, 200, true)]
        [TestCase(PdfRotation.Rotate90, 200, 200, true)]
        [TestCase(PdfRotation.Rotate180, 200, 200, true)]
        [TestCase(PdfRotation.Rotate270, 200, 200, true)]
        public void WithWidthHeightAspect(PdfRotation? rotation, int? width, int? height, bool withAspectRatio)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "Rotation", $"hundesteuer-anmeldung_{Enum.GetName(typeof(PdfRotation), rotation ?? PdfRotation.Rotate0)}_{width?.ToString() ?? "null"}x{height?.ToString() ?? "null"}_{withAspectRatio}.png");

            using var inputStream = GetInputStream(Path.Combine("Assets", "hundesteuer-anmeldung.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            if (rotation == null)
                SavePng(outputStream, inputStream, dpi: 40, width: width, height: height, withAspectRatio: withAspectRatio);
            else
                SavePng(outputStream, inputStream, dpi: 40, width: width, height: height, withAspectRatio: withAspectRatio, rotation: rotation.Value);

            CompareStreams(expectedPath, outputStream);
        }
    }
}