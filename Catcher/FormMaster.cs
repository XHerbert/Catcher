/*
 * Author:Xuhongbo
 * function:Areo FormMaster
 * Date:2014.11.21
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catcher
{
    public partial class FormMaster : Form
    {
        public FormMaster()
        {
            InitializeComponent();
            OpenAreo();
        }

        private int en;
        public struct MARGINS
        {
            public int m_Left;
            public int m_Right;
            public int m_Top;
            public int m_Buttom;
        };
        [DllImport("dwmapi.dll")]
        private static extern void DwmIsCompositionEnabled(ref int enabledptr);
        [DllImport("dwmapi.dll")]
        private static extern void DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margin);

        private void OpenAreo()
        {
            en = 0;
            MARGINS mg = new MARGINS(); //定义透明扩展区域的大小，这里全部-1，即全部透明
            mg.m_Buttom = -1;
            mg.m_Left = -1;
            mg.m_Right = -1;
            mg.m_Top = -1;
            //判断是否Vista及以上的系统
            if (System.Environment.OSVersion.Version.Major >= 6)
            {
                DwmIsCompositionEnabled(ref en);    //检测Aero是否为打开
                if (en > 0)
                {
                    DwmExtendFrameIntoClientArea(this.Handle, ref mg);   //透明
                }
                else
                {
                    MessageBox.Show("Desktop Composition is Disabled!");  //未开启透明桌面
                }
            }
            else
            {
                MessageBox.Show("Please run this at least on Windows Vista.");  //至少在vista运行
            }
            this.Paint += new PaintEventHandler(Form1_Paint);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (en > 0)
            {
                Graphics g = e.Graphics;
                SolidBrush bsh = new SolidBrush(Color.Black);
                g.FillRectangle(bsh, this.ClientRectangle);
                bsh.Dispose();
            }
        }
    }
}
