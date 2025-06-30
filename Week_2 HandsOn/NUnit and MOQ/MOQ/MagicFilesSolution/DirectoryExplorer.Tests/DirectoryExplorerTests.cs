using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using MagicFilesLib;

namespace DirectoryExplorer.Tests
{
    [TestFixture]
    public class DirectoryExplorerTests
    {
        private readonly string _file1 = "file.txt";
        private readonly string _file2 = "file2.txt";
        private Mock<IDirectoryExplorer> _mockDirectoryExplorer;

        [OneTimeSetUp]
        public void Setup()
        {
            _mockDirectoryExplorer = new Mock<IDirectoryExplorer>();
            _mockDirectoryExplorer.Setup(x => x.GetFiles(It.IsAny<string>()))
                .Returns(new List<string> { _file1, _file2 });
        }

        [Test]
        [TestCase("C:\testpath")]
        public void GetFiles_ShouldReturnMockedFiles(string path)
        {
            var result = _mockDirectoryExplorer.Object.GetFiles(path);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.Contains(_file1, (System.Collections.ICollection)result);
        }
    }
}