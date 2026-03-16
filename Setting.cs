
namespace AIDemo
{
    public partial class Setting : UserControl
    {
        AntdUI.BaseForm form;
        string dbPath = "database.db"; // SQLite 文件路径
        public Setting(AntdUI.BaseForm _form)
        {
            form = _form;
            InitializeComponent();
        }
        private void Setting_Load(object sender, EventArgs e)
        {
            table1.CellButtonClick += Table1_CellButtonClick;
            table1.Columns = new AntdUI.ColumnCollection {
                new AntdUI.Column("Title", "标题").SetWidth("100"),
                new AntdUI.Column("Url", "地址"),
                new AntdUI.Column("btns", "操作").SetFixed().SetWidth("auto").SetLocalizationTitleID("Table.Column."),
            };
            List<AntdUI.AntItem[]> list = new List<AntdUI.AntItem[]>();
            using var repo = new ModelRepository(dbPath);
            var data = repo.GetAll();
            foreach (var item in data)
            {
                var btns = new AntdUI.CellLink[]
                {
                new AntdUI.CellButton("delete", "删除", AntdUI.TTypeMini.Error).SetBorder().SetGhost()
                };
                list.Add(new AntdUI.AntItem[]
                {
                    new AntdUI.AntItem("Id", item.Id),
                    new AntdUI.AntItem("Title", item.Title),
                    new AntdUI.AntItem("Url", item.Url),
                    new AntdUI.AntItem("btns", btns)
                });
            }
            table1.DataSource = list;
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            // 去掉首尾空格
            string title = input_title.Text.Trim();
            string url = input_url.Text.Trim();

            if (string.IsNullOrEmpty(title))
            {
                AntdUI.Message.warn(form, "标题不能为空");
                return;
            }

            if (string.IsNullOrEmpty(url))
            {
                AntdUI.Message.warn(form, "URL不能为空");
                return;
            }

            using var repo = new ModelRepository(dbPath);
            // 添加
            repo.Add(new Model
            {
                Title = title,
                Url = url,
                Icon = "AppleFilled" // 可根据需要改
            });

            RefreshTable();
        }

        private void Table1_CellButtonClick(object sender, AntdUI.TableButtonEventArgs e)
        {
            if (e.Btn.Id == "delete")
            {
                int id = 0;
                var row = e.Record as AntdUI.AntItem[];
                foreach (var item in row)
                {
                    if (item.key == "Id") id = Convert.ToInt32(item.value);
                }
                using var repo = new ModelRepository(dbPath);
                repo.Delete(id);
                RefreshTable();
            }
        }

        private void RefreshTable()
        {
            List<AntdUI.AntItem[]> list = new();

            using var repo = new ModelRepository(dbPath);
            var data = repo.GetAll();

            foreach (var item in data)
            {
                var btns = new AntdUI.CellLink[]
                {
                    new AntdUI.CellButton("delete","删除",AntdUI.TTypeMini.Error).SetBorder().SetGhost()
                };

                list.Add(new AntdUI.AntItem[]
                {
                    new AntdUI.AntItem("Id", item.Id),
                    new AntdUI.AntItem("Title", item.Title),
                    new AntdUI.AntItem("Url", item.Url),
                    new AntdUI.AntItem("btns", btns)
                });
            }

            table1.DataSource = list;
        }
    }
}
