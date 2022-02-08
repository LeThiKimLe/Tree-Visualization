
namespace a
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.treeBox = new System.Windows.Forms.GroupBox();
            this.n_generateBox = new System.Windows.Forms.TextBox();
            this.n_generate = new System.Windows.Forms.Label();
            this.SelectType = new System.Windows.Forms.ListBox();
            this.high_Box = new System.Windows.Forms.TextBox();
            this.n_Box = new System.Windows.Forms.TextBox();
            this.level_Label = new System.Windows.Forms.Label();
            this.depth_Label = new System.Windows.Forms.Label();
            this.n_label = new System.Windows.Forms.Label();
            this.deleteBox = new System.Windows.Forms.TextBox();
            this.curLevel_Box = new System.Windows.Forms.TextBox();
            this.addBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Delete = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.Balance = new System.Windows.Forms.Button();
            this.Random = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.algorithmBox = new System.Windows.Forms.GroupBox();
            this.node_find = new System.Windows.Forms.TextBox();
            this.reset_Button = new System.Windows.Forms.Button();
            this.Find = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.traversal = new System.Windows.Forms.ListBox();
            this.BFScheck = new System.Windows.Forms.CheckBox();
            this.DFSCheck = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.resultBox = new System.Windows.Forms.GroupBox();
            this.status_Label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.treeBox.SuspendLayout();
            this.algorithmBox.SuspendLayout();
            this.resultBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(0, -6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(671, 485);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // treeBox
            // 
            this.treeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.treeBox.Controls.Add(this.n_generateBox);
            this.treeBox.Controls.Add(this.n_generate);
            this.treeBox.Controls.Add(this.SelectType);
            this.treeBox.Controls.Add(this.high_Box);
            this.treeBox.Controls.Add(this.n_Box);
            this.treeBox.Controls.Add(this.level_Label);
            this.treeBox.Controls.Add(this.depth_Label);
            this.treeBox.Controls.Add(this.n_label);
            this.treeBox.Controls.Add(this.deleteBox);
            this.treeBox.Controls.Add(this.curLevel_Box);
            this.treeBox.Controls.Add(this.addBox);
            this.treeBox.Controls.Add(this.label1);
            this.treeBox.Controls.Add(this.Delete);
            this.treeBox.Controls.Add(this.Add);
            this.treeBox.Controls.Add(this.Balance);
            this.treeBox.Controls.Add(this.Random);
            this.treeBox.Controls.Add(this.clearButton);
            this.treeBox.Controls.Add(this.okButton);
            this.treeBox.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeBox.Location = new System.Drawing.Point(12, 21);
            this.treeBox.Name = "treeBox";
            this.treeBox.Size = new System.Drawing.Size(310, 336);
            this.treeBox.TabIndex = 2;
            this.treeBox.TabStop = false;
            this.treeBox.Text = "Create Tree";
            this.treeBox.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // n_generateBox
            // 
            this.n_generateBox.Location = new System.Drawing.Point(197, 231);
            this.n_generateBox.Multiline = true;
            this.n_generateBox.Name = "n_generateBox";
            this.n_generateBox.Size = new System.Drawing.Size(45, 30);
            this.n_generateBox.TabIndex = 9;
            this.n_generateBox.Visible = false;
            // 
            // n_generate
            // 
            this.n_generate.AutoSize = true;
            this.n_generate.Location = new System.Drawing.Point(165, 234);
            this.n_generate.Name = "n_generate";
            this.n_generate.Size = new System.Drawing.Size(26, 23);
            this.n_generate.TabIndex = 8;
            this.n_generate.Text = "n=";
            this.n_generate.Visible = false;
            // 
            // SelectType
            // 
            this.SelectType.AllowDrop = true;
            this.SelectType.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectType.FormattingEnabled = true;
            this.SelectType.ItemHeight = 18;
            this.SelectType.Items.AddRange(new object[] {
            "General Tree",
            "Binary Tree",
            "Binary Search Tree"});
            this.SelectType.Location = new System.Drawing.Point(87, 32);
            this.SelectType.Name = "SelectType";
            this.SelectType.Size = new System.Drawing.Size(164, 22);
            this.SelectType.TabIndex = 2;
            this.SelectType.SelectedIndexChanged += new System.EventHandler(this.SelectType_SelectedIndexChanged);
            // 
            // high_Box
            // 
            this.high_Box.Location = new System.Drawing.Point(165, 79);
            this.high_Box.Multiline = true;
            this.high_Box.Name = "high_Box";
            this.high_Box.Size = new System.Drawing.Size(45, 30);
            this.high_Box.TabIndex = 7;
            // 
            // n_Box
            // 
            this.n_Box.Location = new System.Drawing.Point(36, 79);
            this.n_Box.Multiline = true;
            this.n_Box.Name = "n_Box";
            this.n_Box.Size = new System.Drawing.Size(45, 30);
            this.n_Box.TabIndex = 7;
            // 
            // level_Label
            // 
            this.level_Label.AutoSize = true;
            this.level_Label.Location = new System.Drawing.Point(177, 140);
            this.level_Label.Name = "level_Label";
            this.level_Label.Size = new System.Drawing.Size(48, 23);
            this.level_Label.TabIndex = 6;
            this.level_Label.Text = "Level";
            this.level_Label.Visible = false;
            // 
            // depth_Label
            // 
            this.depth_Label.AutoSize = true;
            this.depth_Label.Location = new System.Drawing.Point(106, 82);
            this.depth_Label.Name = "depth_Label";
            this.depth_Label.Size = new System.Drawing.Size(62, 23);
            this.depth_Label.TabIndex = 6;
            this.depth_Label.Text = "Depth=";
            // 
            // n_label
            // 
            this.n_label.AutoSize = true;
            this.n_label.Location = new System.Drawing.Point(11, 82);
            this.n_label.Name = "n_label";
            this.n_label.Size = new System.Drawing.Size(26, 23);
            this.n_label.TabIndex = 6;
            this.n_label.Text = "n=";
            // 
            // deleteBox
            // 
            this.deleteBox.Location = new System.Drawing.Point(112, 173);
            this.deleteBox.Multiline = true;
            this.deleteBox.Name = "deleteBox";
            this.deleteBox.Size = new System.Drawing.Size(45, 30);
            this.deleteBox.TabIndex = 5;
            // 
            // curLevel_Box
            // 
            this.curLevel_Box.Location = new System.Drawing.Point(230, 137);
            this.curLevel_Box.Multiline = true;
            this.curLevel_Box.Name = "curLevel_Box";
            this.curLevel_Box.Size = new System.Drawing.Size(34, 30);
            this.curLevel_Box.TabIndex = 5;
            this.curLevel_Box.Visible = false;
            // 
            // addBox
            // 
            this.addBox.Location = new System.Drawing.Point(112, 137);
            this.addBox.Multiline = true;
            this.addBox.Name = "addBox";
            this.addBox.Size = new System.Drawing.Size(45, 30);
            this.addBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tree Type";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Delete
            // 
            this.Delete.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete.Location = new System.Drawing.Point(6, 173);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(96, 30);
            this.Delete.TabIndex = 1;
            this.Delete.Text = "Delete Node";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Add
            // 
            this.Add.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add.Location = new System.Drawing.Point(6, 137);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(96, 30);
            this.Add.TabIndex = 1;
            this.Add.Text = "Add Node";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Balance
            // 
            this.Balance.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Balance.Location = new System.Drawing.Point(6, 267);
            this.Balance.Name = "Balance";
            this.Balance.Size = new System.Drawing.Size(147, 30);
            this.Balance.TabIndex = 1;
            this.Balance.Text = "Balance Tree";
            this.Balance.UseVisualStyleBackColor = true;
            this.Balance.Click += new System.EventHandler(this.Balance_Click);
            // 
            // Random
            // 
            this.Random.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Random.Location = new System.Drawing.Point(6, 231);
            this.Random.Name = "Random";
            this.Random.Size = new System.Drawing.Size(147, 30);
            this.Random.TabIndex = 1;
            this.Random.Text = "Generate Randomly";
            this.Random.UseVisualStyleBackColor = true;
            this.Random.Click += new System.EventHandler(this.Random_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(242, 299);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(62, 30);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(242, 263);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(62, 30);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // algorithmBox
            // 
            this.algorithmBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.algorithmBox.Controls.Add(this.node_find);
            this.algorithmBox.Controls.Add(this.reset_Button);
            this.algorithmBox.Controls.Add(this.Find);
            this.algorithmBox.Controls.Add(this.playButton);
            this.algorithmBox.Controls.Add(this.label3);
            this.algorithmBox.Controls.Add(this.traversal);
            this.algorithmBox.Controls.Add(this.BFScheck);
            this.algorithmBox.Controls.Add(this.DFSCheck);
            this.algorithmBox.Controls.Add(this.label2);
            this.algorithmBox.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.algorithmBox.Location = new System.Drawing.Point(12, 363);
            this.algorithmBox.Name = "algorithmBox";
            this.algorithmBox.Size = new System.Drawing.Size(310, 233);
            this.algorithmBox.TabIndex = 3;
            this.algorithmBox.TabStop = false;
            this.algorithmBox.Text = "Tree Algorithms";
            // 
            // node_find
            // 
            this.node_find.Location = new System.Drawing.Point(102, 147);
            this.node_find.Name = "node_find";
            this.node_find.Size = new System.Drawing.Size(45, 30);
            this.node_find.TabIndex = 8;
            this.node_find.TextChanged += new System.EventHandler(this.node_find_TextChanged);
            // 
            // reset_Button
            // 
            this.reset_Button.Image = ((System.Drawing.Image)(resources.GetObject("reset_Button.Image")));
            this.reset_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.reset_Button.Location = new System.Drawing.Point(217, 189);
            this.reset_Button.Name = "reset_Button";
            this.reset_Button.Size = new System.Drawing.Size(61, 31);
            this.reset_Button.TabIndex = 1;
            this.reset_Button.Text = "Reset";
            this.reset_Button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reset_Button.UseVisualStyleBackColor = true;
            this.reset_Button.Click += new System.EventHandler(this.reset_Button_Click);
            // 
            // Find
            // 
            this.Find.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Find.Location = new System.Drawing.Point(6, 146);
            this.Find.Name = "Find";
            this.Find.Size = new System.Drawing.Size(90, 31);
            this.Find.TabIndex = 1;
            this.Find.Text = "Find Path";
            this.Find.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Find.UseVisualStyleBackColor = true;
            this.Find.Click += new System.EventHandler(this.Find_Click);
            // 
            // playButton
            // 
            this.playButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.playButton.Location = new System.Drawing.Point(217, 86);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(47, 31);
            this.playButton.TabIndex = 1;
            this.playButton.Text = "GO";
            this.playButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.play_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "*Find Path";
            // 
            // traversal
            // 
            this.traversal.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.traversal.FormattingEnabled = true;
            this.traversal.ItemHeight = 18;
            this.traversal.Items.AddRange(new object[] {
            "Inorder",
            "Preorder",
            "Postorder"});
            this.traversal.Location = new System.Drawing.Point(73, 99);
            this.traversal.Name = "traversal";
            this.traversal.Size = new System.Drawing.Size(123, 22);
            this.traversal.TabIndex = 2;
            this.traversal.Visible = false;
            this.traversal.SelectedIndexChanged += new System.EventHandler(this.traversal_SelectedIndexChanged);
            // 
            // BFScheck
            // 
            this.BFScheck.AutoSize = true;
            this.BFScheck.Location = new System.Drawing.Point(15, 69);
            this.BFScheck.Name = "BFScheck";
            this.BFScheck.Size = new System.Drawing.Size(60, 27);
            this.BFScheck.TabIndex = 1;
            this.BFScheck.Text = "BFS";
            this.BFScheck.UseVisualStyleBackColor = true;
            // 
            // DFSCheck
            // 
            this.DFSCheck.AutoSize = true;
            this.DFSCheck.Location = new System.Drawing.Point(15, 97);
            this.DFSCheck.Name = "DFSCheck";
            this.DFSCheck.Size = new System.Drawing.Size(62, 27);
            this.DFSCheck.TabIndex = 1;
            this.DFSCheck.Text = "DFS";
            this.DFSCheck.UseVisualStyleBackColor = true;
            this.DFSCheck.Visible = false;
            this.DFSCheck.CheckedChanged += new System.EventHandler(this.DFS_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "*Tree Traversal";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // resultBox
            // 
            this.resultBox.Controls.Add(this.status_Label);
            this.resultBox.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultBox.Location = new System.Drawing.Point(345, 511);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(668, 85);
            this.resultBox.TabIndex = 4;
            this.resultBox.TabStop = false;
            this.resultBox.Text = "Result";
            // 
            // status_Label
            // 
            this.status_Label.AutoSize = true;
            this.status_Label.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status_Label.Location = new System.Drawing.Point(28, 32);
            this.status_Label.Name = "status_Label";
            this.status_Label.Size = new System.Drawing.Size(47, 18);
            this.status_Label.TabIndex = 8;
            this.status_Label.Text = "Status";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(345, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 479);
            this.panel1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 608);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.algorithmBox);
            this.Controls.Add(this.treeBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.treeBox.ResumeLayout(false);
            this.treeBox.PerformLayout();
            this.algorithmBox.ResumeLayout(false);
            this.algorithmBox.PerformLayout();
            this.resultBox.ResumeLayout(false);
            this.resultBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox treeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox SelectType;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox algorithmBox;
        private System.Windows.Forms.TextBox addBox;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox traversal;
        private System.Windows.Forms.CheckBox BFScheck;
        private System.Windows.Forms.CheckBox DFSCheck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox resultBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.TextBox deleteBox;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Random;
        private System.Windows.Forms.TextBox n_Box;
        private System.Windows.Forms.Label n_label;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.TextBox node_find;
        private System.Windows.Forms.Label status_Label;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox high_Box;
        private System.Windows.Forms.Label depth_Label;
        private System.Windows.Forms.Label level_Label;
        private System.Windows.Forms.TextBox curLevel_Box;
        private System.Windows.Forms.Button reset_Button;
        private System.Windows.Forms.Button Find;
        private System.Windows.Forms.TextBox n_generateBox;
        private System.Windows.Forms.Label n_generate;
        private System.Windows.Forms.Button Balance;
    }
}

