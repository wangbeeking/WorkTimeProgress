using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static WorkTimeProgress.TaskbarInfo;
using System.Threading;

namespace WorkTimeProgress
{
    public partial class MainForm : Form
    {
        #region 变量
        public static int m_FormHeight = 3;
        public static DateTime m_StartTime = new DateTime(1970, 1, 1, 9, 0, 0);
        public static DateTime m_StopTime = new DateTime(1970, 1, 1, 17, 30, 0);
        public static Task RefreshTask = null;
        #endregion
        #region 初始化
        public MainForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            RegInfoControler.CheckViewMode();
            RefreshTask = Task.Run(new Action(() => { TaskRefresh(this); }));
        }
        #endregion
        #region 方法
        /// <summary>
        /// 设置程序大小与进度条大小
        /// </summary>
        /// <param name="loc"></param>
        public void SetFormSizeLoc(TaskbarLocation loc,MainForm mainForm)
        {
            mainForm.Invoke(new EventHandler(delegate
            {
                if (loc.uEdge == TaskBarEdge.BOTTOM || loc.uEdge == TaskBarEdge.TOP)
                {
                    this.Width = loc.right;
                    this.Height = m_FormHeight;
                    this.HProgressBar.Visible = true;
                    this.VProgressBar.Visible = false;
                }
                else
                {
                    this.Width = m_FormHeight;
                    this.Height = loc.bottom;
                    this.HProgressBar.Visible = false;
                    this.VProgressBar.Visible = true;
                }
                switch (loc.uEdge)
                {
                    case TaskBarEdge.LEFT: this.DesktopLocation = new Point(0, 0); break;
                    case TaskBarEdge.RIGHT: this.DesktopLocation = new Point(loc.left - this.Width, 0); break;
                    case TaskBarEdge.TOP: this.DesktopLocation = new Point(0, 0); break;
                    case TaskBarEdge.BOTTOM: this.DesktopLocation = new Point(0, loc.top - this.Height); break;
                }

            }));
        }
        /// <summary>
        /// 设置进度条最大值，用秒为单位，以下抛弃
        /// </summary>
        /// <returns></returns>
        public int SetMaxValue(MainForm mainForm)
        {
            double TotalSeconds = (m_StopTime - m_StartTime).TotalSeconds;
            mainForm.Invoke(new EventHandler(delegate
            {
                HProgressBar.Maximum = (int)TotalSeconds;
                VProgressBar.Maximum = (int)TotalSeconds;
            }));
            return (int)TotalSeconds;
        }
        /// <summary>
        /// 设置当前进度条位置
        /// </summary>
        /// <param name="TotalSeconds"></param>
        public bool SetValuePosition(double TotalSeconds, MainForm mainForm)
        {

                DateTime NowTime = new DateTime(1970, 1, 1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                if (NowTime > m_StopTime || NowTime < m_StartTime)
                {
                    mainForm.Invoke(new EventHandler(delegate
                    {
                        HProgressBar.Value = (int)TotalSeconds;
                        VProgressBar.Value = (int)TotalSeconds;
                    }));
                    return false;
                }
                else
                {
                    double ValueSeconds = (NowTime - m_StartTime).TotalSeconds;
                    mainForm.Invoke(new EventHandler(delegate
                    {
                        HProgressBar.Value = (int)ValueSeconds;
                        VProgressBar.Value = (int)ValueSeconds;
                    }));
                    return true;
                }

        }
        #endregion
        #region 线程
        public static void TaskRefresh(MainForm mainForm)
        {
            while(true)
            {
                var loc = TaskbarInfo.GetBarLocation();
                mainForm.SetFormSizeLoc(loc, mainForm);
                int TotalSeconds = mainForm.SetMaxValue(mainForm);
                if(!mainForm.SetValuePosition(TotalSeconds, mainForm))
                    Thread.Sleep(5000);
                Thread.Sleep(100);
            }
        }
        #endregion
    }

}