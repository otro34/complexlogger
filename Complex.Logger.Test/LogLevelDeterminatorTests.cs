
using System.Collections.Generic;
using Complex.Logger.Impl;
using Complex.Logger.Interface;
using Complex.Logger.Model;
using Moq;
using NUnit.Framework;

namespace Complex.Logger.Test
{
    [TestFixture]
    public class LogLevelDeterminatorTests
    {
        private Mock<ISettingsExtractor> _mockStub;
        private LogLevelDeterminator _sut;

        [Test]
        public void Determinator_WithInfo_Success()
        {
            _mockStub = new Mock<ISettingsExtractor>();
            _mockStub.Setup(x => x.GetList(It.IsAny<string>())).Returns(new List<string>() {"Info", "Error", "Warning"});
            _sut = new LogLevelDeterminator(_mockStub.Object);
            var result = _sut.AcceptedLogLevel(LogLevel.Info);
            Assert.AreEqual(true,result);
        }

        [Test]
        public void Determinator_WithInfo_Failure()
        {
            _mockStub = new Mock<ISettingsExtractor>();
            _mockStub.Setup(x => x.GetList(It.IsAny<string>())).Returns(new List<string>() {"Error", "Warning" });
            _sut = new LogLevelDeterminator(_mockStub.Object);
            var result = _sut.AcceptedLogLevel(LogLevel.Info);
            Assert.AreEqual(false, result);
        }
    }
}
