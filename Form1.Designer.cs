namespace NATSimulation
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.PCtextBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.PCtextBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.NATtextBox = new System.Windows.Forms.TextBox();
            this.WEBtextBox = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // PCtextBox1
            // 
            this.PCtextBox1.Location = new System.Drawing.Point(23, 97);
            this.PCtextBox1.Multiline = true;
            this.PCtextBox1.Name = "PCtextBox1";
            this.PCtextBox1.ReadOnly = true;
            this.PCtextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PCtextBox1.Size = new System.Drawing.Size(303, 308);
            this.PCtextBox1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Document;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(23, 49);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 1;
            // 
            // PCtextBox2
            // 
            this.PCtextBox2.Location = new System.Drawing.Point(23, 443);
            this.PCtextBox2.Name = "PCtextBox2";
            this.PCtextBox2.Size = new System.Drawing.Size(303, 25);
            this.PCtextBox2.TabIndex = 2;
            this.PCtextBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PCtextBox2_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(235, 490);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "发送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NATtextBox
            // 
            this.NATtextBox.Location = new System.Drawing.Point(383, 244);
            this.NATtextBox.Multiline = true;
            this.NATtextBox.Name = "NATtextBox";
            this.NATtextBox.ReadOnly = true;
            this.NATtextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.NATtextBox.Size = new System.Drawing.Size(277, 279);
            this.NATtextBox.TabIndex = 5;
            // 
            // WEBtextBox
            // 
            this.WEBtextBox.Location = new System.Drawing.Point(760, 97);
            this.WEBtextBox.Multiline = true;
            this.WEBtextBox.Name = "WEBtextBox";
            this.WEBtextBox.ReadOnly = true;
            this.WEBtextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.WEBtextBox.Size = new System.Drawing.Size(301, 426);
            this.WEBtextBox.TabIndex = 6;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(383, 49);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(280, 170);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 647);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.WEBtextBox);
            this.Controls.Add(this.NATtextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PCtextBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.PCtextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PCtextBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox PCtextBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox NATtextBox;
        private System.Windows.Forms.TextBox WEBtextBox;
        private System.Windows.Forms.ListView listView1;
    }
}

