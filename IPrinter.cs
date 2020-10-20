using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Rozmawialiśmy już o dziedziczeniu klas. Ma ono kilka zastosowań, m.in. pozwala przenieść wspólne fragmenty do klasy nadrzędnej 
// jednocześnie zachowując możliwość indywidualnych zachowań.
// Jednak cokolwiek sobie pomyślałeś poznając mechanizm dziedziczenia to tak naprawdę nie jest on aż tak potrzebny jak Ci się wydaje.
// To czego najczęściej potrzebujemy to pewnego „zestawu złączy” jakie powinna zawierać klasa.
// Dzięki temu będziemy mogli korzystać w taki sam sposób z obiektów wielu klas, 
// które teoretycznie nie są ze sobą w ogóle związane, nie musząc wiedzieć jakie konkretnie klasy się tam mogą znaleźć.
// Można to porównać do złącza USB w komputerze – oczekujemy, że urządzenia będą miały takie samo złącze USB, które podepniemy w ten sam sposób,
// i które zapewni takie same możliwości. Mimo, że tymi urządzeniami może być jednocześnie myszka, klawiatura czy smartfon.
// Dzięki temu, że mamy standard USB to z tego samego portu może korzystać bardzo wiele kompletnie nie związanych ze sobą urządzeń.
// I podobnego zachowania oczekujemy w naszych programach.
// W języku C# takie możliwości dają interfejsy.

// Czynnością, którą tutaj chcemy wykonać jest drukowanie. Dlaczego by więc nie przygotować tylko kontraktu mówiącego, że chcę mieć dostępną metodę Print()

namespace Bank
{
    interface IPrinter
    {
        void Print(Account account);
    }
}
