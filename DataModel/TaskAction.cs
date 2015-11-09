/*
 * Author:Xuhongbo
 * function:Some operation for TaskModel
 * Date:2014.11.21
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataModel
{
    public class TaskAction :IDisposable
    {
        //新增一个任务
        public static void AddTask(TaskModel task)
        {
            XmlOperator.CreateXmlTask(task);
        }

        //修改一个任务
        public static bool ModifyTask()
        {
            return true;
        }

        //获取所有的任务
        public static List<TaskModel> GetTaskList()
        {
            List<TaskModel> list = new List<TaskModel>();
            list=XmlOperator.GetXmlTaskList();
            return list;
        }

        public void Dispose()
        {
            
        }
    }

    public class XmlOperator
    {
        private static  XmlDocument doc = new XmlDocument();
        private static string path = AppDomain.CurrentDomain.BaseDirectory.ToString()+"Data.xml";
        public XmlOperator()
        {
           
        }
       
        
        public static List<TaskModel> GetXmlTaskList()
        {
            doc.Load(path);//注意Load数据
            XmlNodeList list = doc.SelectNodes("tasks/task");
            List<TaskModel> tasks = new List<TaskModel>();
            foreach (XmlElement item in list)
            {
                TaskModel task = new TaskModel();
                task.Name = item.SelectSingleNode("./taskName").InnerText;
                task.Application = item.SelectSingleNode("./application").InnerText;
                task.Url = item.SelectSingleNode("./param").InnerText;
                task.PositionX = item.SelectSingleNode("./position/x").InnerText.ToInt();
                task.PositionY = item.SelectSingleNode("./position/y").InnerText.ToInt();
                tasks.Add(task);
            }
            return tasks;
        }

        public static void AnalsisTaskToModel(XmlNodeList list)
        {
           
        }

        //将新建的任务信息存储进XML数据文件中
        public static void CreateXmlTask(TaskModel task)
        {
            doc.Load(path);
            XmlElement xe1 = doc.CreateElement(NodeName.task.ToString());
            XmlElement xe21 =doc.CreateElement(NodeName.taskName.ToString());
            xe21.InnerText = task.Name;
            XmlElement xe22 = doc.CreateElement(NodeName.application.ToString());
            xe22.InnerText = task.Application;
            XmlElement xe23 = doc.CreateElement(NodeName.param.ToString());
            xe23.InnerText = task.Url;
            XmlElement xe24 = doc.CreateElement(NodeName.position.ToString());
            XmlElement xe241 = doc.CreateElement(NodeName.x.ToString());
            xe241.InnerText = task.PositionX.ToString();
            XmlElement xe242 = doc.CreateElement(NodeName.y.ToString());
            xe242.InnerText = task.PositionY.ToString();
            xe24.AppendChild(xe241);
            xe24.AppendChild(xe242);

            XmlElement[] xes = { xe21,xe22,xe23,xe24};
            AppendXeChildren(xe1, xes);
            doc.DocumentElement.AppendChild(xe1);
            doc.Save(path);
        }

        public enum NodeName
        {
            task,
            taskName,
            application,
            param,
            position,
            x,
            y
        }


        private static void AppendXeChildren(XmlElement xe, params XmlElement[] xeChild)
        {
            int index = 0;
            foreach (XmlElement item in xeChild)
            {
                if (item == null) { continue; }
                xe.AppendChild(xeChild[index]);
                index++;
            }
        }
    }

    public static class Extension
    {
        public static int ToInt(this string str)
        {
            return Convert.ToInt32(str);
        }
    }
}
