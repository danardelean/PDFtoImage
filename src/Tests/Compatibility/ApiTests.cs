using NUnit.Framework;
using PDFtoImage.Tests;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;
using static PDFtoImage.Compatibility.Conversion;
using static PDFtoImage.Tests.TestUtils;

namespace Tests.Compatibility
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
        public void StreamMultipleCallsLeaveOpen()
        {
            using var inputStream = GetInputStream(Path.Combine("Assets", "SocialPreview.pdf"));
            ClassicAssert.IsTrue(inputStream.CanRead);

            PDFtoImage.Conversion.GetPageCount(inputStream, true);
            ClassicAssert.IsTrue(inputStream.CanRead, "The stream should be open when calling leaveOpen with true.");

            PDFtoImage.Conversion.GetPageSizes(inputStream, true);
            ClassicAssert.IsTrue(inputStream.CanRead, "The stream should be open when calling leaveOpen with true.");

            var image1 = ToImage(inputStream, true);
            ClassicAssert.IsTrue(inputStream.CanRead, "The stream should be open when calling leaveOpen with true.");

            var image2 = ToImage(inputStream, true);
            ClassicAssert.IsTrue(inputStream.CanRead, "The stream should be open when calling leaveOpen with true.");

            ClassicAssert.IsTrue(image1.ByteCount > 0, "The rendered image should have content.");
            ClassicAssert.AreEqual(image1.ByteCount, image2.ByteCount, "Both images should be equal (in byte size).");

            PDFtoImage.Conversion.GetPageSizes(inputStream, false);
            ClassicAssert.IsFalse(inputStream.CanRead, "The stream should be closed when calling leaveOpen with false.");

            Assert.Throws<ObjectDisposedException>(() => PDFtoImage.Conversion.GetPageCount(inputStream, false), "The stream should be closed and throw an exception.");
        }
    }
}