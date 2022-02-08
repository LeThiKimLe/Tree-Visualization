using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultility;


namespace a
{
    
    public partial class Form1 : Form
    {
        int n;
        int high;
        int i=0;

        GraphicsTree tree;
       
        public Form1()
        {
            InitializeComponent();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        { 
        }

        private void SelectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectType.SelectedIndex == 0)
            {
                tree = new General_GraphicTree();
                AddFeather();
                level_Label.Visible = true;
                curLevel_Box.Visible = true;
                n_Box.Enabled = true;
                high_Box.Enabled = true;
                Balance.Visible = false;
                DFSCheck.Visible = false;
                traversal.Visible = false;
                n_generate.Visible = false;
                n_generateBox.Visible = false;
            }
            else if (SelectType.SelectedIndex == 1)
            {
                tree = new Binary_GraphicTree();
                AddFeather();
                DFSCheck.Visible = true;
                curLevel_Box.Visible = true;
                level_Label.Visible = true;
                n_Box.Enabled = true;
                high_Box.Enabled = true;
                Balance.Visible = false;
                n_generate.Visible = false;
                n_generateBox.Visible = false;
            }
            else if (SelectType.SelectedIndex == 2)
            {
                tree = new SearchBinary_GraphicTree();
                AddFeather();
                curLevel_Box.Visible = false;
                level_Label.Visible = false;
                DFSCheck.Visible = true;
                n_Box.Enabled = false;
                high_Box.Enabled = false;
                Balance.Visible = true;
                n_generate.Visible = true;
                n_generateBox.Visible = true;
            }    
        }
        private void AddFeather()
        {
            tree.notice = new Label();
            tree.panel = this.panel1;
            tree.picturebox = this.pictureBox1;
            this.resultBox.Controls.Add(tree.notice);
            tree.notice.Font = new Font("Comic Sans MS", 10);
            tree.notice.Location = new Point(28, 50);
            tree.notice.AutoSize = true;
        }
        private void Add_Click(object sender, EventArgs e)
        {
            if(SelectType.SelectedIndex==-1)
            {
                status_Label.Text = "You have to choose type of tree";
                return;
            }
            if (SelectType.SelectedIndex == 0 || SelectType.SelectedIndex == 1)
            {
                if (!(Int32.TryParse(n_Box.Text, out n) && Int32.TryParse(high_Box.Text, out high)))
                {
                    status_Label.Text = "You need to enter both number of node('n') and 'high' of tree";
                    return;
                }
                else
                {
                    if (i == 0)
                    {
                        bool success = tree.CreateTree(n, high);
                        if (success == false)
                        {
                            status_Label.Text = "Can not create tree.\n Try another 'n' and 'depth'";
                            return;
                        }
                    }
                    int value;
                    int curLevel;
                    if (!(Int32.TryParse(addBox.Text, out value) && Int32.TryParse(curLevel_Box.Text, out curLevel)))
                        status_Label.Text = "Please enter node name and level of node";
                    else
                    {
                        int check = tree.CheckNode(value, curLevel);
                        status_Label.Text = check.ToString();
                        if (check == 1)
                        {
                            status_Label.Text = "This node is existed. Try another name";
                            return;
                        }
                        else if (check == 2)
                        {
                            status_Label.Text = "The number of node is exceed. You may have to change n";
                            return;
                        }
                        else if (check == 3)
                        {
                            status_Label.Text = "Tree has only one root!";
                            return;
                        }
                        else if (check == 4)
                        {
                            status_Label.Text = "You have reached the max of node per level\nTry to add node on other level";
                            return;
                        }
                        else if (check == 5)
                        {
                            status_Label.Text = "You have exceeded the max level\nYou should enter level that's no higher than Depth-1";
                            return;
                        }
                        else
                        {
                            tree.AddNode(value, curLevel);
                            i = i + 1;
                        }
                    }
                }
            }
            else
            {
                int value;
                if (Int32.TryParse(addBox.Text, out value))
                {
                    tree.AddNode(value);
                    tree.Update(ref n, ref high);
                    n_Box.Text = n.ToString();
                    high_Box.Text = high.ToString();
                }
                else
                    status_Label.Text = "Please enter node value";
            }
        }
        private void Delete_Click(object sender, System.EventArgs e)
        {
            OvalPictureBox delete_node = new OvalPictureBox();
            int deletevalue;
            if (!Int32.TryParse(deleteBox.Text, out deletevalue))
                return;
            else
            {
                tree.Delete(deletevalue);
                if(SelectType.SelectedIndex==2)
                    tree.Update(ref n, ref high);
            }
        }
        private void Random_Click(object sender, EventArgs e)
        {
            if (SelectType.SelectedIndex == 0 || SelectType.SelectedIndex == 1)
            {
                if (!(Int32.TryParse(n_Box.Text, out n) && Int32.TryParse(high_Box.Text, out high)))
                {
                    status_Label.Text = "You need to enter both number of node('n') and 'high' of tree";
                    return;
                }
                else
                {
                    if (tree.CreateTree(n, high))
                        tree.GenerateRandom();
                }
            }
            else if(SelectType.SelectedIndex == 2)
            {
                if (Int32.TryParse(n_generateBox.Text, out n))
                {
                    tree.GenerateRandom(n);
                }
            }    
        }

        private void BFS_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            tree.TreeCheck();
        }

        private void play_Click(object sender, EventArgs e)
        {
            if (tree.confirm==true)
            {
                if(!(BFScheck.Checked == true && DFSCheck.Checked == true))
                    if (BFScheck.Checked == true)
                    {
                        status_Label.Text = "Performing...";
                        tree.LevelOrderTraversal();
                        status_Label.Text = "Done";
                    }
                    else if(DFSCheck.Checked==true)
                    {
                        if (traversal.SelectedIndex != -1)
                        {
                            status_Label.Text = "Performing...";
                            tree.DFS(traversal.SelectedIndex);
                            status_Label.Text = "Done";
                        }
                        else
                            status_Label.Text = "You have to choose type traversal of DFS";
                    }
            }
            else
                status_Label.Text = "You have to confirm tree by click OK";
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            tree.Clear();
            i = 0;
            n_Box.Clear();
            high_Box.Clear();
            n_generateBox.Clear();
            addBox.Clear();
            curLevel_Box.Clear();
            deleteBox.Clear();
            SelectType.ClearSelected();
            status_Label.Text = "";
            node_find.Text = "";
        }

        private void reset_Button_Click(object sender, EventArgs e)
        {
            tree.Reset();
            DFSCheck.CheckState=CheckState.Unchecked;
            BFScheck.CheckState = CheckState.Unchecked;
            node_find.Text = "";
            traversal.ClearSelected();
            status_Label.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Convert_Click(object sender, EventArgs e)
        {
            
        }

        private void ConvertType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void node_find_TextChanged(object sender, EventArgs e)
        {
        }

        private void Find_Click(object sender, EventArgs e)
        {
            int value;
            if (!(Int32.TryParse(node_find.Text, out value)))
            {
                status_Label.Text = "You need to enter the node you want to find";
                return;
            }
            status_Label.Text = "Performing...";
            tree.FindPath(value);
            status_Label.Text = "Done";
        }

        private void DFS_CheckedChanged(object sender, EventArgs e)
        {
            BFScheck.CheckState = CheckState.Unchecked;
            traversal.Visible = true;
        }

        private void traversal_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Balance_Click(object sender, EventArgs e)
        {
            if (tree.confirm == true && SelectType.SelectedIndex == 2)
            {
                tree.Balance();
                status_Label.Text = "";
            }
            else
                status_Label.Text = "You have to confirm tree by click OK";
        }
    }
}
