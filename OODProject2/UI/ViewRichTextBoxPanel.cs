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
    public partial class ViewRichTextBoxPanel : MainPanel
    {
        private Button back = new Button();
        private RichTextBox ct = new RichTextBox();
        private UserForm uf;
        private bool isEdit = false;
        private bool isRemove = false;
        private string content = "";

        public ViewRichTextBoxPanel(string headerStr, string content, UserForm u, bool isEdit, bool isRemove)
        {
            this.uf = u;
            this.isEdit = isEdit;
            this.isRemove = isRemove;
            this.content = content;

            headerLabel.Text = headerStr;
            headerLabel.Location = new Point(75, 10);
            headerLabel.Size = new Size(300, 15);
            InitializeComponent();

            ct.Location = new Point(46, 42);
            ct.Size = new Size(300, 100);
            ct.Text = content;
            ct.ReadOnly = true;
            ct.BackColor = System.Drawing.SystemColors.Window;

            back.Location = new Point(175, 160);
            back.Text = "بازگشت";
            back.Size = new System.Drawing.Size(50, 18);
            back.BackColor = Color.LightSkyBlue;
            back.Click += new System.EventHandler(this.onBackClick);

            this.Controls.Add(ct);
            this.Controls.Add(back);
        }

        private void onBackClick(object obj, EventArgs e)
        {
            if (isEdit)
                uf.ChangeMainPanel(new DetailedViewPanel("با انتخاب الزام زیست محیطی موردنظر خود از جدول زیر آن را ویرایش کنید:", "LegalRequi", isEdit, false, uf));
            else if (isRemove)
                uf.ChangeMainPanel(new DetailedViewPanel("الزامات زیست محیطی موردنظر برای حذف را از جدول زیر انتخاب کنید:", "LegalRequi", false, true, uf));
            else
                uf.ChangeMainPanel(new DetailedViewPanel("الزامات زیست محیطی ثبت شده در سامانه به قرار زیر می باشند:", "LegalRequi", false, false, uf));
        }

        private void ViewRichTextBoxPanel_Load(object sender, EventArgs e)
        {
            this.ct.Text = PersianClass.ToPersianNumber(content) ;
        }
    }
}
