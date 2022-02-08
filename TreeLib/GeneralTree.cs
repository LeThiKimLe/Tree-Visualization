using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeLib
{
    public class GeneralTree : Tree
    {
        public int maxlevel=0;
        public string tt;
        public int N
        {
            get { return n; }
            set { n = value; }
        }
        public int Depth
        {
            get { return depth; }
            set { depth = value; }
        }
        public GeneralTree(int num_n,int num_depth)
        {
            N = num_n;
            Depth = num_depth;
            root = new NodeTree();
            hasroot = false;
        }
        public void Init(NodeTree head)
        {
            root = head;
        }
        public void GenerateRandom()
        {
            Random r = new Random();
            List<int> num = new List<int>();
            int count = 0, ran = 1;
            num.Add(ran);
            for (int j = 1; j < N; j++)
            {
                ran = r.Next(1, 100);
                while (num.Contains(ran))
                    ran = r.Next(1, 100);
                num.Add(ran);
            }
            int divide = (N - 1) / (Depth - 1);
            int i = 1;
            List<NodeTree> list = new List<NodeTree>();
            NodeTree head = new NodeTree();
            NodeTree first = new NodeTree(num[0], 0);
            Stack<NodeTree> stack = new Stack<NodeTree>();
            NodeTree second;
            hasroot = true;
            stack.Push(first);
            count = 1;
            int child = 0;
            while (stack.Count != 0)
            {
                stack.Pop();
                list.Add(first);
                if (first.Level == 0)
                    child = r.Next(1, divide);
                else if (first.Level != Depth - 1)
                {
                    if (count < N)
                        child = r.Next(0, divide);
                }
                else if (first.Level == Depth - 1)
                    continue;
                count = count + child;
                if (count >= N)
                {
                    child = child - count + N;
                    count = N;
                }

                for (int j = 0; j < child; j++)
                {
                    second = new NodeTree(num[i++], first.Level + 1);
                    first.AddChild(second);
                    second.Father = first;
                    stack.Push(second);
                }
                if (first.Level == 0)
                    head = first;
                if (stack.Count != 0)
                    first = stack.Peek();
            }
            int min;
            while (list.Count != N)
            {
                min = IMin(list);
                second = new NodeTree(num[i++], list[min].Level + 1);
                list[min].AddChild(second);
                second.Father = list[min];
                list.Add(second);
            }
            root = head;

        }
        private int IMin(List<NodeTree> T)
        {
            int imin = 0;
            int j;
            for (j = 0; j < T.Count; j++)
            {
                if ((T[j].num_child < T[imin].num_child) && T[j].Level < Depth - 1)
                    imin = j;
            }
            return imin;
        }
    }
}