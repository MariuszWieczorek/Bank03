using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class BankManager
    {

        private AccountManager _accountsManager;
        private IPrinter _printer;

        public BankManager()
        {
            _accountsManager = new AccountManager();
            _accountsManager.CreateSavingsAccount("Jan", "Kowalski", 72080408887);
            _accountsManager.CreateSavingsAccount("Jan", "Szwagierczak", 72080408897);
            _accountsManager.CreateSavingsAccount("Małgorzata", "Nowakowska", 72080409999);
            _accountsManager.CreateSavingsAccount("Marek", "Nowak", 72080409998);
            _accountsManager.CreateBillingAccount("Małgorzata", "Nowakowska", 72080409999);
            _accountsManager.CreateBillingAccount("Joanna", "Karbowniczak", 72080409991);

            _printer = new Printer();
        }

        // wyświetla menu na ekranie
        private void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Wybierz akcję:");
            Console.WriteLine("1 - Lista kont klienta");
            Console.WriteLine("2 - Dodaj konto rozliczeniowe");
            Console.WriteLine("3 - Dodaj konto oszczędnościowe");
            Console.WriteLine("4 - Wpłać pieniądze na konto");
            Console.WriteLine("5 - Wypłać pieniądze z konta");
            Console.WriteLine("6 - Lista klientów");
            Console.WriteLine("7 - Wszystkie konta");
            Console.WriteLine("8 - Zakończ miesiąc");
            Console.WriteLine("0 - Zakończ");
        }


        // Teraz chcemy żeby program pozwalał wykonywać wielokrotnie różne operacje. Przynajmniej do czasu kiedy użytkownik nie wpisze wartości 0 oznaczającej koniec. 
        // Skoro coś ma się dziać wielokrotnie to może zastosować pętlę? Dokładnie tak! W tym wypadku chcemy żeby menu wyświetliło się przynajmniej raz zanim użytkownik cokolwiek wybierze.
        // Dlatego dobrym pomysłem będzie skorzystanie z pętli do…while:
        public void Run()
        {
            int action;
            do
            {
                PrintMainMenu();
                action = SelectedAction();


                switch (action)
                {
                    case 1:
                        ListOfAccounts();
                        break;
                    case 2:
                        AddBillingAccount();
                        break;
                    case 3:
                        AddSavingsAccount();
                        break;
                    case 4:
                        AddMoney();
                        break;
                    case 5:
                        TakeMoney();
                        break;
                    case 6:
                        ListOfCustomers();
                        break;
                    case 7:
                        GetAllAccounts();
                        break;
                    case 8:
                        CloseMonth();
                        break;
                    case 0:
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Nieznane polecenie");
                        Console.ReadKey();
                        break;
                }


            }
            while (action != 0);
        }

        // wybór akcji przez użytkownika
        // jeżeli użytkownik niczego nie wpisał zwracamy -1
        // jeżeli użytkownik jednak coś wpisał to zamieniamy ten tekst na wartość liczbową
        private int SelectedAction()
        {
            Console.Write("Akcja: ");
            string action = Console.ReadLine();
            if (string.IsNullOrEmpty(action))
            {
                return -1;
            }

            int number;
            bool success = Int32.TryParse(action, out number);

            if(!success)
            {
               return  -1;
            }

            return Int32.Parse(action);
        }


        private void GetAllAccounts()
        {
            Console.Clear();
            foreach (Account account in _accountsManager.GetAllAccounts())
            {
                _printer.Print(account);
            }
            Console.ReadKey();

        }


        // lista kont wybranego kontrahenta
        // na wejściu dostajemy obiekt typu CustomerData
        // później metodą _accountsManager.GetAllAccountsFor pobieramy dane konta
        // i wyświetlają pobrane konta w pętli metodą _printer.Print
        private void ListOfAccounts()
        {
            Console.Clear();
            CustomerData data = ReadCustomerData();
            Console.WriteLine();
            Console.WriteLine("Konta klienta {0} {1} {2}", data.FirstName, data.LastName, data.Pesel);

            foreach (Account account in _accountsManager.GetAllAccountsFor(data.FirstName, data.LastName, data.Pesel))
            {
                _printer.Print(account);
            }
            Console.ReadKey();
        }

        // wymusza pobranie danych kontrahenta z konsoli
        // zwrca obiekt Customer
        private CustomerData ReadCustomerData()
        {   
            string firstName;
            string lastName;
            string pesel;
            Console.WriteLine("Podaj dane klienta:");
            Console.Write("Imię: ");
            firstName = Console.ReadLine();
            Console.Write("Nazwisko: ");
            lastName = Console.ReadLine();
            Console.Write("PESEL: ");
            pesel = Console.ReadLine();

            return new CustomerData(firstName, lastName, pesel);
        }

        // Lista kontrahentów
        // _accountsManager.ListOfCustomers() daje nam sformatowaną liste stringów z danymi kontrahenta
        private void ListOfCustomers()
        {
            Console.Clear();
            Console.WriteLine("Lista klientów:");
            foreach(string customer in _accountsManager.ListOfCustomers())
            {
                Console.WriteLine(customer);
            }
            Console.ReadKey();
        }

        // dodanie konta bilingowego
        private void AddBillingAccount()
        {
            Console.Clear();
            CustomerData data = ReadCustomerData();
            Account billingAccount = _accountsManager.CreateBillingAccount(data.FirstName, data.LastName, data.Pesel);

            Console.WriteLine("Utworzono konto rozliczeniowe:");
            _printer.Print(billingAccount);
            Console.ReadKey();
        }


        // dodanie konta oszczędnościowego
        private void AddSavingsAccount()
        {
            Console.Clear();
            CustomerData data = ReadCustomerData();
            Account savingsAccount = _accountsManager.CreateSavingsAccount(data.FirstName, data.LastName, data.Pesel);

            Console.WriteLine("Utworzono konto oszczędnościowe:");
            _printer.Print(savingsAccount);
            Console.ReadKey();
        }


        // pozwala na wpłatę pieniędzy na konto
        // pobieramy z konsoli numer konta
        // pobieramy z konsoli kwotę 
        // wykorzystyjemy metodę AddMoney z klasy AccountMAnager
        private void AddMoney()
        {
            string accountNo;
            decimal value;

            Console.WriteLine("Wpłata pieniędzy");
            Console.Write("Numer konta: ");
            accountNo = Console.ReadLine();
            Console.Write("Kwota: ");
            value = decimal.Parse(Console.ReadLine());
            _accountsManager.AddMoney(accountNo, value);

            Account account = _accountsManager.GetAccount(accountNo);
            _printer.Print(account);

            Console.ReadKey();
        }

        // pozwala na wpłatę pieniędzy na konto
        // pobieramy z konsoli numer konta
        // pobieramy z konsoli kwotę 
        // wykorzystyjemy metodę TakeMoney z klasy AccountMAnager
        private void TakeMoney()
        {
            string accountNo;
            decimal value;

            Console.WriteLine("Wypłata pieniędzy");
            Console.Write("Numer konta: ");
            accountNo = Console.ReadLine();
            Console.Write("Kwota: ");
            value = decimal.Parse(Console.ReadLine());
            _accountsManager.TakeMoney(accountNo, value);

            Account account = _accountsManager.GetAccount(accountNo);
            _printer.Print(account);

            Console.ReadKey();
        }

        private void CloseMonth()
        {
            Console.Clear();
            _accountsManager.CloseMonth();
            Console.WriteLine("Miesiąc zamknięty");
            Console.ReadKey();
        }

    }
}
