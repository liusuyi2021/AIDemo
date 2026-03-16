namespace AIDemo
{
    partial class Setting
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

        private void InitializeComponent()
        {
            flowPanel5 = new AntdUI.FlowPanel();
            btn_add = new AntdUI.Button();
            input_url = new AntdUI.Input();
            label2 = new AntdUI.Label();
            input_title = new AntdUI.Input();
            label1 = new AntdUI.Label();
            table1 = new AntdUI.Table();
            flowPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // flowPanel5
            // 
            flowPanel5.Align = AntdUI.TAlignFlow.Center;
            flowPanel5.Controls.Add(btn_add);
            flowPanel5.Controls.Add(input_url);
            flowPanel5.Controls.Add(label2);
            flowPanel5.Controls.Add(input_title);
            flowPanel5.Controls.Add(label1);
            flowPanel5.Dock = DockStyle.Top;
            flowPanel5.Location = new Point(0, 0);
            flowPanel5.Name = "flowPanel5";
            flowPanel5.Size = new Size(578, 37);
            flowPanel5.TabIndex = 2;
            flowPanel5.Text = "flowPanel5";
            // 
            // btn_add
            // 
            btn_add.Font = new Font("Microsoft YaHei UI", 12F);
            btn_add.Location = new Point(498, 3);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(75, 31);
            btn_add.TabIndex = 14;
            btn_add.Text = "添加";
            btn_add.Type = AntdUI.TTypeMini.Success;
            btn_add.Click += btn_add_Click;
            // 
            // input_url
            // 
            input_url.Location = new Point(224, 3);
            input_url.Name = "input_url";
            input_url.Size = new Size(268, 30);
            input_url.TabIndex = 13;
            // 
            // label2
            // 
            label2.Location = new Point(175, 3);
            label2.Name = "label2";
            label2.Size = new Size(43, 30);
            label2.TabIndex = 12;
            label2.Text = "地址：";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // input_title
            // 
            input_title.Location = new Point(54, 3);
            input_title.Name = "input_title";
            input_title.Size = new Size(115, 30);
            input_title.TabIndex = 11;
            // 
            // label1
            // 
            label1.Location = new Point(5, 3);
            label1.Name = "label1";
            label1.Size = new Size(43, 30);
            label1.TabIndex = 10;
            label1.Text = "标题：";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // table1
            // 
            table1.AutoSizeColumnsMode = AntdUI.ColumnsMode.Fill;
            table1.Bordered = true;
            table1.Dock = DockStyle.Fill;
            table1.Gap = 12;
            table1.Location = new Point(0, 37);
            table1.Name = "table1";
            table1.Size = new Size(578, 286);
            table1.TabIndex = 3;
            table1.Text = "table1";
            // 
            // Setting
            // 
            Controls.Add(table1);
            Controls.Add(flowPanel5);
            Name = "Setting";
            Size = new Size(578, 323);
            Load += Setting_Load;
            flowPanel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private AntdUI.FlowPanel flowPanel5;
        private AntdUI.Table table1;
        private AntdUI.Input input_title;
        private AntdUI.Label label1;
        private AntdUI.Button btn_add;
        private AntdUI.Input input_url;
        private AntdUI.Label label2;
    }
}