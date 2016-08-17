using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           this.toolStripMenuItem1.Click+=new EventHandler(toolStripMenuItem1_Click);
        }

       private void Form1_Load(object sender, EventArgs e)
        {
            browser browser_web = new browser();
            browser_web.Owner = this;
            browser_web.TopLevel = false;
            browser_web.Visible = true;
            browser_web.Dock = DockStyle.Fill;
            tabControl1.SelectedTab.Controls.Add(browser_web);
            browser main = this.Owner as browser;
        }

       private void toolStripMenuItem1_Click(object sender, EventArgs e)
       {
           browser browser_web1 = new browser();
           TabPage tab = new TabPage();
           browser_web1.Owner = this;
           browser_web1.TopLevel = false;
           browser_web1.Visible = true;
           browser_web1.Dock = DockStyle.Fill;
           tabControl1.TabPages.Add(tab);
           tab.Controls.Add(browser_web1);
       }

       private void toolStripMenuItem2_Click(object sender, EventArgs e)
       {
       
       }

       private void tabPage1_Click(object sender, EventArgs e)
       {

       }
        
    }
}
