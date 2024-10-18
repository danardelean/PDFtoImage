using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using NUnit.Framework.Legacy;

namespace PDFtoImage.Tests
{
#if NET6_0_OR_GREATER
    [SupportedOSPlatform("Windows")]
    [SupportedOSPlatform("Linux")]
    [SupportedOSPlatform("macOS")]
    [SupportedOSPlatform("iOS")]
    [SupportedOSPlatform("Android31.0")]
#endif
    public static class TestUtils
    {
        public static void CompareStreams(string expectedFilePath, Stream outputStream)
        {
            using var expectedStream = GetExpectedStream(expectedFilePath);
            CompareStreams(expectedStream, outputStream);
        }

        public static void CompareStreams(Stream expectedStream, Stream outputStream)
        {
            ClassicAssert.IsNotNull(outputStream);
            ClassicAssert.AreNotEqual(0, outputStream.Length);

            ClassicAssert.AreEqual(expectedStream.Length, outputStream.Length);

            expectedStream.Position = 0;
            outputStream.Position = 0;

            for (int i = 0; i < expectedStream.Length; i++)
            {
                ClassicAssert.AreEqual(expectedStream.ReadByte(), outputStream.ReadByte());
            }
        }

        public static string GetPlatformAsString()
        {
#if NET471_OR_GREATER || NETCOREAPP
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return OSPlatform.Windows.ToString();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return OSPlatform.Linux.ToString();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return OSPlatform.OSX.ToString();
            }
#if NET6_0_OR_GREATER
            else if (OperatingSystem.IsAndroid())
            {
                return "ANDROID";
            }
            else if (OperatingSystem.IsIOS())
            {
                return "IOS";
            }

#endif
       

            throw new PlatformNotSupportedException();
#else
            return Environment.OSVersion.Platform == PlatformID.Win32NT
                ? "WINDOWS"
                : "LINUX";
#endif
        }

        public static Func<string,Stream> GetInputStream = GetInputStreamDefaultImpl;
        
        public static FileStream GetInputStreamDefaultImpl(string filePath)
        {
            filePath = Path.Combine("..", filePath);
            return new FileStream( filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.SequentialScan);
        }

        public static Func<string,FileStream> GetExpectedStream = GetExpectedStreamDefaultImpl;
        public static FileStream GetExpectedStreamDefaultImpl(string filePath)
        {
            filePath = Path.Combine("..", filePath);
            if (!File.Exists(filePath))
                ClassicAssert.Inconclusive($"The expected asset '{filePath}' could not be found." );

            return new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.SequentialScan);
        }

        private static readonly object _lockObject = new();
        
        public static Func<string,Stream> CreateOutputStream = CreateOutputStreamDefaultImpl;
        public static Stream CreateOutputStreamDefaultImpl(string expectedPath)
        {
            expectedPath = Path.Combine("..", expectedPath);
            if (!TestBase.SaveOutputInGeneratedFolder)
                return new MemoryStream();

            var outputPath = expectedPath.Replace("Expected", "Generated");

            lock (_lockObject)
            {
                if (!File.Exists(outputPath))
                {
                    if (!Directory.Exists(outputPath))
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);

                    return new FileStream(
                        outputPath,
                        FileMode.CreateNew,
                        FileAccess.ReadWrite,
                        FileShare.None,
                        4096,
                        FileOptions.SequentialScan);
                }
            }

            return new MemoryStream();
        }
    }
}