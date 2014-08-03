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

        private UserForm uf;
        private bool isEdit = false;
        private int index = 0;
        private Button back = new Button();
        private string ntitle = "";
        private string[] naffectedSource;
        private string ntype = "";
        private string nduration = "";
        private string nmagnitude = "";
        private string nlocation = "";
        private string nsource = "";
        private string ndescription = "";

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

        public SAAddEnvironmentalImpactPanel(string initialData, UserForm u, int index)
        {
            isEdit = true;
            this.uf = u;
            this.index = index;
            Dictionary<string, string> data = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(initialData);

            headerLabel.Text = "مشخصات تاثیر زیست محیطی موردنظر خود را تغییر دهید: ";
            headerLabel.Location = new Point(75, 10);
            headerLabel.Size = new Size(300, 15);
            InitializeComponent();

            askTitle.Text = "عنوان تاثیر";
            askTitle.Location = new Point(320, 30);
            askTitle.Size = new Size(50, 15);

            title.Location = new Point(30, 30);
            title.Size = new Size(290, 15);
            title.Text = data["عنوان تاثیر"];
            ntitle = title.Text;

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

            naffectedSource = data["تاثیر روی"].Split('-');
            
            for (int i = 0; i < affectedSource.Items.Count; i++)
                for ( int j=0; j< naffectedSource.Length ; j++)
                    if (affectedSource.Items[i].Equals(naffectedSource[j]))
                        affectedSource.SelectedIndex = i;


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

            ntype = data["نوع تاثیر"];
            if (ntype.Equals("تاثیر مخرب"))
                r2.Checked = true;
            else
                r1.Checked = true;

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

            for (int i = 0; i < duration.Items.Count; i++)
                if (duration.Items[i].Equals(data["مدت تاثیر"]))
                    duration.SelectedIndex = i;

            nduration = data["مدت تاثیر"];

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

            for (int i = 0; i < magnitude.Items.Count; i++)
                if (magnitude.Items[i].Equals(data["شدت تاثیر"]))
                    magnitude.SelectedIndex = i;

            nmagnitude = data["شدت تاثیر"];

            askLocation.Text = "منطقه جغرافیایی تاثیر";
            askLocation.Location = new Point(160, 125);
            askLocation.Size = new Size(90, 15);

            location.Location = new Point(30, 125);
            location.Size = new Size(130, 125);
            location.Text = data["منطقه جغرافیایی"];
            nlocation = data["منطقه جغرافیایی"];

            askSource.Text = "منبع تاثیر";
            askSource.Location = new Point(320, 125);
            askSource.Size = new Size(50, 15);

            source.Items.Add("فعالیت ها");
            source.Items.Add("محصولات");
            source.Items.Add("خدمات");
            source.Location = new Point(260, 125);
            source.Size = new Size(60, 10);
            source.SelectedIndex = 0;

            for (int i = 0; i < source.Items.Count; i++)
                if (source.Items[i].Equals(data["منبع تاثیر"]))
                    source.SelectedIndex = i;

            nsource = data["منبع تاثیر"];

            askDescription.Text = "توضیح";
            askDescription.Location = new Point(157, 150);
            askDescription.Size = new Size(40, 15);

            description.Location = new Point(30, 150);
            description.Size = new Size(130, 60);
            ndescription = data["توضیح"];

            registerButton.Location = new Point(260, 190);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);

            back.Location = new Point(195, 190);
            back.Size = new Size(60, 18);
            back.Text = "بازگشت";
            back.BackColor = Color.LightSkyBlue;
            back.Click += new System.EventHandler(this.onBackClick);
            this.Controls.Add(back);
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
            if (isEdit)
                description.Text = ndescription;
        }

        private void onBackClick(object sender, EventArgs e)
        {
            uf.ChangeMainPanel(new DetailedViewPanel("با انتخاب تاثیر زیست محیطی موردنظر خود از جدول زیر آن را ویرایش کنید:", "EnvImpacts", true, false, uf));
        }

        private void onRegisterClick(object sender, EventArgs e)
        {
            int i = 0;
            string checkedType = "";
            foreach (RadioButton r in type)
                if (r.Checked)
                {
                    i++;
                    checkedType = r.Text;
                }

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
                if (isEdit)
                {
                    bool equal = true;
                    string asources = "";
                    for (int k = 0; k< affectedSource.SelectedIndices.Count; k++)
                    {
                        bool found = false;
                        asources += affectedSource.Items[k];
                        for (int m=0; m<naffectedSource.Length; m++)
                            if(affectedSource.Items[k].Equals(naffectedSource[m]))
                                found = true;
                        if (!found)
                        {
                            equal = false;
                        }
                        if (k < (affectedSource.SelectedIndices.Count - 1))
                            asources += "-";
                    }

                    for (int k = 0; k < naffectedSource.Length; k++)
                    {
                        bool found = false;
                        for (int m = 0; m < affectedSource.SelectedIndices.Count; m++)
                            if (affectedSource.Items[m].Equals(naffectedSource[k]))
                                found = true;
                        if (!found)
                            equal = false;
                    }

                    if (ntitle.Equals(title.Text) && equal && ntype.Equals(checkedType) && nduration.Equals(duration.SelectedItem.ToString()) && nmagnitude.Equals(magnitude.SelectedItem.ToString()) && nlocation.Equals(location.Text) && nsource.Equals(source.SelectedItem.ToString()) && ndescription.Equals(description.Text))
                        MessageBox.Show(this, "!تغییری روی تاثیر زیست محیطی صورت نگرفته است", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        Dictionary<string, string> data = new Dictionary<string, string>();
                        data.Add("title", title.Text);
                        data.Add("affectedSources", asources);
                        data.Add("type", checkedType);
                        data.Add("duration", duration.SelectedItem.ToString());
                        data.Add("magnitude", magnitude.SelectedItem.ToString() );
                        data.Add("location", location.Text);
                        data.Add("source",source.SelectedItem.ToString());
                        data.Add("description", description.Text);
                        string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                        Docs.DocFacade.update("EnvImpacts", index, jsonData);
                        MessageBox.Show(this, "!تاثیر زیست محیطی با موفقیت تغییر یافت", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        uf.ChangeMainPanel(new DetailedViewPanel("با انتخاب تاثیر زیست محیطی موردنظر خود از جدول زیر آن را ویرایش کنید:", "EnvImpacts", true, false, uf));
                    }
                }
                else
                {
                    string asources = "";
                    for (int k = 0; k < affectedSource.SelectedIndices.Count; k++)
                    {
                        asources += affectedSource.Items[k];
                        if (k < (affectedSource.SelectedIndices.Count - 1))
                            asources += "-";
                    }

                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add("title", title.Text);
                    data.Add("affectedSources", asources);
                    data.Add("type", checkedType);
                    data.Add("duration", duration.SelectedItem.ToString());
                    data.Add("magnitude", magnitude.SelectedItem.ToString());
                    data.Add("location", location.Text);
                    data.Add("source", source.SelectedItem.ToString());
                    data.Add("description", description.Text);
                    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    bool added = Docs.DocFacade.AddDoc("EnvImpacts", jsonData);
                    if (!added)
                    {
                        MessageBox.Show(this, "!تاثیر زیست محیطی با عنوان یکسان قبلا در سامانه به ثبت رسیده است", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
