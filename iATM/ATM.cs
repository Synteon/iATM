using System;
using System.Linq;

namespace IATM
{
    public class ATM
    {
        public int hundred, fifty, twenty, ten, five, one;

        public ATM()
        {
            this.Restock();
        }

        private void Restock()
        {
            hundred = 10;
            fifty = 10;
            twenty = 10;
            ten = 10;
            five = 10;
            one = 10;
        }

        public Boolean Parse(String command)
        {
            try
            {
                switch (command[0])
                {
                    case 'Q':
                        return false;
                    case 'W':
                        //Grab the actual number
                        this.Withdraw(Convert.ToInt32(command.Split('$')[1]));
                        break;
                    case 'I':
                        //Strip out the command and send array of numbers to grab
                        var denominations = command.Split(' ');
                        denominations = denominations.Skip(1).ToArray();
                        this.Remaining(denominations);
                        break;
                    case 'R':
                        this.Restock();
                        this.MachineBalance();
                        break;
                    default:
                        Console.WriteLine("Failure: Invalid Command");
                        break;

                }
            }
            catch
            {
                Console.WriteLine("Failure: Invalid Command");
            }

            return true;
        }

        private void Withdraw(int number)
        {
            var dispensed = number;
            int hundreds = number / 100;
            number %= 100;
            int fifties = number / 50;
            number %= 50;
            int twenties = number / 20;
            number %= 20;
            int tens = number / 10;
            number %= 10;
            int fives = number / 5;
            int ones = number % 5;

            //Check if any are less than 0, if so we can't dispense the funds
            if ((hundred - hundreds < 0) || (fifty - fifties < 0) || (twenty - twenties < 0) || (ten - tens < 0) || (five - fives < 0) || (one - ones < 0))
            {
                Console.WriteLine("Failure: insufficient funds");
            }
            else
            {
                hundred -= hundreds;
                fifty -= fifties;
                twenty -= twenties;
                ten -= tens;
                five -= fives;
                one -= ones;
                Console.WriteLine("Success: Dispensed $" + dispensed);
                this.MachineBalance();
            }

        }

        private void Remaining(String[] denominations)
        {


            foreach (var denomination in denominations)
            {
                switch (denomination)
                {
                    case "$100":
                        Console.WriteLine("$100 - " + hundred);
                        break;
                    case "$50":
                        Console.WriteLine("$50 - " + fifty);
                        break;
                    case "$20":
                        Console.WriteLine("$20 - " + twenty);
                        break;
                    case "$10":
                        Console.WriteLine("$10 - " + ten);
                        break;
                    case "$5":
                        Console.WriteLine("$5 - " + five);
                        break;
                    case "$1":
                        Console.WriteLine("$1 - " + one);
                        break;
                }
            }
        }

        private void MachineBalance()
        {
            Console.WriteLine("Machine Balance:");
            var denominations = new string[] { "$100", "$50", "$20", "$10", "$5", "$1" };
            this.Remaining(denominations);
        }
    }
}
