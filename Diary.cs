using System;
using System.IO;

public class Diary
{
    private readonly string filePath = "diary.txt";

    public void WriteEntry(string text)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                writer.WriteLine(text);
                writer.WriteLine("---");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n[Entry saved successfully.]\n");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[Error saving entry: {ex.Message}]\n");
            Console.ResetColor();
        }
    }

    public void ViewAllEntries()
    {
        Console.Clear();
        Console.WriteLine("===> VIEW ALL ENTRIES <===\n");

        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("[No diary entries found.]\n");
                return;
            }

            string content = File.ReadAllText(filePath);
            Console.WriteLine(content);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[Error reading entries: {ex.Message}]\n");
            Console.ResetColor();
        }
    }

    public void SearchByDate(string date)
    {
        Console.Clear();
        Console.WriteLine($"===> SEARCH RESULTS FOR {date} <===\n");

        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("[No diary entries found.]\n");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            bool found = false;
            foreach (string line in lines)
            {
                if (line.StartsWith("Date: ") && line.Contains(date))
                {
                    found = true;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(line);
                    Console.ResetColor();
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

            if (!found)
            {
                Console.WriteLine("[No entries found for the given date.]\n");
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[Error searching entries: {ex.Message}]\n");
            Console.ResetColor();
        }
    }
}
