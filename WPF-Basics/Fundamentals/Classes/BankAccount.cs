using Fundamentals.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals.Classes
{
    /// <summary>
    /// Classe de para funções de 
    /// </summary>
    internal class BankAccount : IInformation
    {
        //Atributos
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

        //Construtores
        public BankAccount() { }

        public BankAccount(double initialBalance)
        {
            Balance = initialBalance;
        }

        //Método de interface
        public string GetInformation()
        {
            return $"Seu saldo atual é de: {Balance:c}";
        }

        //Método de classe
        public virtual double AddToBalance(double amount)
        {
            Balance += amount;
            Console.WriteLine($"Valor adicionado: R${amount}");
            return Balance;
        }

    }

    /// <summary>
    /// Classe herdeira
    /// </summary>
    internal class ChildBankAccount : BankAccount
    {
        public ChildBankAccount()
        {
            Balance = 100;
        }

        public override double AddToBalance(double amount)
        {
            if (amount > 1000)
            {
                Console.WriteLine("Transações limitadas a R$1000!");
                amount = 1000;
            }
            return base.AddToBalance(amount);
        }
    }
}

