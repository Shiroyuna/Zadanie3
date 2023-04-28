using System;

class Menu
{

    static void Main(string[] args)
    {
        Biblioteka biblioteka = new Biblioteka();

        int choice = 0;

        do
        {
            Console.WriteLine("Witaj w systemie zarządzania biblioteką.");
            Console.WriteLine("1. Wyświetl dysponowane książki");
            Console.WriteLine("2. Wyszukaj książkę");
            Console.WriteLine("3. Dodaj książkę do systemu");
            Console.WriteLine("4. Usuń książkę ze systemu");
            Console.WriteLine("5. Aktualizuj dane o książce");
            Console.WriteLine("6. Dodaj wypożyczającego do systemu");
            Console.WriteLine("7. Aktualizuj dane o wypożyczającym");
            Console.WriteLine("8. Wyświetl dokumentację wypożyczeń książek");
            Console.WriteLine("9. Wyjdź z programu");
            Console.Write("Wpisz opcję: ");

            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Wpisz numer od 1 do 9");
                continue;
            }

            switch (choice)
            {
                case 1:
                    biblioteka.DisplayBooks();
                    break;
                case 2:
                    Console.WriteLine("Wpisz tytuł książki do wyszukania: ");
                    string tittle = Console.ReadLine();
                    biblioteka.SearchBook(tittle);
                    break; 
                case 3:
                    Console.Write("Wpisz tytuł książki: ");
                    string tytuł = Console.ReadLine();
                    Console.Write("Wpisz autora ksiązki: ");
                    string autor = Console.ReadLine();
                    Console.Write("Wpisz rok wydania: ");
                    int rokWydania = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Wpisz wydawcę: ");
                    string wydawca = Console.ReadLine();
                    Console.Write("Wpisz numer ISBN: ");
                    int numerISBN = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Wpisz gatunek: ");
                    string gatunek = Console.ReadLine();
                    Console.Write("Wpisz numer dostępnych kopii: ");
                    int dostępneEgz = Convert.ToInt32(Console.ReadLine());
                    biblioteka.AddBook(tytuł, autor, rokWydania, wydawca, numerISBN, gatunek, dostępneEgz);
                    break;
                case 4:
                    Console.WriteLine("Wpisz tytuł książki do usunięcia: ");
                    tytuł = Console.ReadLine();
                    biblioteka.DeleteBook(tytuł);
                    break;
                case 5:
                    Console.WriteLine("Wpisz tytuł książki do aktualizacji: ");
                    tytuł = Console.ReadLine();
                    biblioteka.UpdateBookInfo(tytuł);
                    break;
                case 6:
                    Console.Write("Wpisz imię: ");
                    string imię = Console.ReadLine();
                    Console.Write("Wpisz nazwisko: ");
                    string nazwisko = Console.ReadLine();
                    Console.Write("Wpisz numer telefonu: ");
                    int numerTel = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Wpisz datę wypożyczenia: ");
                    DateTime dataWypo = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Wpisz datę zwrotu: ");
                    DateTime dataZwrotu = Convert.ToDateTime(Console.ReadLine());
                    biblioteka.AddRecords(imię, nazwisko, numerTel, dataWypo, dataZwrotu);
                    break;
                case 7:
                    Console.WriteLine("Wpisz imię i nazwisko osoby do aktualizacji: ");
                    Console.WriteLine("Imię: ");
                    imię = Console.ReadLine();
                    Console.WriteLine("Nazwisko: ");
                    nazwisko = Console.ReadLine();
                    biblioteka.UpdateRecordsInfo(imię, nazwisko);
                    break;
                case 8:
                    biblioteka.DisplayRecords();
                    break;
                case 9:
                    Console.WriteLine("Zamykanie programu..");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Wpisz numer od 1 do 9");
                    Console.ReadLine();
                    break;
            }

            Console.WriteLine();

        } while (choice != 9);

        Console.ReadLine();
    }
}

class Książka
{
    public string tytuł;
    public string autor;
    public int rokWydania;
    public string wydawca;
    public int numerISBN;
    public string gatunek;
    public int dostępneEgz;

    public Książka(string tytuł, string autor, int rokWydania, string wydawca, int numerISBN, string gatunek, int dostępneEgz)
    {
        this.tytuł = tytuł;
        this.autor = autor;
        this.rokWydania = rokWydania;
        this.wydawca = wydawca;
        this.numerISBN = numerISBN;
        this.gatunek = gatunek;
        this.dostępneEgz = dostępneEgz;

    }
}

class Wypożyczający
{
    public string imię;
    public string nazwisko;
    public int numerTel;
    public DateTime dataWypo;
    public DateTime dataZwrotu;

    public Wypożyczający(string imię, string nazwisko, int numerTel, DateTime dataWypo, DateTime dataZwrotu)
    {
        this.imię = imię;
        this.nazwisko = nazwisko;
        this.numerTel = numerTel;
        this.dataWypo = dataWypo;
        this.dataZwrotu = dataZwrotu;
    }
}

class Biblioteka
{
    public Książka[] książki;
    public int ileKsiążek;
    public Wypożyczający[] wypożyczający;
    public int ileWypoż;

    public Biblioteka()
    {
        książki = new Książka[50];
        ileKsiążek = 0;
        wypożyczający = new Wypożyczający[50];
        ileWypoż = 0;
    }

    public void DisplayBooks()
    {
        Console.WriteLine("Lista książek: ");
        for (int i = 0; i < ileKsiążek; i++)
        {
            Console.WriteLine("{0}. Tytuł: {1}\n Autor: {2}\n Rok wydania: {3}\n Wydawca: {4}\n Numer ISBN: {5}\n Gatunek: {6}\n Dostępne Egzemplarze: {7}",
                i + 1, książki[i].tytuł, książki[i].autor, książki[i].rokWydania, książki[i].wydawca, książki[i].numerISBN, książki[i].gatunek, książki[i].dostępneEgz);
        }
    }

    public void SearchBook(string tytuł)
    {
        for (int i = 0; i < ileKsiążek; i++)
        {
            if (książki[i].tytuł == tytuł)
            {
                Console.WriteLine($"Tytuł: {książki[i].tytuł}\n Autor: {książki[i].autor}\n Rok wydania: {książki[i].rokWydania}\n Wydawca: {książki[i].wydawca}\n Numer ISBN: {książki[i].numerISBN}\n Gatunek: {książki[i].gatunek}\n Dostępne Egzemplarze: {książki[i].dostępneEgz}");
                return;
            }
        }
        Console.WriteLine("Nie znaleziono książki o tytule {0}.", tytuł);
        Console.ReadLine();
    } 

    public void AddBook(string tytuł, string autor, int rokWydania, string wydawca, int numerISBN, string gatunek, int dostępneEgz)
    {
        Książka newKsiążka = new Książka(tytuł, autor, rokWydania, wydawca, numerISBN, gatunek, dostępneEgz);
        książki[ileKsiążek] = newKsiążka;
        ileKsiążek++;
    }

    public void DeleteBook(string tytuł)
    {
        for (int i = 0; i < ileKsiążek; i++)
        {
            if (książki[i].tytuł == tytuł)
            {
                for (int j = i; j < ileKsiążek - 1; j++)
                {
                    książki[j] = książki[j + 1];
                }
                ileKsiążek--;
                Console.WriteLine("Książka o tytule {0} została usunięta.", tytuł);
                return;
            }
        }
        Console.WriteLine("Nie znaleziono książki o tytule {0}.", tytuł);
        Console.ReadLine();
    }

    public void UpdateBookInfo(string tytuł)
    {
        for (int i = 0; i < ileKsiążek; i++)
        {
            if (książki[i].tytuł == tytuł)
            {
                Console.WriteLine("Aktualizujesz dane książki o tytule {0}.", tytuł);
                Console.WriteLine("Wpisz nowe informacje o książce: ");

                Console.Write("Tytuł: ");
                string newTytuł = Console.ReadLine();
                if (!string.IsNullOrEmpty(newTytuł))
                {
                    książki[i].tytuł = newTytuł;
                }

                Console.Write("Autor: ");
                string newAutor = Console.ReadLine();
                if (!string.IsNullOrEmpty(newAutor))
                {
                    książki[i].autor = newAutor;
                }

                Console.Write("Rok wydania: ");
                string newRokWydania = Console.ReadLine();
                if (!string.IsNullOrEmpty(newRokWydania))
                {
                    książki[i].rokWydania = Convert.ToInt32(newRokWydania);
                }

                Console.Write("Wydawca: ");
                string newWydawca = Console.ReadLine();
                if (!string.IsNullOrEmpty(newWydawca))
                {
                    książki[i].wydawca = newWydawca;
                }

                Console.Write("Numer ISBN: ");
                string newNumerISBN = Console.ReadLine();
                if (!string.IsNullOrEmpty(newNumerISBN))
                {
                    książki[i].numerISBN = Convert.ToInt32(newNumerISBN);
                }

                Console.Write("Gatunek: ");
                string newGatunek = Console.ReadLine();
                if (!string.IsNullOrEmpty(newGatunek))
                {
                    książki[i].gatunek = newGatunek;
                }

                Console.Write("Dostępne egzemplarze: ");
                string newDostępneEgz = Console.ReadLine();
                if (!string.IsNullOrEmpty(newDostępneEgz))
                {
                    książki[i].dostępneEgz = Convert.ToInt32(newDostępneEgz);
                }

                Console.WriteLine("Dane książki zostały zaktualizowane.");
                return;
            }
        }
        Console.WriteLine("Nie znaleziono książki o tytule {0}.", tytuł);
        Console.ReadLine();
    }

    public void AddRecords(string imię, string nazwisko, int numerTel, DateTime dataWypo, DateTime dataZwrotu)
    {
        Wypożyczający newWypożyczający = new Wypożyczający(imię, nazwisko, numerTel, dataWypo, dataZwrotu);
        wypożyczający[ileWypoż] = newWypożyczający;
        ileWypoż++;
    }

    public void UpdateRecordsInfo(string imię, string nazwisko)
    {
        for (int i = 0; i < ileWypoż; i++)
        {
            if (wypożyczający[i].imię == imię & wypożyczający[i].nazwisko == nazwisko)
            {
                Console.WriteLine("Aktualizujesz dane osoby " + imię + " " + nazwisko);
                Console.WriteLine("Wpisz nowe informacje o wypożyczającym: ");

                Console.Write("Imię: ");
                string newImię = Console.ReadLine();
                if (!string.IsNullOrEmpty(newImię))
                {
                    wypożyczający[i].imię = newImię;
                }

                Console.Write("Nazwisko: ");
                string newNazwisko = Console.ReadLine();
                if (!string.IsNullOrEmpty(newNazwisko))
                {
                    wypożyczający[i].nazwisko = newNazwisko;
                }

                Console.Write("Numer telefonu: ");
                string newnumerTel = Console.ReadLine();
                if (!string.IsNullOrEmpty(newnumerTel))
                {
                    wypożyczający[i].numerTel = Convert.ToInt32(newnumerTel);
                }

                Console.Write("Data wypożyczenia: ");
                string newdataWypo = Console.ReadLine();
                if (!string.IsNullOrEmpty(newdataWypo))
                {
                    wypożyczający[i].dataWypo = Convert.ToDateTime(newdataWypo);
                }

                Console.Write("Data zwrotu: ");
                string newdataZwrotu = Console.ReadLine();
                if (!string.IsNullOrEmpty(newdataZwrotu))
                {
                    wypożyczający[i].dataZwrotu = Convert.ToDateTime(newdataZwrotu);
                }

                Console.WriteLine("Dane osoby zostały zaktualizowane.");
                return;
            }
        }
        Console.WriteLine("Nie znaleziono osoby " + imię + " " + nazwisko);
        Console.ReadLine();
    }

    public void DisplayRecords()
    {
        Console.WriteLine("Informacje o wypożyczających: ");
        for (int i = 0; i < ileWypoż; i++)
        {
            Console.WriteLine("{0}. Imię: {1}\n Nazwisko: {2}\n Numer telefonu: {3}\n Data wypożyczenia: {4}\n Data zwrotu: {5}",
                i + 1, wypożyczający[i].imię, wypożyczający[i].nazwisko, wypożyczający[i].numerTel, wypożyczający[i].dataWypo, wypożyczający[i].dataZwrotu);
        }
        Console.WriteLine("Nie znaleziono żadnych wypożyczających");
        Console.ReadLine();
    }
}