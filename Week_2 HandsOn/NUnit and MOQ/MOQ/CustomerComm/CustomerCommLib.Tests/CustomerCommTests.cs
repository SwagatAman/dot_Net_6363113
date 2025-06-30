using Moq;
using NUnit.Framework;
using CustomerCommLib;

namespace CustomerCommLib.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        [Test]
        public void SendMailToCustomer_WhenCalled_InvokesSendMail()
        {
            var mockMailSender = new Mock<IMailSender>();
            mockMailSender
                .Setup(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            var customerComm = new CustomerComm(mockMailSender.Object);
            var result = customerComm.SendMailToCustomer("test@example.com", "Hello World!");

            Assert.IsTrue(result);
            mockMailSender.Verify(x => x.SendMail("test@example.com", "Hello World!"), Times.Once);
        }
    }
}