using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagement
{
	public class NormalAccount : IAccount
	{
		private decimal balance;

		// Constructor để khởi tạo số dư
		public NormalAccount(decimal initialBalance)
		{
			balance = initialBalance;
		}

		// Implement phương thức CheckBalance
		public void CheckBalance()
		{
			Console.WriteLine($"Your balance is: {balance} đ");
		}

		// Implement phương thức Transfer
		public void Transfer(decimal amount)
		{
			if (amount > balance)
			{
				Console.WriteLine("Insufficient funds for transfer.");
			}
			else
			{
				balance -= amount;
				Console.WriteLine($"Transferred {amount} đ, New balance: {balance} đ");
			}
		}

		// Implement phương thức GetBalance
		public decimal GetBalance()
		{
			return balance;
		}
	}
}
