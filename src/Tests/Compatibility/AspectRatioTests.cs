using NUnit.Framework;
using PDFtoImage.Tests;
using System.IO;
using static PDFtoImage.Compatibility.Conversion;
using static PDFtoImage.Tests.TestUtils;

namespace Tests.Compatibility
{
    [TestFixture]
    public class AspectRatioTests : TestBase
    {
        [Test]
        [TestCase("hundesteuer-anmeldung.pdf")]
        [TestCase("hundesteuer-anmeldung.pdf", 100, null, null)]
        [TestCase("hundesteuer-anmeldung.pdf", 1000, null, null)]
        [TestCase("hundesteuer-anmeldung.pdf", 2000, null, null)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 100, null)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 1000, null)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 2000, null)]
        [TestCase("hundesteuer-anmeldung.pdf", 100, 100, null)]
        [TestCase("hundesteuer-anmeldung.pdf", 1000, 1000, null)]
        [TestCase("hundesteuer-anmeldung.pdf", 2000, 2000, null)]
        [TestCase("hundesteuer-anmeldung.pdf", null, null, 96)]
        [TestCase("hundesteuer-anmeldung.pdf", null, null, 300)]
        [TestCase("hundesteuer-anmeldung.pdf", null, null, 600)]
        [TestCase("hundesteuer-anmeldung.pdf", 100, null, 96)]
        [TestCase("hundesteuer-anmeldung.pdf", 100, null, 300)]
        [TestCase("hundesteuer-anmeldung.pdf", 100, null, 1200)]
        [TestCase("hundesteuer-anmeldung.pdf", 1000, null, 96)]
        [TestCase("hundesteuer-anmeldung.pdf", 1000, null, 300)]
        [TestCase("hundesteuer-anmeldung.pdf", 1000, null, 1200)]
        [TestCase("hundesteuer-anmeldung.pdf", 2000, null, 96)]
        [TestCase("hundesteuer-anmeldung.pdf", 2000, null, 300)]
        [TestCase("hundesteuer-anmeldung.pdf", 2000, null, 1200)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 100, 96)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 100, 300)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 100, 1200)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 1000, 96)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 1000, 300)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 1000, 1200)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 2000, 96)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 2000, 300)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 2000, 1200)]
        [TestCase("hundesteuer-anmeldung.pdf", 100, 100, 96)]
        [TestCase("hundesteuer-anmeldung.pdf", 100, 100, 300)]
        [TestCase("hundesteuer-anmeldung.pdf", 100, 100, 1200)]
        [TestCase("hundesteuer-anmeldung.pdf", 1000, 1000, 96)]
        [TestCase("hundesteuer-anmeldung.pdf", 1000, 1000, 300)]
        [TestCase("hundesteuer-anmeldung.pdf", 1000, 1000, 1200)]
        [TestCase("hundesteuer-anmeldung.pdf", 2000, 2000, 96)]
        [TestCase("hundesteuer-anmeldung.pdf", 2000, 2000, 300)]
        [TestCase("hundesteuer-anmeldung.pdf", 2000, 2000, 1200)]

        [TestCase("SocialPreview.pdf")]
        [TestCase("SocialPreview.pdf", 100, null, null)]
        [TestCase("SocialPreview.pdf", 1000, null, null)]
        [TestCase("SocialPreview.pdf", 2000, null, null)]
        [TestCase("SocialPreview.pdf", null, 100, null)]
        [TestCase("SocialPreview.pdf", null, 1000, null)]
        [TestCase("SocialPreview.pdf", null, 2000, null)]
        [TestCase("SocialPreview.pdf", 100, 100, null)]
        [TestCase("SocialPreview.pdf", 1000, 1000, null)]
        [TestCase("SocialPreview.pdf", 2000, 2000, null)]
        [TestCase("SocialPreview.pdf", null, null, 96)]
        [TestCase("SocialPreview.pdf", null, null, 300)]
        [TestCase("SocialPreview.pdf", null, null, 600)]
        [TestCase("SocialPreview.pdf", 100, null, 96)]
        [TestCase("SocialPreview.pdf", 100, null, 300)]
        [TestCase("SocialPreview.pdf", 100, null, 1200)]
        [TestCase("SocialPreview.pdf", 1000, null, 96)]
        [TestCase("SocialPreview.pdf", 1000, null, 300)]
        [TestCase("SocialPreview.pdf", 1000, null, 1200)]
        [TestCase("SocialPreview.pdf", 2000, null, 96)]
        [TestCase("SocialPreview.pdf", 2000, null, 300)]
        [TestCase("SocialPreview.pdf", 2000, null, 1200)]
        [TestCase("SocialPreview.pdf", null, 100, 96)]
        [TestCase("SocialPreview.pdf", null, 100, 300)]
        [TestCase("SocialPreview.pdf", null, 100, 1200)]
        [TestCase("SocialPreview.pdf", null, 1000, 96)]
        [TestCase("SocialPreview.pdf", null, 1000, 300)]
        [TestCase("SocialPreview.pdf", null, 1000, 1200)]
        [TestCase("SocialPreview.pdf", null, 2000, 96)]
        [TestCase("SocialPreview.pdf", null, 2000, 300)]
        [TestCase("SocialPreview.pdf", null, 2000, 1200)]
        [TestCase("SocialPreview.pdf", 100, 100, 96)]
        [TestCase("SocialPreview.pdf", 100, 100, 300)]
        [TestCase("SocialPreview.pdf", 100, 100, 1200)]
        [TestCase("SocialPreview.pdf", 1000, 1000, 96)]
        [TestCase("SocialPreview.pdf", 1000, 1000, 300)]
        [TestCase("SocialPreview.pdf", 1000, 1000, 1200)]
        [TestCase("SocialPreview.pdf", 2000, 2000, 96)]
        [TestCase("SocialPreview.pdf", 2000, 2000, 300)]
        [TestCase("SocialPreview.pdf", 2000, 2000, 1200)]

        [TestCase("Wikimedia_Commons_web.pdf")]
        [TestCase("Wikimedia_Commons_web.pdf", 100, null, null)]
        [TestCase("Wikimedia_Commons_web.pdf", 1000, null, null)]
        [TestCase("Wikimedia_Commons_web.pdf", 2000, null, null)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 100, null)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 1000, null)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 2000, null)]
        [TestCase("Wikimedia_Commons_web.pdf", 100, 100, null)]
        [TestCase("Wikimedia_Commons_web.pdf", 1000, 1000, null)]
        [TestCase("Wikimedia_Commons_web.pdf", 2000, 2000, null)]
        [TestCase("Wikimedia_Commons_web.pdf", null, null, 96)]
        [TestCase("Wikimedia_Commons_web.pdf", null, null, 300)]
        [TestCase("Wikimedia_Commons_web.pdf", null, null, 600)]
        [TestCase("Wikimedia_Commons_web.pdf", 100, null, 96)]
        [TestCase("Wikimedia_Commons_web.pdf", 100, null, 300)]
        [TestCase("Wikimedia_Commons_web.pdf", 100, null, 1200)]
        [TestCase("Wikimedia_Commons_web.pdf", 1000, null, 96)]
        [TestCase("Wikimedia_Commons_web.pdf", 1000, null, 300)]
        [TestCase("Wikimedia_Commons_web.pdf", 1000, null, 1200)]
        [TestCase("Wikimedia_Commons_web.pdf", 2000, null, 96)]
        [TestCase("Wikimedia_Commons_web.pdf", 2000, null, 300)]
        [TestCase("Wikimedia_Commons_web.pdf", 2000, null, 1200)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 100, 96)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 100, 300)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 100, 1200)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 1000, 96)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 1000, 300)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 1000, 1200)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 2000, 96)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 2000, 300)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 2000, 1200)]
        [TestCase("Wikimedia_Commons_web.pdf", 100, 100, 96)]
        [TestCase("Wikimedia_Commons_web.pdf", 100, 100, 300)]
        [TestCase("Wikimedia_Commons_web.pdf", 100, 100, 1200)]
        [TestCase("Wikimedia_Commons_web.pdf", 1000, 1000, 96)]
        [TestCase("Wikimedia_Commons_web.pdf", 1000, 1000, 300)]
        [TestCase("Wikimedia_Commons_web.pdf", 1000, 1000, 1200)]
        [TestCase("Wikimedia_Commons_web.pdf", 2000, 2000, 96)]
        [TestCase("Wikimedia_Commons_web.pdf", 2000, 2000, 300)]
        [TestCase("Wikimedia_Commons_web.pdf", 2000, 2000, 1200)]
        public void WithoutAspectRatio(string fileName, int? width = null, int? height = null, int? dpi = null)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "AspectRatio", GetExpectedFilename(fileName, "jpg", width, height, dpi, false));

            using var inputStream = GetInputStream(Path.Combine("Assets", fileName));
            using var outputStream = CreateOutputStream(expectedPath);

            if (dpi != null)
                SaveJpeg(outputStream, inputStream, width: width, height: height, withAnnotations: true, withFormFill: true, withAspectRatio: false, dpi: dpi.Value);
            else
                SaveJpeg(outputStream, inputStream, width: width, height: height, withAnnotations: true, withFormFill: true, withAspectRatio: false);

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase("hundesteuer-anmeldung.pdf")]
        [TestCase("hundesteuer-anmeldung.pdf", 100, null, null)]
        [TestCase("hundesteuer-anmeldung.pdf", 1000, null, null)]
        [TestCase("hundesteuer-anmeldung.pdf", 2000, null, null)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 100, null)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 1000, null)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 2000, null)]
        [TestCase("hundesteuer-anmeldung.pdf", 100, 100, null)]
        [TestCase("hundesteuer-anmeldung.pdf", 1000, 1000, null)]
        [TestCase("hundesteuer-anmeldung.pdf", 2000, 2000, null)]
        [TestCase("hundesteuer-anmeldung.pdf", null, null, 96)]
        [TestCase("hundesteuer-anmeldung.pdf", null, null, 300)]
        [TestCase("hundesteuer-anmeldung.pdf", null, null, 600)]
        [TestCase("hundesteuer-anmeldung.pdf", 100, null, 96)]
        [TestCase("hundesteuer-anmeldung.pdf", 100, null, 300)]
        [TestCase("hundesteuer-anmeldung.pdf", 100, null, 1200)]
        [TestCase("hundesteuer-anmeldung.pdf", 1000, null, 96)]
        [TestCase("hundesteuer-anmeldung.pdf", 1000, null, 300)]
        [TestCase("hundesteuer-anmeldung.pdf", 1000, null, 1200)]
        [TestCase("hundesteuer-anmeldung.pdf", 2000, null, 96)]
        [TestCase("hundesteuer-anmeldung.pdf", 2000, null, 300)]
        [TestCase("hundesteuer-anmeldung.pdf", 2000, null, 1200)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 100, 96)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 100, 300)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 100, 1200)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 1000, 96)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 1000, 300)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 1000, 1200)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 2000, 96)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 2000, 300)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 2000, 1200)]
        [TestCase("hundesteuer-anmeldung.pdf", 100, 100, 96)]
        [TestCase("hundesteuer-anmeldung.pdf", 100, 100, 300)]
        [TestCase("hundesteuer-anmeldung.pdf", 100, 100, 1200)]
        [TestCase("hundesteuer-anmeldung.pdf", 1000, 1000, 96)]
        [TestCase("hundesteuer-anmeldung.pdf", 1000, 1000, 300)]
        [TestCase("hundesteuer-anmeldung.pdf", 1000, 1000, 1200)]
        [TestCase("hundesteuer-anmeldung.pdf", 2000, 2000, 96)]
        [TestCase("hundesteuer-anmeldung.pdf", 2000, 2000, 300)]
        [TestCase("hundesteuer-anmeldung.pdf", 2000, 2000, 1200)]

        [TestCase("SocialPreview.pdf")]
        [TestCase("SocialPreview.pdf", 100, null, null)]
        [TestCase("SocialPreview.pdf", 1000, null, null)]
        [TestCase("SocialPreview.pdf", 2000, null, null)]
        [TestCase("SocialPreview.pdf", null, 100, null)]
        [TestCase("SocialPreview.pdf", null, 1000, null)]
        [TestCase("SocialPreview.pdf", null, 2000, null)]
        [TestCase("SocialPreview.pdf", 100, 100, null)]
        [TestCase("SocialPreview.pdf", 1000, 1000, null)]
        [TestCase("SocialPreview.pdf", 2000, 2000, null)]
        [TestCase("SocialPreview.pdf", null, null, 96)]
        [TestCase("SocialPreview.pdf", null, null, 300)]
        [TestCase("SocialPreview.pdf", null, null, 600)]
        [TestCase("SocialPreview.pdf", 100, null, 96)]
        [TestCase("SocialPreview.pdf", 100, null, 300)]
        [TestCase("SocialPreview.pdf", 100, null, 1200)]
        [TestCase("SocialPreview.pdf", 1000, null, 96)]
        [TestCase("SocialPreview.pdf", 1000, null, 300)]
        [TestCase("SocialPreview.pdf", 1000, null, 1200)]
        [TestCase("SocialPreview.pdf", 2000, null, 96)]
        [TestCase("SocialPreview.pdf", 2000, null, 300)]
        [TestCase("SocialPreview.pdf", 2000, null, 1200)]
        [TestCase("SocialPreview.pdf", null, 100, 96)]
        [TestCase("SocialPreview.pdf", null, 100, 300)]
        [TestCase("SocialPreview.pdf", null, 100, 1200)]
        [TestCase("SocialPreview.pdf", null, 1000, 96)]
        [TestCase("SocialPreview.pdf", null, 1000, 300)]
        [TestCase("SocialPreview.pdf", null, 1000, 1200)]
        [TestCase("SocialPreview.pdf", null, 2000, 96)]
        [TestCase("SocialPreview.pdf", null, 2000, 300)]
        [TestCase("SocialPreview.pdf", null, 2000, 1200)]
        [TestCase("SocialPreview.pdf", 100, 100, 96)]
        [TestCase("SocialPreview.pdf", 100, 100, 300)]
        [TestCase("SocialPreview.pdf", 100, 100, 1200)]
        [TestCase("SocialPreview.pdf", 1000, 1000, 96)]
        [TestCase("SocialPreview.pdf", 1000, 1000, 300)]
        [TestCase("SocialPreview.pdf", 1000, 1000, 1200)]
        [TestCase("SocialPreview.pdf", 2000, 2000, 96)]
        [TestCase("SocialPreview.pdf", 2000, 2000, 300)]
        [TestCase("SocialPreview.pdf", 2000, 2000, 1200)]

        [TestCase("Wikimedia_Commons_web.pdf")]
        [TestCase("Wikimedia_Commons_web.pdf", 100, null, null)]
        [TestCase("Wikimedia_Commons_web.pdf", 1000, null, null)]
        [TestCase("Wikimedia_Commons_web.pdf", 2000, null, null)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 100, null)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 1000, null)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 2000, null)]
        [TestCase("Wikimedia_Commons_web.pdf", 100, 100, null)]
        [TestCase("Wikimedia_Commons_web.pdf", 1000, 1000, null)]
        [TestCase("Wikimedia_Commons_web.pdf", 2000, 2000, null)]
        [TestCase("Wikimedia_Commons_web.pdf", null, null, 96)]
        [TestCase("Wikimedia_Commons_web.pdf", null, null, 300)]
        [TestCase("Wikimedia_Commons_web.pdf", null, null, 600)]
        [TestCase("Wikimedia_Commons_web.pdf", 100, null, 96)]
        [TestCase("Wikimedia_Commons_web.pdf", 100, null, 300)]
        [TestCase("Wikimedia_Commons_web.pdf", 100, null, 1200)]
        [TestCase("Wikimedia_Commons_web.pdf", 1000, null, 96)]
        [TestCase("Wikimedia_Commons_web.pdf", 1000, null, 300)]
        [TestCase("Wikimedia_Commons_web.pdf", 1000, null, 1200)]
        [TestCase("Wikimedia_Commons_web.pdf", 2000, null, 96)]
        [TestCase("Wikimedia_Commons_web.pdf", 2000, null, 300)]
        [TestCase("Wikimedia_Commons_web.pdf", 2000, null, 1200)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 100, 96)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 100, 300)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 100, 1200)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 1000, 96)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 1000, 300)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 1000, 1200)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 2000, 96)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 2000, 300)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 2000, 1200)]
        [TestCase("Wikimedia_Commons_web.pdf", 100, 100, 96)]
        [TestCase("Wikimedia_Commons_web.pdf", 100, 100, 300)]
        [TestCase("Wikimedia_Commons_web.pdf", 100, 100, 1200)]
        [TestCase("Wikimedia_Commons_web.pdf", 1000, 1000, 96)]
        [TestCase("Wikimedia_Commons_web.pdf", 1000, 1000, 300)]
        [TestCase("Wikimedia_Commons_web.pdf", 1000, 1000, 1200)]
        [TestCase("Wikimedia_Commons_web.pdf", 2000, 2000, 96)]
        [TestCase("Wikimedia_Commons_web.pdf", 2000, 2000, 300)]
        [TestCase("Wikimedia_Commons_web.pdf", 2000, 2000, 1200)]
        public void WithAspectRatio(string fileName, int? width = null, int? height = null, int? dpi = null)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "AspectRatio", GetExpectedFilename(fileName, "jpg", width, height, dpi, true));

            using var inputStream = GetInputStream(Path.Combine("Assets", fileName));
            using var outputStream = CreateOutputStream(expectedPath);

            if (dpi != null)
                SaveJpeg(outputStream, inputStream, width: width, height: height, withAnnotations: true, withFormFill: true, withAspectRatio: true, dpi: dpi.Value);
            else
                SaveJpeg(outputStream, inputStream, width: width, height: height, withAnnotations: true, withFormFill: true, withAspectRatio: true);

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase("hundesteuer-anmeldung.pdf", 100, null, false)]
        [TestCase("hundesteuer-anmeldung.pdf", 1000, null, false)]
        [TestCase("hundesteuer-anmeldung.pdf", 2000, null, false)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 100, false)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 1000, false)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 2000, false)]
        [TestCase("hundesteuer-anmeldung.pdf", 100, 100, false)]
        [TestCase("hundesteuer-anmeldung.pdf", 1000, 1000, false)]
        [TestCase("hundesteuer-anmeldung.pdf", 2000, 2000, false)]
        [TestCase("hundesteuer-anmeldung.pdf", 100, null, true)]
        [TestCase("hundesteuer-anmeldung.pdf", 1000, null, true)]
        [TestCase("hundesteuer-anmeldung.pdf", 2000, null, true)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 100, true)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 1000, true)]
        [TestCase("hundesteuer-anmeldung.pdf", null, 2000, true)]
        [TestCase("hundesteuer-anmeldung.pdf", 100, 100, true)]
        [TestCase("hundesteuer-anmeldung.pdf", 1000, 1000, true)]
        [TestCase("hundesteuer-anmeldung.pdf", 2000, 2000, true)]

        [TestCase("SocialPreview.pdf", 100, null, false)]
        [TestCase("SocialPreview.pdf", 1000, null, false)]
        [TestCase("SocialPreview.pdf", 2000, null, false)]
        [TestCase("SocialPreview.pdf", null, 100, false)]
        [TestCase("SocialPreview.pdf", null, 1000, false)]
        [TestCase("SocialPreview.pdf", null, 2000, false)]
        [TestCase("SocialPreview.pdf", 100, 100, false)]
        [TestCase("SocialPreview.pdf", 1000, 1000, false)]
        [TestCase("SocialPreview.pdf", 2000, 2000, false)]
        [TestCase("SocialPreview.pdf", 100, null, true)]
        [TestCase("SocialPreview.pdf", 1000, null, true)]
        [TestCase("SocialPreview.pdf", 2000, null, true)]
        [TestCase("SocialPreview.pdf", null, 100, true)]
        [TestCase("SocialPreview.pdf", null, 1000, true)]
        [TestCase("SocialPreview.pdf", null, 2000, true)]
        [TestCase("SocialPreview.pdf", 100, 100, true)]
        [TestCase("SocialPreview.pdf", 1000, 1000, true)]
        [TestCase("SocialPreview.pdf", 2000, 2000, true)]

        [TestCase("Wikimedia_Commons_web.pdf", 100, null, false)]
        [TestCase("Wikimedia_Commons_web.pdf", 1000, null, false)]
        [TestCase("Wikimedia_Commons_web.pdf", 2000, null, false)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 100, false)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 1000, false)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 2000, false)]
        [TestCase("Wikimedia_Commons_web.pdf", 100, 100, false)]
        [TestCase("Wikimedia_Commons_web.pdf", 1000, 1000, false)]
        [TestCase("Wikimedia_Commons_web.pdf", 2000, 2000, false)]
        [TestCase("Wikimedia_Commons_web.pdf", 100, null, true)]
        [TestCase("Wikimedia_Commons_web.pdf", 1000, null, true)]
        [TestCase("Wikimedia_Commons_web.pdf", 2000, null, true)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 100, true)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 1000, true)]
        [TestCase("Wikimedia_Commons_web.pdf", null, 2000, true)]
        [TestCase("Wikimedia_Commons_web.pdf", 100, 100, true)]
        [TestCase("Wikimedia_Commons_web.pdf", 1000, 1000, true)]
        [TestCase("Wikimedia_Commons_web.pdf", 2000, 2000, true)]
        public void IgnoreDpi(string fileName, int? width = null, int? height = null, bool withAspectRatio = false)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "AspectRatio", GetExpectedFilename(fileName, "jpg", width, height, 300, withAspectRatio));

            using var inputStream = GetInputStream(Path.Combine("Assets", fileName));

            for (int i = 72; i < 600; i += 100)
            {
                using var outputStream = CreateOutputStream(expectedPath);

                ToImage(inputStream, true, dpi: i, width: width, height: height, withAnnotations: true, withFormFill: true, withAspectRatio: withAspectRatio).Encode(outputStream, SkiaSharp.SKEncodedImageFormat.Jpeg, 100);
                CompareStreams(expectedPath, outputStream);
            }
        }

        [Test]
        [TestCase("hundesteuer-anmeldung.pdf", 100, 100)]
        [TestCase("hundesteuer-anmeldung.pdf", 1000, 1000)]
        [TestCase("hundesteuer-anmeldung.pdf", 2000, 2000)]
        [TestCase("SocialPreview.pdf", 100, 100)]
        [TestCase("SocialPreview.pdf", 1000, 1000)]
        [TestCase("SocialPreview.pdf", 2000, 2000)]
        [TestCase("Wikimedia_Commons_web.pdf", 100, 100)]
        [TestCase("Wikimedia_Commons_web.pdf", 1000, 1000)]
        [TestCase("Wikimedia_Commons_web.pdf", 2000, 2000)]
        public void IgnoreAspectRatio(string fileName, int width, int height)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "AspectRatio", GetExpectedFilename(fileName, "jpg", width, height, 300, true));

            using var inputStream = GetInputStream(Path.Combine("Assets", fileName));
            using var outputStream1 = CreateOutputStream(expectedPath);
            using var outputStream2 = CreateOutputStream(expectedPath);

            ToImage(inputStream, true, width: width, height: height, withAnnotations: true, withFormFill: true, withAspectRatio: false).Encode(outputStream1, SkiaSharp.SKEncodedImageFormat.Jpeg, 100);
            ToImage(inputStream, true, width: width, height: height, withAnnotations: true, withFormFill: true, withAspectRatio: true).Encode(outputStream2, SkiaSharp.SKEncodedImageFormat.Jpeg, 100);

            CompareStreams(expectedPath, outputStream1);
            CompareStreams(expectedPath, outputStream2);
        }

        [Test]
        [TestCase("hundesteuer-anmeldung.pdf", 96)]
        [TestCase("hundesteuer-anmeldung.pdf", 300)]
        [TestCase("hundesteuer-anmeldung.pdf", 600)]
        [TestCase("SocialPreview.pdf", 96)]
        [TestCase("SocialPreview.pdf", 300)]
        [TestCase("SocialPreview.pdf", 600)]
        [TestCase("Wikimedia_Commons_web.pdf", 96)]
        [TestCase("Wikimedia_Commons_web.pdf", 300)]
        [TestCase("Wikimedia_Commons_web.pdf", 600)]
        public void IgnoreAspectRatioWithDpi(string fileName, int dpi)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), "AspectRatio", GetExpectedFilename(fileName, "jpg", null, null, dpi, true));

            using var inputStream = GetInputStream(Path.Combine("Assets", fileName));
            using var outputStream1 = CreateOutputStream(expectedPath);
            using var outputStream2 = CreateOutputStream(expectedPath);

            ToImage(inputStream, true, dpi: dpi, withAnnotations: true, withFormFill: true, withAspectRatio: false).Encode(outputStream1, SkiaSharp.SKEncodedImageFormat.Jpeg, 100);
            ToImage(inputStream, true, dpi: dpi, withAnnotations: true, withFormFill: true, withAspectRatio: true).Encode(outputStream2, SkiaSharp.SKEncodedImageFormat.Jpeg, 100);

            CompareStreams(expectedPath, outputStream1);
            CompareStreams(expectedPath, outputStream2);
        }

        private static string GetExpectedFilename(string fileName, string? fileExtension, int? width, int? height, int? dpi, bool withAspectRatio)
            => $"{fileName}_w={width?.ToString() ?? "null"}_h={height?.ToString() ?? "null"}_dpi={dpi?.ToString() ?? "null"}_aspectratio={withAspectRatio}{(fileExtension != null ? $".{fileExtension}" : string.Empty)}";
    }
}