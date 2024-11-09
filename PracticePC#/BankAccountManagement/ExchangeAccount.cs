using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagement
{
	public class ExchangeAccount : IAccount
	{
		private decimal balance;
		private decimal exchangeRate; // Tỷ giá hối đoái

		// Constructor để khởi tạo số dư và tỷ giá
		public ExchangeAccount(decimal initialBalance, decimal exchangeRate)
		{
			balance = initialBalance;
			this.exchangeRate = exchangeRate;
		}

		// Implement phương thức CheckBalance
		public void CheckBalance()
		{
			Console.WriteLine($"Your balance in USD is: {balance} USD");
			Console.WriteLine($"Your balance in VND is: {balance * exchangeRate} VND");
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
				Console.WriteLine($"Transferred {amount} USD, New balance: {balance} USD");
				Console.WriteLine($"New balance in VND: {balance * exchangeRate} VND");
			}
		}

		// Implement phương thức GetBalance
		public decimal GetBalance()
		{
			return balance;
		}
	}
}
