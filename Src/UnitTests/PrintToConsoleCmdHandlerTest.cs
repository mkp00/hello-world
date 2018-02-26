using System;
using System.IO;
using CoreDetails;
using Infrastructure.CmdHandlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class PrintToConsoleCmdHandlerTest
    {
        [TestInitialize]
        public void InitializeTest()
        {
            StreamWriter standardOut = new StreamWriter(Console.OpenStandardOutput())
            {
                AutoFlush = true
            };
            Console.SetOut(standardOut);
        }

        [TestMethod]
        public void TestWithSingleLine()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                PrintToConsoleCmdHandler h = new PrintToConsoleCmdHandler();
                h.Handle(new PrintToScreenData("Hello World", 0));

                string expected = $"Hello World{Environment.NewLine}";
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }
    }
}
