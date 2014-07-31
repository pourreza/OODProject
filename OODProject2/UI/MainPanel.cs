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
    public partial class MainPanel : UserControl
    {
        public Label headerLabel;
        public MainPanel()
        {
            InitializeComponent();
            this.BorderStyle = BorderStyle.FixedSingle;
            headerLabel = new Label();
            headerLabel.Text = "داریم تست می کنیم";
            headerLabel.Location = new Point(170, 10);
            headerLabel.Size = new Size(200, 18);
            this.Controls.Add(headerLabel);
        }

        private void MainPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
