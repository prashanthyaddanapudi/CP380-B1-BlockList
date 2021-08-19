using System;
using CP380_B1_BlockList.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace CP380_B1_BlockList
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var myChain = new BlockList();

            List<Payload> data = new()
            { 
                new Payload("user", TransactionTypes.GRANT, 10, null), 
                new Payload("user", TransactionTypes.BUY, 10, "10C"),
            };

            var block = new Block(DateTime.Now, "", data);

            myChain.AddBlock(block);

            var json = JsonSerializer.Serialize(myChain.Chain);
            Console.WriteLine(PrettyJson.MakePretty(json));

            Console.WriteLine($"Is the chain valid --> {myChain.IsValid()}");
        }
    }
}
