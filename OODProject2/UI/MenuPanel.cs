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
    public partial class MenuPanel : UserControl
    {
        private List<MenuStrip> _menuItems;
        public List<MenuStrip> MenuItems
        {
            get { return _menuItems; }
            set
            {
                _menuItems = value;
            }
        }
        public MenuPanel()
        {
            InitializeComponent();
        }

        private void MenuPanel_Load(object sender, EventArgs e)
        {

        }

        public void addItems()
        {
            Panel menuPanel = new Panel();
            menuPanel.Location = new Point(0, 21);
            menuPanel.Size = new Size(130, 200);
            this.Controls.Add(menuPanel);

            foreach (MenuStrip m in MenuItems)
            {
                menuPanel.Controls.Add(m);
            }
        }


    }
}
