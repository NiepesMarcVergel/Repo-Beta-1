using System;

class Program
{
    static void Main(string[] args)
    {
        Diary diary = new Diary();

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n==========> DIARY MENU <==========");
            Console.ResetColor();
            Console.WriteLine("1. Write a New Entry");
            Console.WriteLine("2. View All Entries");
            Console.WriteLine("3. Search Entry by Date");
            Console.WriteLine("4. Exit");
            Console.WriteLine("================================");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[Invalid input. Please enter a number.]\n");
                Console.ResetColor();
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("=== WRITE NEW ENTRY ===");
                    Console.WriteLine("Enter your diary entry. Finish with an empty line:\n");

                    string entry = "";
                    string line;
                    while (!string.IsNullOrEmpty(line = Console.ReadLine()))
                    {
                        entry += line + Environment.NewLine;
                    }

                    if (string.IsNullOrWhiteSpace(entry))
                    {
                        Console.WriteLine("[Entry was empty. Nothing saved.]\n");
                    }
                    else
                    {
                        diary.WriteEntry(entry.Trim());
                    }
                    break;

                case 2:
                    diary.ViewAllEntries();
                    break;

                case 3:
                    Console.Write("\nEnter date to search (YYYY-MM-DD): ");
                    string date = Console.ReadLine();
                    if (DateTime.TryParse(date, out _))
                    {
                        diary.SearchByDate(date);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[Invalid date format. Use YYYY-MM-DD.]\n");
                        Console.ResetColor();
                    }
                    break;

                case 4:
                    Console.WriteLine("\n[Exiting Diary. Goodbye!]");
                    return;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[Invalid choice. Please select 1–4.]\n");
                    Console.ResetColor();
                    break;
            }
        }
    }
}
