using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using TreeLib;

namespace Ultility
{
    public class OvalPictureBox : PictureBox
    {
        NodeTree root=new NodeTree();
        public List<OvalPictureBox> Child = new List<OvalPictureBox>();
        public bool hasFather = false;
        public OvalPictureBox father;
        
        private int y_level;
        public Point TargetPoint;
        public Graphics g;
        public Graphics g1;
        public bool chosen = false;
        public bool left = true;
        
        public int Level
        {
            get { return root.Level; }
            set { root.Level = value; }
        }
        public int Value
        {
            get { return root.Value;}
            set { root.Value=value; }
        }
        public int Y_Level
        {
            get { return y_level; }
            set { y_level = value; }
        }
        public NodeTree Root
        {
            get { return root; }
            set { root = value; }
        }
        public bool hasleft
        {
            get { return root.hasleft; }
            set { root.hasleft = value; }
        }
        public bool hasright
        {
            get { return root.hasright; }
            set { root.hasright = value; }
        }

        public bool isleft
        {
            get { return root.isleft; }
            set { root.isleft = value; }
        }
        public OvalPictureBox()
        {
            this.BackColor = SystemColors.ButtonFace;
            this.MouseMove += new MouseEventHandler(OvalPictureBox_MouseMove);
            this.Paint += new PaintEventHandler(OvalPictureBox_Paint);
            this.MouseClick += new MouseEventHandler(OvalPictureBox_MouseClick);
            this.BorderStyle = BorderStyle.Fixed3D;
            this.Visible = false;
            Size size = new Size(40, 40);
            this.Size = size;
            this.Value = -1;
        }
       
        public OvalPictureBox(NodeTree e)
        {
            this.BackColor = SystemColors.ButtonFace;
            this.MouseMove += new MouseEventHandler(OvalPictureBox_MouseMove);
            this.Paint += new PaintEventHandler(OvalPictureBox_Paint);
            this.MouseClick += new MouseEventHandler(OvalPictureBox_MouseClick);
            root = e;
        }
       
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            using (var gp = new System.Drawing.Drawing2D.GraphicsPath())
            {
                gp.AddEllipse(new Rectangle(0, 0, this.Width - 1, this.Height - 1));
                this.Region = new Region(gp);
            }
        }
        private void OvalPictureBox_MouseMove(object sender, MouseEventArgs e)
        { 
            Control controlToMove = (Control)sender;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                controlToMove.BringToFront();
                controlToMove.Location = new Point(controlToMove.Location.X + e.Location.X - 10, Y_Level);
                if (Child.Count != 0 || hasFather == true)
                {
                    DeleteConnect();
                }
                TargetPoint = new Point(controlToMove.Location.X + 20, Y_Level + 20);
                ReConnect();
            }
        }
        
        public void OvalPictureBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Font myFont = new Font("Comic Sans MS", 15);
            SolidBrush myBrush = new SolidBrush(Color.Black);
            StringFormat myFormat = new StringFormat();
            Graphics g2 = e.Graphics;
            SolidBrush drawBrush1 = new SolidBrush(Color.Aquamarine);
            g2.DrawEllipse(new Pen(Color.Black, 3), 0, 0, 34, 34);
            g2.DrawString((Value < 10) ? "0" + Value : "" + Value, myFont, myBrush, 4, 3, myFormat);
        }
        
        private void OvalPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                choose();
            }
        }
        public void choose()
        {
            g1 = this.CreateGraphics();
            g1.DrawEllipse(new Pen(Color.Plum, 3), 0, 0, 34, 34);
            chosen = true;
        }
        public void unchoose()
        {
            g1 = this.CreateGraphics();
            g1.DrawEllipse(new Pen(Color.Black, 3), 0, 0, 34, 34);
            chosen = false;
        }
        public void AddChild(OvalPictureBox con)
        {
            Child.Add(con);
            AddLine(con, new Pen(Color.Red, 2));
            root.Child.Add(con.Root);
        }
        public void AddLine(OvalPictureBox con,Pen myPen)
        {
            if (this.TargetPoint == new Point(0, 0) || con.TargetPoint == new Point(0, 0))
                return;
            g.DrawLine(myPen, this.TargetPoint,con.TargetPoint);
            
        }
        public void AddFather(OvalPictureBox dad)
        {
            if (hasFather==false)            
            {
                father = dad;
                hasFather = true;
                root.Father = dad.root;
            }
        }
        public void Addrelation(OvalPictureBox dad)
        {
            if (hasFather == false)
            {
                father = dad;
                hasFather = true;
            }
            father.Child.Add(this);
        }
        public void DeleteConnect()
        {
            if(hasFather==true)
                g.DrawLine(new Pen(SystemColors.GradientActiveCaption, 3), this.TargetPoint, father.TargetPoint);
            if(Child.Count!=0)
                foreach (OvalPictureBox oval in Child)
                {
                    AddLine(oval, new Pen(SystemColors.GradientActiveCaption, 3));
                }
        }
        public void ReConnect()
        {
            if (hasFather == true)
                AddLine(father, new Pen(Color.Red, 2));
            if (Child.Count != 0)
                foreach (OvalPictureBox oval in Child)
                {
                    AddLine(oval, new Pen(Color.Red, 2));
                }
        }
        public void DeleteNode()
        {
            DeleteConnect();
            if (Child.Count != 0)
                foreach (OvalPictureBox oval in Child)
                {
                    oval.hasFather = false;
                }
            if(hasFather==true)
                father.DeleteChild(this);
        }
        private void DeleteChild(OvalPictureBox con)
        {
            Child.Remove(con);
        }
        public void OnQueue()
        {
            g1 = this.CreateGraphics();
            g1.DrawEllipse(new Pen(Color.Orange, 3), 0, 0, 34, 34);
        }
        public void OutQueue()
        {
            g1 = this.CreateGraphics();
            g1.DrawEllipse(new Pen(Color.LightGreen, 3), 0, 0, 34, 34);
        }
        
    }
}
