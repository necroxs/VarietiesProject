using BlockChain;
using System;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            Chain mainChain = new Chain();
            //Test add block
            mainChain.AddBlock(new Block
            {
                data = "test",
                date_stamp = DateTime.Now.ToString(),
                owner = "nero"
            });

            mainChain.AddBlock(new Block
            {
                data = "test",
                date_stamp = DateTime.Now.ToString(),
                owner = "nero"
            });
            mainChain.AddBlock(new Block
            {
                data = "test",
                date_stamp = DateTime.Now.ToString(),
                owner = "nero"
            });
            //End Test add block

            Console.WriteLine();


        }
    }
}
