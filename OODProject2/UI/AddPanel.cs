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
    public partial class AddPanel : MainPanel
    {
        public Button registerButton;
        public Label errorLable = new Label();

        public AddPanel()
        {
            InitializeComponent();
            registerButton = new Button();
            registerButton.Text = "ثبت";

            registerButton.BackColor = Color.LightSkyBlue;
            registerButton.Size = new Size(70, 18);
            registerButton.Location = new Point(290, 180);
            this.Controls.Add(registerButton);

            errorLable.Location = new Point(110, 180);
            errorLable.Size = new Size(160, 20);
            errorLable.ForeColor = Color.Red;

            errorLable.Hide();
            this.Controls.Add(errorLable);
        }

        private void AddPanel_Load(object sender, EventArgs e)
        {

        }

    }
}
