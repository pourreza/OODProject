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
    public partial class AddAssociationPanel : AddPanel
    {
        private Label first = new Label();
        private Label second = new Label();
        private ComboBox firstList = new ComboBox();
        private List<CheckBox> secondList = new List<CheckBox>();

        private UserForm uf;
        private bool isEdit = false;
        private int index = 0;
        private Button back = new Button();
        private string[] relatedList;
        private string type1 = "";
        private string type2 = "";

        public AddAssociationPanel(string header, string str1, string str2, string type1, string type2)
        {
            this.type1 = type1;
            this.type2 = type2;
            headerLabel.Text = header;
            headerLabel.Location = new Point(90, 10);
            headerLabel.Size = new Size(280, 15);
            
            InitializeComponent();

            first.Location = new Point(280, 50);
            first.Text = str1;
            first.Size = new Size(90, 20);

            firstList.Location = new Point(122, 50);
            firstList.Size = new Size(150, 20);

            List<string> firstItems = Docs.DocFacade.GetDocsNames(type1);
            for (int i = 0; i < firstItems.Count; i++)
            {
                firstList.Items.Add(PersianClass.ToPersianNumber(firstItems[i]));
            }
            firstList.SelectedIndex = 0;

            second.Location = new Point(280, 80);
            second.Text = str2;
            second.Size = new Size(90, 20);

            Panel pnl = new Panel();
            pnl.BorderStyle = BorderStyle.FixedSingle;
            pnl.Location = new Point(122, 80);
            pnl.Size = new Size(150, 100);
            pnl.AutoScroll = true;

            List<string> secondItems = Docs.DocFacade.GetDocsNames(type2);
            int k = 0;
            for (int i = 0; i < secondItems.Count; i++)
            {
                CheckBox c = new CheckBox();
                c.Text = PersianClass.ToPersianNumber(secondItems[i]);
                c.Font = new Font("Nazanin", 10);
                c.Location = new Point(0, k * 20 + 3);
                if (secondItems.Count <= 4)
                    c.Location = new Point(13, k * 20 + 3);
                c.Size = new Size(130, 15);
                secondList.Add(c);
                pnl.Controls.Add(c);
                k++;
            }
            
            registerButton.Location = new Point(203, 190);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);

            this.Controls.Add(first);
            this.Controls.Add(firstList);
            this.Controls.Add(second);
            this.Controls.Add(pnl);
            
        }

        public AddAssociationPanel(UserForm u, int index, string type1, string type2, string initialData)
        {
            isEdit = true;
            this.uf = u;
            this.index = index;
            this.type1 = type1;
            this.type2 = type2;
            Dictionary<string, string> data = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(initialData);

            headerLabel.Text = "موارد مرتبط با گزینه ی انتخابی خود را تغییر دهید:";
            headerLabel.Location = new Point(90, 10);
            headerLabel.Size = new Size(280, 15);

            InitializeComponent();

            if (type1.Equals("EnvGoals"))
                first.Text = "هدف کلان";
            else
                first.Text = "قانون زیست محیطی";
            first.Location = new Point(280, 50);
            first.Size = new Size(90, 20);

            Label firstItem = new Label();
            firstItem.Location = new Point(122, 50);
            firstItem.Size = new Size(150, 20);

            if (type1.Equals("EnvGoals"))
                firstItem.Text = data["هدف کلان"];
            else
                firstItem.Text = data["قانون زیست محیطی"];

            second.Location = new Point(280, 80);
            second.Size = new Size(90, 20);

            if (type2.Equals("EnvImpacts"))
                second.Text = "تاثیرات زیست محیطی";
            else if (type2.Equals("LegalRequi"))
                second.Text = "قوانین زیست محیطی";
            else
                second.Text = "اهداف اجرایی";

            Panel pnl = new Panel();
            pnl.BorderStyle = BorderStyle.FixedSingle;
            pnl.Location = new Point(122, 80);
            pnl.Size = new Size(150, 100);
            pnl.AutoScroll = true;

            relatedList = data["ارتباطات"].Split('-');

            List<string> secondItems = Docs.DocFacade.GetDocsNames(type2);
            int k = 0;
            for (int i = 0; i < secondItems.Count; i++)
            {
                CheckBox c = new CheckBox();
                c.Text = PersianClass.ToPersianNumber(secondItems[i]);
                for (int m = 0; m < relatedList.Length; m++)
                    if (c.Text.Equals(relatedList[m]))
                        c.Checked = true;
                c.Font = new Font("Nazanin", 10);
                c.Location = new Point(0, k * 20 + 3);
                if (secondItems.Count <= 4)
                    c.Location = new Point(13, k * 20 + 3);
                c.Size = new Size(130, 15);
                secondList.Add(c);
                pnl.Controls.Add(c);
                k++;
            }

            registerButton.Location = new Point(203, 190);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);
            back.Location = new Point(138, 110);
            back.Size = new Size(60, 18);
            back.Text = "بازگشت";
            back.BackColor = Color.LightSkyBlue;
            back.Click += new System.EventHandler(this.onBackClick);
            this.Controls.Add(first);
            this.Controls.Add(firstList);
            this.Controls.Add(second);
            this.Controls.Add(pnl);

        }

        private void AddAssociationPanel_Load(object sender, EventArgs e)
        {

        }

        private void onBackClick(object sender, EventArgs e)
        {
            string tempType = "Relation" + type1 + "-" + type2;
            if (type1.Equals("EnvGoals"))
                uf.ChangeMainPanel(new DetailedViewPanel("هدف کلان موردنظر خود را برای تغییر در ارتباطات آن انتخاب کنید:", tempType, true, false, uf));
            else
                uf.ChangeMainPanel(new DetailedViewPanel("قانون موردنظر خود را برای تغییر در ارتباطات آن انتخاب کنید:", tempType, true, false, uf));
        }

        private void onRegisterClick(object sender, EventArgs e)
        {
            string tempType = "Relation" + type1 + "-" + type2;
            int i = 0;
            foreach (CheckBox indexChecked in secondList)
                if (indexChecked.Checked)
                    i++;
            if (i == 0)
            {
                errorLable.Text = "هیچ یک از موارد لیست جهت برقراری ارتباط انتخاب نشده اند!";
                errorLable.Show();
                errorLable.Location = new Point(55, 370);
                errorLable.Size = new Size(310, 20);
            }
            else
            {
                if (isEdit)
                {
                    string resStr = "";
                    bool equal = true;
                    for (int k = 0; k < secondList.Count; k++)
                    {
                        bool found = false;
                        if (secondList[k].Checked)
                        {
                            resStr += secondList[k].Text;
                            for (int kk = 0; kk < relatedList.Length; kk++)
                            {
                                if (secondList[k].Text.Equals(relatedList[kk]))
                                    found = true;
                            }
                            if (!found)
                                equal = false;
                            if (k < (secondList.Count - 1))
                                resStr += "-";
                        }
                    }
                    for (int m = 0; m < relatedList.Length; m++)
                    {
                        bool found = false;
                        for (int mm = 0; mm < secondList.Count; mm++)
                            if (secondList[mm].Checked && secondList[mm].Text.Equals(relatedList[m]))
                                found = true;
                        if (!found)
                            equal = false;
                    }

                    if (equal)
                        MessageBox.Show(this, "!تغییری روی ارتباطات صورت نگرفته است", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        
                        Dictionary<string, string> data = new Dictionary<string, string>();
                        data.Add("rels", resStr);
                        string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                        Docs.DocFacade.update(tempType, index, jsonData);
                        MessageBox.Show(this, "!ارتباط موردنظر با موفقیت تغییر یافت", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        
                        if (type1.Equals("EnvGoals"))
                            uf.ChangeMainPanel(new DetailedViewPanel("هدف کلان موردنظر خود را برای تغییر در ارتباطات آن انتخاب کنید:", tempType, true, false, uf));
                        else
                            uf.ChangeMainPanel(new DetailedViewPanel("قانون موردنظر خود را برای تغییر در ارتباطات آن انتخاب کنید:", tempType, true, false, uf));
                        
                    }
                }
                else
                {
                    string resStr = "";
                    for (int k = 0; k < secondList.Count; k++)
                    {
                        if (secondList[k].Checked)
                        {
                            resStr += secondList[k].Text;
                            if (k < (secondList.Count - 1))
                                resStr += "-";
                        }
                    }
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add("title", firstList.SelectedItem.ToString());
                    data.Add("rels", resStr);
                    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    bool added = Docs.DocFacade.AddDoc(tempType, jsonData);
                    if (!added)
                    {
                        MessageBox.Show(this, "!ارتباطات مربوط به عنصر انتخاب شده قبلا در سامانه به ثبت رسیده اند", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        errorLable.Hide();
                        this.Hide();
                        UserForm.Confirm("ارتباط موردنظر با موفقیت در سیستم به ثبت رسید.");
                    }
                }
                
            }
        }
    }
}
