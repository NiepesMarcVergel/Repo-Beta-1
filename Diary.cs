using System;
using System.IO;

public class Diary
{
    private readonly string filePath = "diary.txt";

    public void WriteEntry(string text)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            writer.WriteLine(text);
            writer.WriteLine("---");
        }
        Console.WriteLine("Entry saved.");
    }

    public void ViewAllEntries()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No diary entries found.");
            return;
        }

        string content = File.ReadAllText(filePath);
        Console.WriteLine("\nAll Entries:\n");
        Console.WriteLine(content);
    }

    public void SearchByDate(string date)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No diary entries found.");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        bool found = false;
        foreach (string line in lines)
        {
            if (line.StartsWith("Date: ") && line.Contains(date))
            {
                found = true;
                Console.WriteLine(line);
            }
            else if (found)
            {
                if (line == "---")
                {
                    found = false;
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}