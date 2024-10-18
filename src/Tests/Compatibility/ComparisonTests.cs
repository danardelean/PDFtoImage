using NUnit.Framework;
using PDFtoImage.Tests;
using SkiaSharp;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;
using static PDFtoImage.Compatibility.Conversion;
using static PDFtoImage.Tests.TestUtils;

namespace Tests.Compatibility
{
    [TestFixture]
    public class ComparisonTests : TestBase
    {
        [Test]
        [TestCase(0, TestName = "Page 1")]
        [TestCase(1, TestName = "Page 2")]
        [TestCase(2, TestName = "Page 3")]
        [TestCase(3, TestName = "Page 4")]
        [TestCase(4, TestName = "Page 5")]
        [TestCase(5, TestName = "Page 6")]
        [TestCase(6, TestName = "Page 7")]
        [TestCase(7, TestName = "Page 8")]
        [TestCase(8, TestName = "Page 9")]
        [TestCase(9, TestName = "Page 10")]
        [TestCase(10, TestName = "Page 11")]
        [TestCase(11, TestName = "Page 12")]
        [TestCase(12, TestName = "Page 13")]
        [TestCase(13, TestName = "Page 14")]
        [TestCase(14, TestName = "Page 15")]
        [TestCase(15, TestName = "Page 16")]
        [TestCase(16, TestName = "Page 17")]
        [TestCase(17, TestName = "Page 18")]
        [TestCase(18, TestName = "Page 19")]
        [TestCase(19, TestName = "Page 20")]
        [TestCase(0, true, TestName = "Page 1 (with annotations)")]
        [TestCase(1, true, TestName = "Page 2 (with annotations)")]
        [TestCase(2, true, TestName = "Page 3 (with annotations)")]
        [TestCase(3, true, TestName = "Page 4 (with annotations)")]
        [TestCase(4, true, TestName = "Page 5 (with annotations)")]
        [TestCase(5, true, TestName = "Page 6 (with annotations)")]
        [TestCase(6, true, TestName = "Page 7 (with annotations)")]
        [TestCase(7, true, TestName = "Page 8 (with annotations)")]
        [TestCase(8, true, TestName = "Page 9 (with annotations)")]
        [TestCase(9, true, TestName = "Page 10 (with annotations)")]
        [TestCase(10, true, TestName = "Page 11 (with annotations)")]
        [TestCase(11, true, TestName = "Page 12 (with annotations)")]
        [TestCase(12, true, TestName = "Page 13 (with annotations)")]
        [TestCase(13, true, TestName = "Page 14 (with annotations)")]
        [TestCase(14, true, TestName = "Page 15 (with annotations)")]
        [TestCase(15, true, TestName = "Page 16 (with annotations)")]
        [TestCase(16, true, TestName = "Page 17 (with annotations)")]
        [TestCase(17, true, TestName = "Page 18 (with annotations)")]
        [TestCase(18, true, TestName = "Page 19 (with annotations)")]
        [TestCase(19, true, TestName = "Page 20 (with annotations)")]
        public void SaveWebpPageNumber(int page, bool withAnnotations = false)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), $"Wikimedia_Commons_web_{page}{(withAnnotations ? "_ANNOT" : string.Empty)}.webp");

            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            SaveWebp(outputStream, inputStream, page: page, dpi: 40, withAnnotations: withAnnotations);

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase(false, TestName = "Without annotations")]
        [TestCase(true, TestName = "With annotations")]
        public void SaveWebpPages(bool withAnnotations = false)
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));

            int page = 0;

            foreach (var image in ToImages(inputStream, dpi: 40, withAnnotations: withAnnotations))
            {
                var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), $"Wikimedia_Commons_web_{page}{(withAnnotations ? "_ANNOT" : string.Empty)}.webp");

                using var outputStream = CreateOutputStream(expectedPath);
                image.Encode(outputStream, SKEncodedImageFormat.Webp, 100);

                CompareStreams(expectedPath, outputStream);

                page++;
            }
        }

#if NET6_0_OR_GREATER
        [Test]
        [TestCase(false, TestName = "Without annotations")]
        [TestCase(true, TestName = "With annotations")]
        public async Task SaveWebpPagesAsync(bool withAnnotations = false)
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));

            int page = 0;

            await foreach (var image in ToImagesAsync(inputStream, dpi: 40, withAnnotations: withAnnotations))
            {
                var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), $"Wikimedia_Commons_web_{page}{(withAnnotations ? "_ANNOT" : string.Empty)}.webp");

                using var outputStream = CreateOutputStream(expectedPath);
                image.Encode(outputStream, SKEncodedImageFormat.Webp, 100);

                CompareStreams(expectedPath, outputStream);

                page++;
            }
        }
#endif

        [Test]
        [TestCase(0, TestName = "Page 1")]
        [TestCase(1, TestName = "Page 2")]
        [TestCase(2, TestName = "Page 3")]
        [TestCase(3, TestName = "Page 4")]
        [TestCase(4, TestName = "Page 5")]
        [TestCase(5, TestName = "Page 6")]
        [TestCase(6, TestName = "Page 7")]
        [TestCase(7, TestName = "Page 8")]
        [TestCase(8, TestName = "Page 9")]
        [TestCase(9, TestName = "Page 10")]
        [TestCase(10, TestName = "Page 11")]
        [TestCase(11, TestName = "Page 12")]
        [TestCase(12, TestName = "Page 13")]
        [TestCase(13, TestName = "Page 14")]
        [TestCase(14, TestName = "Page 15")]
        [TestCase(15, TestName = "Page 16")]
        [TestCase(16, TestName = "Page 17")]
        [TestCase(17, TestName = "Page 18")]
        [TestCase(18, TestName = "Page 19")]
        [TestCase(19, TestName = "Page 20")]
        [TestCase(0, true, TestName = "Page 1 (with annotations)")]
        [TestCase(1, true, TestName = "Page 2 (with annotations)")]
        [TestCase(2, true, TestName = "Page 3 (with annotations)")]
        [TestCase(3, true, TestName = "Page 4 (with annotations)")]
        [TestCase(4, true, TestName = "Page 5 (with annotations)")]
        [TestCase(5, true, TestName = "Page 6 (with annotations)")]
        [TestCase(6, true, TestName = "Page 7 (with annotations)")]
        [TestCase(7, true, TestName = "Page 8 (with annotations)")]
        [TestCase(8, true, TestName = "Page 9 (with annotations)")]
        [TestCase(9, true, TestName = "Page 10 (with annotations)")]
        [TestCase(10, true, TestName = "Page 11 (with annotations)")]
        [TestCase(11, true, TestName = "Page 12 (with annotations)")]
        [TestCase(12, true, TestName = "Page 13 (with annotations)")]
        [TestCase(13, true, TestName = "Page 14 (with annotations)")]
        [TestCase(14, true, TestName = "Page 15 (with annotations)")]
        [TestCase(15, true, TestName = "Page 16 (with annotations)")]
        [TestCase(16, true, TestName = "Page 17 (with annotations)")]
        [TestCase(17, true, TestName = "Page 18 (with annotations)")]
        [TestCase(18, true, TestName = "Page 19 (with annotations)")]
        [TestCase(19, true, TestName = "Page 20 (with annotations)")]
        public void SavePngPageNumber(int page, bool withAnnotations = false)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), $"Wikimedia_Commons_web_{page}{(withAnnotations ? "_ANNOT" : string.Empty)}.png");

            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            SavePng(outputStream, inputStream, page: page, dpi: 40, withAnnotations: withAnnotations);

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase(false, TestName = "Without annotations")]
        [TestCase(true, TestName = "With annotations")]
        public void SavePngPages(bool withAnnotations = false)
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));

            int page = 0;

            foreach (var image in ToImages(inputStream, dpi: 40, withAnnotations: withAnnotations))
            {
                var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), $"Wikimedia_Commons_web_{page}{(withAnnotations ? "_ANNOT" : string.Empty)}.png");

                using var outputStream = CreateOutputStream(expectedPath);
                image.Encode(outputStream, SKEncodedImageFormat.Png, 100);

                CompareStreams(expectedPath, outputStream);

                page++;
            }
        }

#if NET6_0_OR_GREATER
        [Test]
        [TestCase(false, TestName = "Without annotations")]
        [TestCase(true, TestName = "With annotations")]
        public async Task SavePngPagesAsync(bool withAnnotations = false)
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));

            int page = 0;

            await foreach (var image in ToImagesAsync(inputStream, dpi: 40, withAnnotations: withAnnotations))
            {
                var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), $"Wikimedia_Commons_web_{page}{(withAnnotations ? "_ANNOT" : string.Empty)}.png");

                using var outputStream = CreateOutputStream(expectedPath);
                image.Encode(outputStream, SKEncodedImageFormat.Png, 100);

                CompareStreams(expectedPath, outputStream);

                page++;
            }
        }
#endif

        [Test]
        [TestCase(0, TestName = "Page 1")]
        [TestCase(1, TestName = "Page 2")]
        [TestCase(2, TestName = "Page 3")]
        [TestCase(3, TestName = "Page 4")]
        [TestCase(4, TestName = "Page 5")]
        [TestCase(5, TestName = "Page 6")]
        [TestCase(6, TestName = "Page 7")]
        [TestCase(7, TestName = "Page 8")]
        [TestCase(8, TestName = "Page 9")]
        [TestCase(9, TestName = "Page 10")]
        [TestCase(10, TestName = "Page 11")]
        [TestCase(11, TestName = "Page 12")]
        [TestCase(12, TestName = "Page 13")]
        [TestCase(13, TestName = "Page 14")]
        [TestCase(14, TestName = "Page 15")]
        [TestCase(15, TestName = "Page 16")]
        [TestCase(16, TestName = "Page 17")]
        [TestCase(17, TestName = "Page 18")]
        [TestCase(18, TestName = "Page 19")]
        [TestCase(19, TestName = "Page 20")]
        [TestCase(0, true, TestName = "Page 1 (with annotations)")]
        [TestCase(1, true, TestName = "Page 2 (with annotations)")]
        [TestCase(2, true, TestName = "Page 3 (with annotations)")]
        [TestCase(3, true, TestName = "Page 4 (with annotations)")]
        [TestCase(4, true, TestName = "Page 5 (with annotations)")]
        [TestCase(5, true, TestName = "Page 6 (with annotations)")]
        [TestCase(6, true, TestName = "Page 7 (with annotations)")]
        [TestCase(7, true, TestName = "Page 8 (with annotations)")]
        [TestCase(8, true, TestName = "Page 9 (with annotations)")]
        [TestCase(9, true, TestName = "Page 10 (with annotations)")]
        [TestCase(10, true, TestName = "Page 11 (with annotations)")]
        [TestCase(11, true, TestName = "Page 12 (with annotations)")]
        [TestCase(12, true, TestName = "Page 13 (with annotations)")]
        [TestCase(13, true, TestName = "Page 14 (with annotations)")]
        [TestCase(14, true, TestName = "Page 15 (with annotations)")]
        [TestCase(15, true, TestName = "Page 16 (with annotations)")]
        [TestCase(16, true, TestName = "Page 17 (with annotations)")]
        [TestCase(17, true, TestName = "Page 18 (with annotations)")]
        [TestCase(18, true, TestName = "Page 19 (with annotations)")]
        [TestCase(19, true, TestName = "Page 20 (with annotations)")]
        public void SaveJpegPageNumber(int page, bool withAnnotations = false)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), $"Wikimedia_Commons_web_{page}{(withAnnotations ? "_ANNOT" : string.Empty)}.jpg");

            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            SaveJpeg(outputStream, inputStream, page: page, dpi: 40, withAnnotations: withAnnotations);

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase(false, TestName = "Without annotations")]
        [TestCase(true, TestName = "With annotations")]
        public void SaveJpegPages(bool withAnnotations = false)
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));

            int page = 0;

            foreach (var image in ToImages(inputStream, dpi: 40, withAnnotations: withAnnotations))
            {
                var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), $"Wikimedia_Commons_web_{page}{(withAnnotations ? "_ANNOT" : string.Empty)}.jpg");

                using var outputStream = CreateOutputStream(expectedPath);
                image.Encode(outputStream, SKEncodedImageFormat.Jpeg, 100);

                CompareStreams(expectedPath, outputStream);

                page++;
            }
        }

#if NET6_0_OR_GREATER
        [Test]
        [TestCase(false, TestName = "Without annotations")]
        [TestCase(true, TestName = "With annotations")]
        public async Task SaveJpegPagesAsync(bool withAnnotations = false)
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));

            int page = 0;

            await foreach (var image in ToImagesAsync(inputStream, dpi: 40, withAnnotations: withAnnotations))
            {
                var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), $"Wikimedia_Commons_web_{page}{(withAnnotations ? "_ANNOT" : string.Empty)}.jpg");

                using var outputStream = CreateOutputStream(expectedPath);
                image.Encode(outputStream, SKEncodedImageFormat.Jpeg, 100);

                CompareStreams(expectedPath, outputStream);

                page++;
            }
        }
#endif

        [Test]
        [TestCase(10, TestName = "10 DPI")]
        [TestCase(30, TestName = "30 DPI")]
        [TestCase(100, TestName = "100 DPI")]
        [TestCase(300, TestName = "300 DPI")]
        [TestCase(600, TestName = "600 DPI")]
        [TestCase(1200, TestName = "1200 DPI")]
        [TestCase(10, true, TestName = "10 DPI (with annotations)")]
        [TestCase(30, true, TestName = "30 DPI (with annotations)")]
        [TestCase(100, true, TestName = "100 DPI (with annotations)")]
        [TestCase(300, true, TestName = "300 DPI (with annotations)")]
        [TestCase(600, true, TestName = "600 DPI (with annotations)")]
        [TestCase(1200, true, TestName = "1200 DPI (with annotations)")]
        public void SavePngDpi(int dpi, bool withAnnotations = false)
        {
            using var pdfStream = GetInputStream(Path.Combine("Assets", "SocialPreview.pdf"));
            using var image = ToImage(pdfStream, dpi: dpi, withAnnotations: withAnnotations);

            using var pdfStream2 = GetInputStream(Path.Combine("Assets", "SocialPreview.pdf"));
            using var image2 = ToImage(pdfStream2, dpi: 300, withAnnotations: withAnnotations);

            ClassicAssert.IsNotNull(image);
            ClassicAssert.IsTrue(Math.Abs(image.Width - image2.Width * (dpi / 300.0)) < 3);
            ClassicAssert.IsTrue(Math.Abs(image.Height - image2.Height * (dpi / 300.0)) < 3);
        }

        [Test]
        [TestCase(10, TestName = "10 DPI")]
        [TestCase(30, TestName = "30 DPI")]
        [TestCase(100, TestName = "100 DPI")]
        [TestCase(300, TestName = "300 DPI")]
        [TestCase(600, TestName = "600 DPI")]
        [TestCase(1200, TestName = "1200 DPI")]
        [TestCase(10, true, TestName = "10 DPI (with annotations)")]
        [TestCase(30, true, TestName = "30 DPI (with annotations)")]
        [TestCase(100, true, TestName = "100 DPI (with annotations)")]
        [TestCase(300, true, TestName = "300 DPI (with annotations)")]
        [TestCase(600, true, TestName = "600 DPI (with annotations)")]
        [TestCase(1200, true, TestName = "1200 DPI (with annotations)")]
        public void SavePngDpiImages(int dpi, bool withAnnotations = false)
        {
            using var pdfStream = GetInputStream(Path.Combine("Assets", "SocialPreview.pdf"));
            using var image = ToImages(pdfStream, dpi: dpi, withAnnotations: withAnnotations).Single();

            using var pdfStream2 = GetInputStream(Path.Combine("Assets", "SocialPreview.pdf"));
            using var image2 = ToImages(pdfStream2, dpi: 300, withAnnotations: withAnnotations).Single();

            ClassicAssert.IsNotNull(image);
            ClassicAssert.IsTrue(Math.Abs(image.Width - image2.Width * (dpi / 300.0)) < 3);
            ClassicAssert.IsTrue(Math.Abs(image.Height - image2.Height * (dpi / 300.0)) < 3);
        }

#if NET6_0_OR_GREATER
        [Test]
        [TestCase(10, TestName = "10 DPI")]
        [TestCase(30, TestName = "30 DPI")]
        [TestCase(100, TestName = "100 DPI")]
        [TestCase(300, TestName = "300 DPI")]
        [TestCase(600, TestName = "600 DPI")]
        [TestCase(1200, TestName = "1200 DPI")]
        [TestCase(10, true, TestName = "10 DPI (with annotations)")]
        [TestCase(30, true, TestName = "30 DPI (with annotations)")]
        [TestCase(100, true, TestName = "100 DPI (with annotations)")]
        [TestCase(300, true, TestName = "300 DPI (with annotations)")]
        [TestCase(600, true, TestName = "600 DPI (with annotations)")]
        [TestCase(1200, true, TestName = "1200 DPI (with annotations)")]
        public async Task SavePngDpiImagesAsync(int dpi, bool withAnnotations = false)
        {
            using var pdfStream = GetInputStream(Path.Combine("Assets", "SocialPreview.pdf"));

            await foreach (var image in ToImagesAsync(pdfStream, dpi: dpi, withAnnotations: withAnnotations))
            {
                ClassicAssert.IsNotNull(image);
            }
        }
#endif

#if NET6_0_OR_GREATER
        [Test]
        [TestCase("SocialPreview.pdf")]
        [TestCase("hundesteuer-anmeldung.pdf")]
        [TestCase("Wikimedia_Commons_web.pdf")]
        public async Task ToImagesAsyncTaskCanceledException(string pdfFileName)
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", pdfFileName));
            var token = new CancellationTokenSource();
            
            Assert.ThrowsAsync<TaskCanceledException>(async () =>
            {
                token.Cancel();

                await foreach (var image in ToImagesAsync(inputStream, dpi: 1200, cancellationToken: token.Token))
                {
                }
            });
        }

        [Test]
        [TestCase("SocialPreview.pdf")]
        [TestCase("hundesteuer-anmeldung.pdf")]
        [TestCase("Wikimedia_Commons_web.pdf")]
        public async Task ToImagesAsyncOperationCanceledException(string pdfFileName)
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", pdfFileName));
            var token = new CancellationTokenSource();
            var pageCount = PDFtoImage.Conversion.GetPageCount(inputStream);

            using var inputStream2 = GetInputStream(Path.Combine("Assets", pdfFileName));

            if (pageCount < 2)
            {
                // no OperationCanceledException should be thrown if there are not multiple pages to iterate through
                await foreach (var image in ToImagesAsync(inputStream2, dpi: 1200, cancellationToken: token.Token))
                {
                    token.Cancel();
                }

                return;
            }
            Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await foreach (var image in ToImagesAsync(inputStream2, dpi: 1200, cancellationToken: token.Token))
                {
                    token.Cancel();
                }
            });
        }
#endif
    }
}