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
                LabelWithCheck lbck = BuildLabel(task.Name);
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
        private LabelWithCheck BuildLabel(string name)
        {
            LabelWithCheck lbck = new LabelWithCheck();
            lbck.LabelText = name;
            lbck.BackColor = System.Drawing.Color.LightPink;
            lbck.ForeColor = System.Drawing.Color.Black;
            lbck.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            lbck.Size = new System.Drawing.Size(74, 22);
            return lbck;
        }
    }
}
