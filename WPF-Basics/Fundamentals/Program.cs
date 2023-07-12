using Fundamentals.Classes;

// Do .NET 6 em diante, o compilador sintetiza uma classe Program com um método Main e coloca todas as instruções de nível superior nesse método.

Console.WriteLine("Início!");

BankAccount bankAccount = new BankAccount();

Console.WriteLine(bankAccount.AddToBalance(20000));