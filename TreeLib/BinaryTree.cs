using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeLib
{
    public class BinaryTree : Tree
    {
        List<int> levellimit;
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
        public BinaryTree(int num_n, int num_depth)
        {
            N = num_n;
            Depth = num_depth;
            root = new NodeTree();
            hasroot = false;
            LevelLimit(num_depth);
        }
        public BinaryTree(int num_n)
        {
            N = num_n;
            hasroot = false;
        }
        private void LevelLimit(int depthtree)
        {
            levellimit = new List<int>();
            levellimit.Add(1);
            for (int i = 1; i < depthtree; i++)
                levellimit.Add(levellimit[i - 1] * 2);
        }
        public void Init(NodeTree head)
        {
            root = head;
        }
        public void GenerateRandom()
        {
            List<NodeTree> list = new List<NodeTree>();
            Random r = new Random();
            List<int> num = new List<int>();
            int ran = 1;
            num.Add(ran);
            for (int j = 1; j < N; j++)
            {
                ran = r.Next(1, 100);
                while (num.Contains(ran))
                    ran = r.Next(1, 100);
                num.Add(ran);
            }

            double index;
            index = Math.Pow(2, Depth) - 1;
            if (index == N)
            {
                GeneratePerfect(num);
            }
            else
            {
                GenerateOne(num, list);
                if (N > Depth)
                    GenerateBinary(num, list);
            }

        }
        private void GeneratePerfect(List<int> num)
        {
            NodeTree head = new NodeTree();
            NodeTree first = new NodeTree(num[0], 0);
            Queue<NodeTree> queue = new Queue<NodeTree>();
            NodeTree second;
            hasroot = true;
            queue.Enqueue(first);
            int i = 1;
            while (queue.Count != 0)
            {
                queue.Dequeue();
                if (first.Level == Depth - 1)
                    continue;
                for (int j = 0; j < 2; j++)
                {
                    second = new NodeTree(num[i++], first.Level + 1);
                    first.AddChild(second);
                    second.Father = first;
                    queue.Enqueue(second);
                }
                if (first.Level == 0)
                    root = first;
                if (queue.Count != 0)
                    first = queue.Peek();
            }
            
        }
        private void GenerateOne(List<int> num, List<NodeTree> list)
        {

            NodeTree first = new NodeTree(num[0], 0);
            NodeTree second;
            root = first;
            int i = 1;
            while (i < Depth)
            {
                second = new NodeTree(num[i++], first.Level + 1);
                first.AddChild(second);
                second.Father = first;
                if (first.Level == 0)
                    root = first;
                list.Add(first);
                first = second;
            }
        }
        private void GenerateBinary(List<int> num, List<NodeTree> list)
        {
            int count = Depth,i=Depth;
            int min;
            NodeTree first, second;
            while(count<N)
            {
                min = IMin(list);
                second = new NodeTree(num[i++], list[min].Level + 1);
                list[min].AddChild(second);
                second.Father = list[min];
                list.Add(second);
                count++;
            }
            
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