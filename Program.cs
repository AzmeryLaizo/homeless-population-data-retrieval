using System;
using static System.Console;
using System.IO;

class HomelessPopulation
// The class HomelessPopulation is the main application class. It holds the menu created to display data from the datafile.
// It also holds the different switch statements used to compute and display data from the datafile.
// The class HomelessPopByYear is a non-applicaton class with five properties and contains getter/setter methods.
{
    static int Main(string[] args)
    {
        int selection;
        bool quitting = false;

        do
        {
            selection = getUserSelection();

            try
            {
                switch (selection)
                {
                    case 1:
                        {
                            string filePath = args[0]; // Command line argument needed to supply the program with file path.
                            FileStream inFile = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                            StreamReader reader = new StreamReader(inFile);

                            int count = 0;
                            int size;
                            string record;

                            while ((record = reader.ReadLine()) != null)
                            {
                                count++;
                            }
                            WriteLine("There are {0} lines in the file.", count);
                            size = (int)inFile.Length;
                            WriteLine("The total number of characters in the file are {0}.", size);

                            WriteLine();
                            reader.Close();
                            inFile.Close();
                        }
                        break;

                    case 2:
                        {
                            const char DELIM = ',';
                            string filePath = args[0];
                            FileStream inFile = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                            StreamReader reader = new StreamReader(inFile);

                            string record;
                            string[] fields;
                            int rows = 0;
                            record = reader.ReadLine();

                            while (record != null && rows < 21) // Reads records from the file for 20 rows.
                            {
                                fields = record.Split(DELIM);
                                WriteLine("\n{0,5}{1,3}{2,-30}{3,3}{4, 10}", fields[0], "   ", fields[1], "   ", fields[2]);
                                record = reader.ReadLine();
                                rows++;
                            }

                            WriteLine();
                            reader.Close();
                            inFile.Close();
                        }
                        break;

                    case 3:
                        {
                            const char DELIM = ',';
                            string filePath = args[0];
                            FileStream inFile = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                            StreamReader reader = new StreamReader(inFile);

                            try
                            {
                                string record;
                                string headerrecord = reader.ReadLine(); // Removes the header row by reading it.
                                string[] fields;
                                int sumOne = 0;
                                int count = 0;

                                while ((record = reader.ReadLine()) != null)
                                {
                                    HomelessPopByYear pop = new HomelessPopByYear();
                                    fields = record.Split(DELIM);
                                    pop.Year = fields[0];
                                    pop.Area = fields[1];
                                    pop.HomelessEstimates = Convert.ToInt32(fields[2]);
                                    if (record.Contains("Total")) // Skips over the records where total population is already calculated.
                                    {
                                        continue;
                                    }
                                    sumOne = pop.HomelessEstimates + sumOne; // Assigns first value of population to sumOne and then adds next line. 
                                    count++;                                 // Continues doing this while the value is not null.
                                }
                                double average = sumOne / count; // Divides the sum by the number of rows to find average.
                                WriteLine("{0, 40}", "Average homeless population for years 2009 to 2012");
                                WriteLine();
                                WriteLine("{0, 25}", average.ToString("f2"));
                            }
                            catch (Exception e)
                            {
                                WriteLine(e.Message);
                            }
                            WriteLine();
                            reader.Close();
                            inFile.Close();
                        }
                        break;

                    case 4:
                        {
                            try
                            {
                                const char DELIM = ',';
                                string filePath = args[0];
                                FileStream inFile = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                                StreamReader reader = new StreamReader(inFile);

                                string record;
                                string headerrecord = reader.ReadLine();
                                string[] fields;

                                Write("Enter Year to find homeless estimates from the years { 2009, 2010, 2011 and 2012 } >> ");
                                string findYear = ReadLine();

                                WriteLine();
                                WriteLine("Please enter valid values for area. This program is case sensitive. Thank you.");
                                WriteLine();
                                WriteLine("Enter area name of your preferred location.");
                                WriteLine();
                                Write("Please select from one of these area names { Manhattan, Bronx, Brooklyn, Queens, Staten Island, Subways } >> ");
                                string findArea = ReadLine();

                                while ((record = reader.ReadLine()) != null)
                                {
                                    fields = record.Split(DELIM);
                                    HomelessPopByYear two = new HomelessPopByYear();
                                    two.Year = fields[0];
                                    two.Area = fields[1];
                                    two.HomelessEstimates = Convert.ToInt32(fields[2]);

                                    if (record.Contains("Total"))
                                    {
                                        continue;
                                    }
                                    if (two.Year == findYear) // Assigns input received from user to two.Year and uses it as a condition to filter.
                                    {
                                        if (two.Area.Contains(findArea))  // Assigns input received from user to two.Year and uses it as a condition to filter.
                                        {
                                            Array.Sort(fields);  // Sorts filtered values in ascending order.
                                            Clear();
                                            Array.Reverse(fields); // Sorts filtered values in descending order.
                                            Clear();
                                            for (int i = 0; i < 2; i++)
                                            {
                                                ++i;
                                            }
                                            WriteLine("\n{0,-5}{1,3}{2,-30}{3,3}{4, 10}", "Year", "   ", "Area", "   ", "Population");
                                            WriteLine("\n{0,-5}{1,3}{2,-30}{3,3}{4, 10}", two.Year, "   ", two.Area, "   ", two.HomelessEstimates);
                                        }
                                    }
                                }
                                WriteLine();
                                reader.Close();
                                inFile.Close();
                            }
                            catch (Exception e)
                            {
                                WriteLine(e.Message);
                            }
                        }
                        break;

                    case 5:
                        {
                            HomelessPopByYear first = new HomelessPopByYear(); // Instantiates object from non-application class HomelessPopByYear.
                            first.Id = 'A';
                            first.Year = "2009";
                            first.AvgByYear = 388.00;
                            first.HomelessEstimates = 968;
                            first.Area = "Subways";

                            HomelessPopByYear second = new HomelessPopByYear();
                            second.Id = 'B';
                            second.Year = "2010";
                            second.AvgByYear = 518.50;
                            second.HomelessEstimates = 1145;
                            second.Area = "Manhattan";

                            HomelessPopByYear third = new HomelessPopByYear();
                            third.Id = 'C';
                            third.Year = "2011";
                            third.AvgByYear = 441.33;
                            third.HomelessEstimates = 1275;
                            third.Area = "Subways";

                            HomelessPopByYear fourth = new HomelessPopByYear();
                            fourth.Id = 'D';
                            fourth.Year = "2012";
                            fourth.AvgByYear = 543.67;
                            fourth.HomelessEstimates = 1634;
                            fourth.Area = "Subways";

                            WriteLine("       Average Homeless Population by Year");
                            WriteLine("\n{0, 5}{1,10}{2,-10}{3,3}{4, 15}", "Id", "   ", "Year", "   ", "Homeless Population Average");
                            WriteLine("\n{0, 5}{1,10}{2,-10}{3,3}{4, 15}", first.Id, "   ", first.Year, "   ", first.AvgByYear.ToString("f2"));
                            WriteLine("\n{0, 5}{1,10}{2,-10}{3,3}{4, 15}", second.Id, "   ", second.Year, "   ", second.AvgByYear.ToString("f2"));
                            WriteLine("\n{0, 5}{1,10}{2,-10}{3,3}{4, 15}", third.Id, "   ", third.Year, "   ", third.AvgByYear.ToString("f2"));
                            WriteLine("\n{0, 5}{1,10}{2,-10}{3,3}{4, 15}", fourth.Id, "   ", fourth.Year, "   ", fourth.AvgByYear.ToString("f2"));
                            WriteLine();
                            WriteLine();
                            WriteLine("     Maximum Homeless Population by Year & Area");
                            WriteLine("\n{0, 5}{1,10}{2,-10}{3,3}{4, -15}{5,3}{6, 10}", "Id", "   ", "Year", "   ", "Area", "   ", "Maximum Population");
                            WriteLine("\n{0, 5}{1,10}{2,-10}{3,3}{4, -15}{5,3}{6, 10}", first.Id, "   ", first.Year, "   ", first.Area, "   ", first.HomelessEstimates);
                            WriteLine("\n{0, 5}{1,10}{2,-10}{3,3}{4, -15}{5,3}{6, 10}", second.Id, "   ", second.Year, "   ", second.Area, "   ", second.HomelessEstimates);
                            WriteLine("\n{0, 5}{1,10}{2,-10}{3,3}{4, -15}{5,3}{6, 10}", third.Id, "   ", third.Year, "   ", third.Area, "   ", third.HomelessEstimates);
                            WriteLine("\n{0, 5}{1,10}{2,-10}{3,3}{4, -15}{5,3}{6, 10}", fourth.Id, "   ", fourth.Year, "   ", fourth.Area, "   ", fourth.HomelessEstimates);
                            WriteLine();
                        }
                        break;

                    case 6: quitting = true; WriteLine("Exiting program."); break;
                    default: WriteLine($"Invalid choice = {selection}"); break;
                }
            }
            catch (Exception e) // Handles exceptions caused by the presence of no command line arguments.
            {
                WriteLine(e.Message);
                WriteLine("No arguments were passed to this program. Please provide data file location.");
                WriteLine();
            }
            WriteLine("Press <enter> to continue.");
            ReadLine();
        } while (!quitting);

        return 0;
    }

    static int getUserSelection() // Gets user input for menu.
    {
        displayMenu();
        int selection;
        string s = ReadLine();
        while (!int.TryParse(s, out selection))
        {
            displayMenu();
            s = ReadLine();
        }
        return selection;
    }

    static void displayMenu() // Displays menu items.
    {
        string[] menuChoices =
        {
            "\t1. Total Records & Characters",
            "\t2. Homeless Population Report",
            "\t3. Average Homeless Population",
            "\t4. Homeless Population Queries",
            "\t5. Summary of Homeless Population Data",
            "\t6. Exit"
        };

        Clear();
        WriteLine("\tHomeless Population Data by Year for the State of New York");
        WriteLine();

        foreach (string str in menuChoices)
        {
            WriteLine(str);
        }
    }
}

class HomelessPopByYear
// This is a non-application class which holds five properties which are called from the main application class using getters and setters. 
// The object for HomelessPopByYear is instantiated in the main application class.
{
    public string Year { get; set; }
    public string Area { get; set; }
    public int HomelessEstimates { get; set; }
    public double AvgByYear { get; set; }
    public char Id { get; set; }
}






