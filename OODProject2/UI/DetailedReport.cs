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
    public partial class DetailedReport : MainPanel
    {
        private UserForm uf;
        private Button back = new Button();
        private string type;
        private Dictionary<string, string> data;
        private RichTextBox content = new RichTextBox();
        private RichTextBox fine = new RichTextBox();

        public DetailedReport(string type, string jsonData, UserForm uf)
        {
            this.type = type;
            this.uf = uf;

            headerLabel.Text = "جزئیات مستند انتخاب شده به شرح زیر است:";

            InitializeComponent();

            back.Size = new Size(50,15);
            back.Text = "بازگشت";
            data = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);

            if (type.Equals("هدف کلان"))
            {
                Label askTitle = new Label();
                askTitle.Location = new Point(260, 70);
                askTitle.Text = "عنوان هدف کلان:";

                Label goalTitle = new Label();
                goalTitle.Location = new Point(52, 70);
                goalTitle.Size = new Size(210, 20);
                goalTitle.Text = PersianClass.ToPersianNumber(data["title"]);

                back.Location = new Point(190, 110);
                this.Controls.Add(askTitle);
                this.Controls.Add(goalTitle);
            }
            else if (type.Equals("هدف اجرایی"))
            {
                Label askTitle = new Label();
                askTitle.Location = new Point(270, 70);
                askTitle.Text = "عنوان هدف اجرایی";

                Label goalTitle = new Label();
                goalTitle.Location = new Point(72, 70);
                goalTitle.Size = new Size(200, 20);
                goalTitle.Text = PersianClass.ToPersianNumber(data["title"]);

                Label askDate = new Label();
                askDate.Location = new Point(270, 100);
                askDate.Text = "موعد اجرای هدف";

                Label date = new Label();
                date.Location = new Point(122, 100);
                date.Size = new Size(150, 15);
                date.Text = PersianClass.ToPersianNumber(data["date"]);

                back.Location = new Point(200, 150);
                this.Controls.Add(askTitle);
                this.Controls.Add(goalTitle);
                this.Controls.Add(askDate);
                this.Controls.Add(date);
            }
            else if (type.Equals("میثاق نامه مدیریت محیطی"))
            {
                Label askContent = new Label();
                askContent.Text = "متن میثاق نامه:";
                askContent.Location = new Point(305, 30);
                askContent.Size = new Size(70, 15);

                content.Location = new Point(33, 32);
                content.Size = new Size(270, 130);
                content.ReadOnly = true;
                content.BackColor = System.Drawing.SystemColors.Window;

                back.Location = new Point(230, 170);
                this.Controls.Add(askContent);
                this.Controls.Add(content);
            }
            else if (type.Equals("قانون زیست محیطی"))
            {
                Label askTitle = new Label();
                askTitle.Text = "عنوان قانون";
                askTitle.Location = new Point(330, 40);
                askTitle.Size = new Size(50, 15);

                Label title = new Label();
                title.Location = new Point(30, 40);
                title.Size = new Size(280, 15);
                title.Text = PersianClass.ToPersianNumber(data["title"]);

                Label askType = new Label();
                askType.Text = "نوع قانون";
                askType.Location = new Point(330, 60);
                askType.Size = new Size(50, 15);

                Label type3 = new Label();
                type3.Location = new Point(215, 60);
                type3.Size = new Size(95, 15);
                type3.Text = data["type"];

                Label askYear = new Label();
                askYear.Text = "سال تصویب";
                askYear.Location = new Point(330, 80);
                askYear.Size = new Size(50, 15);

                Label year = new Label();
                year.Location = new Point(215, 80);
                year.Size = new Size(95, 15);
                year.Text = PersianClass.ToPersianNumber(data["year"]);

                Label askFine = new Label();
                askFine.Text = "جریمه تخلف";
                askFine.Location = new Point(320, 100);
                askFine.Size = new Size(60, 15);

                fine.Location = new Point(30, 100);
                fine.Size = new Size(280, 45);

                Label askdefinition = new Label();
                askdefinition.Text = "توضیح ماده قانونی";
                askdefinition.Location = new Point(308, 150);
                askdefinition.Size = new Size(72, 15);

                content.Location = new Point(30, 150);
                content.Size = new Size(280, 45);

                back.Location = new Point(240, 205);
                this.Controls.Add(askTitle);
                this.Controls.Add(title);
                this.Controls.Add(askType);
                this.Controls.Add(type3);
                this.Controls.Add(askYear);
                this.Controls.Add(year);
                this.Controls.Add(askFine);
                this.Controls.Add(fine);
                this.Controls.Add(askdefinition);
                this.Controls.Add(content);
            }
            else if (type.Equals("تاثیر زیست محیطی"))
            {
                Label askTitle = new Label();
                askTitle.Text = "عنوان تاثیر";
                askTitle.Location = new Point(320, 30);
                askTitle.Size = new Size(50, 15);
                this.Controls.Add(askTitle);

                Label title = new Label();
                title.Location = new Point(30, 30);
                title.Size = new Size(290, 15);
                title.Text = PersianClass.ToPersianNumber(data["title"]);
                this.Controls.Add(title);

                Label askEffect = new Label();
                askEffect.Text = "تاثیر روی";
                askEffect.Location = new Point(320, 50);
                askEffect.Size = new Size(50, 15);
                this.Controls.Add(askTitle);

                Panel affectedSource = new Panel() ;
                affectedSource.AutoScroll = true;
                affectedSource.Location = new Point(225, 50);
                affectedSource.Font = new Font("Nazanin", 10);
                affectedSource.Size = new Size(95, 50);
                string[] aSources = data["affectedSources"].Split('-');
                for (int i = 0; i < aSources.Length; i++)
                {
                    Label temp = new Label();
                    temp.Text = aSources[i];
                    temp.Size = new Size(95, 15);
                    temp.Location = new Point(0, i * 15 + 3);
                    affectedSource.Controls.Add(temp);
                }
                this.Controls.Add(affectedSource);

                Label askType = new Label();
                askType.Text = "نوع تاثیر";
                askType.Location = new Point(320, 120);
                askType.Size = new Size(50, 15);
                this.Controls.Add(askType);

                Label r1 = new Label();
                r1.Size = new Size(60, 120);
                r1.Location = new Point(260, 50);
                r1.Text = data["type"];
                this.Controls.Add(r1);

                Label askDuration = new Label();
                askDuration.Text = "مدت تاثیر";
                askDuration.Location = new Point(320, 140);
                askDuration.Size = new Size(50, 15);
                this.Controls.Add(askDuration);

                Label duration = new Label();
                duration.Location = new Point(190, 140);
                duration.Size = new Size(130, 10);
                duration.Text = PersianClass.ToPersianNumber(data["duration"]);
                this.Controls.Add(duration);

                Label askMagnitude = new Label();
                askMagnitude.Text = "شدت تاثیر";
                askMagnitude.Location = new Point(320, 160);
                askMagnitude.Size = new Size(50, 15);
                this.Controls.Add(askMagnitude);

                Label magnitude = new Label();
                magnitude.Location = new Point(190, 160);
                magnitude.Size = new Size(130, 10);
                magnitude.Text = PersianClass.ToPersianNumber(data["magnitude"]);
                this.Controls.Add(magnitude);

                Label askLocation = new Label();
                askLocation.Text = "منطقه جغرافیایی تاثیر";
                askLocation.Location = new Point(280, 180);
                askLocation.Size = new Size(90, 15);
                this.Controls.Add(askLocation);

                Label location = new Label();
                location.Location = new Point(190, 180);
                location.Size = new Size(130, 125);
                location.Text = PersianClass.ToPersianNumber(data["location"]);
                this.Controls.Add(location);

                Label askSource = new Label();
                askSource.Text = "منبع تاثیر";
                askSource.Location = new Point(320, 200);
                askSource.Size = new Size(50, 15);
                this.Controls.Add(askSource);

                Label source = new Label();
                source.Location = new Point(260, 200);
                source.Size = new Size(60, 10);
                source.Text = data["source"];
                this.Controls.Add(source);

                back.Location = new Point(130, 200);
            }
            this.uf = uf;

            back.Click += new EventHandler(this.onBackClick);
            this.Controls.Add(back);
        }

        private void DetailedReport_Load(object sender, EventArgs e)
        {
            if (type.Equals("میثاق نامه مدیریت محیطی"))
            {
                content.Text = PersianClass.ToPersianNumber(data["convention"]);
            }
            if (type.Equals("قانون زیست محیطی"))
            {
                fine.Text = PersianClass.ToPersianNumber(data["fine"]);
                content.Text = PersianClass.ToPersianNumber(data["description"]);
            }
        }

        private void onBackClick(object sender, EventArgs e)
        {
            uf.ChangeMainPanel(new FirstViewReport(true, uf));
        }
    }
}
