using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace UnitTestForTeht2
{
    [TestClass]
    public class UnitTestLotto
    {
        [TestMethod]
        public void TestGetWeek()
        {
            //viittaus oik luokka ja metodi
            JAMK.IT.WinLotto.Lotto lotto = new JAMK.IT.WinLotto.Lotto();
            //kutsutaan testattavaa metodia
            string vk = lotto.GetWeekUnfinished();
            Assert.AreEqual("41/2015", vk);

        }

        [TestMethod]
        public void TestGetWeek2()
        {
            //viittaus oik luokka ja metodi
            JAMK.IT.WinLotto.Lotto lotto = new JAMK.IT.WinLotto.Lotto();
            //kutsutaan testattavaa metodia
            string vk = lotto.GetWeekFixed();
            Assert.AreEqual("41/2015", vk);

        }
    }
}
