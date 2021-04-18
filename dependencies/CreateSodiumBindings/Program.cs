using System;
using CppSharp;

namespace CreateSodiumBindings
{
    public static class Program
    {
        public static void Main(string[] _)
        {
            ConsoleDriver.Run(new SodiumBindingLibrary());
        }
    }
}
