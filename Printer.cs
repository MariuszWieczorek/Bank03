using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Printer : IPrinter
    {
       // zamiast przeciążać metodę i pisać odrębny kod dla klas BilansAccount i SavingsAccount
       // tworzymy jedną wspólną metodę dla klasy Account

        public void Print(Account account)
        {
            Console.WriteLine($"Dane konta:  {account.AccountNumber} ");
            Console.WriteLine($"Saldo: {account.Balance} zł");
            Console.WriteLine("Imię właściciela: {0}", account.FirstName);
            Console.WriteLine("Nazwisko właściciela: {0}", account.LastName);
            Console.WriteLine("PESEL właściciela: {0}", account.Pesel);
            Console.WriteLine("Typ konta: {0}", account.TypeName());
            Console.WriteLine();
        }
    }
}
