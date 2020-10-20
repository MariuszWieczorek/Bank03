using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Nazwa: Bank";
            string author = "Autor: Mariusz Wieczorek";
            Console.WriteLine(name);
            Console.WriteLine(author);
            Console.WriteLine();

            AccountManager manager = new AccountManager();
            manager.CreateSavingsAccount("Jan", "Kowalski", 72080408887);
            manager.CreateSavingsAccount("Jan", "Szwagierczak", 72080408897);
            manager.CreateSavingsAccount("Małgorzata", "Nowakowska", 72080409999);
            manager.CreateSavingsAccount("Marek", "Nowak", 72080409998);
            manager.CreateBillingAccount("Małgorzata", "Nowakowska", 72080409999);
            manager.CreateBillingAccount("Joanna", "Karbowniczak", 72080409991);

            BankManager BankX = new BankManager();
            BankX.Run();


            Console.ReadKey();
        }
    }
}
