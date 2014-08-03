using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace OODProject_2_.UI
{
    public partial class TreeViewPanel : MainPanel
    {
        private TreeView content;
        private bool isRemove = false;
        private Button deleteBtn = new Button();
        private Boolean relationOrStructure = false;
        private string type = "";

        public TreeViewPanel(String headerStr, String jsonData, Boolean relationOrStructure, bool isRemove, string type)
        {
            this.isRemove = isRemove;
            this.relationOrStructure = relationOrStructure;
            this.type = type;

            InitializeComponent();
            headerLabel.Text = headerStr;
            headerLabel.Location = new Point(90, 10);
            headerLabel.Size = new Size(280, 15);
            
            content = new TreeView();
            content.Location = new Point(100, 33);
            content.Size = new Size(200, 150);
            content.BeginUpdate();

            deleteBtn.Hide();

            if (isRemove)
            {
                this.content.CheckBoxes = true;
                deleteBtn.Show();
            }

            if (relationOrStructure)// the jsonData represents association
            {
                Dictionary<string, List<string>> associations = JsonConvert.DeserializeObject<Dictionary<string,List<string>>>(jsonData);
                
                int i = 0;
                
                foreach (KeyValuePair<string, List<string>> entry in associations)
                {
                    content.Nodes.Add(PersianClass.ToPersianNumber(entry.Key));
                    
                    foreach (string str in entry.Value)
                    {
                        content.Nodes[i].Nodes.Add(PersianClass.ToPersianNumber(str));
                    }

                    i++;
                }

            }
            else
            {
                Dictionary<string, List<int>> tree = JsonConvert.DeserializeObject<Dictionary<string, List<int>>>(jsonData);
                
                foreach (KeyValuePair<string, List<int>> entry in tree)
                {
                    string child = PersianClass.ToPersianNumber(entry.Key);
                    List<int> nums = entry.Value;
                    int[] ns = nums.ToArray();
                    if (ns.Length == 0)
                        content.Nodes.Add(child);
                    else
                    {
                        TreeNode node = content.Nodes[ns[0]];
                        for (int num = 1; num < ns.Length; num++ )
                        {
                            node = node.Nodes[ns[num]];
                        }
                        node.Nodes.Add(child);
                    }
                    
                }
                
                
            }
            
            content.EndUpdate();

            deleteBtn.Location = new Point(165, 200);
            deleteBtn.Size = new Size(70, 20);
            deleteBtn.Text = "حذف داده ها";
            deleteBtn.BackColor = Color.LightSkyBlue;
            deleteBtn.Click += new EventHandler(this.onDeleteClick);
            
            this.Controls.Add(content);
            this.Controls.Add(deleteBtn);
        }

        private void TreeViewPanel_Load(object sender, EventArgs e)
        {
            if (isRemove)
                if (relationOrStructure)
                {
                    for (int i = 0; i < content.Nodes.Count; i++)
                        for (int j = 0; j < content.Nodes[i].Nodes.Count; j++)
                            HideCheckBox(content, content.Nodes[i].Nodes[j]);
                }
        }

        List<String> CheckedNames(System.Windows.Forms.TreeNodeCollection theNodes)
        {
            List<String> aResult = new List<String>();

            if (theNodes != null)
            {
                foreach (System.Windows.Forms.TreeNode aNode in theNodes)
                {
                    if (aNode.Checked)
                    {
                        aResult.Add(aNode.Text);
                    }

                    aResult.AddRange(CheckedNames(aNode.Nodes));
                }
            }

            return aResult;
        }
 
        private void onDeleteClick(object sender, EventArgs e)
        {
            List<string> checkedNodes = CheckedNames(content.Nodes);

            if (checkedNodes.Count == 0)
                MessageBox.Show("!داده ای برای حذف انتخاب نشده است", "!توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            // Configure the message box to be displayed 
            else if (MessageBox.Show("مطمئنید که می خواهید این اطلاعات را حذف کنید؟", "!توجه",
         MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
         == DialogResult.Yes)
            {
                Docs.DocFacade.DeleteRelations(type, checkedNodes);
                UserForm.Confirm("اطلاعات موردنظر با موفقیت از سیستم حذف گردیدند.");
            }
            
        }

        private const int TVIF_STATE = 0x8;
        private const int TVIS_STATEIMAGEMASK = 0xF000;
        private const int TV_FIRST = 0x1100;
        private const int TVM_SETITEM = TV_FIRST + 63;

        [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Auto)]
        private struct TVITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr IParam;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref TVITEM lParam);

        private void HideCheckBox(TreeView tvw, TreeNode node)
        {
            TVITEM tvi = new TVITEM();
            tvi.hItem = node.Handle;
            tvi.mask = TVIF_STATE;
            tvi.stateMask = TVIS_STATEIMAGEMASK;
            tvi.state = 0;
            SendMessage(tvw.Handle, TVM_SETITEM, IntPtr.Zero, ref tvi);
        }
    }

}
