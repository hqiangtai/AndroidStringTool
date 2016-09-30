using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StringTool.utils
{
    class FileUtils
    {
        public static readonly string strValueFileFilter = "string*.xml";
        public static readonly string valueDirFilter = "values*.xml";
        public static List<FileInfo> getFiles(string folde, string fileFilterKey, string dirFilterKey)
        {
            DirectoryInfo Dir = new DirectoryInfo(folde);
            List<DirectoryInfo> DirSub = getDirs(folde, dirFilterKey);
            List<FileInfo> result = new List<FileInfo>();
            foreach (FileInfo f in Dir.GetFiles(fileFilterKey, SearchOption.TopDirectoryOnly)) //查找文件
            {
                result.Add(f);
            }     

            foreach (DirectoryInfo d in DirSub)//查找子目录 
            {
                if (d.Name.StartsWith("values"))
                {
                    foreach (FileInfo f in d.GetFiles(fileFilterKey, SearchOption.TopDirectoryOnly)) //查找文件
                    {
                        //listBox1.Items.Add(Dir+f.ToString()); //listBox1中填加文件名

                        result.Add(f);
                    }
                }
            }
            return result;
        }
        public static List<DirectoryInfo> getDirs(string folde, string dirFilterKey)
        {
            DirectoryInfo Dir = new DirectoryInfo(folde);
            List<DirectoryInfo> result = new List<DirectoryInfo>();
            DirectoryInfo[] DirSub = Dir.GetDirectories(dirFilterKey, SearchOption.TopDirectoryOnly);
            foreach (DirectoryInfo d in DirSub)
            {
                result.Add(d);
            }
            return result;
        }
        public static int getFilesCount(string flode)
        {
            return getFiles(flode, strValueFileFilter, valueDirFilter).Count;
        }
        public static bool checkIncludeString(DirectoryInfo dir)
        {
            FileInfo[] fileArray = dir.GetFiles(strValueFileFilter);

            return fileArray != null && fileArray.Length > 0;
        }
        public static List<FileInfo> getValuesFiles(string valuesDir)
        {
            
            List<FileInfo> result = getFiles(valuesDir, strValueFileFilter, valueDirFilter);

            return result;
        }
         
    }
}