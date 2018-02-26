using Infrastructure.QryHandlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class HelloWorldQryHandlerTest
    {
        [TestMethod]
        public void TestHandleMethod()
        {
            var expectedStr = "Hello World";
            uint expectedRepeats = 1;
            var qry = new HelloWorldQryHandler();
            var data = qry.Handle();
            Assert.AreEqual<string>(expectedStr, data.PrintText);
            Assert.AreEqual<uint>(expectedRepeats, data.Repeats);
        }
    }
}