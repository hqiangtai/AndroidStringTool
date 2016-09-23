using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringTool.utils
{
    /// <summary>
    /// 国家、地区语言工具类
    /// </summary>
    class LocalUtils
    {
        public static List<LocalObject> getLocalList(){
            List<LocalObject> result=new List<LocalObject>();

            return result;
        }
        public  class LocalObject:object{
            private string packeName; ////资源包文件名称

            public string PackeName
            {
                get { return packeName; }
                set { packeName = value; }
            }
            private string flage;   ////语言标示

            public string Flage
            {
                get { return flage; }
                set { flage = value; }
            }
            private string displayName;////显示的名称

            public string DisplayName
            {
                get { return displayName; }
                set { displayName = value; }
            }
        }
    }
}
