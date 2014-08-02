using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OODProject_2_.UI
{
    public partial class DetailedUpdatePanel : MainPanel
    {
        private DataGridView content = new DataGridView();
        private Button change = new Button();
        private string type = "";
        private Dictionary<string, List<string>> data;

        public DetailedUpdatePanel(string headerStr, String type)
        {
            this.type = type;
            headerLabel.Text = headerStr;
            headerLabel.Location = new Point(120, 10);
            headerLabel.Size = new Size(250, 15);
            InitializeComponent();
            content = new DataGridView();
            content.Location = new Point(40, 40);
            content.Size = new Size(320, 120);
            if (type.Equals("EnvGoals"))
            {
                string d = Docs.DocFacade.ViewDocs(type);
                data = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(d);
                List<string> goals = new List<string>();
                List<string> dates = new List<string>();
                List<string> names = new List<string>();
                foreach (KeyValuePair<string, List<string>> entry in data)
                {
                    if (entry.Key.Equals("goals"))
                        goals = entry.Value;
                    else if (entry.Key.Equals("dates"))
                        dates = entry.Value;
                    else
                        names = entry.Value;
                }

                content.EditMode = DataGridViewEditMode.EditOnKeystroke;

                content.AllowUserToAddRows = false;
                content.AllowUserToDeleteRows = false;
                content.AllowUserToOrderColumns = false;
                
                DataTable ct = new DataTable();
                ct.Columns.Add(" ");
                ct.Columns.Add("عنوان هدف کلان");
                ct.Columns.Add("تاریخ آخرین ویرایش");
                ct.Columns.Add("آخرین ویرایشگر");

                ct.Columns[0].ReadOnly = true;
                ct.Columns[2].ReadOnly = true;
                ct.Columns[3].ReadOnly = true;

                int i = 0;
                foreach (string str in goals)
                {
                    DataRow r = ct.NewRow();
                    r[" "] = (i + 1).ToString();
                    r["عنوان هدف کلان"] = str;
                    r["تاریخ آخرین ویرایش"] = dates[i];
                    r["آخرین ویرایشگر"] = names[i];
                    ct.Rows.Add(r);
                    i++;
                }

                BindingSource bs = new BindingSource();
                bs.DataSource = ct;
                content.DataSource = bs;

            }

            change.Location = new Point(160, 170);
            change.Size = new Size(70, 20);
            change.Text = "ثبت تغییرات";
            change.BackColor = Color.LightSkyBlue;
            change.Click += new EventHandler(this.onChangeClick);

            this.Controls.Add(content);
            this.Controls.Add(change);
        }

        private void DetailedUpdatePanel_Load(object sender, EventArgs e)
        {
            content.Columns[0].Width = 40;
            content.Columns[1].Width = 180;
            content.Columns[2].Width = 90;
            content.Columns[3].Width = 90;
            content.ColumnHeadersHeight = 60;
        }

        private void onChangeClick(object sender, EventArgs e)
        {
            List<List<string>> data = new List<List<string>>();
            for (int rows = 0; rows < content.Rows.Count; rows++)
            {
                List<string> row = new List<string>();
                for (int col= 0; col < content.Rows[rows].Cells.Count; col++)
                {
                    string value = content.Rows[rows].Cells[col].Value.ToString();
                    row.Add(value);
                }
                data.Add(row);
            }

            this.Hide();
            UserForm.Confirm("تغییرات موردنظر با موفقیت در سیستم به ثبت رسیدند.");
        }

    }
}
