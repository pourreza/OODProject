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
    public partial class DetailedViewPanel : MainPanel
    {

        private DataGridView content;
        public DetailedViewPanel(String headerStr)
        {
            headerLabel.Text = headerStr;
            InitializeComponent();
            content = new DataGridView();

        }

        private void DetailedViewPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
