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
    public partial class AddAssociationPanel : AddPanel
    {
        public AddAssociationPanel(string type)
        {
            if (type.Equals("SA1"))
            {
                headerLabel.Text = "لطفا مشخصات تاثیر زیست محیطی جدید موردنظر خود را وارد کنید: ";
            }

            InitializeComponent();
        }

        private void AddAssociationPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
