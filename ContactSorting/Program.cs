using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            //wykorzystanie sortowania przy użyciu metody porównującej kontakty po imieniu i nazwisku

            Sort(CompareByNameAndSurname);
        }

        //parametrem ma być delegat do metody porównującej 2 kontakty i zwracającej czy są równe czy 1 jest mniejszy od 2


        static void Sort(Func<Contact, Contact, int> compare) 
        {
            //dowolny algorytm sortujący, który będzie wykorzystywał przekazaną metodę porównującą
            //na przykład sortowanie bąbelkowe

            var c1 = new Contact() { Name = "buddy", FirstName = "Buddy", Surname = "Guy" };
            var c2 = new Contact() { Name = "albert", FirstName = "Albert", Surname = "King" };
            var c3 = new Contact() { Name = "albertc", FirstName = "Albert", Surname = "Collins" };
            var c4 = new Contact() { Name = "freddie", FirstName = "Freddie", Surname = "King" };
            var c5 = new Contact() { Name = "muddy", FirstName = "Muddy", Surname = "Waters" };

            var ContactsList = new List<Contact>() { c1, c2, c3, c4, c5 };

            for (int i = 0; i < ContactsList.Count-1; i++)
            {
                for (int j = 0; j < ContactsList.Count-1; j++)
                {
                    if (compare(ContactsList[j],ContactsList[j+1])==2)
                    {
                        var x = ContactsList[j];
                        ContactsList[j] = ContactsList[j + 1];
                        ContactsList[j + 1] = x;
                    }
                }
            }

            foreach (var item in ContactsList)
            {
                Console.WriteLine($"{item.FirstName} {item.Surname}");
            }
        }

        static int CompareByNameAndSurname(Contact c1, Contact c2)
        {
            if (c1.FirstName == c2.FirstName && c1.Surname == c2.Surname)
            {
                return 0;
            }

            var contactList = new List<Contact>() {c1,c2 };
            var sorted = contactList.OrderBy(c => c.FirstName)
                                    .ThenBy(c => c.Surname).ToList();
            if (sorted[0].Name==c1.Name)
            {
                return 1;
            }

            return 2;
        }
    }
}
