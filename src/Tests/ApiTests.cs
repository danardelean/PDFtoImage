using NUnit.Framework;
using PDFtoImage.Tests;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;
using static PDFtoImage.Conversion;
using static PDFtoImage.Tests.TestUtils;

namespace Tests
{
    [TestFixture]
    public class ApiTests : TestBase
    {
        [Test]
        public void SaveWebpStringNullException()
        {
            Assert.Throws<ArgumentNullException>(() => SaveWebp((string)null!, (string)null!));
        }

        [Test]
        public void SaveWebpStreamNullException()
        {
            Assert.Throws<ArgumentNullException>(() => SaveWebp((Stream)null!, (string)null!));
        }

        [Test]
        public void SavePngStringNullException()
        {
            Assert.Throws<ArgumentNullException>(() => SavePng((string)null!, (string)null!));
        }

        [Test]
        public void SavePngStreamNullException()
        {
            Assert.Throws<ArgumentNullException>(() => SavePng((Stream)null!, (string)null!));
        }

        [Test]
        public void SaveJpegStringNullException()
        {
            Assert.Throws<ArgumentNullException>(() => SaveJpeg((string)null!, (string)null!));
        }

        [Test]
        public void SaveJpegStreamNullException()
        {
            Assert.Throws<ArgumentNullException>(() => SaveJpeg((Stream)null!, (string)null!));
        }

        [Test]
        public void ToImagePdfStringNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ToImage((string)null!));
        }

        [Test]
        public void ToImagePdfArrayNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ToImage((byte[])null!));
        }

        [Test]
        public void ToImagePdfStreamNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ToImage((Stream)null!));
        }

        [Test]
        public void GetPageCountPdfStringNullException()
        {
            Assert.Throws<ArgumentNullException>(() => GetPageCount((string)null!));
        }

        [Test]
        public void GetPageCountPdfArrayNullException()
        {
            Assert.Throws<ArgumentNullException>(() => GetPageCount((byte[])null!));
        }

        [Test]
        public void GetPageCountPdfStreamNullException()
        {
            Assert.Throws<ArgumentNullException>(() => GetPageCount((Stream)null!));
        }

        [Test]
        public void GetPageSizePdfStringNullException()
        {
            Assert.Throws<ArgumentNullException>(() => GetPageSize((string)null!, 0));
        }

        [Test]
        public void GetPageSizePdfArrayNullException()
        {
            Assert.Throws<ArgumentNullException>(() => GetPageSize((byte[])null!, 0));
        }

        [Test]
        public void GetPageSizePdfStreamNullException()
        {
            Assert.Throws<ArgumentNullException>(() => GetPageSize((Stream)null!, page: 0));
        }

        [Test]
        public void GetPageSizesPdfStringNullException()
        {
            Assert.Throws<ArgumentNullException>(() => GetPageSizes((string)null!));
        }

        [Test]
        public void GetPageSizesPdfArrayNullException()
        {
            Assert.Throws<ArgumentNullException>(() => GetPageSizes((byte[])null!));
        }

        [Test]
        public void GetPageSizesPdfStreamNullException()
        {
            Assert.Throws<ArgumentNullException>(() => GetPageSizes((Stream)null!));
        }

        [Test]
        public void ToImagesPdfStringNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ToImages((string)null!).ToList());
        }

        [Test]
        public void ToImagesPdfArrayNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ToImages((byte[])null!).ToList());
        }

        [Test]
        public void ToImagesPdfStreamNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ToImages((Stream)null!).ToList());
        }

#if NET6_0_OR_GREATER
        [Test]
        public void ToImagesAsyncPdfStringNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await foreach (var page in ToImagesAsync((string)null!))
                {
                }
            });
        }

        [Test]
        public void ToImagesAsyncPdfArrayNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await foreach (var page in ToImagesAsync((byte[])null!))
                {
                }
            });
        }

        [Test]
        public void ToImagesAsyncPdfStreamNullException()
        {
           Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await foreach (var page in ToImagesAsync((Stream)null!))
                {
                }
            });
        }
#endif

        [Test]
        public void ToImageStreamLeaveOpenDefault()
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "SocialPreview.pdf"));
            ClassicAssert.IsTrue(inputStream.CanRead);

            ToImage(inputStream);
            ClassicAssert.IsFalse(inputStream.CanRead, "The stream should be closed when calling the default overload.");
        }

        [Test]
        public void ToImageStreamLeaveOpenFalse()
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "SocialPreview.pdf"));
            ClassicAssert.IsTrue(inputStream.CanRead);

            ToImage(inputStream, false);
            ClassicAssert.IsFalse(inputStream.CanRead, "The stream should be closed when calling leaveOpen with false.");
        }

        [Test]
        public void ToImageStreamLeaveOpenTrue()
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "SocialPreview.pdf"));
            ClassicAssert.IsTrue(inputStream.CanRead);

            ToImage(inputStream, true);
            ClassicAssert.IsTrue(inputStream.CanRead, "The stream should be open when calling leaveOpen with true.");
        }

        [Test]
        public void ToImagesStreamLeaveOpenDefault()
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "SocialPreview.pdf"));
            ClassicAssert.IsTrue(inputStream.CanRead);

            var result = ToImages(inputStream);
            ClassicAssert.IsTrue(inputStream.CanRead, "The stream should be open as long as the iterator is not used yet.");

            foreach (var _ in result) ;
            ClassicAssert.IsFalse(inputStream.CanRead, "The stream should be closed when calling the default overload.");
        }

        [Test]
        public void ToImagesStreamLeaveOpenFalse()
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "SocialPreview.pdf"));
            ClassicAssert.IsTrue(inputStream.CanRead);

            var result = ToImages(inputStream, false);
            ClassicAssert.IsTrue(inputStream.CanRead, "The stream should be open as long as the iterator is not used yet.");

            foreach (var _ in result) ;
            ClassicAssert.IsFalse(inputStream.CanRead, "The stream should be closed when calling leaveOpen with false.");
        }

        [Test]
        public void ToImagesStreamLeaveOpenTrue()
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "SocialPreview.pdf"));
            ClassicAssert.IsTrue(inputStream.CanRead);

            var result = ToImages(inputStream, true);
            ClassicAssert.IsTrue(inputStream.CanRead, "The stream should be open as long as the iterator is not used yet.");

            foreach (var _ in result) ;
            ClassicAssert.IsTrue(inputStream.CanRead, "The stream should be open when calling leaveOpen with true.");
        }

#if NET6_0_OR_GREATER
        [Test]
        public async Task ToImagesAsyncStreamLeaveOpenDefault()
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "SocialPreview.pdf"));
            ClassicAssert.IsTrue(inputStream.CanRead);

            var result = ToImagesAsync(inputStream);
            ClassicAssert.IsTrue(inputStream.CanRead, "The stream should be open as long as the iterator is not used yet.");

            await foreach (var _ in result) ;
            ClassicAssert.IsFalse(inputStream.CanRead, "The stream should be closed when calling the default overload.");
        }

        [Test]
        public async Task ToImagesAsyncStreamLeaveOpenFalse()
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "SocialPreview.pdf"));
            ClassicAssert.IsTrue(inputStream.CanRead);

            var result = ToImagesAsync(inputStream, false);
            ClassicAssert.IsTrue(inputStream.CanRead, "The stream should be open as long as the iterator is not used yet.");

            await foreach (var _ in result) ;
            ClassicAssert.IsFalse(inputStream.CanRead, "The stream should be closed when calling leaveOpen with false.");
        }

        [Test]
        public async Task ToImagesAsyncStreamLeaveOpenTrue()
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "SocialPreview.pdf"));
            ClassicAssert.IsTrue(inputStream.CanRead);

            var result = ToImagesAsync(inputStream, true);
            ClassicAssert.IsTrue(inputStream.CanRead, "The stream should be open as long as the iterator is not used yet.");

            await foreach (var _ in result) ;
            ClassicAssert.IsTrue(inputStream.CanRead, "The stream should be open when calling leaveOpen with true.");
        }
#endif

        [Test]
        public void GetPageCountStreamLeaveOpenDefault()
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "SocialPreview.pdf"));
            ClassicAssert.IsTrue(inputStream.CanRead);

            GetPageCount(inputStream);
            ClassicAssert.IsFalse(inputStream.CanRead, "The stream should be closed when calling the default overload.");
        }

        [Test]
        public void GetPageCountStreamLeaveOpenFalse()
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "SocialPreview.pdf"));
            ClassicAssert.IsTrue(inputStream.CanRead);

            GetPageCount(inputStream, false);
            ClassicAssert.IsFalse(inputStream.CanRead, "The stream should be closed when calling leaveOpen with false.");
        }

        [Test]
        public void GetPageCountStreamLeaveOpenTrue()
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "SocialPreview.pdf"));
            ClassicAssert.IsTrue(inputStream.CanRead);

            GetPageCount(inputStream, true);
            ClassicAssert.IsTrue(inputStream.CanRead, "The stream should be open when calling leaveOpen with true.");
        }

        [Test]
        public void GetPageSizeStreamLeaveOpenDefault()
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "SocialPreview.pdf"));
            ClassicAssert.IsTrue(inputStream.CanRead);

            GetPageSize(inputStream, page: 0);
            ClassicAssert.IsFalse(inputStream.CanRead, "The stream should be closed when calling the default overload.");
        }

        [Test]
        public void GetPageSizeStreamLeaveOpenFalse()
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "SocialPreview.pdf"));
            ClassicAssert.IsTrue(inputStream.CanRead);

            GetPageSize(inputStream, false, 0);
            ClassicAssert.IsFalse(inputStream.CanRead, "The stream should be closed when calling leaveOpen with false.");
        }

        [Test]
        public void GetPageSizeStreamLeaveOpenTrue()
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "SocialPreview.pdf"));
            ClassicAssert.IsTrue(inputStream.CanRead);

            GetPageSize(inputStream, true, 0);
            ClassicAssert.IsTrue(inputStream.CanRead, "The stream should be open when calling leaveOpen with true.");
        }

        [Test]
        public void GetPageSizesStreamLeaveOpenDefault()
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "SocialPreview.pdf"));
            ClassicAssert.IsTrue(inputStream.CanRead);

            GetPageSizes(inputStream);
            ClassicAssert.IsFalse(inputStream.CanRead, "The stream should be closed when calling the default overload.");
        }

        [Test]
        public void GetPageSizesStreamLeaveOpenFalse()
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "SocialPreview.pdf"));
            ClassicAssert.IsTrue(inputStream.CanRead);

            GetPageSizes(inputStream, false);
            ClassicAssert.IsFalse(inputStream.CanRead, "The stream should be closed when calling leaveOpen with false.");
        }

        [Test]
        public void GetPageSizesStreamLeaveOpenTrue()
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "SocialPreview.pdf"));
            ClassicAssert.IsTrue(inputStream.CanRead);

            GetPageSizes(inputStream, true);
            ClassicAssert.IsTrue(inputStream.CanRead, "The stream should be open when calling leaveOpen with true.");
        }

        [Test]
        public void StreamMultipleCallsLeaveOpen()
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "SocialPreview.pdf"));
            ClassicAssert.IsTrue(inputStream.CanRead);

            GetPageCount(inputStream, true);
            ClassicAssert.IsTrue(inputStream.CanRead, "The stream should be open when calling leaveOpen with true.");

            GetPageSizes(inputStream, true);
            ClassicAssert.IsTrue(inputStream.CanRead, "The stream should be open when calling leaveOpen with true.");

            var image1 = ToImage(inputStream, true);
            ClassicAssert.IsTrue(inputStream.CanRead, "The stream should be open when calling leaveOpen with true.");

            var image2 = ToImage(inputStream, true);
            ClassicAssert.IsTrue(inputStream.CanRead, "The stream should be open when calling leaveOpen with true.");

            ClassicAssert.IsTrue(image1.ByteCount > 0, "The rendered image should have content.");
            ClassicAssert.AreEqual(image1.ByteCount, image2.ByteCount, "Both images should be equal (in byte size).");

            GetPageSizes(inputStream, false);
            ClassicAssert.IsFalse(inputStream.CanRead, "The stream should be closed when calling leaveOpen with false.");

            Assert.Throws<ObjectDisposedException>(() => GetPageCount(inputStream, false), "The stream should be closed and throw an exception.");
        }
    }
}