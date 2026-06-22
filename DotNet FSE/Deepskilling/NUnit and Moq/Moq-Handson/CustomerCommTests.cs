using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerComm.Tests
{
    // TestFixture marks the class for NUnit testing
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mockMailSender;
        private CustomerCommLib.CustomerComm _customerComm;

        // OneTimeSetUp runs once before any of the tests in this class start
        [OneTimeSetUp]
        public void Init()
        {
            // 1. Initialize the mock object
            _mockMailSender = new Mock<IMailSender>();

            // 2. Configure the mock object so that SendMail() will accept ANY string arguments 
            // and ALWAYS return true (as per assignment instructions)
            _mockMailSender.Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            // 3. Inject the mocked object into the CustomerComm class via Constructor Injection
            _customerComm = new CustomerCommLib.CustomerComm(_mockMailSender.Object);
        }

        // TestCase attribute marks the actual test method
        [TestCase]
        public void SendMailToCustomer_WhenInvoked_ReturnsTrue()
        {
            // Act
            bool result = _customerComm.SendMailToCustomer();

            // Assert - verifying the return value is true
            Assert.That(result, Is.True);
            
            // Optional Professional Verification: 
            // Ensure the mocked SendMail method was actually called exactly once during the test
            _mockMailSender.Verify(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
