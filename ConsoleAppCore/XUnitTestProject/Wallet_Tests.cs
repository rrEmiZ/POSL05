using ConsoleAppCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject
{
    public class Wallet_Tests
    {
        [Fact]
        public void TakeMoney_ForSaldo200Take300_ThrowsEx()
        {
            var wallet = new Wallet(200);

            Assert.Throws<InvalidOperationException>(() => wallet.TakeMoney(300));
        }

        [Fact]
        public void TakeMoney_ForSaldo300Take200_SaldoIs100()
        {
            var wallet = new Wallet(300);
            double expectedSaldo = 100;

            wallet.TakeMoney(200);

            Assert.Equal(wallet.Saldo, expectedSaldo);
        }
    }
}
