//调用WinAPI，获取任务栏位置
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static WorkTimeProgress.TaskbarInfo;

namespace WorkTimeProgress
{
    public class TaskbarInfo
    {
        [DllImport("user32.dll")]
        public static extern int SystemParametersInfo(int uAction, int uParam, ref RECT re, int fuWinTni);

        [DllImport("SHELL32", CallingConvention = CallingConvention.StdCall)]
        public static extern uint SHAppBarMessage(int dwMessage, ref APPBARDATA pData);

        [StructLayout(LayoutKind.Sequential)]
        public struct APPBARDATA
        {

            public int cbSize;

            public IntPtr hWnd;

            public int uCallbackMessage;

            public int uEdge;//属性代表上、下、左、右

            public RECT rc;

            public IntPtr lParam;

        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {

            public int left;

            public int top;

            public int right;

            public int bottom;



            public override string ToString()
            {

                return "{left=" + left.ToString() + ", " + "top=" + top.ToString() + ", " +

                    "right=" + right.ToString() + ", " + "bottom=" + bottom.ToString() + "}";

            }

        }

        public static TaskbarLocation GetBarLocation()
        {
            APPBARDATA pdat = new APPBARDATA();
            SHAppBarMessage(0x00000005, ref pdat);
            return new TaskbarLocation(pdat);
        }
    }
    public class TaskbarLocation
    {
        #region 初始化

        public TaskbarLocation(APPBARDATA data)
        {
            Set(data);
        }
        #endregion
        #region 变量
        public int cbSize;

        public TaskBarEdge uEdge;//属性代表上、下、左、右

        public int left;

        public int top;

        public int right;

        public int bottom;
        #endregion
        #region 辅助
        public void Set(APPBARDATA data)
        {
            cbSize = data.cbSize;
            uEdge = (TaskBarEdge)data.uEdge;
            left = data.rc.left;
            top = data.rc.top;
            right = data.rc.right;
            bottom = data.rc.bottom;
        }

        public void Set(RECT data)
        {
            left = data.left;
            top = data.top;
            right = data.right;
            bottom = data.bottom;
        }
        public override string ToString()
        {
            string str = string.Format("cbSize={0},uEdge={1},left={2},top={3},right={4},bottom={5}"
                , cbSize, uEdge, left, top, right, bottom);
            return str;
        }
        #endregion
    }
    public enum TaskBarEdge
    {
        LEFT = 0,
        TOP = 1,
        RIGHT = 2,
        BOTTOM = 3
    }
}
