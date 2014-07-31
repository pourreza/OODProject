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
    public partial class IAddMetricAuditPanel : AddPanel
    {
        public IAddMetricAuditPanel()
        {
            headerLabel.Text = "لطفا مقدار اندازه گیری شده برای هر یک از متریک های زیر را از 100 وارد کنید:";

            InitializeComponent();
        }

        private void IAddMetricAuditPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
