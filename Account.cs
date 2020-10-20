using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    // Dziedziczenie 
    // Praktycznie każda klasa może dziedziczyć z innej klasy.
    // Tworzą one wtedy hierarchię rodzica i dziecka.
    // Jednak w przeciwieństwie do ludzi, klasa w C# może mieć tylko jednego rodzica. Jest to odgórnie wprowadzone ograniczenie.

    // Konstruktor Bazowy
    // Ogólnie wykorzystanie konstruktora bazowego wygląda w następujący sposób:
    // NazwaKlasy(parametry) : base(parametry_konstruktora_z_klasy_bazowej)
    // {
    // }

    // Fakt, że klasa bazowa może zawierać część wspólną wszystkich klas, które z niej dziedziczą to nie jedyna jej zaleta.
    // Inną jest fakt, że tworząc zmienną, której typem jest właśnie tak klasa możemy do niej przypisać obiekty dowolnej klasy dziedziczącej.
    // Account account = new SavingsAccount(...);
    // Jednak w takim przypadku chcąc cokolwiek z tą zmienną zrobić jesteśmy ograniczeni jedynie do elementów, które zawiera klasa Account.

    // Dodaliśmy tutaj klasę, na której bazują wszystkie konta
    // ustawiamy klasę jako abstrakcyjną aby nie tworzyć obiektów tej klasy

    // 
    // Konto, jeżeli nie jest konkretnego typu, nie stanowi czegoś co powinno mieć rzeczywistą reprezentację w postaci gotowego obiektu.
    // Konto jest w tym przypadku czymś abstrakcyjnym. Czymś na czym chcemy oprzeć konkretne typy kont,
    // ale samo w sobie nie stanowi czegoś co nadaje się do wyprodukowania, utworzenia.
    // Kiedy idziesz do banku to nie zakładasz po prostu konta. Zakładasz konto oszczędnościowe, rozliczeniowe, inwestycyjne.
    // Wszystkie one są kontami, ale nie możemy założyć po prostu konta jako takiego.
    // Jeżeli teraz chcielibyśmy wykonać gdzieś w kodzie instrukcję new Account() to dostaniemy błąd
    // ale nadal możliwe jest Account Konto = new SavingsAccount();


    // Modyfikatory dostępu
    // Przedmioty codziennego użytku też posiadają swoje tajemnice.
    // Ukrywają pewne szczegóły, które są nieistotne dla użytkownika ale niezbędne do działania tego przedmiotu.
    // Ot chociażby zegar. Mechanizm, który porusza wskazówkami jest przed nami zazwyczaj ukryty.
    // Nie mamy potrzeby go oglądać ani tym bardziej bezpośrednio w nim grzebać.
    // Chcemy tylko żeby zegar działał, wskazywał poprawną godzinę i dawał możliwość jej ustawienia.
    // Podobnie sprawa ma się z klasami. One też mogą posiadać takie ukryte fragmenty.
    // public
    // private - domyślny modyfikator - taki jest ustawiany gdy nie podamy żadnego
    // Elementy oznaczone jako prywatne to są właśnie te najbardziej ukryte.
    // Tworzymy je korzystając ze słowa kluczowego private.
    // Mamy do nich dostęp tylko wewnątrz klasy w jakiej się znajdują.
    // Są wykorzystywane najczęściej do funkcji, w których chcemy wydzielić jakieś fragmenty kodu, a które mają sens tylko wewnątrz tej jednej klasy.
    // protected
    // Ostatni typ modyfikatora dostępu jaki tutaj omawiamy do dostęp chroniony czyli protected.
    // Jest on ściśle związany z omawianym poprzednio dziedziczeniem.
    // A to dlatego, że działa on prawie tak samo jak dostęp prywatny z tą różnicą, że uchyla rąbka tajemnicy klasom dziedziczącym.
    // Dzięki temu jednocześnie unikamy duplikacji kodu pomiędzy klasą bazową i dziedziczącą oraz zachowujemy prywatność pewnych zmiennych i funkcji.

    //Hermetyzacja zwana też enkapsulacją oznacza udostępnianie na zewnątrz klasy tylko niezbędnego minimum informacji.
    // Jest ona możliwa właśnie dzięki poznanym przed chwilą modyfikatorom dostępu.

    abstract class Account
    {

        public int Id { get; }
        public string AccountNumber { get; }
        public decimal Balance { get; protected set; }
        public string FirstName { get; }
        public string LastName { get; }
        public long Pesel { get; }

        public Account()
        {
        }

        
        public Account(int id, string firstName, string lastName, long pesel)
        {
            Id = id;
            AccountNumber = generateAccountNumber(id);
            FirstName = firstName;
            LastName = lastName;
            Balance = 0.00M;
            Pesel = pesel;
        }

        public string GetBalance()
        {
            string balanceX = $"{Balance} zł";
            return balanceX;
        }

        public string GetFullName()
        {
            string fullName = string.Format("{0} {1}", FirstName, LastName);
            return fullName;
        }


        // Metoda Abstrakcyjna
        // Jej cechą charakterystyczną jest to, że nie posiada żadnej implementacji.
        // W tej klasie jedynie mówimy, że taka metoda istnieje.
        // Dzięki temu możliwe jest jej użycie kiedy posługujemy się zmienną typu Account.
        // Klasa, która posiada metodę abstrakcyjną sama musi być abstrakcyjna
        // Taką Metodę Abstrakcyjną muszą teraz zaimplementować wszystkie klasy, które dziedziczą po klasie, w której znajduje się metoda abstrakcyjna
        // Jej cechą charakterystyczną jest to, że nie posiada żadnej implementacji.
        // Dzięki temu możliwe jest jej użycie kiedy posługujemy się zmienną typu Account.
        public abstract string TypeName();


        string generateAccountNumber(int id)
        {
            // Ta dziwna wartość :D10 w funkcji do formatowania tekstu oznacza
            // wstaw tutaj liczbę, która jest argumentem, ale całość uzupełnij zerami tak żeby w sumie było 10 znaków
            var accountNumber = string.Format("94{0:D5}", id);
            
            return accountNumber;
        }


        public void ChangeBalance(decimal value)
        {
            Balance += value;
        }

    }
}
