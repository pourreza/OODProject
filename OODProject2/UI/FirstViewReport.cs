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
    public partial class FirstViewReport : MainPanel
    {
        private Label header2Label = new Label();
        private DataGridView content = new DataGridView();
        private UserForm uf;
        private bool isDoc = false;

        public FirstViewReport(bool isDoc, UserForm uf)
        {
            InitializeComponent();
            this.uf = uf;
            this.isDoc = isDoc;

            headerLabel.Location = new Point(90, 10);
            headerLabel.Size = new Size(280, 15);

            header2Label.Location = new Point(90, 30);
            header2Label.Size = new Size(280, 15);

            content.Location = new Point(30, 40);
            content.Size = new Size(330, 180);

            content.AllowUserToAddRows = false;
            content.AllowUserToDeleteRows = false;
            content.AllowUserToOrderColumns = false;

            if (isDoc)
            {
                headerLabel.Text = "مستندات ثبت شده به ترتیب تاریخ به شرح زیراند.";
                header2Label.Text = "جهت مشاهده ریزگزارش، گزارش موردنظر خود را انتخاب کنید.";
            }
            else
            {
                headerLabel.Text = "گزارش پیشرفت برنامه اقدام هر هدف اجرایی به شرح زیر است.";
                header2Label.Text = "برای مشاهده روندهای زمانی، برنامه موردنظر خود را انتخاب کنید.";
            }

            DataTable ct = new DataTable();
            ct.Columns.Add(" ");
            
            string d = "";
            if (isDoc)
                d = Docs.DocFacade.ReportDocs();
            else 
                d = Audits.AuditFacade.ReportPlan();

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

            content.CellClick += new DataGridViewCellEventHandler(this.content_CellClick);
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            content.Columns.Add(btn);
            btn.HeaderText = "ریزگزارش";
            btn.Text = "مشاهده";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;

            this.Controls.Add(content);
            this.Controls.Add(header2Label);
        }

        private void FirstViewReport_Load(object sender, EventArgs e)
        {
            content.Columns[0].Width = 50;
            content.Columns[1].Width = 30;
            content.Columns[2].Width = 180;
            content.Columns[3].Width = 180;
        }

        private void content_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Dictionary<string,string> data = new Dictionary<string,string>();
            for (int i=2; i<content.ColumnCount; i++)
                if (!data.ContainsKey(content.Columns[i].Name))
                    data.Add(content.Columns[i].Name, content.Rows[e.RowIndex].Cells[i].Value.ToString());
            
            if (isDoc && e.ColumnIndex == 0)
            {
                string jsonData = Docs.DocFacade.GetReportDetail(data["نوع مستند و پرونده الکترونیک"], data["عنوان مستند"]);
                uf.ChangeMainPanel(new DetailedReport(data["نوع مستند و پرونده الکترونیک"],jsonData, uf));
            }
            else if (!isDoc && e.ColumnIndex == 0)
            {
                string jsonData = Audits.AuditFacade.ReportDetailPlan(data["عنوان برنامه"]);
                uf.ChangeMainPanel(new ChartReport(jsonData, false, uf));
            }
            
        }
        
    }
}
