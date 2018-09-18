using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChain
{
    public class Block
    {
        public string unique_id { get; set; }
        public object data { get; set; }
        public string owner { get; set; }
        public string date_stamp { get; set; }


        public string hash { get; set; }
        public string prev_hash { get; set; }


    }
}
