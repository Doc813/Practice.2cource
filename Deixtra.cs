using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_Company
{
    public class Deixtra
    {

        public Node[] nodes { get; private set; }

        public Node BeginPoint { get; private set; }

        public Deixtra(Node[] pointsOfgrath)
        {
            nodes = pointsOfgrath;
        }

        public void Run(int beginp)
        {
            Step(beginp);
            for (int i = 0; i < nodes[beginp].Roads.Count; i++)
            {
                if (nodes[nodes[beginp].Roads[i][0]].Checked != true)
                {
                    Run(nodes[beginp].Roads[i][0]);
                }
            }

        }

        public void Step(int beginpoint)
        {
            for (int i = 0; i < nodes[beginpoint].Roads.Count(); i++)
            {
                if (nodes[beginpoint].CurrentValue + nodes[beginpoint].Roads[i][1] < nodes[nodes[beginpoint].Roads[i][0]].CurrentValue)
                {
                    nodes[nodes[beginpoint].Roads[i][0]].CurrentValue = nodes[beginpoint].Roads[i][1] + nodes[beginpoint].CurrentValue;
                    nodes[nodes[beginpoint].Roads[i][0]].PrevNode = beginpoint;
                    nodes[nodes[beginpoint].Roads[i][0]].Checked = false;
                }
            }
            nodes[beginpoint].Checked = true;
        }

    }
}