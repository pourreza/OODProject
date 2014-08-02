using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OODProject_2_.UI
{
    public partial class DetailedViewPanel : MainPanel
    {

        private DataGridView content;
        private bool isEditView = false;
        private bool isRemoveView = false;
        private string type = "";
        private Button deleteBtn = new Button();
        private UserForm uf;

        public DetailedViewPanel(String headerStr, String type, bool isEditView, bool isRemoveView, UserForm u)
        {
            this.isEditView = isEditView;
            this.isRemoveView = isRemoveView;
            this.type = type;
            this.uf = u;

            headerLabel.Text = headerStr;
            headerLabel.Location = new Point(120, 10);
            headerLabel.Size = new Size(250, 15);
            InitializeComponent();

            content = new DataGridView();
            content.Location = new Point(40, 40);
            content.Size = new Size(320, 130);

            content.AllowUserToAddRows = false;
            content.AllowUserToDeleteRows = false;
            content.AllowUserToOrderColumns = false;

            DataTable ct = new DataTable();
            ct.Columns.Add(" ");
            
            string d = Docs.DocFacade.ViewDocs(type);
            Dictionary<string, List<string>> data = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(d);

            int countColumns = 0;
            List<string> temp = new List<string>();
            foreach (KeyValuePair<string, List<string>> entry in data)
            {
                if (countColumns == 0)
                    temp = entry.Value;
                ct.Columns.Add(entry.Key);
                ct.Columns[countColumns].ReadOnly = true;
                countColumns++;
            }

            for (int j = 0; j < temp.Count; j++)
            {
                DataRow r = ct.NewRow();
                r[" "] = PersianClass.ToPersianNumber((j + 1).ToString());
                for (int k = 0; k < countColumns; k++)
                    r[ct.Columns[k + 1].ColumnName] = data[ct.Columns[k + 1].ColumnName][j];
                ct.Rows.Add(r);
            }
            
            BindingSource bs = new BindingSource();
            bs.DataSource = ct;
            content.DataSource = bs;

            deleteBtn.Location = new Point(165, 180);
            deleteBtn.Size = new Size(70, 20);
            deleteBtn.Text = "حذف داده ها";
            deleteBtn.BackColor = Color.LightSkyBlue;
            deleteBtn.Click += new EventHandler(this.onDeleteClick);
            deleteBtn.Hide();

            if (isEditView)
            {
                content.CellClick += new DataGridViewCellEventHandler(this.content_CellClick);
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                content.Columns.Add(btn);
                btn.HeaderText = "ویرایش";
                btn.Text = "ویرایش";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;
            }
            else if (isRemoveView)
            {
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                content.Columns.Add(chk);
                chk.HeaderText = "انتخاب";
                chk.Name = "chk";
                deleteBtn.Show();
            }
            
            this.Controls.Add(content);
            this.Controls.Add(deleteBtn);
        }

        private void DetailedViewPanel_Load(object sender, EventArgs e)
        {
            content.RowTemplate.Height = 30;
            
            content.Columns[" "].Width = 30;
            content.Columns[1].Width = 180;
            content.Columns[2].Width = 90;
            content.Columns[3].Width = 90;
            content.ColumnHeadersHeight = 60;

            if (isEditView)
            {
                content.Columns[0].Width = 50;
                content.Columns[1].Width = 30;
                content.Columns[2].Width = 180;
            }
            else if (isRemoveView)
            {
                content.Columns[0].Width = 50;
                content.Columns[1].Width = 30;
                content.Columns[2].Width = 180;
            }

        }

        private void content_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Dictionary<string,string> data = new Dictionary<string,string>();
            for (int i=2; i<content.ColumnCount; i++)
                data.Add(content.Columns[i].Name, content.Rows[e.RowIndex].Cells[i].Value.ToString());
            
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            
            if (type.Equals("EnvGoals") && e.ColumnIndex == 0)
            {
                uf.ChangeMainPanel(new SAAddEnvironmentalGoalPanel(jsonData,uf,(e.RowIndex)));
            }
        }
        
        private void onDeleteClick(object sender, EventArgs e)
        {
            List<int> indexes = new List<int>();
            int count = 0;
            for (int rows = 0; rows < content.Rows.Count; rows++)
            {
                if (content.Rows[rows].Cells[0].Value != null)
                {
                    count++;
                    indexes.Add(rows);
                }
            }
            
            if (count==0)
                MessageBox.Show("!داده ای برای حذف انتخاب نشده است","!توجه",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            // Configure the message box to be displayed 
            else if (MessageBox.Show("مطمئنید که می خواهید این اطلاعات را حذف کنید؟", "!توجه",
         MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
         == DialogResult.Yes)
            {
                Docs.DocFacade.deleteDocs(type, indexes);
                UserForm.Confirm("اطلاعات موردنظر با موفقیت از سیستم حذف گردیدند.");
            }
            
        }

    }
}
