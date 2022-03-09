using System;
using System.Collections.Generic;

namespace L06.MoneyTransactions
{
    class BalanceOverflowException : Exception
    {
        public BalanceOverflowException(string msg) : base(msg) { }
    }

    internal class Program
    {
        private static Dictionary<int, double> bankAccounts;

        static void Main(string[] args)
        {
            bankAccounts = new Dictionary<int, double>();

            string[] bankAccountsInfo = Console.ReadLine().Split(',');
            foreach (string bankAccount in bankAccountsInfo)
            {
                string[] data = bankAccount.Split('-');
                bankAccounts[int.Parse(data[0])] = double.Parse(data[1]);
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] commands = input.Split();

                try
                {
                    CheckInput(commands[0]);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Enter another command");
                    input = Console.ReadLine();
                }

                if (commands[0] == "Deposit")
                {
                    try
                    {
                        Deposit(int.Parse(commands[1]), double.Parse(commands[2]));
                        Console.WriteLine($"Account {int.Parse(commands[1])} has new balance: {bankAccounts[int.Parse(commands[1])]:f2}");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        Console.WriteLine("Enter another command");
                        input = Console.ReadLine();
                    }
                }
                else if (commands[0] == "Withdraw")
                {
                    try
                    {
                        Withdraw(int.Parse(commands[1]), double.Parse(commands[2]));
                        Console.WriteLine($"Account {int.Parse(commands[1])} has new balance: {bankAccounts[int.Parse(commands[1])]:f2}");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (BalanceOverflowException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        Console.WriteLine("Enter another command");
                        input = Console.ReadLine();
                    }
                }
            }
        }

        private static void Withdraw(int account, double sum)
        {
            try
            {
                CheckAccountExistance(account);
            }
            catch (ArgumentException)
            {
                throw;
            }

            try
            {
                CheckBalanceOverflow(account, sum);
            }
            catch (BalanceOverflowException)
            {
                throw;
            }

            bankAccounts[account] -= sum;
        }

        private static void Deposit(int account, double sum)
        {
            try
            {
                CheckAccountExistance(account);
            }
            catch (ArgumentException)
            {
                throw;
            }

            bankAccounts[account] += sum;
        }

        private static void CheckInput(string command)
        {
            if (command != "Deposit" && command != "Withdraw")
            {
                throw new ArgumentException("Invalid command!");
            }
        }

        private static void CheckBalanceOverflow(int account, double sum)
        {
            if (sum > bankAccounts[account])
            {
                throw new BalanceOverflowException("Insufficient balance!");
            }
        }

        private static void CheckAccountExistance(int account)
        {
            if (!bankAccounts.ContainsKey(account))
            {
                throw new ArgumentException("Invalid account!");
            }
        }
    }
}
