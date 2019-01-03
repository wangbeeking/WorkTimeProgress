//windows在高分屏下会产生自动缩放，导致程序显示异常，如根据屏幕分辨率设置程序显示位置产生显示异常。
//解决方案为在高分屏下，写入注册表
//[HKEY_CURRENT_USER\Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers]
//"文件路径"="~ HIGHDPIAWARE"
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimeProgress
{
    public class RegInfoControler
    {
        private static string m_ViewModeKeyPath = @"Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers";
        public static void CheckViewMode()
        {
            try
            {
                var regkey = Registry.CurrentUser.OpenSubKey(m_ViewModeKeyPath,true);
                if (regkey == null)
                    Registry.CurrentUser.CreateSubKey(m_ViewModeKeyPath);
                var valuenameList = regkey.GetValueNames().ToList();
                var processname = Process.GetCurrentProcess().MainModule.FileName;
                if (valuenameList.FindIndex(s => s.Equals(processname)) == -1)
                {
                    regkey.SetValue(processname, "~ HIGHDPIAWARE");
                    Process.Start(processname);
                    System.Environment.Exit(0);
                }
                else
                {
                    string value = regkey.GetValue(processname).ToString();
                    if (!value.Contains("HIGHDPIAWARE"))
                    {
                        value += "HIGHDPIAWARE";
                        regkey.SetValue(processname, value);
                        Process.Start(processname);
                        System.Environment.Exit(0);
                    }
                }

            }
            catch(Exception e)
            {
                throw new Exception("读写注册表错误！");
            }
        }
    }
    /*
Registry.RegistryKey
1、创建注册表：CreateSubKey , SetValue;
2、删除注册表：DeleteSubKey，DeleteSubKeyTree , DeleteValue
3、获取注册表：OpenSubKey , GetValue
*/
//public static bool IsFirstTimeLaunch()
//    {
//        RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(Strings.RegBasePath);
//        string a = (string)registryKey.GetValue("FirstTimeLaunch", "");
//        if (a == "")
//        {
//            registryKey.SetValue("FirstTimeLaunch", DateTime.Now.ToString());
//        }
//        return a == "";
//    }
}
