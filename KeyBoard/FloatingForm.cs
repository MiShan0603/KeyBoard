using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyBoard
{
    public partial class FloatingForm : Form
    {
        #region 把当前窗体设置为浮动工具条。不会影响其它进程的窗体的光标焦点。虽然这个窗体现在为当前激活的前台窗体，但光标仍然停在其他进程的窗体上
        private const int WS_EX_TOOLWINDOW = 0x00000080;
        private const int WS_EX_NOACTIVATE = 0x08000000;
        private const int WS_EX_TOPMOS = 0x00000008;
        //重写该方法实现窗体变为浮动工具条，不获取光标焦点
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // cp.ExStyle |= (WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW | WS_EX_TOPMOS);
                cp.ExStyle |= (WS_EX_NOACTIVATE | WS_EX_TOPMOS);
                cp.Parent = IntPtr.Zero;
                return cp;
            }
        }
        #endregion


        private KeyBoardForm _keyBoardForm = null;

        public FloatingForm()
        {
            InitializeComponent();

            // this.TopMost = true;
            int screenHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            int screenWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;

            double winWidth = 78.0 / 1.5;
            double winHeight = 44.0 / 1.5;
#if false
            this.Left = (screenWidth - winWidth) - 20;
            this.Top = (screenHeight - winHeight) - 20;
            this.Width = winWidth;
            this.Height = winHeight;    
#else
            Graphics currentGraphics = Graphics.FromHwnd(this.Handle);
            double dpixRatio = currentGraphics.DpiX / 96;

            winWidth *= dpixRatio;
            winHeight *= dpixRatio;

            int left = (int)(screenWidth - winWidth) - 20;
            int top = (int)(screenHeight - winHeight) - 20;

            Win32Wrapper.MoveWindow(this.Handle, left, top, (int)winWidth, (int)winHeight, true);
#endif
        }

        private void FloatingForm_Load(object sender, EventArgs e)
        {
            // animation.AnimateWindow(this.Handle, 200, animation.AW_BLEND);//窗体加载动画
        }

        private void FloatingForm_Click(object sender, EventArgs e)
        {
            // Console.WriteLine("FloatingForm_Click ");
        }

        private Point _mouseOff;//鼠标移动位置变量
        private bool _leftFlag;//标签是否为左键
        private long _lastTickCount = 0;
        private void FloatingForm_MouseDown(object sender, MouseEventArgs e)
        {
            // Win32Wrapper.OutputDebugString("FloatingForm_MouseDown ");
            if (e.Button == MouseButtons.Left)
            {
                _mouseOff = new Point(-e.X, -e.Y); //这个是鼠标相对窗体左上角的位置
                _leftFlag = true;                  //点击左键按下时标注为true;
            }

            _lastTickCount = System.Environment.TickCount;
        }

        private void FloatingForm_MouseMove(object sender, MouseEventArgs e)
        {
            // Win32Wrapper.OutputDebugString("FloatingForm_MouseMove ");
            if (_leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(_mouseOff.X, _mouseOff.Y);  //光标和窗口左上角的位置保持一致就是托着不动了
                Location = mouseSet;    //窗口更新为新的位置
            }
        }

        private void FloatingForm_MouseUp(object sender, MouseEventArgs e)
        {
            // Win32Wrapper.OutputDebugString("FloatingForm_MouseUp ");
            if (_leftFlag)
            {
                _leftFlag = false;//释放鼠标后标注为false;
            }

            if (System.Environment.TickCount - _lastTickCount <= 100)
            {
                // MessageBox.Show("open keyboard");
                if (_keyBoardForm == null) 
                {
                    _keyBoardForm = new KeyBoardForm();
                    _keyBoardForm.Show();
                }
                else
                {
                    _keyBoardForm.Show();
                }
            }
        }
    }
}
