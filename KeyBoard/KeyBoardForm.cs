using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace KeyBoard
{
    public partial class KeyBoardForm : Form
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

        public KeyBoardForm()
        {
            InitializeComponent();
            if (Console.CapsLock)
            {
                this.CapsLockL.BackColor = SystemColors.ControlDark;
            }
            else
            {
                this.CapsLockL.BackColor = SystemColors.ControlLight;
            }

            UpdateKeyText();
        }

        private void KeyBoardForm_Load(object sender, EventArgs e)
        {
            animation.AnimateWindow(this.Handle, 200, animation.AW_BLEND);//窗体加载动画
        }

        private void KeyBoardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            this.Hide();
        }

        #region 系统全局 大小写按键
        bool isCapitalization = false; //是否大写，默认小写
        bool isShift = false; 
        bool isCtrl = false; 
                              //模拟键盘API  键值用byte最准确
        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        public static extern void keybd_event1(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        private void CapsLock_Click(object sender, EventArgs e)
        {
            const int KEYEVENTF_EXTENDEDKEY = 0x1;
            const int KEYEVENTF_KEYUP = 0x2;
            keybd_event1(0x14, 0x45, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event1(0x14, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
            if(Console.CapsLock)
            {
                this.CapsLockL.BackColor = SystemColors.ControlDark;
            }
            else
            {
                this.CapsLockL.BackColor = SystemColors.ControlLight;
            }

            UpdateKeyText();

            /*
            if (!isCapitalization)
            {
                isCapitalization = true;
                this.CapsLockL.BackColor = SystemColors.ControlDark;
            }
            else
            {
                isCapitalization = false;
                this.CapsLockL.BackColor = SystemColors.ControlLight; 
            }
            */
        }
        #endregion


        #region 字母键，组合键   多个虚拟字母键按钮-统一监听
        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        public static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        private void SendKeyCode(Keys bVk)
        {
            keybd_event(bVk, 0, 0, 0);                   //压下
            keybd_event(bVk, 0, 2, 0);                   //弹起
        }

        private void Char_Click(object sender, EventArgs e)
        {
            String cr = ((Button)sender).Text;
            switch (cr)
            {
                case "A":
                case "a":
                    if (isShift)
                        SendKeys.Send("+A");
                    else
                        SendKeyCode(Keys.A);
                    break;
                case "B":
                case "b":
                    if (isShift)
                        SendKeys.Send("+B");
                    else
                        SendKeyCode((Keys)66);
                    break;
                case "C":
                case "c":
                    if (isShift)
                        SendKeys.Send("+C");
                    else
                        SendKeyCode((Keys)67);
                    break;
                case "D":
                case "d":
                    if (isShift)
                        SendKeys.Send("+D");
                    else
                        SendKeyCode((Keys)68);
                    break;
                case "E":
                case "e":
                    if (isShift)
                        SendKeys.Send("+E");
                    else
                        SendKeyCode((Keys)69);
                    break;
                case "F":
                case "f":
                    if (isShift)
                        SendKeys.Send("+F");
                    else
                        SendKeyCode((Keys)70);
                    break;
                case "G":
                case "g":
                    if (isShift)
                        SendKeys.Send("+G");
                    else
                        SendKeyCode((Keys)71);
                    break;
                case "H":
                case "h":
                    if (isShift)
                        SendKeys.Send("+H");
                    else
                        SendKeyCode((Keys)72);
                    break;
                case "I":
                case "i":
                    if (isShift)
                        SendKeys.Send("+I");
                    else
                        SendKeyCode((Keys)73);
                    break;
                case "J":
                case "j":
                    if (isShift)
                        SendKeys.Send("+J");
                    else
                        SendKeyCode((Keys)74);
                    break;
                case "K":
                case "k":
                    if (isShift)
                        SendKeys.Send("+K");
                    else
                        SendKeyCode((Keys)75);
                    break;
                case "L":
                case "l":
                    if (isShift)
                        SendKeys.Send("+L");
                    else
                        SendKeyCode((Keys)76);
                    break;
                case "M":
                case "m":
                    if (isShift)
                        SendKeys.Send("+M");
                    else
                        SendKeyCode((Keys)77);
                    break;
                case "N":
                case "n":
                    if (isShift)
                        SendKeys.Send("+N");
                    else
                        SendKeyCode((Keys)78);
                    break;
                case "O":
                case "o":
                    if (isShift)
                        SendKeys.Send("+O");
                    else
                        SendKeyCode((Keys)79);
                    break;
                case "P":
                case "p":
                    if (isShift)
                        SendKeys.Send("+P");
                    else
                        SendKeyCode((Keys)80);
                    break;
                case "Q":
                case "q":
                    if (isShift)
                        SendKeys.Send("+Q");
                    else
                        SendKeyCode((Keys)81);
                    break;
                case "R":
                case "r":
                    if (isShift)
                        SendKeys.Send("+R");
                    else
                        SendKeyCode((Keys)82);
                    break;
                case "S":
                case "s":
                    if (isShift)
                        SendKeys.Send("+S");
                    else
                        SendKeyCode((Keys)83);
                    break;
                case "T":
                case "t":
                    if (isShift)
                        SendKeys.Send("+T");
                    else
                        SendKeyCode((Keys)84);
                    break;
                case "U":
                case "u":
                    if (isShift)
                        SendKeys.Send("+U");
                    else
                        SendKeyCode((Keys)85);
                    break;
                case "V":
                case "v":
                    if (isShift)
                        SendKeys.Send("+V");
                    else
                        SendKeyCode((Keys)86);
                    break;
                case "W":
                case "w":
                    if (isShift)
                        SendKeys.Send("+W");
                    else
                        SendKeyCode((Keys)87);
                    break;
                case "X":
                case "x":
                    if (isShift)
                        SendKeys.Send("+X");
                    else
                        SendKeyCode((Keys)88);
                    break;
                case "Y":
                case "y":
                    if (isShift)
                        SendKeys.Send("+Y");
                    else
                        SendKeyCode((Keys)89);
                    break;
                case "Z":
                case "z":
                    if (isShift)
                        SendKeys.Send("+Z");
                    else
                        SendKeyCode((Keys)90);
                    break;
                case "0":
                    if (isShift)
                        SendKeys.Send("+0");
                    else
                        SendKeyCode(Keys.D0);
                    break;
                case "1":
                    if (isShift)
                        SendKeys.Send("+1");
                    else
                        SendKeyCode(Keys.D1);
                    break;
                case "2":
                    if (isShift)
                        SendKeys.Send("+2");
                    else
                        SendKeyCode((Keys)50);
                    break;
                case "3":
                    if (isShift)
                        SendKeys.Send("+3");
                    else
                        SendKeyCode((Keys)51);
                    break;
                case "4":
                    if (isShift)
                        SendKeys.Send("+4");
                    else
                        SendKeyCode((Keys)52);
                    break;
                case "5":
                    if (isShift)
                        SendKeys.Send("+5");
                    else
                        SendKeyCode((Keys)53);
                    break;
                case "6":
                    if (isShift)
                        SendKeys.Send("+6");
                    else
                        SendKeyCode((Keys)54);
                    break;
                case "7":
                    if (isShift)
                        SendKeys.Send("+7");
                    else
                        SendKeyCode((Keys)55);
                    break;
                case "8":
                    if (isShift)
                        SendKeys.Send("+8");
                    else
                        SendKeyCode((Keys)56);
                    break;
                case "9":
                    if (isShift)
                        SendKeys.Send("+9");
                    else
                        SendKeyCode((Keys)57);
                    break;
                case "F1":
                    SendKeyCode((Keys)112);
                    break;
                case "F2":
                    SendKeyCode((Keys)113);
                    break;
                case "F3":
                    SendKeyCode((Keys)114);
                    break;
                case "F4":
                    SendKeyCode((Keys)115);
                    break;
                case "F5":
                    SendKeyCode((Keys)116);
                    break;
                case "F6":
                    SendKeyCode((Keys)117);
                    break;
                case "F7":
                    SendKeyCode((Keys)118);
                    break;
                case "F8":
                    SendKeyCode((Keys)119);
                    break;
                case "F9":
                    SendKeyCode((Keys)120);
                    break;
                case "F10":
                    SendKeyCode((Keys)121);
                    break;
                case "F11":
                    SendKeyCode((Keys)122);
                    break;
                case "F12":
                    SendKeyCode((Keys)123);
                    break;
                case "BackSpace":
                    SendKeyCode((Keys)8);
                    break;
                case "Tab":
                    SendKeyCode((Keys)9);
                    break;
                case "Clear":
                    SendKeyCode((Keys)12);
                    break;
                case "Enter":
                    SendKeyCode((Keys)13);
                    break;
                case "Shift":
                    {
                        isShift = !isShift;
                        if (isShift)
                        {
                            this.button_l_shift.BackColor = SystemColors.ControlDark;
                            this.button_r_shift.BackColor = SystemColors.ControlDark;
                        }
                        else
                        {
                            // 再次按shift响应shift按键
                            SendKeyCode(Keys.ShiftKey);
                            this.button_l_shift.BackColor = SystemColors.ControlLight;
                            this.button_r_shift.BackColor = SystemColors.ControlLight;
                        }
                        // SendKeyCode((Keys)16);

                        // 如果shift 和 ctrl 都按下了
                        if (isShift && isCtrl)
                        {
                            keybd_event(Keys.ControlKey, 0, 0, 0);
                            keybd_event(Keys.ShiftKey, 0, 0, 0);
                            keybd_event(Keys.ControlKey, 0, 2, 0);
                            keybd_event(Keys.ShiftKey, 0, 2, 0);

                            this.button_l_shift.BackColor = SystemColors.ControlLight;
                            this.button_r_shift.BackColor = SystemColors.ControlLight;

                            this.button_l_ctrl.BackColor = SystemColors.ControlLight;
                            this.button_r_ctrl.BackColor = SystemColors.ControlLight;

                            isShift = false;
                            isCtrl = false;
                        }

                        UpdateKeyText();
                    }
                    break;
                case "Ctrl":
                    {
                        isCtrl = !isCtrl;
                        if (isCtrl)
                        {
                            this.button_l_ctrl.BackColor = SystemColors.ControlDark;
                            this.button_r_ctrl.BackColor = SystemColors.ControlDark;
                        }
                        else
                        {
                            // 再次按 Ctrl 响应 Ctrl 按键
                            SendKeyCode(Keys.ControlKey);
                            this.button_l_ctrl.BackColor = SystemColors.ControlLight;
                            this.button_r_ctrl.BackColor = SystemColors.ControlLight;
                        }
                        // SendKeyCode((Keys)17);

                        // 如果shift 和 ctrl 都按下了
                        if (isShift && isCtrl)
                        {
                            keybd_event(Keys.ControlKey, 0, 0, 0);
                            keybd_event(Keys.ShiftKey, 0, 0, 0);
                            keybd_event(Keys.ControlKey, 0, 2, 0);
                            keybd_event(Keys.ShiftKey, 0, 2, 0);

                            this.button_l_shift.BackColor = SystemColors.ControlLight;
                            this.button_r_shift.BackColor = SystemColors.ControlLight;

                            this.button_l_ctrl.BackColor = SystemColors.ControlLight;
                            this.button_r_ctrl.BackColor = SystemColors.ControlLight;

                            isShift = false;
                            isCtrl = false;
                        }

                        UpdateKeyText();
                    }
                    break;
                case "Alt": 
                    SendKeyCode((Keys)18);
                    break;
                case "Caps":
                    SendKeyCode(Keys.CapsLock);
                    break;
                case "Esc":
                    SendKeyCode(Keys.Escape);
                    break;
                case " ":
                    SendKeyCode(Keys.Space);
                    break;
                case "PageUp":
                    SendKeyCode(Keys.PageUp);
                    break;
                case "PageDown":
                    SendKeyCode(Keys.PageDown);
                    break;
                case "End":
                    SendKeyCode((Keys)35);
                    break;
                case "Home":
                    SendKeyCode((Keys)36);
                    break;
                case "←":
                    SendKeyCode((Keys)37);
                    break;
                case "↑":
                    SendKeyCode((Keys)38);
                    break;
                case "→":
                    SendKeyCode((Keys)39);
                    break;
                case "↓":
                    SendKeyCode((Keys)40);
                    break;
                case "Ins":
                    SendKeyCode((Keys)45);
                    break;
                case "Del":
                    SendKeyCode((Keys)46);
                    break;
                case "NumLock":
                    SendKeyCode((Keys)144);
                    break;

                case ";":
                    if (isShift)
                        SendKeys.Send("+;");
                    else
                        SendKeyCode((Keys)186);
                    break;
                case "=":
                    if (isShift)
                        SendKeys.Send("+=");
                    else
                        SendKeyCode((Keys)187);
                    break;
                case ",":
                    if (isShift)
                        SendKeys.Send("+,");
                    else
                        SendKeyCode((Keys)188);
                    break;
                case "-":
                    if (isShift)
                        SendKeys.Send("+-");
                    else
                        SendKeyCode((Keys)189);
                    break;
                case ".":
                    if (isShift)
                        SendKeys.Send("+.");
                    else
                        SendKeyCode((Keys)190);
                    break;
                case "/":
                    if (isShift)
                        SendKeys.Send("+/");
                    else
                        SendKeyCode((Keys)191);
                    break;
                case "`":
                    if (isShift)
                        SendKeys.Send("+`");
                    else
                        SendKeyCode((Keys)192);
                    break;
                case "[":
                    if (isShift)
                        SendKeys.Send("+[");
                    else
                        SendKeyCode((Keys)219);
                    break;
                case "\\":
                    if (isShift)
                        SendKeys.Send("+\\");
                    else
                        SendKeyCode((Keys)220);
                    break;
                case "]":
                    if (isShift)
                        SendKeys.Send("+]");
                    else
                        SendKeyCode((Keys)220);
                    SendKeyCode((Keys)221);
                    break;
                case "'":
                    if (isShift)
                        SendKeys.Send("+'");
                    else
                        SendKeyCode((Keys)222);
                    break;

                    /*
                case "EN/CN":
                    SendKeys.Send("^+");
                    break;
                     */
            }
        }
        #endregion

        
        private void UpdateKeyText()
        {
            if (Console.CapsLock && isShift)
            {
                KeyText_Lower();
            }
            else if (Console.CapsLock || (!Console.CapsLock && isShift))
            {
                KeyText_Upper();
            }
            else
            {
                KeyText_Lower();
            }
        }

        private void KeyText_Lower()
        {
            button_a.Text = "a";
            button_b.Text = "b";
            button_c.Text = "c";
            button_d.Text = "d";
            button_e.Text = "e";
            button_f.Text = "f";
            button_g.Text = "g";
            button_h.Text = "h";
            button_i.Text = "i";
            button_j.Text = "j";
            button_k.Text = "k";
            button_l.Text = "l";
            button_m.Text = "m";
            button_n.Text = "n";
            button_o.Text = "o";
            button_p.Text = "p";
            button_q.Text = "q";
            button_r.Text = "r";
            button_s.Text = "s";
            button_t.Text = "t";
            button_u.Text = "u";
            button_v.Text = "v";
            button_w.Text = "w";
            button_x.Text = "x";
            button_y.Text = "y";
            button_z.Text = "z";
        }

        private void KeyText_Upper()
        {
            button_a.Text = "a".ToUpper();
            button_b.Text = "b".ToUpper();
            button_c.Text = "c".ToUpper();
            button_d.Text = "d".ToUpper();
            button_e.Text = "e".ToUpper();
            button_f.Text = "f".ToUpper();
            button_g.Text = "g".ToUpper();
            button_h.Text = "h".ToUpper();
            button_i.Text = "i".ToUpper();
            button_j.Text = "j".ToUpper();
            button_k.Text = "k".ToUpper();
            button_l.Text = "l".ToUpper();
            button_m.Text = "m".ToUpper();
            button_n.Text = "n".ToUpper();
            button_o.Text = "o".ToUpper();
            button_p.Text = "p".ToUpper();
            button_q.Text = "q".ToUpper();
            button_r.Text = "r".ToUpper();
            button_s.Text = "s".ToUpper();
            button_t.Text = "t".ToUpper();
            button_u.Text = "u".ToUpper();
            button_v.Text = "v".ToUpper();
            button_w.Text = "w".ToUpper();
            button_x.Text = "x".ToUpper();
            button_y.Text = "y".ToUpper();
            button_z.Text = "z".ToUpper();
        }
    }
}
