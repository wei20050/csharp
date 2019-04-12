using System.Windows.Forms;
using yxz;

namespace demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //实例化钩子
            var kh = new KeyHook();
            //挂载钩子按键事件
            kh.OnKeyPressEvent += OnKeyPress;
            //注册钩子
            kh.SetHook();
        }

        //按下按键时触发这个函数
        private static void OnKeyPress(object o,KeyPressEventArgs e)
        {
            //判断按下的是 a
            if (e.KeyChar == 'a')
            {
                //执行移动鼠标到  100,100 位置
                Yx.MoveTo(100,100);
            }
        }
    }
}
