using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataModel;

namespace Catcher
{
    public partial class TasksForm : Catcher.FormMaster
    {
        private const int iSeed = 10;
        private static TasksForm taskFormInstance;
        private TasksForm()
        {
            InitializeComponent();
        }

        private void TasksForm_Load(object sender, EventArgs e)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            int m = 0;
            List<TaskModel> existTasks = GetTaskListOfURL();
            if (existTasks.Count == 0 || existTasks == null)
            {
                return;
            }
            foreach (var task in existTasks)
            {
                long tick = DateTime.Now.Ticks;
                Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
                int seed = ran.Next(0, 9);
                LabelWithCheck lbck = BuildLabel(task.Name, seed);
                lbck.Location = new System.Drawing.Point(13 + (88 * m), 20 + (32 * k));
                URLTasks.Controls.Add(lbck);
                i++;
                j++;
                m = i % 4;
                k = j / 4;
            }
        }

        /// <summary>
        /// 取任务列表
        /// </summary>
        /// <returns></returns>
        private List<TaskModel> GetTaskListOfURL()
        {
            List<TaskModel> tasks = XmlOperator.GetXmlTaskList();
            return tasks;
        }

        /// <summary>
        /// 构造标签
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private LabelWithCheck BuildLabel(string name, int color)
        {
            LabelWithCheck lbck = new LabelWithCheck();
            lbck.LabelText = name;
            lbck.BackColor = Color.LightPink;
            lbck.ForeColor = Color.Black;
            lbck.BackColor = ColorTranslator.FromHtml(ColorConvertor(color));
            lbck.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            lbck.Size = new System.Drawing.Size(74, 22);
            return lbck;
        }

        private static string ColorConvertor(int flag)
        {
            StringBuilder builder = new StringBuilder("#");
            builder.Append(((EnumValuePack.ColorTable)flag).ToString());
            return builder.ToString();
        }

        private void selectAll_Click(object sender, EventArgs e)
        {
            foreach (Control groupBox in this.Controls)
            {
                if (groupBox is GroupBox)
                {
                    foreach (Control checkItem in groupBox.Controls)
                    {
                        if (checkItem is LabelWithCheck)
                        {
                            LabelWithCheck myCheckItem = (LabelWithCheck)checkItem;
                            if (myCheckItem.Checked == false)
                            {
                                myCheckItem.Checked = true;
                                Console.WriteLine(myCheckItem.CheckState);
                            }

                        }
                    }
                }
            }
        }

        private void unSelectAll_Click(object sender, EventArgs e)
        {
            foreach (Control groupBox in this.Controls)
            {
                if (groupBox is GroupBox)
                {
                    foreach (Control checkItem in groupBox.Controls)
                    {
                        if (checkItem is LabelWithCheck)
                        {
                            LabelWithCheck myCheckItem = (LabelWithCheck)checkItem;
                            if (myCheckItem.Checked == true)
                            {
                                myCheckItem.Checked = false;
                                Console.WriteLine(myCheckItem.CheckState);
                            }

                        }
                    }
                }
            }
        }

        private void TasksForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void TasksForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            taskFormInstance = null;
        }

        /// <summary>
        /// 获取单例窗体
        /// </summary>
        /// <returns></returns>
        public static TasksForm GetInstanceTask()
        {
            if (taskFormInstance == null)
            {
                taskFormInstance = new TasksForm();
            }
            return taskFormInstance;
        }
    }

    public class FormTool
    {
        private static bool instance_flag = false;
        //public static TasksForm GetInstance()
        //{
        //    if (!instance_flag)
        //    {
        //        taskForm = new TasksForm();
        //        instance_flag = true;
        //        return taskForm;
        //    }
        //    else
        //    {
        //        //Console.WriteLine("you have already create a instance");
        //        return null;
        //    }
        //}

        public static void MM()
        {

        }
    }
}
