using System;
using System.Collections.Generic;
using System.Text;

namespace PODuSl01
{
    public class Walet
    {
        private decimal _saldo;

        public decimal Saldo
        {
            get { return _saldo; }
        }

        public Walet(decimal saldo)
        {
            _saldo = saldo;
        }

        public void TakeMoney(decimal value)
        {
            if(_saldo - value < 0)
            {
                throw new InvalidOperationException("Nie można wyplacic wiecej niz mamy");
            }

            _saldo -= value;                 
        }
    }
}
