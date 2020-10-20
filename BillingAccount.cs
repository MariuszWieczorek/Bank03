using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    // klasa BillingAccount dziedziczy po klasie Account
    class BillingAccount : Account
    {

        // Używamy konstruktora bazowego
        public BillingAccount(int id, string firstName, string lastName,  long pesel)
               : base(id, firstName, lastName,  pesel)
        { 
        }


        // Implementacja Metody Abstrakcyjnej w klasie dziedziczącej
        // Implementacja takiej metody w klasie dziedziczącej jest banalnie prosta.
        // Wystarczy, że wstawimy w niej funkcję o takiej samej nazwie
        // tylko słowo abstract zamienimy na override,
        // co będzie oznaczało, że świadomie nadpisujemy taką funkcję.

        // Polimorfizm
        // Teraz jeżeli mamy zmienną Account, do której przypiszemy obiekt klasy BillingAccount
        // to korzystając z metody TypeName() skorzystamy właśnie z tej, którą zapisaliśmy poniżej. Tak samo będzie ze wszystkimi innymi klasami, które dziedziczą po Account.
        // To o czym tutaj mówię jest częścią mechanizmu, który nazywa się polimorfizmem. 
        public override string TypeName()
        {
            return "ROR";
        }

        public void TakeCharge(decimal value)
        {
            Balance -= value;
        }

    }
}
