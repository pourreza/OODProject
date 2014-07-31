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
    public partial class IAAddSchedulePanel : AddPanel
    {
        private Label askGoal = new Label();
        private ComboBox relatedGoal = new ComboBox();
        public IAAddSchedulePanel()
        {
            headerLabel.Text = "ابتدا هدف مربوط به برنامه موردنظر خود را انتخاب کرده، سپس زمان بندی مسئولیت های آن\nرا مشخص کنید: ";
            headerLabel.Location = new Point(20, 10);
            headerLabel.Size = new Size(350, 28); 
            InitializeComponent();

            //relatedGoal.SelectedIndexChanged += new System.EventHandler(relatedGoal_SelectedIndexChanged);
        }

        private void IAAddSchedulePanel_Load(object sender, EventArgs e)
        {

        }
    }
}
