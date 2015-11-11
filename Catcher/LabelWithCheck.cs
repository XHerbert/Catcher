using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catcher
{
    public partial class LabelWithCheck : UserControl
    {
        private string labelText;
        int width = 0;
        int height = 0;

        public string LabelText
        {
            get
            {
                if(!String.IsNullOrEmpty(lb.Text))
                    return lb.Text;
                return "输入标签";
            }

            set
            {
                lb.Text = value;
            }
        }

        public LabelWithCheck()
        {
            InitializeComponent();
            width = lb.Width + 6 + ck.Width;
            height = lb.Height + 6;
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int x = this.Width;
            int y = this.Height;
            Point leftTop = new Point(0, 0);
            Point rightTop = new Point(x - 1, 0);
            Point leftBottom = new Point(0, y - 1);
            Point rightBottom = new Point(x - 1, y - 1);

            g.DrawLine(new Pen(Color.White), leftTop, rightTop);
            g.DrawLine(new Pen(Color.White), leftBottom, rightBottom);
            g.DrawLine(new Pen(Color.White), leftTop, leftBottom);
            g.DrawLine(new Pen(Color.White), rightTop, rightBottom);
            //画上边缘
            for (int i = 0; i < x - 1; i += 3)
            {
                g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(i, 0, 2, 1));
            }

            //画下边缘
            for (int m = 0; m < x - 1; m += 3)
            {
                g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(m, y - 1, 2, 1));
            }

            //画左边缘
            for (int i = 0; i < y - 1; i += 3)
            {
                g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, i, 1, 2));
            }

            //画右边缘
            for (int i = 0; i < y - 1; i += 3)
            {
                g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(x - 1, i, 1, 2));
            }
            base.OnPaint(e);
        }


        //[Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Bindable(true)]
        //public override string Text
        //{
        //    get
        //    {
        //        return lb.Text;
        //    }
        //    set
        //    {
        //        this.lb.Text = value;
        //    }
        //}

        //[Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Bindable(true)]
        //protected override int  DefaultSize
        //{
        //    get
        //    {
        //        return new Size(width, height);
        //    }
        //}
    }
}
