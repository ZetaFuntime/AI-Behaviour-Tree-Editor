using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_Behaviour_Tree_Editor
{
    public partial class Form1 : Form
    {
        private Point m_imageLocation = new Point(13, 5);
        private Point m_imageHitArea = new Point(13, 2);
        Image CloseImage;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.DrawItem += tabControl1_DrawItem;
            CloseImage = AI_Behaviour_Tree_Editor.Properties.Resources.close;
            tabControl1.Padding = new Point(10, 3);
        }

        private void tabControl1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            try
            {
                Image img = new Bitmap(CloseImage);
                Rectangle r = e.Bounds;
                r = this.tabControl1.GetTabRect(e.Index);
                r.Offset(2, 2);
                string title = this.tabControl1.TabPages[e.Index].Text;
                Font f = this.Font;
                Brush titleBrush = new SolidBrush(Color.Black);
                e.Graphics.DrawString(title, f, titleBrush, new PointF(r.X, r.Y));

                if (tabControl1.TabCount >= 0)
                {
                    e.Graphics.DrawImage(img, new Point(r.X + (this.tabControl1.GetTabRect(e.Index).Width - m_imageLocation.X), m_imageLocation.Y));
                }
            }
            catch (Exception)
            {

            }
        }

        private void tabControl1_MouseClick_1(object sender, MouseEventArgs e)
        {
            TabControl tc = (TabControl)sender;
            Point p = e.Location;
            int m_tabWidth = 0;
            m_tabWidth = this.tabControl1.GetTabRect(tc.SelectedIndex).Width - (m_imageHitArea.X);
            Rectangle r = this.tabControl1.GetTabRect(tc.SelectedIndex);
            r.Offset(m_tabWidth, m_imageHitArea.Y);
            r.Width = 16;
            r.Height = 16;
            if (tabControl1.SelectedIndex >= 0)
            {
                if (r.Contains(p))
                {
                    TabPage tabP = (TabPage)tc.TabPages[tc.SelectedIndex];
                    tc.TabPages.Remove(tabP);
                }
            }
        }

        // New file button
        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tpage = new TabPage("new tab " + (tabControl1.TabCount + 1).ToString());
            tabControl1.TabPages.Add(tpage);
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
