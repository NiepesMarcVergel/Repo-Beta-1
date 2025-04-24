using System;

class Program
{
    static void Main(string[] args)
    {
        Diary diary = new Diary();
        int choice;

        while (true)
        {
            Console.WriteLine("\nDiary Menu:");
            Console.WriteLine("1. Write a New Entry");
            Console.WriteLine("2. View All Entries");
            Console.WriteLine("3. Search Entry by Date");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter your diary entry (end with an empty line):");
                    string entry = "";
                    string line;
                    while (!string.IsNullOrEmpty(line = Console.ReadLine()))
                    {
                        entry += line + Environment.NewLine;
                    }
                    diary.WriteEntry(entry);
                    break;

                case 2:
                    diary.ViewAllEntries();
                    break;

                case 3:
                    Console.Write("Enter date to search (YYYY-MM-DD): ");
                    string date = Console.ReadLine();
                    diary.SearchByDate(date);
                    break;

                case 4:
                    return;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}