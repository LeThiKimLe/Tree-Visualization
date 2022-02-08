using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using TreeLib;
namespace Ultility
{
    public class GraphicsTree
    {
        private int n;
        private int depth;
        protected bool hasroot = false;

        protected List<OvalPictureBox> nod;
        protected OvalPictureBox root=new OvalPictureBox();
        
        public Label notice;
        public Panel panel;
        public PictureBox picturebox;
        
        protected int currentNum = 0;
        protected int[] level_ycoodinate;
        protected int clickcount = 1;
        protected int temp1, temp2;
        public bool confirm = false;
        public bool isBST=false;
        
        public GraphicsTree() { }
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
        public virtual void AddNode(int Value, int Level,int middle=0,bool left=true)
        {
            OvalPictureBox temp = new OvalPictureBox();
            nod.Add(temp);
            currentNum=nod.Count;
            temp.Level = Level;
            temp.Value = Value;
            ShowImage(ref temp,null,middle,left);
            this.panel.Controls.Add(temp);
            temp.BringToFront();
            if (Level == 0)
            {
                root = temp;
                hasroot = true;
            }
            nod[currentNum - 1] = temp;
            temp.Invalidate();
        }
        public virtual void AddNode(NodeTree b)
        {
            OvalPictureBox temp = new OvalPictureBox();
            nod.Add(temp);
            temp.Root = b;
            currentNum = nod.Count;
            ShowImage(ref temp,b);
            this.panel.Controls.Add(temp);
            temp.BringToFront();
            if (b.Level == 0)
            {
                root = temp;
                hasroot = true;
            }
            nod[currentNum - 1] = temp;
            temp.Invalidate();
        }
        public virtual void AddNode(int value) { }
        public virtual void Update(ref int nodenum, ref int depth) { }
        public void ShowImage(ref OvalPictureBox e,NodeTree b=null,int middle=0,bool left=true)
        {
            int x;
            int y = level_ycoodinate[e.Level];
            e.Y_Level = level_ycoodinate[e.Level];
            e.g = picturebox.CreateGraphics();
            Random r = new Random();
            if (b != null)
                if (b.hasfather && isBST==false)
                {
                    e.Addrelation(nod[nod.FindIndex(node => node.Root == b.Father)]);
                    if (e.father.left == true)
                    {
                        x = r.Next(e.father.Location.X - 80, e.father.Location.X-20);
                        e.father.left = false;
                    }
                    else
                    {
                        x = r.Next(e.father.Location.X + 50, e.father.Location.X + 100);
                        e.father.left = true;
                    }
                }
                else if(b.hasfather && isBST == true)
                {
                    e.Addrelation(nod[nod.FindIndex(node => node.Root == b.Father)]);
                    if (e.isleft == true)
                        x = r.Next(e.father.Location.X - 80, e.father.Location.X - 20);
                    else
                        x = r.Next(e.father.Location.X + 50, e.father.Location.X +100);
                }
                else
                {
                    x = 300;
                }
            else
            {
                x = r.Next(130, 500);
            }
            if(middle!=0)
            {
                if (left==true)
                    x = r.Next(middle- 80, middle-20);
                else
                    x = r.Next(middle+50, middle+100);
            }
            Point position = new Point(x, y);
            nod[currentNum - 1].Location = position;
            nod[currentNum - 1].TargetPoint = new Point(position.X + 20, position.Y + 20);
            nod[currentNum - 1].Visible = true;
        }
        protected void Level_Divide(int heigh)
        {
            level_ycoodinate = new int[heigh];
            for (int j = 0; j < heigh; j++)
                level_ycoodinate[j] = (j + 1) * 450 / (heigh + 1);
        }
        public virtual void LevelOrderTraversal()
        {
            if (root == null)
                return;
            notice.Text = "";
            Queue<OvalPictureBox> q = new Queue<OvalPictureBox>();
            q.Enqueue(root);
            root.OnQueue();
            Wait(1000);
            while (q.Count != 0)
            {
                int m = q.Count;
                while (m > 0)
                {
                    OvalPictureBox p = q.Peek();
                    q.Dequeue();
                    p.OutQueue();
                    notice.Text += " " + p.Value;
                    Wait(1000);
                    for (int j = 0; j < p.Child.Count; j++)
                    {
                        q.Enqueue(p.Child[j]);
                        p.Child[j].OnQueue();
                        Wait(1000);
                    }
                    m--;
                }
            }
        }
        public virtual void DFS(int signal) { }
        public virtual void Balance() { }
        public virtual void FindPath(int value)
        {
            OvalPictureBox nodefound = new OvalPictureBox();
            bool found = false;

            if (root == null)
                return;
            if (value == root.Value)
            {
                notice.Text = root.Value.ToString();
                return;
            }
            notice.Text = "";
            Queue<OvalPictureBox> q = new Queue<OvalPictureBox>();
            q.Enqueue(root);
            root.OnQueue();
            Wait(1000);
            int count = 1;
            while (q.Count != 0 || found == false)
            {
                int num = q.Count;
                while (num > 0 || found == false)
                {
                    OvalPictureBox p = q.Peek();
                    q.Dequeue();
                    p.OutQueue();
                    
                    Wait(1000);
                    for (int j = 0; j < p.Child.Count; j++)
                    {
                        q.Enqueue(p.Child[j]);
                        p.Child[j].OnQueue();
                        Wait(1000);
                        if (p.Child[j].Value == value)
                        {
                            found = true;
                            nodefound = p.Child[j];
                            goto Found;
                        }
                        count++;
                    }
                    if (count == N)
                        goto NotFound;
                    num--;
                }
            }
            if (found == false)
            {
                notice.Text = "Node not found";
                Reset();
                return;
            }
        Found:
            for (int i = 0; i < 8; i++)
            {
                nodefound.choose();
                Wait(200);
                nodefound.unchoose();
                Wait(200);
            }
            Reset();
            Wait(1000);
            PrintPath(nodefound);
            return;
        NotFound:
            notice.Text = "Node can not be found. Try another node";
            return;

        }
        protected void PrintPath(OvalPictureBox des)
        {
            OvalPictureBox temp;
            notice.Text = "";
            Stack<OvalPictureBox> stack = new Stack<OvalPictureBox>();
            while (des.hasFather == true)
            {
                stack.Push(des);
                des = des.father;
            }
            notice.Text = des.Value.ToString();
            des.OutQueue();
            Wait(1000);
            while (stack.Count != 0)
            {
                temp = stack.Pop();
                temp.OutQueue();
                notice.Text += "->" + temp.Value.ToString();
                Wait(1000);
            }
        }
        public void Wait(int time)
        {
            Thread thread = new Thread(delegate ()
            {
                System.Threading.Thread.Sleep(time);
            });
            thread.Start();
            while (thread.IsAlive)
                Application.DoEvents();
        }
        public virtual bool CreateTree(int nodenum, int depthtree)
        {
            Clear();
            N = nodenum;
            Depth = depthtree;
            if (N >= Depth)
            {
                nod = new List<OvalPictureBox>();
                Level_Divide(Depth);
                return true;
            }
            else
                return false;
        }
        public virtual void GenerateRandom() { }
        public virtual void GenerateRandom(int n) { }

        public virtual int CheckNode(int name, int level)
        {
            for (int k = 0; k < nod.Count; k++)
                if (nod[k].Value == name)
                {
                    return 1;
                }
            if (nod.Count == n)
            {
               return 2;
            }
            if (level == 0)
            {
                if (hasroot == true)
                {
                    return 3;
                }
                else
                {
                    hasroot = true;
                    return 0;
                }
            }
            else if (level >= Depth)
                return 5;
            return 0;
        }
        public virtual void picturebox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Control pic = (Control)sender;
                if (clickcount == 1)
                {
                    clickcount++;
                    for (int j = 0; j < nod.Count; j++)
                        if (nod[j] != null && nod[j].chosen == true)
                        {
                            temp1 = j;
                            break;
                        }
                }
                else if (clickcount == 2)
                {
                    for (int j = 0; j < nod.Count; j++)
                            if (nod[j].chosen == true && j != temp1)
                            {
                                temp2 = j;
                            }
                    int higher = (nod[temp1].Level < nod[temp2].Level) ? temp1 : temp2;
                    int lower  = (nod[temp1].Level > nod[temp2].Level) ? temp1 : temp2;
                    if (nod[higher].Level == nod[lower].Level - 1)
                    {
                       
                        if (nod[lower].hasFather == false)
                        {
                            nod[higher].AddChild(nod[lower]);
                            nod[lower].AddFather(nod[higher]);
                        }
                        else
                            notice.Text = "A node cannot have two dad";

                    }
                    else if (nod[temp1].Level == nod[temp2].Level)
                        notice.Text = "Cannot connect two node on the same level";
                    else 
                        notice.Text = "Cannot connect two node";
                    Wait(500);
                    nod[temp1].unchoose();
                    nod[temp2].unchoose();
                    clickcount = 1;
                }
            }
        }
        public virtual void Delete(int deletevalue)
        {
            int j;
            for (j = 0; j < nod.Count; j++)
                if (nod[j].Value == deletevalue)
                    break;
            if (j == nod.Count)
            {
                notice.Text = "Node is not found";
                return;
            }
            DeleteNode(nod[j]);
        }
        public void DeleteNode(OvalPictureBox e)
        {
            if (e.hasFather == true)
                if (e.isleft == true)
                    e.father.hasleft = false;
                else
                    e.father.hasright = false;
            e.DeleteNode();
            panel.Controls.Remove(e);
            nod.Remove(e);
            currentNum = nod.Count;
        }
        public virtual void TreeCheck()
        {
            int j;
            if (nod.Count == N)
            {
                for (j = 0; j < currentNum; j++)
                {
                    if (nod[j].hasFather == false && nod[j].Child.Count == 0)
                    {
                        notice.Text = "Node" + nod[j].Value.ToString() + "still has no connection. Add them";
                        return;
                    }
                }
                if (nod.Find(x => x.Level == 0) == null)
                {
                    notice.Text = "You have to add root to tree";
                    return;
                }
                else
                {
                    notice.Text = "OK";
                    confirm = true;
                    ChildArrange(root);
                    return;
                }

            }
            else
            {
                notice.Text = "Are you missing some nodes? Add them";
                return;
            }
        }
        protected void ChildArrange(OvalPictureBox basenode)
        {
            if (basenode.Child.Count() == 0)
            {
                return;
            }
            else
            {
                basenode.Child.Sort((n1, n2) => (n1.TargetPoint.X).CompareTo(n2.TargetPoint.X));
                foreach (OvalPictureBox child in basenode.Child)
                    if (child.Child.Count() > 1)
                        ChildArrange(child);
            }

        }
        public void Clear()
        {
            if (N != 0)
            {
                notice.Text = nod.Count.ToString();
                for (int j = 0; j < nod.Count; j++)
                {
                    nod[j].DeleteNode();
                    panel.Controls.Remove(nod[j]);
                }
                currentNum = 0;
                hasroot = false;
                notice.Text = "";
            }
            else
                return;
        }
        public void Reset()
        {
            for (int j = 0; j < currentNum; j++)
                if (nod[j] != null)
                    nod[j].unchoose();
            notice.Text = "";
        }
        public void VisualizeTree(NodeTree head)
        {
            Queue<NodeTree> q = new Queue<NodeTree>();
            NodeTree t = new NodeTree();
            Random r = new Random();
            q.Enqueue(head);
            while (q.Count != 0)
            {
                t = q.Peek();
                q.Dequeue();
                AddNode(t);
                if (t.hasfather)
                {
                    nod[currentNum - 1].AddLine(nod[currentNum - 1].father, new Pen(Color.Red, 2));
                }

                foreach (var child in t.Child)
                {
                    q.Enqueue(child);
                }
            }
        }
    }
    public class General_GraphicTree:GraphicsTree
    {
        public General_GraphicTree()
        {
            isBST = false;
        }

        GeneralTree tree;

        public override void AddNode(int Value, int Level, int middle = 0, bool left = true)
        {
            base.AddNode(Value, Level);
            nod[currentNum - 1].MouseClick += new MouseEventHandler(picturebox_MouseClick);
        }
        public void AddNode(OvalPictureBox e)
        {
            base.AddNode(e.Value, e.Level);
            nod[currentNum - 1].MouseClick += new MouseEventHandler(picturebox_MouseClick);
        }

        public override void GenerateRandom()
        {
            Level_Divide(Depth);
            tree = new GeneralTree(N, Depth);
            tree.GenerateRandom();
            VisualizeTree(tree.root);
        }
        
    }

    public class Binary_GraphicTree : GraphicsTree
    {
        BinaryTree tree;
        List<int> levellimit;
        int[] nodeperlevel;
        public Binary_GraphicTree(){
            isBST = false;
        }
        public override bool CreateTree(int nodenum, int depthtree)
        {
            if (CheckCondition(nodenum, depthtree) == true)
            {
                base.CreateTree(nodenum, depthtree);
                LevelLimit(depthtree);
                nodeperlevel = new int[depthtree];
                return true;
            }
            else
            {
                return false;
            }
        }
        private void LevelLimit(int depthtree)
        {
            levellimit = new List<int>();
            levellimit.Add(1);
            for (int i = 1; i < depthtree; i++)
                levellimit.Add(levellimit[i-1]*2);
        }
        public override int CheckNode(int name, int level)
        {
            if (level >= Depth)
                return 5;
            if (nodeperlevel[level] + 1 <= levellimit[level])
            {
                for (int k = 0; k < nod.Count; k++)
                    if (nod[k].Value == name)
                    {
                        return 1;
                    }
                if (nod.Count == N)
                {
                    return 2;
                }
                if (level == 0)
                {
                    if (hasroot == true)
                    {
                        return 3;
                    }
                    else
                    {
                        hasroot = true;
                        nodeperlevel[level]++;
                        return 0;
                    }
                }
                else
                {
                    nodeperlevel[level]++;
                    return 0;
                }
            }
            else
                return 4;
        }
        public override void AddNode(int Value, int Level, int middle = 0, bool left = true)
        {
            base.AddNode(Value, Level,middle,left);
            nod[currentNum - 1].MouseClick += new MouseEventHandler(picturebox_MouseClick);
        }
        public new void picturebox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Control pic = (Control)sender;
                if (clickcount == 1)
                {
                    clickcount++;
                    for (int j = 0; j < nod.Count; j++)
                        if (nod[j] != null && nod[j].chosen == true)
                        {
                            temp1 = j;
                            break;
                        }
                }
                else if (clickcount == 2)
                {
                    for (int j = 0; j < nod.Count; j++)
                        if (nod[j].chosen == true && j != temp1)
                        {
                            temp2 = j;
                        }
                    int higher = (nod[temp1].Level < nod[temp2].Level) ? temp1 : temp2;
                    int lower = (nod[temp1].Level > nod[temp2].Level) ? temp1 : temp2;
                    if (nod[higher].Level == nod[lower].Level - 1)
                    {
                        if (nod[higher].Child.Count == 2)
                        {
                            notice.Text = "A binary node can have only two children";
                            Wait(500);
                            nod[temp1].unchoose();
                            nod[temp2].unchoose();
                            clickcount = 1;
                            return;
                        }
                        if (nod[lower].hasFather == false)
                        {
                            nod[higher].AddChild(nod[lower]);
                            nod[lower].AddFather(nod[higher]);
                        }
                        else
                            notice.Text = "A node cannot have two dad";

                    }
                    else if (nod[temp1].Level == nod[temp2].Level)
                        notice.Text = "Cannot connect two node on the same level";
                    else
                        notice.Text = "Cannot connect two node";
                    Wait(500);
                    nod[temp1].unchoose();
                    nod[temp2].unchoose();
                    clickcount = 1;
                    return;
                }
            }

        }
        public override void GenerateRandom()
        {
            Level_Divide(Depth);
            tree = new BinaryTree(N, Depth);
            tree.GenerateRandom();
            VisualizeTree(tree.root);
        }
        private bool CheckCondition(int num_n,int num_depth)
        {
            double x =Math.Pow(2, num_depth) - 1;
            if (num_n > x)
                return false;
            else
                return true;
        }
        public override void DFS(int signal)
        {
            notice.Text = "";
            if (signal == 0)
                Inorder(root);
            else if (signal == 1)
                Preorder(root);
            else if (signal==2)
                Postorder(root);
        }
        public void Inorder(OvalPictureBox e)
        {
           
            if (e.Child.Count != 0)
                Inorder(e.Child[0]);

            e.OutQueue();
            notice.Text += e.Value.ToString()+" ";
            Wait(1000);

            if(e.Child.Count ==2)
                Inorder(e.Child[1]);
            return;
            
        }
        public void Preorder(OvalPictureBox e)
        {
            e.OutQueue();
            notice.Text += e.Value.ToString() + " ";
            Wait(1000);
            
            if (e.Child.Count != 0)
                Preorder(e.Child[0]);

            if (e.Child.Count == 2)
                Preorder(e.Child[1]);
        }
        public void Postorder(OvalPictureBox e)
        {
            if (e.Child.Count != 0)
                Postorder(e.Child[0]);

            if (e.Child.Count == 2)
                Postorder(e.Child[1]);

            e.OutQueue();
            notice.Text += e.Value.ToString() + " ";
            Wait(1000);
              
        }

    }
    public class SearchBinary_GraphicTree : Binary_GraphicTree
    {
        int oldDepth;
        Binary_SearchTree tree;
        public SearchBinary_GraphicTree()
        {
            N = 0;
            Depth = 1;
            oldDepth = 1;
            nod = new List<OvalPictureBox>();
            Level_Divide(Depth);
            isBST = true;
        }
        public override void Update(ref int nodenum, ref int depth)
        {
            nodenum = nod.Count();
            depth = Depth;
        }
        public override void AddNode(int Value)
        {
            N++;
            if (hasroot == false)
                AddNode(Value, 0);
            else
            {
                insertRec(ref root, Value);
            }

        }
        
        private void insertRec(ref OvalPictureBox head, int Value)
        {
            OvalPictureBox temp;
            head.OutQueue();
            Wait(500);
            if (Value < head.Value)
            {
                head.unchoose();
                Wait(500);
                if (head.hasleft == true)
                {
                    temp = head.Child.Find(x => x.isleft == true);
                    insertRec(ref temp, Value);
                }
                else
                {
                    if (head.Level + 1 == Depth)
                    {
                        Depth++;
                        Level_Divide(Depth);
                        Reshow();
                    }
                    AddNode(Value, head.Level + 1, head.Location.X);
                    head.hasleft = true;
                    head.AddChild(nod[currentNum - 1]);
                    nod[currentNum - 1].AddFather(head);
                    nod[currentNum - 1].isleft = true;
                    nod[currentNum - 1].AddLine(head, new Pen(Color.Red, 2));
                    return;
                }
            }
            else if (Value > head.Value)
            {
                head.unchoose();
                Wait(500);
                if (head.hasright == true)
                {
                    temp = head.Child.Find(x => x.isleft == false);
                    insertRec(ref temp, Value);

                }
                else
                {
                    if (head.Level + 1 == Depth)
                    {
                        Depth++;
                        Level_Divide(Depth);
                        Reshow();
                    }
                    AddNode(Value, head.Level + 1, head.Location.X, false);
                    head.hasright = true;
                    head.AddChild(nod[currentNum - 1]);
                    nod[currentNum - 1].isleft = false;
                    nod[currentNum - 1].AddFather(head);
                    nod[currentNum - 1].AddLine(head, new Pen(Color.Red, 2));
                    return;
                }
            }
            else
            {
                notice.Text = "Node has existed. Try another node";
                return;
            }
        }
        private void Reshow()
        {
            Point p;
            foreach (OvalPictureBox e in nod)
            {
                e.DeleteConnect();
                e.Visible = false;
                p = new Point(e.Location.X, level_ycoodinate[e.Level]);
                e.Y_Level = level_ycoodinate[e.Level];
                e.Location = p;
                e.TargetPoint = new Point(e.Location.X + 20, e.Location.Y + 20);
            }
            Wait(500);
            foreach (OvalPictureBox e in nod)
            {
                e.Visible = true;
                e.ReConnect();
            }
        }
        
        private void Reshow(OvalPictureBox e, bool insertleft, int xlocation = 0)
        {
            Queue<OvalPictureBox> q = new Queue<OvalPictureBox>();
            List<OvalPictureBox> lis = new List<OvalPictureBox>();
            OvalPictureBox temp,left,right;
            q.Enqueue(e);
            while (q.Count != 0)
            {
                temp = q.Dequeue();
                lis.Add(temp);
                left = temp.Child.Find(x => x.isleft == true);
                right = temp.Child.Find(x => x.isleft == false);
                if (left != null)
                    q.Enqueue(left);
                if (right != null)
                    q.Enqueue(right);
                temp.DeleteConnect();
                temp.Visible = false;
            }
            foreach (OvalPictureBox i in lis)
            {
                i.Level--;
                i.Y_Level = level_ycoodinate[i.Level];
                if (i == e && xlocation!=0)
                {
                    if (insertleft == true)
                        i.Location = new Point(xlocation - 30, e.Y_Level);
                    else
                        i.Location = new Point(xlocation + 30, e.Y_Level);
                }
                else
                    i.Location = new Point(i.Location.X, i.Y_Level);
                i.TargetPoint = new Point(i.Location.X + 20, i.Location.Y + 20);
            }
            Wait(500);
            foreach (OvalPictureBox i in lis)
            {
                i.Visible = true;
                i.ReConnect();
            }

        }
        private OvalPictureBox search(OvalPictureBox e, int key)
        {
            if (e == null || e.Value == key)
                return e;
            e.OutQueue();
            Wait(500);
            e.unchoose();
            Wait(500);
            if (e.Value > key)
                return search(e.Child.Find(x => x.isleft == true), key);
            return search(e.Child.Find(x => x.isleft == false), key);
        }
        public override void Delete(int deletevalue)
        {
            if (root == null)
                return;
            OvalPictureBox des = search(root, deletevalue);
            if (des != null)
                deleteNode(des);
            else
                notice.Text = "Can't find node";
        }
        private void deleteNode(OvalPictureBox head)
        {
            OvalPictureBox dad, leftchild, rightchild;
            bool insertleft=true;
            dad = head.father;
            leftchild = head.Child.Find(x => x.isleft == true);
            rightchild = head.Child.Find(x => x.isleft == false);

            if (leftchild != null || rightchild != null)
            {
                if (dad != null)
                {
                    if (head.isleft == true)
                    {
                        insertleft = true;
                        dad.hasleft = true;
                    }
                    else if (head.isleft == false)
                    {
                        insertleft = false;
                        dad.hasright = true;
                    }

                    if (leftchild != null && rightchild == null)
                    {
                        DeleteNode(head);
                        leftchild.Addrelation(dad);
                        Reshow(leftchild, insertleft, dad.Location.X);
                        dad.hasleft = true;
                        leftchild.AddLine(dad, new Pen(Color.Red, 2));
                    }

                    else if ((leftchild == null && rightchild != null))
                    {
                        DeleteNode(head);
                        rightchild.Addrelation(dad);
                        Reshow(rightchild, insertleft, dad.Location.X);
                        dad.hasleft = true;
                        rightchild.isleft = true;
                        rightchild.AddLine(dad, new Pen(Color.Red, 2));
                    }
                }
                else
                {
                    if (leftchild != null && rightchild == null)
                    {
                        DeleteNode(head);
                        Reshow(leftchild, true);
                    }
                    else if (leftchild == null && rightchild != null)
                    {
                        DeleteNode(head);
                        Reshow(rightchild, true);
                    }
                }
                  
                if (leftchild != null && rightchild != null)
                {
                    OvalPictureBox alter = FindAlter(rightchild);
                    head.Value = alter.Value;
                    head.Visible = false;
                    head.Paint += new PaintEventHandler(head.OvalPictureBox_Paint);
                    Wait(200);
                    
                    head.Visible = true;
                    if (alter.Child.Count() == 0)
                        DeleteNode(alter);
                    else
                        deleteNode(alter);
                }
            }
            else
                DeleteNode(head);
        }
        
        private OvalPictureBox FindAlter(OvalPictureBox e)
        {
            OvalPictureBox before = e;
            OvalPictureBox temp = e.Child.Find(x => x.isleft == true);
            if ( temp == null)
                return e;
            while (temp!=null)
            {
                before = temp;
                temp = temp.Child.Find(x => x.isleft == true);
            }
            
            return before;
        }

        public override void FindPath(int value)
        {
            OvalPictureBox kq = search(root, value);
            if (kq != null)
            {
                for (int i = 0; i < 8; i++)
                {
                    kq.choose();
                    Wait(200);
                    kq.unchoose();
                    Wait(200);
                }
                PrintPath(kq);
            }
            else
                notice.Text = "Can't find node";
            return;
        }

        public override void TreeCheck()
        {
            confirm = true;
            tree = new Binary_SearchTree(nod.Count());
            tree.root = root.Root;
            ChildArrange(root);
        }

        public override void GenerateRandom(int n)
        {
            Clear();
            N = n;
            tree = new Binary_SearchTree(n);
            tree.GenerateRandom();
            Depth = tree.Depth;
            Level_Divide(Depth);
            VisualizeTree(tree.root);
        }
        public override void Balance()
        {
            if (root != null)
            {
                tree = new Binary_SearchTree(nod.Count());
                tree.root = root.Root;
                Clear();
                tree.Balance();
                VisualizeTree(tree.root);
            }
            
        }
    }

}
