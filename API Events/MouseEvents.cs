/*
 * Author:Xuhongbo
 * function:Excute mouse click action
 * Date:2014.11.21
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace API_Events
{
    public class MouseEvents
    {
        [Flags]
        private enum MouseEventFlag : uint
        {
            Move = 0x0001,//移动鼠标
            LeftDown = 0x0002,//模拟鼠标左键按下
            LeftUp = 0x0004,//模拟鼠标左键抬起
            RightDown = 0x0008,//模拟鼠标右键按下
            RightUp = 0x0010,//模拟鼠标右键抬起
            MiddleDown = 0x0020,//模拟鼠标中键按下
            MiddleUp = 0x0040,//模拟鼠标中键抬起
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000 //表示是否采用绝对坐标
        }

        [DllImport("user32.dll")]
        private static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);
        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);

        //模拟鼠标单击
        public static void MouseOneClick()
        {
            /*
            mouse_event(MouseEventFlag.LeftDown, 10, 10, 0, UIntPtr.Zero);
            mouse_event(MouseEventFlag.LeftUp, 10, 10, 0, UIntPtr.Zero);
            */
            //采用组合的方式对代码进行优化
            mouse_event(MouseEventFlag.LeftDown | MouseEventFlag.LeftUp, 10, 10, 0, UIntPtr.Zero);
        }

        //模拟鼠标双击
        public static void MouseDbClick()
        {
            for (int i = 0; i < 2; i++)
            {
                mouse_event(MouseEventFlag.LeftDown | MouseEventFlag.LeftUp, 10, 10, 0, UIntPtr.Zero);
            }
        }

        //设置鼠标位置
        public static void SetCursorPosition(int x,int y)
        {
            SetCursorPos(x,y);
        }
    }
}
