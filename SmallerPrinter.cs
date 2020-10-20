using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class SmallerPrinter : IPrinter
    {
        public void Print(Account account)
        {
            Console.WriteLine($"Numer konta:  {account.AccountNumber} ");
            Console.WriteLine($"Właściciel: {account.FirstName} {account.LastName}");
        }
    }
}
