using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class SavingsAccount:Account
    {
        public SavingsAccount() : base()
        {
        }

        public SavingsAccount(int id, string firstName, string lastName,  long pesel)
               : base(id, firstName, lastName,  pesel)
        {
        }

        // Implementacja Metody Abstrakcyjnej w klasie dziedziczącej
        // Implementacja takiej metody w klasie dziedziczącej jest banalnie prosta.
        // Wystarczy, że wstawimy w niej funkcję o takiej samej nazwie tylko słowo abstract zamienimy na override,
        // co będzie oznaczało, że świadomie nadpisujemy taką funkcję.

        // Polimorfizm
        // Teraz jeżeli mamy zmienną Account, do której przypiszemy obiekt klasy SavingsAccount
        // to korzystając z metody TypeName() skorzystamy właśnie z tej, którą zapisaliśmy poniżej. Tak samo będzie ze wszystkimi innymi klasami, które dziedziczą po Account.
        // To o czym tutaj mówię jest częścią mechanizmu, który nazywa się polimorfizmem. 
        public override string TypeName()
        {
            return "OSZCZĘDNOŚCIOWE";
        }


        public void AddInterest(decimal interest)
        {
            Balance += Balance * interest;
        }
    }
}
