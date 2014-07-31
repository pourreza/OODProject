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
    public partial class IAAddResourcePanel : AddPanel
    {
        private Label askResource = new Label();
        private TextBox resourceName = new TextBox();
        private Label askNumber = new Label();
        private NumericUpDown resourceNumber = new NumericUpDown();
        private Label askType = new Label();
        private CheckedListBox resourceType = new CheckedListBox();

        public IAAddResourcePanel()
        {
            InitializeComponent();

            askResource.Location = new Point(300, 50);
            askResource.Text = "نام منبع";
            askResource.Size= new Size(40,20);

            resourceName.Location = new Point(72, 50);
            resourceName.Size = new Size(200, 20);

            askNumber.Location = new Point(290, 80);
            askNumber.Text = "تعداد منبع";
            askNumber.Size = new Size(50, 20);

            resourceNumber.Location = new Point(160, 80);
            resourceNumber.Size = new Size(110, 20);
            resourceNumber.Minimum = 1;

            askType.Location = new Point(300, 110);
            askType.Text = "نوع منبع";
            askType.Size = new Size(40, 20);

            resourceType.Location = new Point(160, 110);
            resourceType.Size = new Size(110, 50);
            resourceType.BorderStyle = BorderStyle.Fixed3D;
            resourceType.Items.Add("مالی");
            resourceType.Items.Add("تجهیزاتی");
            resourceType.Items.Add("مواد و ملزومات");
            resourceType.BackColor = SystemColors.Control;

            registerButton.Location = new Point(200, 170);
            registerButton.Click += new System.EventHandler(this.onRegisterClick);

            headerLabel.Text = "لطفا منبع جدید موردنظر خود را وارد کنید: ";

            this.Controls.Add(askNumber);
            this.Controls.Add(askResource);
            this.Controls.Add(askType);
            this.Controls.Add(resourceName);
            this.Controls.Add(resourceNumber);
            this.Controls.Add(resourceType);
        }

        private void IAAddResourcePanel_Load(object sender, EventArgs e)
        {

        }

        private void onRegisterClick(object sender, EventArgs e)
        {
            int i =0;
            foreach (int indexChecked in resourceType.CheckedIndices)
                i++;
            if (resourceName.Text.Equals(""))
            {
                errorLable.Text = "لطفا عنوان منبع را وارد کنید!";
                errorLable.Show();
                errorLable.Location = new Point(205,340);
                errorLable.Size = new Size(160, 20);
            }
            else if (i==0)
            {
                errorLable.Text = "لطفا نوع منبع را وارد کنید!";
                errorLable.Show();
                errorLable.Location = new Point(205, 340);
                errorLable.Size = new Size(160, 20);
            }else{

                errorLable.Hide();
                this.Hide();
                UserForm.Confirm("منبع موردنظر با موفقیت در سیستم به ثبت رسید.");
            }
        }
    }
}
