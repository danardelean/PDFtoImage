using NUnit.Framework;
using PDFtoImage.Tests;
using SkiaSharp;
using System;
using System.IO;
using System.Threading.Tasks;
using static PDFtoImage.Conversion;
using static PDFtoImage.Tests.TestUtils;

namespace Tests
{
    [TestFixture]
    public class BatchingTests : TestBase
    {
        [Test]
        [TestCase(null)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(16)]
        [TestCase(17)]
        [TestCase(18)]
        [TestCase(19)]
        public void ToImageWithInteger(int? page)
        {
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), $"Wikimedia_Commons_web_{page ?? 0}.png");

            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            if (page == null)
                SavePng(outputStream, inputStream, options: new(Dpi: 40));
            else
                SavePng(outputStream, inputStream, page: page.Value, options: new(Dpi: 40));

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        public void ToImagesWithSelectionOdd()
        {
            int[] selection = [1, 3, 5, 7, 9, 11, 13, 15, 17, 19];

            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));

            int i = 0;

            foreach (var bitmap in ToImages(inputStream, selection, options: new(Dpi: 40)))
            {
                var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), $"Wikimedia_Commons_web_{selection[i]}.png");
                using var outputStream = CreateOutputStream(expectedPath);
                bitmap.Encode(outputStream, SKEncodedImageFormat.Png, 100);

                CompareStreams(expectedPath, outputStream);
                i++;
            }
        }
#if NET6_0_OR_GREATER
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(16)]
        [TestCase(17)]
        [TestCase(18)]
        [TestCase(19)]
        public void ToImageWithIndex(int page)
        {
            var index = (Index)page;
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), $"Wikimedia_Commons_web_{index.GetOffset(20)}.png");

            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            SavePng(outputStream, inputStream, index, options: new(Dpi: 40));

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(16)]
        [TestCase(17)]
        [TestCase(18)]
        [TestCase(19)]
        public void ToImageWithIndexFromEnd(int page)
        {
            var index = new Index(page + 1, true);
            var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), $"Wikimedia_Commons_web_{index.GetOffset(20)}.png");

            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));
            using var outputStream = CreateOutputStream(expectedPath);

            SavePng(outputStream, inputStream, index, options: new(Dpi: 40));

            CompareStreams(expectedPath, outputStream);
        }

        [Test]
        public void ToImagesWithRangeAll()
        {
            var range = ..;

            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));

            int i = range.Start.Value;

            foreach (var bitmap in ToImages(inputStream, range, options: new(Dpi: 40)))
            {
                var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), $"Wikimedia_Commons_web_{i}.png");
                using var outputStream = CreateOutputStream(expectedPath);
                bitmap.Encode(outputStream, SKEncodedImageFormat.Png, 100);

                CompareStreams(expectedPath, outputStream);
                i++;
            }
        }

        [Test]
        public void ToImagesWithRangeSecondHalf()
        {
            var range = 10..;

            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));

            int i = range.Start.Value;

            foreach (var bitmap in ToImages(inputStream, range, options: new(Dpi: 40)))
            {
                var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), $"Wikimedia_Commons_web_{i}.png");
                using var outputStream = CreateOutputStream(expectedPath);
                bitmap.Encode(outputStream, SKEncodedImageFormat.Png, 100);

                CompareStreams(expectedPath, outputStream);
                i++;
            }
        }

        [Test]
        public void ToImagesWithSelectionEven()
        {
            int[] selection = [0, 2, 4, 6, 8, 10, 12, 14, 16, 18];

            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));

            int i = 0;

            foreach (var bitmap in ToImages(inputStream, selection, options: new(Dpi: 40)))
            {
                var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), $"Wikimedia_Commons_web_{selection[i]}.png");
                using var outputStream = CreateOutputStream(expectedPath);
                bitmap.Encode(outputStream, SKEncodedImageFormat.Png, 100);

                CompareStreams(expectedPath, outputStream);
                i++;
            }
        }

        [Test]
        public async Task ToImagesWithRangeAllAsync()
        {
            var range = ..;

            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));

            int i = range.Start.Value;

            await foreach (var bitmap in ToImagesAsync(inputStream, range, options: new(Dpi: 40)))
            {
                var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), $"Wikimedia_Commons_web_{i}.png");
                using var outputStream = CreateOutputStream(expectedPath);
                bitmap.Encode(outputStream, SKEncodedImageFormat.Png, 100);

                CompareStreams(expectedPath, outputStream);
                i++;
            }
        }

        [Test]
        public async Task ToImagesWithRangeSecondHalfAsync()
        {
            var range = 10..;

            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));

            int i = range.Start.Value;

            await foreach (var bitmap in ToImagesAsync(inputStream, range, options: new(Dpi: 40)))
            {
                var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), $"Wikimedia_Commons_web_{i}.png");
                using var outputStream = CreateOutputStream(expectedPath);
                bitmap.Encode(outputStream, SKEncodedImageFormat.Png, 100);

                CompareStreams(expectedPath, outputStream);
                i++;
            }
        }

        [Test]
        public async Task ToImagesWithSelectionEvenAsync()
        {
            int[] selection = [0, 2, 4, 6, 8, 10, 12, 14, 16, 18];

            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));

            int i = 0;

            await foreach (var bitmap in ToImagesAsync(inputStream, selection, options: new(Dpi: 40)))
            {
                var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), $"Wikimedia_Commons_web_{selection[i]}.png");
                using var outputStream = CreateOutputStream(expectedPath);
                bitmap.Encode(outputStream, SKEncodedImageFormat.Png, 100);

                CompareStreams(expectedPath, outputStream);
                i++;
            }
        }

        [Test]
        public async Task ToImagesWithSelectionOddAsync()
        {
            int[] selection = [1, 3, 5, 7, 9, 11, 13, 15, 17, 19];

            using var inputStream = GetInputStream(Path.Combine("Assets", "Wikimedia_Commons_web.pdf"));

            int i = 0;

            await foreach (var bitmap in ToImagesAsync(inputStream, selection, options: new(Dpi: 40)))
            {
                var expectedPath = Path.Combine("Assets", "Expected", GetPlatformAsString(), $"Wikimedia_Commons_web_{selection[i]}.png");
                using var outputStream = CreateOutputStream(expectedPath);
                bitmap.Encode(outputStream, SKEncodedImageFormat.Png, 100);

                CompareStreams(expectedPath, outputStream);
                i++;
            }
        }
#endif
    }
}