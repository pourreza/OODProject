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
    public partial class SAAddLegalRequirementPanel : AddPanel
    {
        private Label askTitle = new Label();
        private Label askType = new Label();
        private Label askYear = new Label();
        private Label askFine = new Label();
        private Label askdefinition = new Label();

        private TextBox title = new TextBox();
        private ComboBox type = new ComboBox();
        private DomainUpDown year = new DomainUpDown();
        private RichTextBox fine = new RichTextBox();
        private RichTextBox description = new RichTextBox();

        private UserForm uf;
        private bool isEdit = false;
        private int index = 0;
        private Button back = new Button();
        private string ltitle = "";
        private string ltype = "";
        private string lyear = "";
        private string lfine = "";
        private string ldescription = "";
        
        public SAAddLegalRequirementPanel()
        {
            headerLabel.Text = "لطفا مشخصات الزام زیست محیطی جدید موردنظر خود را وارد کنید: ";
            headerLabel.Location = new Point(75, 10);
            headerLabel.Size = new Size(300, 15);
            InitializeComponent();

            askTitle.Text = "عنوان قانون";
            askTitle.Location = new Point(330, 40);
            askTitle.Size = new Size(50, 15);

            title.Location = new Point(30, 40);
            title.Size = new Size(280, 15);

            askType.Text = "نوع قانون";
            askType.Location = new Point(330, 65);
            askType.Size = new Size(50, 15);

            type.Items.Add("بین المللی");
            type.Items.Add("ملی");
            type.Items.Add("استانی");
            type.Items.Add("شهری");
            type.Location = new Point(215, 65);
            type.Size = new Size(95, 78);
            type.SelectedIndex = 0;

            askYear.Text = "سال تصویب";
            askYear.Location = new Point(110, 65);
            askYear.Size = new Size(50, 15);

            for (int i = 1368; i < 1393; i++)
                year.Items.Add(PersianClass.ToPersianNumber("" + i));
            year.Location = new Point(30, 65);
            year.Size = new Size(70, 10);
            year.SelectedIndex = 0;

            askFine.Text = "جریمه تخلف";
            askFine.Location = new Point(320, 90);
            askFine.Size = new Size(60, 15);

            fine.Location = new Point(30, 90);
            fine.Size = new Size(280, 45);

            askdefinition.Text = "توضیح ماده قانونی";
            askdefinition.Location = new Point(308, 140);
            askdefinition.Size = new Size(72, 15);

            description.Location = new Point(30, 140);
            description.Size = new Size(280, 45);

            registerButton.Location = new Point(240, 195);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);
            this.Controls.Add(askTitle);
            this.Controls.Add(title);
            this.Controls.Add(askYear);
            this.Controls.Add(year);
            this.Controls.Add(askType);
            this.Controls.Add(type);
            this.Controls.Add(askFine);
            this.Controls.Add(fine);
            this.Controls.Add(askdefinition);
            this.Controls.Add(description);
        }

        public SAAddLegalRequirementPanel(string initialData, UserForm u, int index)
        {
            InitializeComponent();

            isEdit = true;
            this.uf = u;
            this.index = index;
            Dictionary<string, string> data = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(initialData);

            headerLabel.Text = "مشخصات الزام زیست محیطی موردنظر خود را تغییر دهید: ";
            headerLabel.Location = new Point(75, 10);
            headerLabel.Size = new Size(300, 15);
            
            askTitle.Text = "عنوان قانون";
            askTitle.Location = new Point(330, 40);
            askTitle.Size = new Size(50, 15);

            title.Location = new Point(30, 40);
            title.Size = new Size(280, 15);
            title.Text = data["عنوان قانون"];

            ltitle = data["عنوان قانون"];

            askType.Text = "نوع قانون";
            askType.Location = new Point(330, 65);
            askType.Size = new Size(50, 15);

            type.Items.Add("بین المللی");
            type.Items.Add("ملی");
            type.Items.Add("استانی");
            type.Items.Add("شهری");
            type.Location = new Point(215, 65);
            type.Size = new Size(95, 78);
            
            for (int i=0; i<type.Items.Count; i++)
                if (type.Items[i].Equals(data["نوع قانون"]))
                    type.SelectedIndex = i;

            ltype = data["نوع قانون"];

            askYear.Text = "سال تصویب";
            askYear.Location = new Point(110, 65);
            askYear.Size = new Size(50, 15);

            for (int i = 1368; i < 1394; i++)
                year.Items.Add(PersianClass.ToPersianNumber("" + i));

            year.Location = new Point(30, 65);
            year.Size = new Size(70, 10);
            year.SelectedIndex = 0;

            for (int i = 0; i < year.Items.Count; i++)
                if (year.Items[i].Equals(PersianClass.ToPersianNumber(data["سال تصویب"])))
                    year.SelectedIndex = i;

            lyear = data["سال تصویب"];

            askFine.Text = "جریمه تخلف";
            askFine.Location = new Point(320, 90);
            askFine.Size = new Size(60, 15);

            fine.Location = new Point(30, 90);
            fine.Size = new Size(280, 45);
            fine.Text = data["جریمه تخلف"];
            lfine = data["جریمه تخلف"];

            askdefinition.Text = "توضیح ماده قانونی";
            askdefinition.Location = new Point(308, 140);
            askdefinition.Size = new Size(72, 15);

            description.Location = new Point(30, 140);
            description.Size = new Size(280, 45);
            description.Text = data["توضیح ماده قانونی"];
            ldescription = data["توضیح ماده قانونی"];

            registerButton.Location = new Point(240, 195);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);
            
            back.Location = new Point(175, 195);
            back.Size = new Size(60, 18);
            back.Text = "بازگشت";
            back.BackColor = Color.LightSkyBlue;
            back.Click += new System.EventHandler(this.onBackClick);

            this.Controls.Add(askTitle);
            this.Controls.Add(title);
            this.Controls.Add(askYear);
            this.Controls.Add(year);
            this.Controls.Add(askType);
            this.Controls.Add(type);
            this.Controls.Add(askFine);
            this.Controls.Add(fine);
            this.Controls.Add(askdefinition);
            this.Controls.Add(description);
            this.Controls.Add(back);
        }

        private void SAAddLegalRequirementPanel_Load(object sender, EventArgs e)
        {
            if (isEdit)
            {
                description.Text = ""+ ldescription;
                fine.Text = lfine;
                
            }
        }

        private void onBackClick(object sender, EventArgs e)
        {
            uf.ChangeMainPanel(new DetailedViewPanel("با انتخاب الزام زیست محیطی موردنظر خود از جدول زیر آن را ویرایش کنید:", "LegalRequi", true, false, uf));
        }

        private void onRegisterClick(object sender, EventArgs e)
        {
            if (title.Text.Equals(""))
            {
                errorLable.Text = "لطفا عنوان الزام زیست محیطی را وارد کنید!";
                errorLable.Location = new Point(165, 380);
                errorLable.Size = new Size(250, 20);
                errorLable.Show();
            }
            else if (fine.Text.Equals(""))
            {
                errorLable.Text = "لطفا جریمه تخلف الزام زیست محیطی را وارد کنید!";
                errorLable.Location = new Point(165, 380);
                errorLable.Size = new Size(250, 20);
                errorLable.Show();
            }
            else if (description.Text.Equals(""))
            {
                errorLable.Text = "لطفا توضیحی از ماده قانونی الزام زیست محیطی را وارد کنید!";
                errorLable.Location = new Point(115, 380);
                errorLable.Size = new Size(300, 20);
                errorLable.Show();
            }
            else
            {
                if (isEdit)
                {
                    if (ltitle.Equals(title.Text) && ltype.Equals(type.SelectedItem.ToString()) && lyear.Equals(year.SelectedItem.ToString()) && lfine.Equals(fine.Text) && ldescription.Equals(description.Text))
                        MessageBox.Show(this, "!تغییری روی قانون زیست محیطی صورت نگرفته است", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        Dictionary<string, string> data = new Dictionary<string, string>();
                        data.Add("title", title.Text);
                        data.Add("type", type.SelectedItem.ToString());
                        data.Add("year", year.SelectedItem.ToString());
                        data.Add("fine", fine.Text);
                        data.Add("description", description.Text);
                        string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                        Docs.DocFacade.update("LegalRequi", index, jsonData);
                        MessageBox.Show(this, "!الزام زیست محیطی با موفقیت تغییر یافت", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        uf.ChangeMainPanel(new DetailedViewPanel("با انتخاب الزام زیست محیطی موردنظر خود از جدول زیر آن را ویرایش کنید:", "LegalRequi", true, false, uf));
                    }
                }
                else
                {
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add("title", title.Text);
                    data.Add("type", type.SelectedItem.ToString());
                    data.Add("year", year.SelectedItem.ToString());
                    data.Add("fine", fine.Text);
                    data.Add("description", description.Text);
                    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    bool added = Docs.DocFacade.AddDoc("LegalRequi", jsonData);
                    if (!added)
                    {
                        MessageBox.Show(this, "!الزام زیست محیطی با عنوان یکسان قبلا در سامانه به ثبت رسیده است", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        errorLable.Hide();
                        this.Hide();
                        UserForm.Confirm("الزام زیست محیطی موردنظر با موفقیت در سیستم به ثبت رسید.");
                    }
                }
            }
        }
    }
}
