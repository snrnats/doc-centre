using System;

namespace Sorted.Docs.Plugins.Contributors.Utils
{
    public static class ConsoleWriter
    {
        private const string Prefix = "::Sorted:Plugin:Contributors::  ";
        
        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Write(message);
            Console.ResetColor();
        }

        public static void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Write(message);
            Console.ResetColor();
        }

        public static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Write(message);
            Console.ResetColor();
        }

        public static void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Write(message);
            Console.ResetColor();
        }
        
        private static void Write(string message)
        {
            Console.WriteLine($"${Prefix}{message}");
        }
    }
}