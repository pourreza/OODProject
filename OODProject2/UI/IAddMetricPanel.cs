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
    public partial class IAddMetricPanel : AddPanel
    {
        private Label askTitle = new Label();
        private TextBox title = new TextBox();
        private Label askType = new Label();
        private ComboBox type = new ComboBox();
        private Label askImportance = new Label();
        private DomainUpDown importance = new DomainUpDown();

        public IAddMetricPanel()
        {
            InitializeComponent();

            askTitle.Location = new Point(300, 50);
            askTitle.Text = "نام متریک";
            askTitle.Size = new Size(40, 20);

            title.Location = new Point(72, 50);
            title.Size = new Size(200, 20);

            askType.Location = new Point(280, 80);
            askType.Text = "طبقه بندی متریک";
            askType.Size = new Size(60, 20);

            type.Location = new Point(160, 80);
            type.Size = new Size(110, 20);
            type.Items.Add("مصرف منابع");
            type.Items.Add("کیفیت هوا");
            type.Items.Add("کیفیت/کمیت خاک");
            type.Items.Add("کیفیت آب");
            type.Items.Add("تنوع محیطی طبیعی");

            askImportance.Location = new Point(300, 110);
            askImportance.Text = "وزن اهمیت";
            askImportance.Size = new Size(40, 20);

            importance.Location = new Point(160, 110);
            importance.Size = new Size(110, 50);
            importance.BorderStyle = BorderStyle.Fixed3D;
            importance.Items.Add(PersianClass.ToPersianNumber("1"));
            importance.Items.Add(PersianClass.ToPersianNumber("2"));
            importance.Items.Add(PersianClass.ToPersianNumber("3"));
            importance.Items.Add(PersianClass.ToPersianNumber("4"));
            importance.Items.Add(PersianClass.ToPersianNumber("5"));

            registerButton.Location = new Point(200, 170);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);

            headerLabel.Text = "لطفا متریک جدید موردنظر خود را وارد کنید: ";

            this.Controls.Add(askType);
            this.Controls.Add(askTitle);
            this.Controls.Add(askImportance);
            this.Controls.Add(title);
            this.Controls.Add(type);
            this.Controls.Add(importance);
        }

        private void IAddMetricPanel_Load(object sender, EventArgs e)
        {

        }

        private void onRegisterClick(object sender, EventArgs e)
        {
            if (title.Text.Equals(""))
            {
                errorLable.Text = "لطفا عنوان متریک را وارد کنید!";
                errorLable.Show();
                errorLable.Location = new Point(205, 340);
                errorLable.Size = new Size(160, 20);
            }
            else
            {

                errorLable.Hide();
                this.Hide();
                UserForm.Confirm("متریک موردنظر با موفقیت در سیستم به ثبت رسید.");
            }
        }
    }
}
