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
    public partial class ConfirmPanel : MainPanel
    {
        public ConfirmPanel()
        {
            InitializeComponent();
            
            headerLabel.Font = new Font("Nazanin", 14, FontStyle.Bold);
            headerLabel.Location = new Point(30, 40);
            headerLabel.Size = new Size(340, 20);

            Label check = new Label() { Image = OODProject2.Properties.Resources.checkImg };
            check.Location = new Point(180, 60);
            check.Size = new Size(61, 46);
            this.Controls.Add(check);
        }

        private void ConfirmPanel_Load(object sender, EventArgs e)
        {

        }

        public void setMsg(String msg)
        {
            headerLabel.Text = msg;
        }
    }
}
