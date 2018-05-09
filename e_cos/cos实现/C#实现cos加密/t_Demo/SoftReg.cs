using System;
using System.Linq;
using System.Management;//需要在项目中添加System.Management引用

namespace t_Demo
{
    public class SoftReg
    {
        /// <summary>
        /// 取得设备硬盘的卷标号
        /// </summary>
        /// <returns></returns>
        public string GetDiskVolumeSerialNumber()
        {
            var disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            disk.Get();
            return disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }

        /// <summary>
        /// 获得CPU的序列号
        /// </summary>
        /// <returns></returns>
        public string GetCpu()
        {
            var myCpu = new ManagementClass("win32_Processor");
            var myCpuConnection = myCpu.GetInstances();
            return (from ManagementBaseObject myObject in myCpuConnection select myObject.Properties["Processorid"].Value.ToString()).FirstOrDefault();
        }

        /// <summary>
        /// 生成机器码
        /// </summary>
        /// <returns></returns>
        public string GetMNum()
        {
            var strNum = GetCpu() + GetDiskVolumeSerialNumber();//获得24位Cpu和硬盘序列号
            var strMNum = strNum.Substring(0, 24);//从生成的字符串中取出前24个字符做为机器码
            return strMNum;
        }
        public int[] IntCode = new int[127];//存储密钥
        public int[] IntNumber = new int[25];//存机器码的Ascii值
        public char[] Charcode = new char[25];//存储机器码字
        public void SetIntCode()//给数组赋值小于10的数
        {
            for (var i = 1; i < IntCode.Length; i++)
            {
                IntCode[i] = i % 9;
            }
        }

        /// <summary>
        /// 生成注册码
        /// </summary>
        /// <returns></returns>
        public string GetRNum()
        {
            SetIntCode();//初始化127位数组
            var mNum = GetMNum();//获取注册码
            for (var i = 1; i < Charcode.Length; i++)//把机器码存入数组中
            {
                Charcode[i] = Convert.ToChar(mNum.Substring(i - 1, 1));
            }
            for (int j = 1; j < IntNumber.Length; j++)//把字符的ASCII值存入一个整数组中。
            {
                IntNumber[j] = IntCode[Convert.ToInt32(Charcode[j])] + Convert.ToInt32(Charcode[j]);
            }
            string strAsciiName = "";//用于存储注册码
            for (int j = 1; j < IntNumber.Length; j++)
            {
                if (IntNumber[j] >= 48 && IntNumber[j] <= 57)//判断字符ASCII值是否0－9之间
                {
                    strAsciiName += Convert.ToChar(IntNumber[j]).ToString();
                }
                else if (IntNumber[j] >= 65 && IntNumber[j] <= 90)//判断字符ASCII值是否A－Z之间
                {
                    strAsciiName += Convert.ToChar(IntNumber[j]).ToString();
                }
                else if (IntNumber[j] >= 97 && IntNumber[j] <= 122)//判断字符ASCII值是否a－z之间
                {
                    strAsciiName += Convert.ToChar(IntNumber[j]).ToString();
                }
                else//判断字符ASCII值不在以上范围内
                {
                    if (IntNumber[j] > 122)//判断字符ASCII值是否大于z
                    {
                        strAsciiName += Convert.ToChar(IntNumber[j] - 10).ToString();
                    }
                    else
                    {
                        strAsciiName += Convert.ToChar(IntNumber[j] - 9).ToString();
                    }
                }
            }
            return strAsciiName;//返回注册码
        }
    }
}