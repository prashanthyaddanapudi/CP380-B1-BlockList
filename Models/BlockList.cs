using System;
using System.Collections.Generic;
using System.Linq;

namespace CP380_B1_BlockList.Models
{
    public class BlockList
    {
        public IList<Block> Chain { get; set; }

        public int Difficulty { get; set; } = 2;

        public BlockList()
        {
            Chain = new List<Block>();
            MakeFirstBlock();
        }

        public void MakeFirstBlock()
        {
            var block = new Block(DateTime.Now, null, new List<Payload>());
            block.Mine(Difficulty);
            Chain.Add(block);
        }

        public void AddBlock(Block block)
        {
            var previousBlock = Chain.Last();
            block.PreviousHash = previousBlock.Hash;
            block.Mine(Difficulty);
            Chain.Add(block);
        }

        public bool IsValid()
        {

            if (Chain[0].fetchDifficulty() != Difficulty)
            {
                return false;
            } 

            for (int i = 1; i < Chain.Count(); i++)
            {
                if (Chain[i - 1].Hash != Chain[i].PreviousHash || Chain[i].fetchDifficulty() != Difficulty)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
