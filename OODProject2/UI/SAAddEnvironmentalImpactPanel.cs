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
    public partial class SAAddEnvironmentalImpactPanel : AddPanel
    {
        private Label askTitle = new Label();
        private Label askEffect = new Label();
        private Label askType = new Label();
        private Label askDuration = new Label();
        private Label askMagnitude = new Label();
        private Label askLocation = new Label();
        private Label askSource = new Label();
        private Label askDescription = new Label();

        private TextBox title = new TextBox();
        private CheckedListBox affectedSource = new CheckedListBox();
        private List<RadioButton> type = new List<RadioButton>();
        private DomainUpDown duration = new DomainUpDown();
        private ComboBox magnitude = new ComboBox();
        private TextBox location = new TextBox();
        private ComboBox source = new ComboBox();
        private RichTextBox description = new RichTextBox();

        public SAAddEnvironmentalImpactPanel()
        {
            headerLabel.Text = "لطفا مشخصات تاثیر زیست محیطی جدید موردنظر خود را وارد کنید: ";
            headerLabel.Location = new Point(75, 10);
            headerLabel.Size = new Size(300, 15);
            InitializeComponent();

            askTitle.Text = "عنوان تاثیر";
            askTitle.Location = new Point(320, 30);
            askTitle.Size = new Size(50, 15);

            title.Location = new Point(30, 30);
            title.Size = new Size(290, 15);

            askEffect.Text = "تاثیر روی";
            askEffect.Location = new Point(320, 50);
            askEffect.Size = new Size(50, 15);

            affectedSource.Items.Add("هوا");
            affectedSource.Items.Add("آب");
            affectedSource.Items.Add("گیاهان");
            affectedSource.Items.Add("جانداران");
            affectedSource.Items.Add("منابع معدنی");
            affectedSource.Location = new Point(225, 50);
            affectedSource.Font = new Font("Nazanin", 10);
            affectedSource.Size = new Size(95, 78);
            affectedSource.BackColor = SystemColors.Control;

            askType.Text = "نوع تاثیر";
            askType.Location = new Point(160, 50);
            askType.Size = new Size(50, 15);

            RadioButton r1 = new RadioButton();
            r1.Text = "تاثیر مفید";
            r1.Size = new Size(60, 15);
            r1.Location = new Point(100, 50);
            this.Controls.Add(r1);

            RadioButton r2 = new RadioButton();
            r2.Text = "تاثیر مخرب";
            r2.Size = new Size(65, 15);
            r2.Location = new Point(30, 50);
            this.Controls.Add(r2);

            type.Add(r1);
            type.Add(r2);

            askDuration.Text = "مدت تاثیر";
            askDuration.Location = new Point(160, 75);
            askDuration.Size = new Size(50, 15);

            duration.Items.Add(PersianClass.ToPersianNumber("کمتر از 5 سال"));
            duration.Items.Add(PersianClass.ToPersianNumber("5الی 10 سال"));
            duration.Items.Add(PersianClass.ToPersianNumber("10الی 20 سال"));
            duration.Items.Add(PersianClass.ToPersianNumber("20 الی 100 سال"));
            duration.Items.Add(PersianClass.ToPersianNumber("بیشتر از 100 سال"));
            duration.SelectedIndex = 0;
            duration.Location = new Point(30, 75);
            duration.Size = new Size(130, 10);

            askMagnitude.Text = "شدت تاثیر";
            askMagnitude.Location = new Point(160, 100);
            askMagnitude.Size = new Size(50, 15);

            magnitude.Location = new Point(30, 100);
            magnitude.Size = new Size(130, 10);
            magnitude.Items.Add("خیلی کم");
            magnitude.Items.Add("کم");
            magnitude.Items.Add("زیاد");
            magnitude.Items.Add("خیلی زیاد");
            magnitude.SelectedIndex = 0;

            askLocation.Text = "منطقه جغرافیایی تاثیر";
            askLocation.Location = new Point(160, 125);
            askLocation.Size = new Size(90, 15);

            location.Location = new Point(30, 125);
            location.Size = new Size(130, 125);

            askSource.Text = "منبع تاثیر";
            askSource.Location = new Point(320, 125);
            askSource.Size = new Size(50, 15);

            source.Items.Add("فعالیت ها");
            source.Items.Add("محصولات");
            source.Items.Add("خدمات");
            source.Location = new Point(260, 125);
            source.Size = new Size(60, 10);
            source.SelectedIndex = 0;

            askDescription.Text = "توضیح";
            askDescription.Location = new Point(157, 150);
            askDescription.Size = new Size(40, 15);

            description.Location = new Point(30, 150);
            description.Size = new Size(130, 60);

            registerButton.Location = new Point(250, 190);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);

            this.Controls.Add(askTitle);
            this.Controls.Add(title);
            this.Controls.Add(askEffect);
            this.Controls.Add(affectedSource);
            this.Controls.Add(askType);
            this.Controls.Add(askDuration);
            this.Controls.Add(duration);
            this.Controls.Add(askMagnitude);
            this.Controls.Add(magnitude);
            this.Controls.Add(askLocation);
            this.Controls.Add(location);
            this.Controls.Add(askSource);
            this.Controls.Add(source);
            this.Controls.Add(askDescription);
            this.Controls.Add(description);
        }

        private void SAAddEnvironmentalImpactPanel_Load(object sender, EventArgs e)
        {

        }

        private void onRegisterClick(object sender, EventArgs e)
        {
            int i = 0;
            foreach (RadioButton r in type)
                if (r.Checked)
                    i++;

            int j = 0;
            foreach (int m in affectedSource.CheckedIndices)
                j++;
            if (title.Text.Equals(""))
            {
                errorLable.Text = "لطفا عنوان تاثیر زیست محیطی را وارد کنید!";
                errorLable.Location = new Point(200, 380);
                errorLable.Size = new Size(230, 20);
                errorLable.Show();
            }
            else if (j == 0)
            {
                errorLable.Text = "لطفا منابع تاثیر گیرنده را انتخاب کنید!";
                errorLable.Location = new Point(200, 380);
                errorLable.Size = new Size(230, 20);
                errorLable.Show();
            }
            else if (i == 0)
            {
                errorLable.Text = "لطفا نوع تاثیر را انتخاب کنید!";
                errorLable.Location = new Point(200, 380);
                errorLable.Size = new Size(230, 20);
                errorLable.Show();
            }
            else if (location.Text.Equals(""))
            {
                errorLable.Text = "لطفا منطقه جغرافیایی تاثیر را وارد کنید!";
                errorLable.Location = new Point(200, 380);
                errorLable.Size = new Size(230, 20);
                errorLable.Show();
            }
            else
            {
                errorLable.Hide();
                this.Hide();
                UserForm.Confirm("تاثیر زیست محیطی موردنظر با موفقیت در سیستم به ثبت رسید.");
            }
        }
    }
}
