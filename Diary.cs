using System;
using System.IO;
using System.Text;

public class Diary
{
    private readonly string filePath = "diary.txt";

    public void WriteEntry(string text)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            writer.WriteLine(text.Trim());
            writer.WriteLine(new string('-', 30));
        }
        Console.WriteLine("Entry have been saved successfully.\n");
    }

    public void ViewAllEntries()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No diary entries found.\n");
            return;
        }

        string content = File.ReadAllText(filePath);
        Console.WriteLine("\n=== All Diary Entries ===\n");
        Console.WriteLine(content);
    }

    public void SearchByDate(string date)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No diary entries found.\n");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        bool matchFound = false;
        bool show = false;

        Console.WriteLine($"\n===> Entries on {date} <===\n");

        foreach (string line in lines)
        {
            if (line.StartsWith("Date: ") && line.Contains(date))
            {
                matchFound = true;
                show = true;
                Console.WriteLine(line);
            }
            else if (show)
            {
                if (line.StartsWith("-"))
                {
                    show = false;
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(line);
                }
            }
        }

        if (!matchFound)
        {
            Console.WriteLine("No entries found for that date.\n");
        }
    }
}
