using ConsoleApp1;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using NUnit.Framework.Constraints;
namespace TestProject2
{
	public class Tests
	{
		public List<TimeData> testData = new List<TimeData>();
		public TimeData inputPrevious;




		[SetUp]
		public void Setup() {						  
		    testData.Add(new TimeData("1617660020: 0"));
			testData.Add(new TimeData("1617660025: 0"));
			testData.Add(new TimeData("1617660023: 0"));
			testData.Add(new TimeData("1617660018: 0"));
			testData.Add(new TimeData("1617660324: 1"));
			testData.Add(new TimeData("1617660330: 1"));
			testData.Add(new TimeData("1617660337: 1"));
			testData.Add(new TimeData("1617660342: 1"));
			
			inputPrevious = testData.First();
			testData.OrderBy(x => x.Timestamp).ToList();

		}

		[Test]
		public void PrintInputPairs_CountChanges()
		{
			var loggerMock = new Mock<ILogger>();
			var sut = new Input(loggerMock.Object);
			var result = sut.PrintInputPairs(testData, inputPrevious);
			loggerMock.Verify(logger => logger.Log(It.IsAny<string>()), Times.Once());
			Assert.That(result, Is.EqualTo(1));
			Assert.Pass();
		}

	}
}