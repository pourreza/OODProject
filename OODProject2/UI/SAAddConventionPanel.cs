﻿using System;
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
    public partial class SAAddConventionPanel : AddPanel
    {
        private Label askContent = new Label();
        private RichTextBox content = new RichTextBox();

        private UserForm uf;
        private bool isEdit = false;
        private int index = 0;
        private Button back = new Button();
        private string ncontent = "";

        public SAAddConventionPanel()
        {
            headerLabel.Text = "لطفا متن میثاق نامه مدیریت محیطی جدید موردنظر خود را وارد کنید: ";
            headerLabel.Location = new Point(75, 10);
            headerLabel.Size = new Size(300, 15);
            InitializeComponent();

            askContent.Text = "متن میثاق نامه:";
            askContent.Location = new Point(305, 30);
            askContent.Size = new Size(70, 15);

            content.Location = new Point(33, 32);
            content.Size = new Size(270, 130);

            registerButton.Location = new Point(230, 170);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);

            this.Controls.Add(askContent);
            this.Controls.Add(content);

        }

        public SAAddConventionPanel(string initialData, UserForm u, int index)
        {
            isEdit = true;
            this.uf = u;
            this.index = index;
            Dictionary<string, string> data = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(initialData);

            headerLabel.Text = "متن میثاق نامه مدیریت محیطی موردنظر خود را تغییر دهید: ";
            headerLabel.Location = new Point(75, 10);
            headerLabel.Size = new Size(300, 15);
            InitializeComponent();

            askContent.Text = "متن میثاق نامه:";
            askContent.Location = new Point(305, 30);
            askContent.Size = new Size(70, 15);

            content.Location = new Point(33, 32);
            content.Size = new Size(270, 130);
            ncontent = data["متن میثاق نامه"];

            registerButton.Location = new Point(230, 170);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);

            back.Location = new Point(165, 190);
            back.Size = new Size(60, 18);
            back.Text = "بازگشت";
            back.BackColor = Color.LightSkyBlue;
            back.Click += new System.EventHandler(this.onBackClick);
            this.Controls.Add(back);

            this.Controls.Add(askContent);
            this.Controls.Add(content);

        }

        private void SAAddConventionPanel_Load(object sender, EventArgs e)
        {
            if (isEdit)
                content.Text = PersianClass.ToPersianNumber(ncontent);
        }

        private void onBackClick(object sender, EventArgs e)
        {
            uf.ChangeMainPanel(new DetailedViewPanel("با انتخاب میثاق نامه زیست محیطی موردنظر خود از جدول زیر آن را ویرایش کنید:", "0Convention", true, false, uf));
        }

        private void onRegisterClick(object sender, EventArgs e)
        {
            if (content.Text.Equals(""))
            {
                errorLable.Text = "لطفا متن میثاق نامه را وارد کنید!";
                errorLable.Location = new Point(190, 340);
                errorLable.Show();
            }
            else
            {
                if (isEdit)
                {
                    if (ncontent.Equals(content.Text))
                        MessageBox.Show(this, "!تغییری روی میثاق نامه صورت نگرفته است", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    else
                    {
                        Dictionary<string, string> data = new Dictionary<string, string>();
                        data.Add("title", content.Text);
                        string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                        Docs.DocFacade.update("Convention", index, jsonData);
                        MessageBox.Show(this, "!میثاق نامه با موفقیت تغییر یافت", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        uf.ChangeMainPanel(new DetailedViewPanel("با انتخاب میثاق نامه زیست محیطی موردنظر خود از جدول زیر آن را ویرایش کنید:", "0Convention", true, false, uf));
                    }
                }
                else
                {
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add("title", content.Text);
                    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    bool added = Docs.DocFacade.AddDoc("Convention", jsonData);
                    if (!added)
                        MessageBox.Show(this, "میثاق نامه ای با متن یکسان قبلا در سامانه به ثبت رسیده است.", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        errorLable.Hide();
                        this.Hide();
                        UserForm.Confirm("میثاق نامه موردنظر با موفقیت در سیستم به ثبت رسید.");
                    }
                }
            }
        }
    }
}
