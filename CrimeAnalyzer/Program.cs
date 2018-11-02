using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            if (args.Length != 2)
            {
                Console.WriteLine("Please specify only the Crime Data file and the Crime Data Report file.");
                Console.ReadLine();
            } else
            {
                //Console.WriteLine("First Argument: " + args[0] + "Second Argument: " + args[1]);
                try
                {
                    using (var reader = new StreamReader(args[0]))
                    {
                        var crimeList = new List<CrimeData>();
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(',');

                            //Console.WriteLine("\nValues: " + values[0]);
                            if (count == 0)
                            {
                                count++;
                            }
                            else
                            {
                                var item = new CrimeData
                                {
                                    Year = Int32.Parse(values[0]),
                                    Population = Int32.Parse(values[1]),
                                    ViolentCrime = Int32.Parse(values[2]),
                                    Murder = Int32.Parse(values[3]),
                                    Rape = Int32.Parse(values[4]),
                                    Robbery = Int32.Parse(values[5]),
                                    AggravatedAssault = Int32.Parse(values[6]),
                                    PropertyCrime = Int32.Parse(values[7]),
                                    Burglary = Int32.Parse(values[8]),
                                    Theft = Int32.Parse(values[9]),
                                    MotorVehicleTheft = Int32.Parse(values[10])
                                };
                                crimeList.Add(item);
                            }


                        }
                        Console.WriteLine("Please Work: " + crimeList[0].Year);
                        Console.WriteLine("Please Work: " + crimeList[1].Year);
                        Console.WriteLine("Please Work: " + crimeList[2].Year);
                        string header = "Crime Analyzer Report\n\n";
                        string question1_2 = "Period: " + crimeList[0].Year + "-" + crimeList[crimeList.Count - 1].Year + " (" + crimeList.Count + " years)\n";
                        var years = from crimeStats in crimeList where crimeStats.Murder < 15000 select crimeStats.Year;
                        string question3 = "\nYears murders per year < 15000: ";
                        foreach (var year in years)
                        {
                            question3 += year + " ";
                        }
                        var yearsAndRobberies = from crimeStats in crimeList where crimeStats.Robbery > 500000 select new { crimeStats.Year, crimeStats.Robbery };
                        string question4 = "\nRobberies per year > 500000: ";
                        foreach (var year in yearsAndRobberies)
                        {
                            question4 += year.Year + " = " + year.Robbery + " ";
                        }
                        var violentCrimePerCapita = from crimeStats in crimeList where crimeStats.Year == 2010 select new { crimeStats.ViolentCrime, crimeStats.Population };
                        string question5 = "\nViolent crime per capita rate (2010): ";
                        foreach (var element in violentCrimePerCapita)
                        {
                            double vcpc = (double)element.ViolentCrime / element.Population;
                            Console.WriteLine(element.Population + "  " + element.ViolentCrime);
                            Console.WriteLine("vcpc: " + vcpc);
                            question5 += vcpc;
                        }
                        var avgMurderAll = crimeList.Average(x => x.Murder);
                        string question6 = "\nAverage murder per year (all years): " + avgMurderAll;
                        var avgMurderQ7 = (from crimeStats in crimeList where crimeStats.Year <= 1997 select crimeStats.Murder).Average();
                        string question7 = "Average murder per year (1994–1997): " + avgMurderQ7;
                        var avgMurderQ8 = (from crimeStats in crimeList where crimeStats.Year >= 2010 select crimeStats.Murder).Average();
                        string question8 = "Average murder per year (2010-2013): " + avgMurderQ8;
                        var minThefts = (from crimeStats in crimeList where crimeStats.Year >= 1999 && crimeStats.Year <= 2004 select crimeStats.Theft).Min();
                        string question9 = "Minimum thefts per year (1999–2004): " + minThefts;
                        var maxThefts = (from crimeStats in crimeList where crimeStats.Year >= 1999 && crimeStats.Year <= 2004 select crimeStats.Theft).Max();
                        string question10 = "Maximum thefts per year (1999–2004): " + maxThefts;
                        var orderMotorThefts = from crimeStats in crimeList orderby crimeStats.MotorVehicleTheft descending select crimeStats.Year;
                        var maxMotorThefts = orderMotorThefts.FirstOrDefault();
                        string question11 = "Year of highest number of motor vehicle thefts: " + maxMotorThefts;
                        try
                        {
                            using (StreamWriter sw = new StreamWriter(args[1]))
                            {
                                sw.WriteLine(header);
                                sw.WriteLine(question1_2);
                                sw.WriteLine(question3);
                                sw.WriteLine(question4);
                                sw.WriteLine(question5);
                                sw.WriteLine(question6);
                                sw.WriteLine(question7);
                                sw.WriteLine(question8);
                                sw.WriteLine(question9);
                                sw.WriteLine(question10);
                                sw.WriteLine(question11);
                            }
                        }
                        catch (Exception Ex)
                        {
                            Console.WriteLine(Ex.ToString());
                            Environment.Exit(0);
                            Console.ReadLine();
                        }
                    }
                } catch (Exception Ex)
                {
                    Console.WriteLine(Ex.ToString());
                    Environment.Exit(0);
                    Console.ReadLine();
                }
            }
            //Console.ReadLine();
        }
    }
}
