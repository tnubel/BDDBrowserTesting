using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBehave.Narrator.Framework;

namespace BrowserTests
{
    [TestClass]
    public class BrowserTests
    {
        [TestMethod]
        public void RunTestFeature()
        {
            @"tests/test.feature".ExecuteFile();
        }
    }
}
