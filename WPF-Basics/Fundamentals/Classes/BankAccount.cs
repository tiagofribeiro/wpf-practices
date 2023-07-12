using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals.Classes
{
    internal class BankAccount
    {
        private double _balance;

        public double Balance
        {
            get
            {
                return _balance;
            }
            protected set
            {
                if (value > 0)
                    _balance = value;
            }
        }

        public BankAccount()
        {

        }

        public virtual double AddToBalance(double amount)
        {
            Balance += amount;
            Console.WriteLine($"Valor adicionado: R${amount}");
            return Balance;
        }
    }
    internal class ChildBankAccount : BankAccount
    {
        public ChildBankAccount()
        {
            Balance = 100;
        }

        public override double AddToBalance(double amount)
        {
            if(amount > 1000)
            {
                Console.WriteLine("Transações limitadas a R$1000");
                amount = 1000;
            }
            return base.AddToBalance(amount);
        }
    }
}

