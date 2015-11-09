/*
 * Author:Xuhongbo
 * function:Task Model
 * Date:2014.11.21
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class TaskModel
    {

        private string name;
        private string application;
        private string url;
        private string position;
        private int positionX;
        private int positionY;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        public string Application
        {
            get
            {
                return application;
            }

            set
            {
                application = value;
            }
        }
        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }
        public int PositionX
        {
            get
            {
                return positionX;
            }

            set
            {
                positionX = value;
            }
        }
        public string Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }
        public int PositionY
        {
            get
            {
                return positionY;
            }

            set
            {
                positionY = value;
            }
        }
    }


    
}
