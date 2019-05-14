using System;

namespace IATM
{
    class Program
    {

        static void Main(string[] args)
        {
            String command;
            var ATM = new ATM();
            do
            {
                command = Console.ReadLine();

            } while (ATM.Parse(command));
        }


    }
}
