using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zk_Stark.Models
{
	public class Blockchain
	{
		public List<Block> chain;

		public Blockchain()
		{
			this.chain = new List<Block>();
			Block genesisBlock = new Block(0, "0", new Transaction { FirstName = "Genesis", LastName = "Block", FinCode = "00000", Amount = 0, CardNumber = "0000000000000000" });
			this.chain.Add(genesisBlock);
		}

		public Block CreateNewBlock(int proof, string previousHash, Transaction data)
		{
			var block = new Block(this.chain.Count, previousHash, data);
			this.chain.Add(block);
			return block;
		}

		public bool IsValid()
		{
			for (int i = 1; i < this.chain.Count; i++)
			{
				var current = this.chain[i];
				var previous = this.chain[i - 1];

				if (current.PreviousHash != previous.Hash || current.Hash != current.CalculateHash())
					return false;
				// Yeni blokun hash'i, yeni blokun məlumatlarına görə hesablanmalıdır
				if (current.Hash != current.CalculateHash())
					return false;

				// ZK-STARK doğrulamasını əlavə edirik
				if (!ZKStark.VerifyBlockHash(previous, current))
					return false;
			}
			return true;
		}
	}

}
