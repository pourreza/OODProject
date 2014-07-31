using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace OODProject_2_.UI
{
    public partial class TreeViewPanel : MainPanel
    {
        private TreeView content;
        public TreeViewPanel(String headerStr, String jsonData, Boolean relationOrStructure)
        {
            InitializeComponent();
            headerLabel.Text = headerStr;
            content = new TreeView();
            content.Location = new Point(100, 33);
            content.Size = new Size(200, 150);
            content.BeginUpdate();

            if (relationOrStructure)// the jsonData represents association
            {
                Dictionary<string, List<string>> associations = JsonConvert.DeserializeObject<Dictionary<string,List<string>>>(jsonData);
                
                int i = 0;
                foreach (KeyValuePair<string, List<string>> entry in associations)
                {
                    content.Nodes.Add(entry.Key);
                    
                    foreach (string str in entry.Value)
                        content.Nodes[i].Nodes.Add(str);
                    i++;
                }

            }
            else
            {
                Dictionary<string, List<int>> tree = JsonConvert.DeserializeObject<Dictionary<string, List<int>>>(jsonData);
                
                foreach (KeyValuePair<string, List<int>> entry in tree)
                {
                    string child = entry.Key;
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
            this.Controls.Add(content);
        }

        private void TreeViewPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
