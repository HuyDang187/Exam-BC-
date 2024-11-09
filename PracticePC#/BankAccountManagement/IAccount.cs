using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagement
{
	public interface IAccount
	{
		void CheckBalance();
		void Transfer(decimal amount);
		decimal GetBalance();
	}
}
