using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    class TaskType
    {
        private string typeName;
        private int typeID;
        //任务分类名称
        public string TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }

        //任务ID
        public int TypeID
        {
            get { return typeID; }
            set { typeID = value; }
        }
    }
}
