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
        private int subsystem = 0;
        private Button deleteBtn = new Button();
        private UserForm uf;

        public DetailedViewPanel(String headerStr, String type, bool isEditView, bool isRemoveView, UserForm u)
        {
            this.isEditView = isEditView;
            this.isRemoveView = isRemoveView;
            this.type = type.Remove(0, 1) ;
            this.uf = u;

            headerLabel.Text = headerStr;
            headerLabel.Location = new Point(90, 10);
            headerLabel.Size = new Size(280, 15);
            InitializeComponent();

            content = new DataGridView();
            content.Location = new Point(40, 40);
            content.Size = new Size(320, 130);

            content.AllowUserToAddRows = false;
            content.AllowUserToDeleteRows = false;
            content.AllowUserToOrderColumns = false;

            DataTable ct = new DataTable();
            ct.Columns.Add(" ");
            
            string d = "";
            if (type[0] == '0')
                d = Docs.DocFacade.ViewDocs(this.type);
            else if (type[0] == '1')
            {
                d = Plannings.PlanningFacade.ViewDocs(this.type);
                subsystem = 1;
            }
            else
                subsystem = 2;

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
                    r[ct.Columns[k + 1].ColumnName] = PersianClass.ToPersianNumber(data[ct.Columns[k + 1].ColumnName][j]);
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
            if (type.Equals("LegalRequi"))
            {
                content.Columns["جریمه تخلف"].Visible = false;
                content.Columns["توضیح ماده قانونی"].Visible = false;
                
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                content.Columns.Add(btn);
                content.Columns[8].DisplayIndex = 4;
                btn.HeaderText = "جریمه تخلف";
                btn.Text = "مشاهده";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;

                DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
                content.Columns.Add(btn2);
                btn2.HeaderText = "توضیح ماده قانونی";
                btn2.Text = "مشاهده";
                btn2.Name = "btn";
                btn2.UseColumnTextForButtonValue = true;
                content.Columns[9].DisplayIndex = 5;

                content.CellClick += new DataGridViewCellEventHandler(this.content_CellClick);
            }
            if (type.Equals("EnvImpacts"))
            {
                content.Columns["توضیح"].Visible = false;
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                content.Columns.Add(btn);
                content.Columns[10].DisplayIndex = 8;
                btn.HeaderText = "توضیح";
                btn.Text = "مشاهده";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;
                content.CellClick += new DataGridViewCellEventHandler(this.content_CellClick);
            }
            if (type.Equals("Convention"))
            {
                content.Columns["متن میثاق نامه"].Visible = false;
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                content.Columns.Add(btn);
                content.Columns[5].DisplayIndex = 2;
                btn.HeaderText = "متن میثاق نامه";
                btn.Text = "مشاهده";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;
                content.CellClick += new DataGridViewCellEventHandler(this.content_CellClick);
            }
            if (type.Contains("Relation"))
                content.Columns["ارتباطات"].Visible = false;
        }

        private void content_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Dictionary<string,string> data = new Dictionary<string,string>();
            for (int i=2; i<content.ColumnCount; i++)
                if (!data.ContainsKey(content.Columns[i].Name))
                    data.Add(content.Columns[i].Name, content.Rows[e.RowIndex].Cells[i].Value.ToString());
            
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            
            if (type.Equals("EnvGoals") && e.ColumnIndex == 0)
            {
                uf.ChangeMainPanel(new SAAddEnvironmentalGoalPanel(jsonData,uf,(e.RowIndex)));
            }
            else if (type.Equals("LegalRequi") && isEditView && e.ColumnIndex == 0 && !isRemoveView)
            {
                uf.ChangeMainPanel(new SAAddLegalRequirementPanel(jsonData, uf, (e.RowIndex)));
            }
            else if (type.Equals("LegalRequi") && e.ColumnIndex == 1 && ( isEditView || isRemoveView))
            {
                uf.ChangeMainPanel(new ViewRichTextBoxPanel("جریمه تخلف الزام قانونی انتخاب شده به شرح زیر است:", data["جریمه تخلف"], uf, isEditView, isRemoveView));
            }
            else if (type.Equals("LegalRequi") && e.ColumnIndex == 2 && (isEditView || isRemoveView))
            {
                uf.ChangeMainPanel(new ViewRichTextBoxPanel("توضیح ماده قانونی الزام قانونی انتخاب شده به شرح زیر است:", data["توضیح ماده قانونی"], uf, isEditView, isRemoveView));
            }
            else if (type.Equals("LegalRequi") && e.ColumnIndex == 0 && !isRemoveView && !isEditView)
            {
                uf.ChangeMainPanel(new ViewRichTextBoxPanel("جریمه تخلف الزام قانونی انتخاب شده به شرح زیر است:",data["جریمه تخلف"],uf,isEditView, isRemoveView));
            }
            else if (type.Equals("LegalRequi") && e.ColumnIndex == 1 && !isRemoveView)
            {
                uf.ChangeMainPanel(new ViewRichTextBoxPanel("توضیح ماده قانونی الزام قانونی انتخاب شده به شرح زیر است:",data["توضیح ماده قانونی"],uf, isEditView, isRemoveView));
            }
            else if (type.Equals("EnvImpacts") && isEditView && e.ColumnIndex == 0 && !isRemoveView)
            {
                uf.ChangeMainPanel(new SAAddEnvironmentalImpactPanel(jsonData, uf, (e.RowIndex)));
            }
            else if (type.Equals("EnvImpacts") && e.ColumnIndex == 0 && !isRemoveView && !isEditView)
            {
                uf.ChangeMainPanel(new ViewRichTextBoxPanel("توضیح تاثیر زیست محیطی انتخاب شده به شرح زیر است:", data["توضیح"], uf, isEditView, isRemoveView));
            }
            else if (type.Equals("Convention") && isEditView && e.ColumnIndex == 0 && !isRemoveView)
            {
                uf.ChangeMainPanel(new SAAddConventionPanel(jsonData, uf, (e.RowIndex)));
            }
            else if (type.Equals("Convention") && e.ColumnIndex == 0 && !isRemoveView && !isEditView)
            {
                uf.ChangeMainPanel(new ViewRichTextBoxPanel("متن میثاق نامه انتخاب شده به شرح زیر است:", data["متن میثاق نامه"], uf, isEditView, isRemoveView));
            }
            else if (type.Contains("Relation") && e.ColumnIndex == 0 && isEditView)
            {
                string[] types = (type.Remove(0, 8)).Split('-');
                uf.ChangeMainPanel(new AddAssociationPanel(uf, (e.RowIndex), types[0], types[1],jsonData)); 
            }
            else if (type.Equals("Resources") && e.ColumnIndex == 0 && isEditView)
            {
                uf.ChangeMainPanel(new IAAddResourcePanel(jsonData, uf, (e.RowIndex)));
            }
            else if (type.Equals("OpGoals") && e.ColumnIndex == 0 && isEditView)
            {
                uf.ChangeMainPanel(new IAAddOpGoalPanel(jsonData, uf, (e.RowIndex)));
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
                if (subsystem == 0)
                    Docs.DocFacade.deleteDocs(type, indexes);
                else if (subsystem == 1)
                    Plannings.PlanningFacade.DeleteDocs(type, indexes);

                UserForm.Confirm("اطلاعات موردنظر با موفقیت از سیستم حذف گردیدند.");
            }
            
        }

    }
}
