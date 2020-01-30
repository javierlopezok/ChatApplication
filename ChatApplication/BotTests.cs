using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChatApplication
{
    [TestClass]
    public class BotTests
    {
        [TestMethod]
        public void Bot_GetsCorrectInformation()
        {
            var testBot= new TestableBot();
            Assert.AreEqual<string>(" APPL.US quote is 324.42 per share.", testBot.getStock("appl.us"));
        }

        [TestMethod]
        public void Bot_GetsWrongInformation()
        {
            var testBot = new TestableBot();
            Assert.AreEqual<string>(" BAD quote is N/D per share.", testBot.getStock("BAD"));
        }

    }

}