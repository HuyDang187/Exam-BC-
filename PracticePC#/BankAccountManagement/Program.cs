using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagement
{
	internal class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				// Hiển thị menu cho người dùng chọn loại tài khoản
				Console.WriteLine("Choose account type:");
				Console.WriteLine("1. Normal Account");
				Console.WriteLine("2. Exchange Account");
				Console.WriteLine("3. Exit");
				int choice = int.Parse(Console.ReadLine());

				IAccount account = null;

				if (choice == 1)
				{
					Console.WriteLine("Enter the initial balance for Normal Account:");
					decimal balance = decimal.Parse(Console.ReadLine());
					account = new NormalAccount(balance);
				}
				else if (choice == 2)
				{
					Console.WriteLine("Enter the initial balance for Exchange Account (USD):");
					decimal balance = decimal.Parse(Console.ReadLine());
					Console.WriteLine("Enter the exchange rate (USD to VND):");
					decimal exchangeRate = decimal.Parse(Console.ReadLine());
					account = new ExchangeAccount(balance, exchangeRate);
				}
				else if (choice == 3) { break; }
				else { Console.WriteLine("Invalid action. Try again."); }

				// Hiển thị các tùy chọn hành động
				while (true)
				{
					Console.WriteLine("\nChoose an action:");
					Console.WriteLine("1. Check Balance");
					Console.WriteLine("2. Transfer Money");
					Console.WriteLine("3. Exit");
					int action = int.Parse(Console.ReadLine());

					if (action == 1)
					{
						account.CheckBalance();
					}
					else if (action == 2)
					{
						Console.WriteLine("Enter the amount to transfer:");
						decimal amount = decimal.Parse(Console.ReadLine());
						account.Transfer(amount);
					}
					else if (action == 3)
					{
						break;
					}
					else
					{
						Console.WriteLine("Invalid action. Try again.");
					}
				}
			}
		}
	}
}
