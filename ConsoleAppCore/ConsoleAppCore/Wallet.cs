using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCore
{
    public class Wallet
    {
        private double _saldo;

        public double Saldo { get => _saldo; }


        public Wallet(double saldo)
        {
            _saldo = saldo;
        }


        public void TakeMoney(double money)
        {
            if((_saldo - money) < 0)
            {
                throw new InvalidOperationException("Nie mozna pobrac wiecej hajsu jak mamy w portfelu");
            }

            _saldo -= money;
        }

    }
}
