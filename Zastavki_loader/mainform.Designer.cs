namespace Zastavki_loader
{
    partial class mainform
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
            this.components = new System.ComponentModel.Container();
            this.strip = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.get_prev_btn = new System.Windows.Forms.Button();
            this.get_btn = new System.Windows.Forms.Button();
            this.all_items = new System.Windows.Forms.Label();
            this.g_count = new System.Windows.Forms.Label();
            this.genres_list = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.previews = new System.Windows.Forms.ImageList(this.components);
            this.progress = new System.Windows.Forms.ProgressBar();
            this.prog = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.current_page = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.prev_btn = new System.Windows.Forms.Button();
            this.next_btn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.LV = new Zastavki_loader.MyListView();
            this.strip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // strip
            // 
            this.strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.strip.Location = new System.Drawing.Point(0, 463);
            this.strip.Name = "strip";
            this.strip.Size = new System.Drawing.Size(1217, 22);
            this.strip.TabIndex = 0;
            this.strip.Text = "0";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(13, 17);
            this.status.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.prog);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.progress);
            this.panel1.Controls.Add(this.get_prev_btn);
            this.panel1.Controls.Add(this.get_btn);
            this.panel1.Controls.Add(this.all_items);
            this.panel1.Controls.Add(this.g_count);
            this.panel1.Controls.Add(this.genres_list);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1217, 60);
            this.panel1.TabIndex = 1;
            // 
            // get_prev_btn
            // 
            this.get_prev_btn.Enabled = false;
            this.get_prev_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.get_prev_btn.Location = new System.Drawing.Point(16, 335);
            this.get_prev_btn.Name = "get_prev_btn";
            this.get_prev_btn.Size = new System.Drawing.Size(151, 23);
            this.get_prev_btn.TabIndex = 4;
            this.get_prev_btn.Text = "Get Previews";
            this.get_prev_btn.UseVisualStyleBackColor = true;
            this.get_prev_btn.Visible = false;
            this.get_prev_btn.Click += new System.EventHandler(this.get_prev_btn_Click);
            // 
            // get_btn
            // 
            this.get_btn.Enabled = false;
            this.get_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.get_btn.Location = new System.Drawing.Point(14, 306);
            this.get_btn.Name = "get_btn";
            this.get_btn.Size = new System.Drawing.Size(153, 23);
            this.get_btn.TabIndex = 3;
            this.get_btn.Text = "Reload";
            this.get_btn.UseVisualStyleBackColor = true;
            this.get_btn.Visible = false;
            this.get_btn.Click += new System.EventHandler(this.get_btn_Click);
            // 
            // all_items
            // 
            this.all_items.AutoSize = true;
            this.all_items.Location = new System.Drawing.Point(9, 37);
            this.all_items.Name = "all_items";
            this.all_items.Size = new System.Drawing.Size(79, 14);
            this.all_items.TabIndex = 2;
            this.all_items.Text = " Всего обоев: ";
            // 
            // g_count
            // 
            this.g_count.AutoSize = true;
            this.g_count.Location = new System.Drawing.Point(121, 36);
            this.g_count.Name = "g_count";
            this.g_count.Size = new System.Drawing.Size(13, 14);
            this.g_count.TabIndex = 1;
            this.g_count.Text = "0";
            this.g_count.Visible = false;
            // 
            // genres_list
            // 
            this.genres_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genres_list.FormattingEnabled = true;
            this.genres_list.Location = new System.Drawing.Point(11, 12);
            this.genres_list.Name = "genres_list";
            this.genres_list.Size = new System.Drawing.Size(153, 22);
            this.genres_list.TabIndex = 0;
            this.genres_list.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.LV);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1217, 403);
            this.panel2.TabIndex = 2;
            // 
            // previews
            // 
            this.previews.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.previews.ImageSize = new System.Drawing.Size(255, 152);
            this.previews.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(14, 364);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(151, 23);
            this.progress.TabIndex = 5;
            this.progress.Visible = false;
            // 
            // prog
            // 
            this.prog.AutoSize = true;
            this.prog.Location = new System.Drawing.Point(170, 373);
            this.prog.Name = "prog";
            this.prog.Size = new System.Drawing.Size(23, 14);
            this.prog.TabIndex = 6;
            this.prog.Text = "0%";
            this.prog.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.current_page);
            this.panel3.Location = new System.Drawing.Point(219, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(59, 22);
            this.panel3.TabIndex = 9;
            // 
            // current_page
            // 
            this.current_page.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.current_page.Dock = System.Windows.Forms.DockStyle.Fill;
            this.current_page.Enabled = false;
            this.current_page.Location = new System.Drawing.Point(0, 0);
            this.current_page.Name = "current_page";
            this.current_page.Size = new System.Drawing.Size(59, 22);
            this.current_page.TabIndex = 0;
            this.current_page.Text = "1";
            this.current_page.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.prev_btn);
            this.panel4.Location = new System.Drawing.Point(173, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(40, 22);
            this.panel4.TabIndex = 10;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.next_btn);
            this.panel5.Location = new System.Drawing.Point(284, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(40, 22);
            this.panel5.TabIndex = 10;
            // 
            // prev_btn
            // 
            this.prev_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prev_btn.Enabled = false;
            this.prev_btn.FlatAppearance.BorderSize = 0;
            this.prev_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prev_btn.Location = new System.Drawing.Point(0, 0);
            this.prev_btn.Name = "prev_btn";
            this.prev_btn.Size = new System.Drawing.Size(38, 20);
            this.prev_btn.TabIndex = 7;
            this.prev_btn.Text = "<<";
            this.prev_btn.UseVisualStyleBackColor = true;
            this.prev_btn.Click += new System.EventHandler(this.prev_btn_Click_1);
            // 
            // next_btn
            // 
            this.next_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.next_btn.Enabled = false;
            this.next_btn.FlatAppearance.BorderSize = 0;
            this.next_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.next_btn.Location = new System.Drawing.Point(0, 0);
            this.next_btn.Name = "next_btn";
            this.next_btn.Size = new System.Drawing.Size(38, 20);
            this.next_btn.TabIndex = 9;
            this.next_btn.Text = ">>";
            this.next_btn.UseVisualStyleBackColor = true;
            this.next_btn.Click += new System.EventHandler(this.next_btn_Click_1);
            // 
            // timer1
            // 
            // 
            // LV
            // 
            this.LV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LV.HideSelection = false;
            this.LV.LargeImageList = this.previews;
            this.LV.Location = new System.Drawing.Point(0, 0);
            this.LV.Margin = new System.Windows.Forms.Padding(10);
            this.LV.Name = "LV";
            this.LV.Size = new System.Drawing.Size(1215, 401);
            this.LV.TabIndex = 0;
            this.LV.UseCompatibleStateImageBehavior = false;
            this.LV.DoubleClick += new System.EventHandler(this.LV_DoubleClick);
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 485);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.strip);
            this.Font = new System.Drawing.Font("Motiva Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zastavki loader";
            this.Load += new System.EventHandler(this.mainform_Load);
            this.strip.ResumeLayout(false);
            this.strip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip strip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox genres_list;
        private System.Windows.Forms.Label g_count;
        private System.Windows.Forms.Label all_items;
        private System.Windows.Forms.Button get_btn;
        private Zastavki_loader.MyListView LV;
        private System.Windows.Forms.ImageList previews;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.Button get_prev_btn;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label prog;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label current_page;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button next_btn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button prev_btn;
        private System.Windows.Forms.Timer timer1;
    }
}

