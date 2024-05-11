using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zk_Stark.Models
{
	public class Block
	{
		public int Index { get; set; }
		public string PreviousHash { get; set; }
		public Transaction Data { get; set; }
		public string Hash { get; set; }

		public Block(int index, string previousHash, Transaction data)
		{
			Index = index;
			PreviousHash = previousHash;
			Data = data;
			Hash = CalculateHash();
		}

		public string CalculateHash()
		{
			using (var sha256 = System.Security.Cryptography.SHA256.Create())
			{
				var hashData = Encoding.UTF8.GetBytes($"{Index}{PreviousHash}{Data}");
				var hash = sha256.ComputeHash(hashData);
				return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
			}
		}
	}
}
