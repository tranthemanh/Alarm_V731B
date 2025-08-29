using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace OBA
{
    class IO_ini
    {
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string section,
              string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileSection(string section, IntPtr lpReturnedString,
          int nSize, string lpFileName);

        [DllImport("kernel32.dll")]
        private static extern int WritePrivateProfileString(string ApplicationName, string KeyName, string StrValue, string FileName);
        public static string ReadIniFile(string section, string key, string _default, string fileName)
        {
            const int bufferSize = 255;
            StringBuilder temp = new StringBuilder(bufferSize);
            GetPrivateProfileString(section, key, "", temp, bufferSize, fileName);
            if (temp.Length > 0)
            {
                return temp.ToString();
            }
            return _default;
        }
        public static void WriteIniFile(string SectionName, string KeyName, string KeyValue, string FileName)
        {
            WritePrivateProfileString(SectionName, KeyName, KeyValue, FileName);
        }
    }
}
