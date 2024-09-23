namespace MagicTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConcertManager concert = new ImplConcertManager();

            do
            {
                Console.WriteLine("*** QUEEN MAGIC TOUR 1986 ***");
                Console.WriteLine("1 - Információ");
                Console.WriteLine("2 - Helyszínek");
                Console.WriteLine("3 - Koncerteken játszott dalok listája");
                Console.WriteLine("4 - Legmagasabb látogatottság");
                Console.WriteLine("5 - Átlag látogatottság");
                Console.WriteLine("6 - Keresés adat alapján");
                Console.WriteLine("7 - Delilah");
                Console.WriteLine("0 - Kilépés");
                Console.Write("Adja meg a választott műveletet: ");

                int choice = 0;
                do
                {
                    try
                    {
                        choice = int.Parse(Console.ReadLine() ?? "");
                        if (choice < 0 || choice > 7)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Hiba: Nem adott meg semmit");
                        Console.Write("Adja meg újból a műveletet: ");
                    }
                    catch
                    {
                        Console.WriteLine("Hiba: Nincs ilyen opció");
                        Console.Write("Adja meg újból a műveletet: ");
                    }

                } while (true);
                if (choice == 0) break;

                switch (choice)
                {
                    case 1: concert.AboutTour();
                            break;
                    case 2: concert.ListItinerary(ImplConcertManager.getDataFromJson());
                            break;
                    case 3: concert.ListSetlist();
                            break;
                    case 4: concert.MaxAttendace(ImplConcertManager.getDataFromJson());
                            break;
                    case 5: concert.AvrAttendance(ImplConcertManager.getDataFromJson());
                            break;
                    case 6: concert.ListBy(ImplConcertManager.getDataFromJson());
                            break;
                    case 7: concert.Delilah();
                            break;
                }

            } while (true);
        }
    }
}
