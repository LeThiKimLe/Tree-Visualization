using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeLib
{
    public class NodeTree
    {
        private int name;
        private NodeTree father;
        public List<NodeTree> Child=new List<NodeTree>();
        public int num_child;
        private int level;
        public bool hasfather;
        public bool hasleft = false;
        public bool hasright = false;
        public bool isleft = true;

        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        public int Value
        {
            get { return name; }
            set { name = value; }
        }
        public void AddChild(NodeTree son)
        {
            Child.Add(son);
            num_child = Child.Count();
           
        }
        public void AddChild(int value)
        {
            NodeTree temp = new NodeTree(value, this.Level + 1);
            this.Child.Add(temp);
            num_child = Child.Count(); 
        }
        public void DeleteChild(NodeTree son)
        {
            this.Child.Remove(son);
            num_child--;
        }

        public NodeTree Father
        {
            get 
            {
                if (hasfather == true)
                    return father;
                else
                    return null;
            }
            set
            {
                if (hasfather == false)
                {
                    father = value;
                    hasfather = true;
                }
                else
                    return;
            }
        }
        public NodeTree() { }
        public NodeTree(int Nodename,int Nodelevel)
        {
            Value = Nodename;
            Level = Nodelevel;
        }
    }
}