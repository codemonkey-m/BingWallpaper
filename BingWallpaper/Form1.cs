using Microsoft.Win32;
using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace BingWallpaper
{
    public partial class Form1 : Form
    {
        enum ShowType {
            Center,         //居中
            Tiling,         //平铺
            Stretching,     //拉伸

            ShowType_Max,
        };

        int[,] arrType = new int[(int)ShowType.ShowType_Max, 2] {
            {0, 0},
            {1, 0},
            {0, 2}
        };

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        private static extern int SystemParametersInfo(
            int uAction,
            int uParam,
            string lpvParam,
            int fuWinIni
        );

        WebClient page_client = new WebClient();
        string strCurPicName = "";
        const string strRegName = "BingWallpaper";
        const string strSelfName = "Bing壁纸 v0.0.1.0";
        const string strPicDescFile = "PicDesc.ini";
        const string strSectionName = "desc";
        string strMainPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\" + strRegName;
        System.Windows.Forms.Timer timerCheck = new System.Windows.Forms.Timer();

        public Form1()
        {
            page_client.Headers.Add("Accept-Encoding", "");
            page_client.Encoding = System.Text.Encoding.GetEncoding("GB2312");

            InitializeComponent();

            CheckAndCreateDir();

            StartTimer();

            RefreshImage();

            //判断开机启动状态
            AutoRun.Checked = CheckRegExists(strRegName);
        }

        //检测并创建图片文件夹
        private void CheckAndCreateDir()
        {
            if (!Directory.Exists(strMainPath))
                Directory.CreateDirectory(strMainPath);
        }

        //启动定时器
        private void StartTimer()
        {
            timerCheck.Tick += new EventHandler(OnTimerRun);
            timerCheck.Enabled = true;
            timerCheck.Interval = 60 * 60 * 1000;
        }

        //定时器回调
        private void OnTimerRun(object sender, EventArgs e)
        {
            RefreshImage();
        }

        //刷新图片
        private bool RefreshImage()
        {
            string strHtml = "";
            try {
                strHtml = Encoding.UTF8.GetString(page_client.DownloadData("https://bing.ioliu.cn/"));
            }
            catch (Exception e) {
                ShowTips("检查新壁纸失败.\n" + e.Message);
                return true;
            }

            //查找第一个image
            Match reMatch = Regex.Match(strHtml, "data-progressive=\"(\\S*)\"");
            if (!reMatch.Success)
                return false;

                //取文件名
            Match reFileName = Regex.Match(reMatch.Groups[1].Value, "bing\\/(.*)$");
            if (!reFileName.Success)
                return false;

            //文件完整路径
            string strFileName = reFileName.Groups[1].Value;
            strCurPicName = strMainPath + "\\" + strFileName;

            //获取文件的描述
            reFileName = Regex.Match(strHtml, @"<h3>(.*?)</h3>");
            if (reFileName.Success)
            {
                string strDesc = reFileName.Groups[1].Value;
                //超长截断
                if (strDesc.Length >= (62 - strSelfName.Length))
                    strDesc = strDesc.Substring(0, (62 - strSelfName.Length));

                SetIconText(strDesc);
            }

            //检查文件是否存在
            if (File.Exists(strCurPicName))
                return false;

            try {
                page_client.DownloadFile(reMatch.Groups[1].Value, strCurPicName);
            }
            catch (Exception e) {
                ShowTips("有新壁纸,但是下载失败.请手动刷新.\n" + e.Message);
                return true;
            }

            SetWallpaper(ShowType.Center);

            ShowTips("壁纸已刷新.");
            return true;
        }

        //隐藏窗口
        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(false);
        }

        //选择居中
        private void Center_Click(object sender, EventArgs e)
        {
            SetWallpaper(ShowType.Center);
        }

        //选择平铺
        private void Tiling_Click(object sender, EventArgs e)
        {
            SetWallpaper(ShowType.Tiling);
        }

        //选择拉伸
        private void Stretching_Click(object sender, EventArgs e)
        {
            SetWallpaper(ShowType.Stretching);
        }

        private void SetWallpaper(ShowType nType)
        {
            #region 默认1080p,不需要设置
            //设置墙纸显示方式
            /*RegistryKey myRegKey = Registry.CurrentUser.OpenSubKey("Control Panel/desktop", true);
            if (null != myRegKey)
            {
                //赋值
                myRegKey.SetValue("TileWallpaper", arrType[(int)nType, 0]);
                myRegKey.SetValue("WallpaperStyle", arrType[(int)nType, 1]);

                //关闭该项,并将改动保存到磁盘
                myRegKey.Close();
            }
            else
            {
                notifyIcon1.ShowBalloonTip(1000, "获取注册表项失败", "使用默认的拉伸方式显示", ToolTipIcon.Info);
            }*/
            #endregion

            //设置墙纸
            SystemParametersInfo(20, 1, strCurPicName, 1);
        }

        private void Button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AutoRun_Click(object sender, EventArgs e)
        {
            //存在就删除,不存在就新增
            if (CheckRegExists(strRegName, true))
                AutoRun.Checked = false;
            else
                AutoRun.Checked = true;
        }

        //检查注册表项存在
        private bool CheckRegExists(string strName, bool bHandle = false)
        {
            bool bRet = false;
            RegistryKey reAutoRun = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (null != reAutoRun.GetValue(strName))
                bRet = true;

            if (bHandle)
            {
                if (!bRet)  //没有的时候创建
                    reAutoRun.SetValue(strName, System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                else        //有的话就删除
                    reAutoRun.DeleteValue(strName);
            }

            reAutoRun.Close();
            return bRet;
        }

        //手动刷新
        private void Refresh_Img_Click(object sender, EventArgs e)
        {
            if (!RefreshImage())
                ShowTips("无新壁纸.");
        }

        private void Open_Img_Dir_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", strMainPath);
        }

        public void ShowTips(string str)
        {
            notifyIcon1.ShowBalloonTip(1000, strSelfName, DateTime.Now.ToLocalTime().ToString() + "\n" + str, ToolTipIcon.Info);
        }

        private void SetIconText(string str)
        {
            notifyIcon1.Text = strSelfName + "\n" + str;
        }

        private void About_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/codemonkey-m/BingWallpaper");
        }
    }
}
