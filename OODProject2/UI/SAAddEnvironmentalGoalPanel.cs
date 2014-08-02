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
    public partial class SAAddEnvironmentalGoalPanel : AddPanel
    {
        private Label askTitle = new Label();
        private TextBox goalTitle = new TextBox();
        private UserForm uf;
        private bool isEdit = false;
        private int index = 0;
        private string gTitle = "";
        private Button back = new Button();

        public SAAddEnvironmentalGoalPanel()
        {
            headerLabel.Text = "لطفا هدف کلان جدید موردنظر خود را وارد کنید: ";
            InitializeComponent();

            askTitle.Location = new Point(260, 70);
            askTitle.Text = "عنوان هدف کلان:";

            goalTitle.Location = new Point(52, 70);
            goalTitle.Size = new Size(210, 20);

            registerButton.Location = new Point(190, 110);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);
            this.Controls.Add(askTitle);
            this.Controls.Add(goalTitle);

        }

        public SAAddEnvironmentalGoalPanel(string initialData, UserForm u, int index)
        {
            isEdit = true;
            this.uf = u;
            this.index = index;

            headerLabel.Text = "هدف کلان موردنظر خود را تغییر دهید: ";
            InitializeComponent();

            askTitle.Location = new Point(260, 70);
            askTitle.Text = "عنوان هدف کلان:";

            goalTitle.Location = new Point(52, 70);
            goalTitle.Size = new Size(210, 20);

            Dictionary<string, string> data = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(initialData);
            goalTitle.Text = data["عنوان هدف کلان"];
            gTitle = data["عنوان هدف کلان"];

            registerButton.Location = new Point(190, 110);
            registerButton.Text = "ثبت تغییرات";
            registerButton.Click += new System.EventHandler(this.onRegisterClick);

            back.Location = new Point(125, 110);
            back.Size = new Size(60, 18);
            back.Text = "بازگشت";
            back.BackColor = Color.LightSkyBlue;
            back.Click += new System.EventHandler(this.onBackClick);
            this.Controls.Add(askTitle);
            this.Controls.Add(goalTitle);
            this.Controls.Add(back);

        }

        private void SAAddEnvironmentalGoalPanel_Load(object sender, EventArgs e)
        {

        }

        private void onBackClick(object sender, EventArgs e)
        {
            uf.ChangeMainPanel(new DetailedViewPanel("با انتخاب هدف کلان موردنظر خود از جدول زیر آن را ویرایش کنید:", "EnvGoals", true, false, uf));
        }

        private void onRegisterClick(object sender, EventArgs e)
        {
            if (goalTitle.Text.Equals(""))
            {
                errorLable.Text = "لطفا عنوان هدف کلان را وارد کنید!";
                errorLable.Location = new Point(135, 250);
                errorLable.Show();
            }
            else
            {
                if (isEdit)
                {
                    if (gTitle.Equals(goalTitle.Text))
                        MessageBox.Show(this, "!تغییری روی هدف کلان صورت نگرفته است", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        Dictionary<string, string> data = new Dictionary<string, string>();
                        data.Add("goal", goalTitle.Text);
                        string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                        Docs.DocFacade.update("EnvGoal", index, jsonData);
                        MessageBox.Show(this, "!هدف کلان با موفقیت تغییر یافت", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        uf.ChangeMainPanel(new DetailedViewPanel("با انتخاب هدف کلان موردنظر خود از جدول زیر آن را ویرایش کنید:", "EnvGoals", true, false, uf));
                    }
                }
                else
                {
                    errorLable.Hide();
                    this.Hide();
                    UserForm.Confirm("هدف کلان موردنظر با موفقیت در سیستم به ثبت رسید.");
                }
            }
        }
    }
}
