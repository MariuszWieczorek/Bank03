using System;
using System.Collections.Generic;
using System.Linq;

namespace Bank
{
    class AccountManager
    {
        private List<Account> _accounts;
        public AccountManager()
        {
            _accounts = new List<Account>();
        }


        // Metoda zwracająca wszystkie konta
        // Jak widać skorzystaliśmy tutaj z interfejsu IEnumerable,
        // ponieważ i tak jakiekolwiek operacje na liście powinniśmy od teraz wykonywać poprzez nasz manager.
        // Dlatego jedyne do czego potrzebujemy listę kont to wyciągnięcie ich w celu np. wyświetlenia.
        public IEnumerable<Account> GetAllAccounts()
        {
            return _accounts;
        }
        


        // -----------------------------------------------------------------------------------------------------

        // Metoda generująca numer konta
        // Gdy Lista jest pusta zwraca najniższy możliwy numer czyli 1
        // Metoda Any() i Max() należy do biblioetki LINQ
        // Metoda Max() jako parametr przyjmuje wyrażenie lambda, pozwala ono w prosty sposób przekazać jako parametr funkcję
        // Max() będzie wykonywała tą przekazaną funkcję dla każdego elementu na liście i dopiero na zwróconych wartościach będzie operować
        // Wyrażenie przekazane w parametrze wyglądałoby tak jak poniżej jeżeli byśmy chcieli je zapisać jako osobną funkcję:
        // int Func(Account x)
        // {
        //    return x.Id;
        // }
        private int generateId()
        {
            int id = 1;

            if (_accounts.Any())
            {
                id = _accounts.Max(x => x.Id) + 1;
            }

            return id;
        }

        // -----------------------------------------------------------------------------------------------------


        // Metoda tworząca konto oszczędnościowe
        public SavingsAccount CreateSavingsAccount(string firstName, string lastName, long pesel)
        {
            int id = generateId();

            SavingsAccount account = new SavingsAccount(id, firstName, lastName, pesel);

            _accounts.Add(account);

            return account;
        }

        // -----------------------------------------------------------------------------------------------------

        // Metoda tworząca konto rozliczeniowe
        public BillingAccount CreateBillingAccount(string firstName, string lastName, long pesel)
        {
            int id = generateId();

            BillingAccount account = new BillingAccount(id, firstName, lastName, pesel);

            _accounts.Add(account);

            return account;
        }

        // -----------------------------------------------------------------------------------------------------


        // Metody zwracająca listę kont podanego klienta
        // Implementacja za pomocą pętli
        public IEnumerable<Account> GetAllAccountsFor1(string firstName, string lastName, long pesel)
        {
            List<Account> customerAccounts = new List<Account>();

            foreach (Account account in _accounts)
            {
                if (account.FirstName == firstName && account.LastName == lastName && account.Pesel == pesel)
                {
                    customerAccounts.Add(account);
                }
            }
            return customerAccounts;
        }


        // Implementacja za pomocą wyrażenia LINQ
        public IEnumerable<Account> GetAllAccountsFor(string firstName, string lastName, long pesel)
        {
            return _accounts.Where(x => x.FirstName == firstName && x.LastName == lastName && x.Pesel == pesel);
        }

        // -----------------------------------------------------------------------------------------------------
       
        // Metody zwracające pojedyncze konto, gdzie jako paramete podajemy numer tego konta
        // implemantacja za pomocą pętli
        public Account GetAccount2(string accountNo)
        {
            Account account;
            account = null;

            foreach (Account acc in _accounts)
            {
                if (acc.AccountNumber == accountNo)
                {
                    account = acc;
                    break;
                }
            }

            return account;
        }


        // implementacja za pomocą wyrażenia LINQ
        // Tym razem możemy wykorzystać funkcję Single(), która zgodnie z nazwą zwróci dokładnie jeden element z listy. 
        public Account GetAccount(string accountNo)
        {

            return _accounts.Single(x => x.AccountNumber == accountNo);
            
        }

        // -----------------------------------------------------------------------------------------------------

        //Lista klientów
        //Rozwiązanie za pomocą Linq. Wykorzystamy tym razem dwie metody: Select() i Distinct()
        //Select() pozwala wyciągnąć imię, nazwisko i PESEL właściciela każdego konta i zwrócić je jako string, nie zwracając całego konta.
        //Jako jej parametr przekazujemy funkcję, która zwróci jakąś wartość na podstawie każdego obiektu z listy kont.
        //Dzięki funkcji Distinct() wszystkie te powtórzenia usuniemy i dostaniemy po jednym elemencie dla każdego klienta 
        public IEnumerable<string> ListOfCustomers()
        {
            return _accounts.Select(a => string.Format("Imię: {0} | Nazwisko: {1} | PESEL: {2}", a.FirstName, a.LastName, a.Pesel)).Distinct();
        }


        // Lista klientów 
        // Implementacja za pomocą pętli
        public List<string> ListOfCustomers2()
        {
            List<string> klienci = new List<string>();
            int powt = 0;
            foreach( var x in _accounts)
            {
                string klient = string.Format("Imię: {0} | Nazwisko: {1} | PESEL: {2}", x.FirstName, x.LastName, x.Pesel);
                powt = 0;
                foreach(string y in klienci)
                {
                    if(y == klient)
                    {
                        powt = 1;
                    }   

                }
                
                if(powt==0) 
                    klienci.Add(klient);

            }

            return klienci;
        }


        // zamknięcie miesiąca
        // Tutaj z pomocą przyjdzie znowu Linq oraz dodatkowo operator is, 
        // który pozwala sprawdzić czy jakiś obiekt jest podanego przez nas typu.
        // Dzięki is możemy sprawdzić czy konto kryjące się pod obiektem klasy bazowej Account jest tak naprawdę typu BillingAccount czy SavingsAccount
        public void CloseMonth()
        {
            foreach (SavingsAccount account in _accounts.Where(x => x is SavingsAccount))
            {
                account.AddInterest(0.04M);
            }

            foreach (BillingAccount account in _accounts.Where(x => x is BillingAccount))
            {
                account.TakeCharge(5.0M);
            }
        }


        public void AddMoney(string accountNo, decimal value)
        {
            Account account = GetAccount(accountNo);
            account.ChangeBalance(value);
        }

        public void TakeMoney(string accountNo, decimal value)
        {
            Account account = GetAccount(accountNo);
            account.ChangeBalance(-value);
        }


    }
}
