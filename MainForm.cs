using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Core;

namespace AIDemo
{
    public partial class MainForm : AntdUI.Window
    {
        string dbPath = "database.db"; // SQLite 文件路径
        // 保存所有 Tab 配置
        private List<TabConfig> tabConfigs = new List<TabConfig>();
        private Dictionary<AntdUI.TabPage, WebView2> tabWebMap = new();

        public MainForm()
        {
            InitializeComponent();
            bool isLight = ThemeHelper.IsLightMode();
            ThemeHelper.SetColorMode(this, isLight);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                await ReloadTabs();
            }
            catch(Exception ex)
            {
                MessageBox.Show("异常："+ex.Message);
            }
            //// 初始化默认 Tabs
            //await AddTab(new TabConfig { Title = "ChatGPT", Url = "https://chat.openai.com" });
            //await AddTab(new TabConfig { Title = "豆包", Url = "https://www.doubao.com/" });
            //await AddTab(new TabConfig { Title = "DeepSeek", Url = "https://chat.deepseek.com/" });
            //await AddTab(new TabConfig { Title = "千问", Url = "https://www.qianwen.com/" });
        }
        private async Task ReloadTabs()
        {
            // 清空现有 Tab
            tabs1.Pages.Clear();

            using var repo = new ModelRepository(dbPath);
            List<Model> models = repo.GetAll();

            foreach (Model model in models)
            {
                await AddTab(new TabConfig
                {
                    Title = model.Title,
                    Url = model.Url,
                    Icon = model.Icon
                });
            }
        }
        /// <summary>
        /// 添加 Tab
        /// </summary>
        public async Task<AntdUI.TabPage> AddTab(TabConfig cfg)
        {
            if (cfg == null || string.IsNullOrWhiteSpace(cfg.Url))
            {
                AntdUI.Message.error(this, "URL不能为空");
                return null;
            }

            string url = cfg.Url.Trim();

            // 自动补全协议
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "https://" + url;
            }

            // 验证URL
            if (!Uri.TryCreate(url, UriKind.Absolute, out var uri))
            {
                AntdUI.Message.error(this, "URL格式错误: " + url);
                return null;
            }

            var tabPage = new AntdUI.TabPage
            {
                ReadOnly = false,
                IconSvg = cfg.Icon ?? "AppleFilled",
                Text = cfg.Title
            };

            var web = new WebView2
            {
                Dock = DockStyle.Fill
            };

            tabPage.Controls.Add(web);

            tabs1.Pages.Add(tabPage);
            tabs1.SelectedIndex = tabs1.Pages.Count - 1;

            await web.EnsureCoreWebView2Async();

            web.Source = uri;   // 推荐用 Source 而不是 Navigate

            return tabPage;
        }

        /// <summary>
        /// 删除 Tab
        /// </summary>
        public void RemoveTab(AntdUI.TabPage tab)
        {
            if (tabWebMap.ContainsKey(tab))
            {
                var web = tabWebMap[tab];
                web.Dispose(); // 释放 WebView2
                tabWebMap.Remove(tab);
            }

            var cfg = tabConfigs.FirstOrDefault(c => c.Title == tab.Text);
            if (cfg != null)
                tabConfigs.Remove(cfg);

            tabs1.Pages.Remove(tab);
        }

        /// <summary>
        /// 修改 Tab
        /// </summary>
        public void UpdateTab(AntdUI.TabPage tab, TabConfig newCfg)
        {
            tab.Text = newCfg.Title;
            tab.IconSvg = newCfg.Icon ?? "AppleFilled";

            if (tabWebMap.TryGetValue(tab, out var web))
            {
                web.CoreWebView2.Navigate(newCfg.Url);
            }

            var oldCfg = tabConfigs.FirstOrDefault(c => c.Title == tab.Text);
            if (oldCfg != null)
                tabConfigs[tabConfigs.IndexOf(oldCfg)] = newCfg;
        }

        /// <summary>
        /// 获取所有 Tab 配置
        /// </summary>
        public List<TabConfig> GetTabConfigs() => tabConfigs;

        private void btn_setting_Click(object sender, EventArgs e)
        {
            var setting = new Setting(this);
            AntdUI.Modal.Config config = new AntdUI.Modal.Config(this, "设置", setting);
            config.CancelText = null;
            DialogResult dialogResult = AntdUI.Modal.open(config);
            if (dialogResult == DialogResult.OK)
            {       
                // 关闭后重新加载
                _ = ReloadTabs();
                Refresh();
            }
        }
    }
}