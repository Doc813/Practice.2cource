using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_Company
{
    public class Node
    {
        public int CurrentValue { get; set; }
        public bool Checked { get; set; }
        public int PrevNode { get; set; }
        public List<int[]> Roads = new List<int[]>();

        public Node()
        {
            CurrentValue = 999999;
            Checked = false;
        }

    }
}