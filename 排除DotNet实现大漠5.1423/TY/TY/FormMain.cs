using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using dm;

namespace TY
{
    public partial class FormMain : Form
    {
        [DllImport("dm5.dll")]
        public static extern int Reg();
        //全局大漠对象
        // ReSharper disable once InconsistentNaming
        private readonly dmsoft dm;
        public FormMain()
        {
            InitializeComponent();
            //大漠插件免注册或注册
            var r = Reg();
            switch (r)
            {
                case 0:
                    Console.WriteLine(@"reg注册成功");
                    break;
                case 1:
                    MessageBox.Show(@"reg无法释放资源");
                    break;
                case 2:
                    MessageBox.Show(@"reg免注册失败,请重启软件");
                    break;
                case 3:
                    MessageBox.Show(@"加载dm.dll失败");
                    break;
                case 4:
                    MessageBox.Show(@"dm调用失败");
                    break;
                default:
                    MessageBox.Show(@"reg无法调用");
                    break;
            }
            dm = new dmsoft();
            //实例化钩子
            var kh = new HookHelper();
            //挂载钩子按键事件
            kh.KeyDownEvent += OnKeyDown;
            //注册钩子
            kh.SetHook();
        }
        //按下按键时触发这个函数
        private void OnKeyDown(object o, KeyEventArgs e)
        {
            //这里建立大漠对象
            //判断按下的是 a
            if (e.KeyCode != Keys.A) return;
            //执行移动鼠标到  100,100 位置
            dm.delay(1000);
            dm.LeftClick();
            dm.KeyPressStr(@"WlkkDXxNbnYww23123124444555",10);
        }

    }
}
