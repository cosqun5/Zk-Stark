

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zk_Stark.Models;


// Bu sınıf SHA-256 hashing algoritmini temsil edir
public static class SHA256
{
	// Bu metod, hash'i hesablayır
	public static byte[] ComputeHash(byte[] data)
	{
		using (var hash = Create())
		{
			return hash.ComputeHash(data);
		}
	}

	// Bu metod, hash algoritmasının örnünü yaradır
	public static System.Security.Cryptography.SHA256 Create()
	{
		return System.Security.Cryptography.SHA256.Create();
	}
}



public class ZKStark
{
	// Bu metod, verilmiş blok üçün ZK-STARK doğrulamasını həyata keçirir
	public static bool VerifyBlockHash(Block previousBlock, Block currentBlock)
	{
		// Burada sadə bir nümunə göstərilir. Real tətbiqat daha mürəkkəb olardı.
		string dataToVerify = $"{currentBlock.Index}{currentBlock.PreviousHash}{currentBlock.Data}";
		string calculatedHash = CalculateHash(dataToVerify);

		// Hash dəyərini yoxlayırıq
		return calculatedHash == currentBlock.Hash;
	}

	// Hash hesablayan köməkçi metod
	private static string CalculateHash(string input)
	{
		using (var sha256 = System.Security.Cryptography.SHA256.Create())
		{
			byte[] inputBytes = Encoding.UTF8.GetBytes(input);
			byte[] hashBytes = sha256.ComputeHash(inputBytes);
			return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
		}
	}
}


// Bu proqramın giriş nöqtəsi
class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Blockchain demo başladı!");
		Blockchain blockchain = new Blockchain();


        Console.Write("Adınızı daxil edin : ");
        string  FirstName = Console.ReadLine();


		Console.Write("Soyadınızı daxil edin : ");
		string LastName = Console.ReadLine();

		Console.Write("Fin Kodunuzu  daxil edin : ");
		string FinCode = Console.ReadLine();

		Console.Write("Məbləği  daxil edin : ");
		decimal Amount = decimal.Parse(Console.ReadLine());

		Console.Write("kart Nömrənizi  daxil edin : ");
		string CardNumber = Console.ReadLine();
		var transaction1 = new Transaction { FirstName = FirstName, LastName = LastName, FinCode = FinCode, Amount = Amount, CardNumber = CardNumber };
		//var transaction2 = new Transaction { FirstName = "Mehemmed", LastName = "Hüseynov", FinCode = "FGHIJ67890", Amount = 200.75m, CardNumber = "6543210987654321" };

		blockchain.CreateNewBlock(123, blockchain.chain.Last().Hash, transaction1);
        Console.WriteLine("Birinci blok yaradildi");
  //      blockchain.CreateNewBlock(124444, blockchain.chain.Last().Hash, transaction2);
		//Console.WriteLine("Ikinci blok yaradildi");


		if (blockchain.IsValid())
		{
			Console.WriteLine("Blockchain doğrudur!");
		}
		else
		{
			Console.WriteLine("Blockchain yanlışdır!");
		}
	}
}

