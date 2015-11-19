/*
 * Author:Xuhongbo
 * function:MainForm
 * Date:2014.11.21
 */
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using API_Events;
using System.Diagnostics;
using System.Threading;
using DataModel;
using System.Collections.Generic;

namespace Catcher
{
    public partial class MainFrom : FormMaster
    {
        public delegate void FormMovingEventHanler();
        public event FormMovingEventHanler FormMovingEvent;
        private const int BASENUM = 1000;
        private TaskModel task;
        private TasksForm taskForm;
        private MouseHookEvents mouse;
        public MainFrom()
        {
            InitializeComponent();
            mouse = new MouseHookEvents();
            mouse.OnMouseActivity += new MouseEventHandler(mouse_OnMouseActivity);
            this.FormMovingEvent += FollowMainForm;
            mouse.Start();
            task = new TaskModel();
        }


        private void mouse_OnMouseActivity(object sender, MouseEventArgs e)
        {
            txt_X.Text = e.X.ToString();
            txt_Y.Text = e.Y.ToString();
            //使用鼠标右键对当前坐标进行存储
            if (e.Button == MouseButtons.Right)
            {
                SavePoint();
                lblMsg.Text = string.Format("当前坐标(X,Y)=({0},{1})已存储", txt_X.Text, txt_Y.Text);
            }
        }
        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = Control.MousePosition;
            //textBox1.Text = e.X.ToString();
            //textBox2.Text = e.Y.ToString();
            //txt_X.Text = p.X.ToString();
            //txt_Y.Text = p.Y.ToString();
        }
        //存储坐标
        private void SavePoint()
        {
            //this.WindowState = FormWindowState.Minimized;
            //MouseOneClick();
            //MouseOnWheel();
            //MouseEvents.SetCursorPosition();
            //ExcuteTask("iexplore.exe", "http://www.baiduyun.me/forum.php", 1244, 140);
            //point= new Task.Point();
            task.PositionX = txt_X.Text.ToInt();//应用扩展方法
            task.PositionY = txt_Y.Text.ToInt();
        }
        //执行任务
        public void ExcuteTask(string applicationName, string url, int x, int y)
        {
            ProcessStartInfo ps = new ProcessStartInfo(applicationName, url);
            Process.Start(ps);
            Thread.Sleep(5000);
            MouseEvents.SetCursorPosition(x, y);
            MouseEvents.MouseOneClick();
        }

        public void ExcuteTask(TaskModel task)
        {
            int processID;
            ProcessStartInfo ps = new ProcessStartInfo(task.Application, task.Url);
            ps.WindowStyle = ProcessWindowStyle.Maximized;
            Process myProc = Process.Start(ps);
            processID = myProc.Id;
            Thread.Sleep((int)numericUpDown2.Value * BASENUM);
            //设置鼠标位置
            MouseEvents.SetCursorPosition(task.PositionX, task.PositionY);
            //模拟鼠标双击
            MouseEvents.MouseDbClick();
            Thread.Sleep(1000);

            KillProcess(task.Application);
            //Process.GetCurrentProcess().Kill();
            //myProc = Process.GetProcessById(processID);
            //myProc.Kill();
        }

        //新增任务
        private void button1_Click(object sender, EventArgs e)
        {

            task.Name = txt_Name.Text;
            task.Application = txt_App.Text;
            task.Url = txt_Param.Text;
            if (string.IsNullOrEmpty(task.Name.Trim()) || string.IsNullOrEmpty(task.Url.Trim()) || string.IsNullOrEmpty(task.Application.Trim()))
            {
                MessageBox.Show("参数不能为空，请重试！");
                return;
            }
            else
            {
                TaskAction.AddTask(task);
                MessageBox.Show("新增任务成功！");
            }
        }

        //执行任务列表
        private void button2_Click(object sender, EventArgs e)
        {
            //ExcuteTask()
            List<TaskModel> tasks = TaskAction.GetTaskList();
            new Thread(() =>
            {//开启新线程，避免与主线程UI冲突，导致界面假死
                foreach (TaskModel item in tasks)
                {
                    ExcuteTask(item);
                    Thread.Sleep((int)numericUpDown1.Value * BASENUM);
                }
            }).Start();
        }

        //关闭进程
        private void KillProcess(string processName)
        {
            Process proc = new Process();
            foreach (Process item in Process.GetProcessesByName(processName))
            {
                if (!item.CloseMainWindow())
                {
                    item.Kill();
                }
            }
        }

        private void MainFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            //卸载钩子
            mouse.Stop();
        }

        private void btn_ChooseTask_Click(object sender, EventArgs e)
        {
            taskForm = TasksForm.GetInstanceTask();
            FollowMainForm();
            taskForm.Show();
        }
        /// <summary>
        /// 跟随主窗体
        /// </summary>
        private void FollowMainForm()
        {
            Point taskFormPoint = new Point(this.Location.X - taskForm.Width, this.Location.Y);
            taskForm.Location = taskFormPoint;
        }

        private void MainFrom_LocationChanged(object sender, EventArgs e)
        {
            if (this.FormMovingEvent != null)
            {
                if (taskForm != null)
                {
                    FormMovingEvent();
                }
            }
        }
    }

    //静态类的静态方法，扩展方法
    public static class Extension
    {
        public static int ToInt(this string str)
        {
            return Convert.ToInt32(str);
        }

        public static string ToString(this int n)
        {
            return n.ToString();
        }
    }
}
