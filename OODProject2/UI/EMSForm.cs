using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OODProject_2_.UI
{
    public partial class EMSForm : Form
    {
        string _title = "سامانه مدیریت زیست محیطی سازمان";
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public EMSForm()
        {
            InitializeComponent();
            this.Text = Title;
        }

        private void EMSForm_Load(object sender, EventArgs e)
        {

        }

    }
}
