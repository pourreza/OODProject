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

        private void SAAddLegalRequirementPanel_Load(object sender, EventArgs e)
        {

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
                errorLable.Hide();
                this.Hide();
                UserForm.Confirm("الزام زیست محیطی موردنظر با موفقیت در سیستم به ثبت رسید.");
            }
        }
    }
}
