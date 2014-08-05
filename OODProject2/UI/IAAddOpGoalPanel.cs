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
    public partial class IAAddOpGoalPanel : AddPanel
    {
        private Label askTitle = new Label();
        private TextBox goalTitle = new TextBox();
        private Label askDate = new Label();
        //private DateTimePicker date = new DateTimePicker();
        private FarsiLibrary.Win.Controls.FADatePicker date = new FarsiLibrary.Win.Controls.FADatePicker();

        private UserForm uf;
        private bool isEdit = false;
        private int index = 0;
        private Button back = new Button();
        private string ntitle;
        private string ndate;
        
        public IAAddOpGoalPanel()
        {
            headerLabel.Text = "لطفا هدف اجرایی جدید موردنظر خود را وارد کنید: ";
            InitializeComponent();
            
            askTitle.Location = new Point(270, 70);
            askTitle.Text = "عنوان هدف اجرایی";

            goalTitle.Location = new Point(72, 70);
            goalTitle.Size = new Size(200, 20);

            askDate.Location = new Point(270, 100);
            askDate.Text = "موعد اجرای هدف";

            date.Location = new Point(122, 100);
            date.Size = new Size(150, 15);
            
            date.SelectedDateTime = FarsiLibrary.Utils.PersianDate.Now;
 
            registerButton.Location = new Point(200, 150);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);
            this.Controls.Add(askTitle);
            this.Controls.Add(askDate);
            this.Controls.Add(goalTitle);
            this.Controls.Add(date);
        }

        public IAAddOpGoalPanel(string initialData, UserForm u, int index)
        {
            isEdit = true;
            this.uf = u;
            this.index = index;

            Dictionary<string, string> data = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(initialData);

            headerLabel.Text = "لطفا هدف اجرایی جدید موردنظر خود را وارد کنید: ";
            InitializeComponent();

            askTitle.Location = new Point(270, 70);
            askTitle.Text = "عنوان هدف اجرایی";

            goalTitle.Location = new Point(72, 70);
            goalTitle.Size = new Size(200, 20);
            goalTitle.Text = data["عنوان هدف اجرایی"];
            ntitle = goalTitle.Text;

            askDate.Location = new Point(270, 100);
            askDate.Text = "موعد اجرای هدف";

            date.Location = new Point(122, 100);
            date.Size = new Size(150, 15);
            date.SelectedDateTime = FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(Convert.ToDateTime(data["موعد اجرای هدف"]));
            ndate = data["موعد اجرای هدف"];

            registerButton.Location = new Point(200, 150);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);

            back.Location = new Point(135, 150);
            back.Size = new Size(60, 18);
            back.Text = "بازگشت";
            back.BackColor = Color.LightSkyBlue;
            back.Click += new System.EventHandler(this.onBackClick);
            this.Controls.Add(back);
            this.Controls.Add(askTitle);
            this.Controls.Add(askDate);
            this.Controls.Add(goalTitle);
            this.Controls.Add(date);
        }

        private void IAAddOpGoalPanel_Load(object sender, EventArgs e)
        {

        }

        private void onBackClick(object sender, EventArgs e)
        {
            uf.ChangeMainPanel(new DetailedViewPanel("هدف اجرایی موردنظر خود را برای ویرایش از لیست زیر انتخاب کنید:", "1OpGoals", true, false, uf));
        }

        private void onRegisterClick(object sender, EventArgs e)
        {
            if (goalTitle.Text.Equals(""))
            {
                errorLable.Text = "لطفا عنوان هدف اجرایی را وارد کنید!";
                errorLable.Show();
            }
            else
            {
                if (isEdit)
                {
                    if(ntitle.Equals(goalTitle.Text) && date.SelectedDateTime.Equals(FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(Convert.ToDateTime(ndate))))
                        MessageBox.Show(this, "!تغییری روی هدف اجرایی صورت نگرفته است", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        Dictionary<string, string> data = new Dictionary<string, string>();
                        data.Add("title", goalTitle.Text);
                        data.Add("date", date.SelectedDateTime.ToString());
                        string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                        Plannings.PlanningFacade.Update("OpGoals", index, jsonData);
                        MessageBox.Show(this, "!هدف اجرایی با موفقیت تغییر یافت", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        uf.ChangeMainPanel(new DetailedViewPanel("هدف اجرایی موردنظر خود را برای ویرایش از لیست زیر انتخاب کنید:", "1OpGoals", true, false, uf));
                    }
                }
                else
                {
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add("title", goalTitle.Text);
                    data.Add("date", date.SelectedDateTime.ToString());
                    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    bool added = Plannings.PlanningFacade.AddDoc("OpGoals", jsonData);
                    if (!added)
                    {
                        MessageBox.Show(this, "!هدفی با عنوان یکسان قبلا در سامانه به ثبت رسیده است", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        errorLable.Hide();
                        this.Hide();
                        UserForm.Confirm("هدف اجرایی موردنظر با موفقیت در سیستم به ثبت رسید.");
                    }
                }
            }
        }


    }
}
