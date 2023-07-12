using Fundamentals.Classes;
using Fundamentals.Interfaces;

// Do .NET 6 em diante, o compilador sintetiza uma classe Program com um método Main e coloca todas as instruções de nível superior nesse método.
Console.WriteLine("Início!");

// A expressão new pode ser simplificada ao especificar o tipo da variável
BankAccount bankAccount = new(1000);

bankAccount.AddToBalance(100);

Console.WriteLine(Information(bankAccount));


ChildBankAccount childBankAccount = new();

childBankAccount.AddToBalance(1200);

Console.WriteLine(Information(childBankAccount));

// Implementação de interface
string Information(IInformation infoInterface)
{
    return infoInterface.GetInformation();
}