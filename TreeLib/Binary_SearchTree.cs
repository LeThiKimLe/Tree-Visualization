using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace TreeLib
{
    public class Binary_SearchTree : BinaryTree
    {
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
        public NodeTree Root
        {
            get { return root; }
            set { root = value; }
        }
        public Binary_SearchTree(int num_n) : base(num_n)
        {
            N = num_n;
        }
        private void insertRec(NodeTree head, int Value)
        {
            NodeTree temp, child=new NodeTree();
            if (Value < head.Value)
            {
                if (head.hasleft == true)
                {
                    temp = head.Child.Find(x => x.isleft == true);
                    insertRec(temp, Value);
                }
                else
                {
                    head.hasleft = true;
                    child = new NodeTree(Value, head.Level + 1);
                    head.AddChild(child);
                    child.Father = head;
                    child.isleft = true;
                    if (child.Level >= Depth)
                        Depth++;
                    return;
                }
            }
            else if (Value > head.Value)
            {
                if (head.hasright == true)
                {
                    temp = head.Child.Find(x => x.isleft == false);
                    insertRec(temp, Value);
                }
                else
                {
                    head.hasright = true;
                    child = new NodeTree(Value, head.Level + 1);
                    head.AddChild(child);
                    child.Father = head;
                    child.isleft = false;
                    if (child.Level >= Depth)
                        Depth++;
                    return;
                }
            }
            
        }
        List<int> CreateRandom()
        {
            Random r = new Random();
            List<int> num = new List<int>();
            int ran;
            for (int j = 0; j < N; j++)
            {
                ran = r.Next(9, 100);
                while (num.Contains(ran))
                    ran = r.Next(9, 100);
                num.Add(ran);
            }
            return num;
        }
        public new void GenerateRandom()
        {
            List<int> num = CreateRandom();
            Generate(num);
        }
        public new void Generate(List<int> num)
        { 
            if (root == null)
            {
                root = new NodeTree(num[0], 0);
                Depth = 1;
            }
            int i = 1;
            NodeTree head = root;
            while(i<N)
            {
                insertRec(head, num[i++]);
                head = root;
            }

        }
        
        
        public void Balance()
        {
            List<int> arr = new List<int>();
            List<int> arr3 = new List<int>();
            SortedList arr2 = new SortedList();
            
            ConverttoList(root, arr);
            ListBalance(arr, 0, N - 1, arr2,0);
            int min,minVal=0;
            while(arr3.Count()!=N)
            {
                min = 100;
                foreach (DictionaryEntry item in arr2)
                {
                    if ((Int32)item.Value < min)
                    {
                        min = (Int32)item.Value;
                        minVal = (Int32)item.Key;
                    }
                }
                arr3.Add(minVal);
                arr2.Remove(minVal);

            }
            root = null;
            Generate(arr3);
        }
        
        private void ConverttoList(NodeTree head,List<int> arr)
        {
            if (head == null)
                return;
            NodeTree left = head.Child.Find(x => x.isleft == true);
            NodeTree right = head.Child.Find(x => x.isleft == false);
            ConverttoList(left, arr);
            arr.Add(head.Value);
            ConverttoList(right, arr);
        }
       
        public void ListBalance(List<int> arr, int low, int high, SortedList arr2,int i)
        {
            if (high < low)
                return;
            int mid = low + (high - low) / 2;
            arr2.Add(arr[mid],i);
            i++;
            ListBalance(arr, low, mid - 1,arr2,i);
            ListBalance(arr, mid + 1, high,arr2,i);
            
            return;
        }
    }
}