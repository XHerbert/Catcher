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
        public TasksForm()
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
                int seed= ran.Next(0, 9);
                LabelWithCheck lbck = BuildLabel(task.Name,seed);
                lbck.Location = new System.Drawing.Point(13+(88 * m), 20+(32*k));
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
            List<TaskModel> tasks= XmlOperator.GetXmlTaskList();
            return tasks;
        }

        /// <summary>
        /// 构造标签
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private LabelWithCheck BuildLabel(string name,int color)
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

        //private Color MakeColor(int color)
        //{
        //    //int colorHex = (DataModel.EnumValuePack.ColorTable)color;
        //    string colorResult="#"+Enum.GetName(typeof(EnumValuePack), color);
        //    return ColorTranslator.FromHtml(colorResult);
        //}

        private static string ColorConvertor(int flag)
        {
            StringBuilder builder = new StringBuilder("#");
            builder.Append(((EnumValuePack.ColorTable)flag).ToString());
            return builder.ToString();
        }
    }
}
