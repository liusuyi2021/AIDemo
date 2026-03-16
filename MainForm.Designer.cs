namespace AIDemo
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AntdUI.Tabs.StyleLine styleLine1 = new AntdUI.Tabs.StyleLine();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            pageHeader1 = new AntdUI.PageHeader();
            btn_setting = new AntdUI.Button();
            tabs1 = new AntdUI.Tabs();
            pageHeader1.SuspendLayout();
            SuspendLayout();
            // 
            // pageHeader1
            // 
            pageHeader1.Controls.Add(btn_setting);
            pageHeader1.Dock = DockStyle.Top;
            pageHeader1.Icon = Properties.Resources.favicon;
            pageHeader1.Location = new Point(0, 0);
            pageHeader1.Name = "pageHeader1";
            pageHeader1.ShowButton = true;
            pageHeader1.ShowIcon = true;
            pageHeader1.Size = new Size(1024, 23);
            pageHeader1.TabIndex = 1;
            pageHeader1.Text = "AIDemo";
            // 
            // btn_setting
            // 
            btn_setting.Dock = DockStyle.Right;
            btn_setting.Ghost = true;
            btn_setting.IconSvg = "SettingOutlined";
            btn_setting.Location = new Point(834, 0);
            btn_setting.Name = "btn_setting";
            btn_setting.Radius = 0;
            btn_setting.Size = new Size(46, 23);
            btn_setting.TabIndex = 9;
            btn_setting.WaveSize = 0;
            btn_setting.Click += btn_setting_Click;
            // 
            // tabs1
            // 
            tabs1.Centered = true;
            tabs1.Dock = DockStyle.Fill;
            tabs1.Gap = 10;
            tabs1.Location = new Point(0, 23);
            tabs1.Name = "tabs1";
            tabs1.Size = new Size(1024, 745);
            tabs1.Style = styleLine1;
            tabs1.TabIndex = 2;
            tabs1.Text = "tabs1";
            tabs1.TextCenter = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 768);
            Controls.Add(tabs1);
            Controls.Add(pageHeader1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AIDemo";
            Load += MainForm_Load;
            pageHeader1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private AntdUI.PageHeader pageHeader1;
        private AntdUI.Tabs tabs1;
        private AntdUI.Button btn_setting;
    }
}
