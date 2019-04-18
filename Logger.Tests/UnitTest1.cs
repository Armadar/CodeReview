using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Belatrix;
using System.Collections.Generic;

namespace Logger.Tests
{
    [TestClass]
    public class Logger2Tests
    {
        [TestMethod]
        [Owner("JesusAlvino")]
        [TestCategory("SmokeTest")]
        [Priority(4)]
        public void LoggerConsole_checkMessageTypeColor_WarningYellow()
        {
            LoggerConsole lc = new LoggerConsole ();

            lc.Log("Warning", "simple message");

            Assert.IsTrue(lc.ColorResult == ConsoleColor.Yellow);
        }

        [TestMethod]
        [Owner("JesusAlvino")]
        [TestCategory("SmokeTest")]
        [Priority(3)]
        public void Logger_checkLogMode_OnlyErrors()
        {
            // Arrange
            List<JobLogger.LogDestiny> destiny = new List<JobLogger.LogDestiny>();
            destiny.Add(JobLogger.LogDestiny.TextFile);
            JobLogger jl = new JobLogger(destiny, JobLogger.LogMode.OnlyErrors);
            // Act
            bool r = jl.validateLogMode(JobLogger.LogMode.OnlyErrors, JobLogger.LogMessageType.Error);
            // Assert
            Assert.IsTrue(r);
        }
    }
}