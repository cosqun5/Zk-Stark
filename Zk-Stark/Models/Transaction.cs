using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zk_Stark.Models
{
	public class Transaction
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FinCode { get; set; }
		public decimal Amount { get; set; }
		public string CardNumber { get; set; }

		public override string ToString()
		{
			// Bu metod, Transaction obyektinin string təmsilini qaytarır ki, hash hesablanarkən istifadə edilsin.
			return $"{FirstName} {LastName} {FinCode} {Amount} {CardNumber}";
		}
	}
}
