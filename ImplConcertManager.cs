using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTour
{
    internal class ImplConcertManager : IConcertManager
    {
        public void AboutTour()
        {
            Console.WriteLine("\nInformáció a turnéról:\n");
            Console.WriteLine("A Magic Tour 1986 a Queen utolsó nagyszabású turnéja volt Freddie Mercuryvel\n" +
                "és egyben az egyik legemlékezetesebb is. A turné sok rajongó számára maradandó élményt jelentett,\n" +
                "mivel lehetőséget kínált arra, hogy élőben láthassák és hallhassák a Queen legendás előadását.\n" +
                "A turnét '86 júniusától augusztusáig tartották Európában és a Magic című stúdióalbumukat promótálták vele.\n" +
                "A turné állomásai között szerepeltek Európa nagyvárosai, például London, Párizs, Bécs és mi kis hazánk\n" +
                "fővárosa Budapest is. A Queen hírneve és népszerűsége ekkor már a csúcson volt, és ez a turné ismételten\n" +
                "bebizonyította, hogy amit csinálnak az korszakalkotó.");
            Console.WriteLine();
            Console.WriteLine("\"I love the fact that I can make people happy, in any form. Even if it’s just an hour of their lives,\n" +
                "if I can make them feel lucky or make them feel good, or bring a smile to a sour face, that to me is worthwhile.\"\n" +
                "- Freddie Mercury");
            Console.WriteLine();
        }

        public void ListItinerary(List<Concert> concerts)
        {
            Console.WriteLine("\nKoncertek:\n");
            foreach (var concert in concerts)
            {
                Console.WriteLine($"Ország: {concert.Country}\nVáros: {concert.City}\nHelyszín: {concert.Venue}\n" +
                    $"Dátum: {concert.Date.Year}-{concert.Date.Month}-{concert.Date.Day}\nLátogatottság: {concert.Attendance}\n");
            }
        }

        public void ListSetlist()
        {
            const string fileName = "setlist.txt";
            int counter = 1;

            List<string> songs = [];
            try
            {
                songs = File.ReadAllLines(fileName).ToList();
            }
            catch (Exception e) when (e is FormatException or FileNotFoundException)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nA turné keretein belül játszott dalok:");
            songs.ForEach(x => Console.Write($"{counter++}. {x}\n"));
            Console.WriteLine();
        }
        
        public void MaxAttendace(List<Concert> concerts)
        {
            Concert maxAtt = concerts[0];
            int biggest = 0;
            concerts.ForEach(x =>
            {
                if (x.Attendance > biggest) maxAtt = x;
            });
            Console.WriteLine($"\nA leglátogatottabb koncertre {maxAtt.Attendance} néző gyűlt össze.\n" +
                $"Itt került megrendezésre: {maxAtt.Country}, {maxAtt.City} ({maxAtt.Venue})\n" +
                $"Ekkor: {maxAtt.Date.Year}-{maxAtt.Date.Month}-{maxAtt.Date.Day}\n");
        }

        public void AvrAttendance(List<Concert> concerts)
        {
            int counter = 0;
            int sum = 0;

            concerts.ForEach(x =>
            {
                sum += x.Attendance;
                counter++;
            });

            double avgAtt = (double)sum / counter;
            Console.WriteLine($"\nA koncertek átlag látogatottsága: {avgAtt}\n");
        }

        public void ListBy(List<Concert> concerts)
        {
            bool done = false;
            string input = "";
            do
            {
                try
                {
                    Console.Write("\nMi alapján szeretnél keresni?\nO - ország\nV - város\nS - színhely\nH - hónap\nN - nap" +
                        "\nAdja meg a választott keresési módot: ");

                    input = Console.ReadLine() ?? "";
                    input = input.ToLower().Trim();

                    if (input != "o" && input != "v" && input != "s" && input != "h" && input != "n")
                    {
                        throw new BadInputException(SearchErrorType.INVALID_OPTION.GetErrorMessage());
                    }
                    else
                    {
                        done = true;
                    }
                } catch (BadInputException e)
                {
                    Console.WriteLine("Hiba történt: " + e.Message);
                }
            } while (!done);

            List<Concert> listBy = new List<Concert>();
            do
            {
                try
                {
                    switch (input)
                    {
                        case "o":
                            Console.Write("Kérem az ország nevét (angolul): ");
                            string country = Console.ReadLine() ?? "";
                            country = country.ToLower().Trim();
                            if (!string.IsNullOrEmpty(country) && country.Any(char.IsDigit))
                            {
                                throw new BadInputException(SearchErrorType.NOT_STRING.GetErrorMessage());
                            }
                            else
                            {
                                listBy = concerts.Where(x => country == (x.Country).ToLower()).ToList();
                                done = true;
                            }
                            break;
                        case "v":
                            Console.Write("Kérem a város nevét (angolul): ");
                            string city = Console.ReadLine() ?? "";
                            city = city.ToLower().Trim();
                            if (!string.IsNullOrEmpty(city) && city.Any(char.IsDigit))
                            {
                                throw new BadInputException(SearchErrorType.NOT_STRING.GetErrorMessage());
                            }
                            else
                            {
                                listBy = concerts.Where(x => city == (x.City).ToLower()).ToList();
                                done = true;
                            }
                            break;
                        case "s":
                            Console.Write("Kérem a helyszín nevét: ");
                            string venue = Console.ReadLine() ?? "";
                            venue = venue.ToLower().Trim();
                            if (!string.IsNullOrEmpty(venue) && venue.Any(char.IsDigit))
                            {
                                throw new BadInputException(SearchErrorType.NOT_STRING.GetErrorMessage());
                            }
                            else
                            {
                                listBy = concerts.Where(x => venue == (x.Venue).ToLower()).ToList();
                                done = true;
                            }
                            break;
                        case "h":
                            Console.Write("Kérem a hónap sorszámát: ");
                            int month;
                            bool validM = int.TryParse(Console.ReadLine(), out month);
                            if (!(validM))
                            {
                                throw new BadInputException(SearchErrorType.NOT_NUMBER.GetErrorMessage());
                            }
                            else if (month.ToString().Length > 2)
                            {
                                throw new BadInputException(SearchErrorType.TOO_LONG.GetErrorMessage());
                            }
                            else
                            {
                                listBy = concerts.Where(x => month == x.Date.Month).ToList();
                                done = true;
                            }
                            break;
                        case "n":
                            Console.Write("Kérem a nap sorszámát: ");
                            int day;
                            bool validD = int.TryParse(Console.ReadLine(), out day);
                            if (!(validD))
                            {
                                throw new BadInputException(SearchErrorType.NOT_NUMBER.GetErrorMessage());
                            }
                            else if (day.ToString().Length > 2)
                            {
                                throw new BadInputException(SearchErrorType.TOO_LONG.GetErrorMessage());
                            }
                            else
                            {
                                listBy = concerts.Where(x => day == x.Date.Day).ToList();
                                done = true;
                            }
                            break;
                    }
                } catch (BadInputException ex)
                {
                    Console.WriteLine(ex.Message);
                    done = false;
                }
            } while (!done);

            if (listBy.Any())
            {
                Console.WriteLine("\nEzek a koncertek feleltek meg a keresésnek:\n");
                foreach (var concert in listBy)
                {
                    Console.WriteLine($"Ország: {concert.Country}\nVáros: {concert.City}\nHelyszín: {concert.Venue}\n" +
                        $"Dátum: {concert.Date.Year}-{concert.Date.Month}-{concert.Date.Day}\nLátogatottság: {concert.Attendance}\n");
                }
            }
            else 
            {
                Console.WriteLine("\nSajnos nincs a keresésnek megfelelő találat!\n");
            }

        }

        public void Delilah()
        {
            Console.Clear();
            string[] asciiArtArray = new string[]
            {
                "      |\\      _,,,---,,_\r\n    z /,`.-'`'    -.  ;-;;,_\r\n     |,4-  ) )-,_. ,\\ (  `'-'\r\n    '---''(_/--'  `-'\\_)  ",
                "      |\\      _,,,---,,_\r\n   zz /,`.-'`'    -.  ;-;;,_\r\n     |,4-  ) )-,_. ,\\ (  `'-'\r\n    '---''(_/--'  `-'\\_)  ",
                "      |\\      _,,,---,,_\r\n  zzz /,`.-'`'    -.  ;-;;,_\r\n     |,4-  ) )-,_. ,\\ (  `'-'\r\n    '---''(_/--'  `-'\\_)  ",
                "      |\\      _,,,---,,_\r\n Zzzz /,`.-'`'    -.  ;-;;,_\r\n     |,4-  ) )-,_. ,\\ (  `'-'\r\n    '---''(_/--'  `-'\\_)  ",
                "      |\\      _,,,---,,_\r\nZZzzz /,`.-'`'    -.  ;-;;,_\r\n     |,4-  ) )-,_. ,\\ (  `'-'\r\n    '---''(_/--'  `-'\\_)  "

            };

            foreach (string asciiArt in asciiArtArray)
            {
                Console.WriteLine(asciiArt);
                Thread.Sleep(700);
                Console.Clear();
            }
            Console.WriteLine(asciiArtArray[4]);
            Console.WriteLine("\nFun Fact: Freddie Mercury nagyon szerette a cicákat olyannyira, hogy a pletykák szerint a Kensingtoni\n" +
                "birtokán külön szobát kapott az összes macskája. Delilah volt az a cica, akit annyira szeretett, hogy az\n" +
                "élete utolsó dalának egyikét neki írta. A dal Delilah címen található meg a Queen 1991-ben kiadott Innuendo\n" +
                "című albumán.\n");
        }

        public static List<Concert> getDataFromJson()
        {
            string jsonFile = @"tour.json";
            List<Concert> concerts = new List<Concert>();

            if (File.Exists(jsonFile))
            {
                string jsonText = File.ReadAllText(jsonFile);

                concerts = JsonConvert.DeserializeObject<List<Concert>>(jsonText) ?? [];
            }
            else
            {
                Console.WriteLine("A megadott JSON fájl nem létezik.");
            }
            return concerts;
        }
    }
}
