using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace BlockChain
{
    public class Chain
    {
        public List<Block> block_chain { get; set; }
        public Chain()
        {
            block_chain = new List<Block>();
            block_chain.Add(new Block
            {
                unique_id = "1",
                data = "GENESIS",
                owner = "SYSTEM",
                date_stamp = DateTime.Now.ToString(),
                hash = "#",
                prev_hash = "#"

            });
        }
        public void AddBlock(Block blk)
        {
            if (block_chain.Count > 0)
            {
                blk.unique_id = Guid.NewGuid().ToString();
                blk.prev_hash = block_chain[block_chain.Count - 1].hash;
                blk.hash = ComputeSha256Hash(ConcatData(blk));
                this.block_chain.Add(blk);
            }
        }

        public ResultReport isValid()
        {
            ResultReport result = new ResultReport();
            for (var i = 0; i < block_chain.Count; i++)
            {
                if (i > 0)
                {
                    if(block_chain[i].hash != ComputeSha256Hash(ConcatData(block_chain[i])))
                    {
                        result.status = false;
                        result.message = "Chain is invalid, block number "+ (i + 1) + "'s data has been changed.";
                        result.invalid_block = (i + 1)+"";
                        return result;
                    }

                    if(block_chain[i].prev_hash != block_chain[i - 1].hash)
                    {
                        result.status = false;
                        result.message = "Chain is invalid, block number " + (i + 1) + "'s data has been changed.";
                        result.invalid_block = (i + 1) + "";
                        return result;
                    }
                }
            }
            result.status = true;
            result.message = "Chain is valid";
            return result;
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private string ConcatData(Block blk)
        {
            var property = blk.GetType().GetProperties();
            string concatText = string.Join("-", property.ToList().Where(x=>x.Name != "hash").Select(x => x.GetValue(blk)).ToArray());
            return concatText;
        }
    }
}
