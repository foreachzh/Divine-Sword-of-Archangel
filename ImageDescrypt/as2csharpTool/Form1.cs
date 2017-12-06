using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XRFAppPlat.Logger;
using System.Text.RegularExpressions;

namespace as2csharpTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            if (AppSetting.GetValue("chkValName") == "true")
                checkBox1.Checked = true;
            if (AppSetting.GetValue("chkDelSuper") == "true")
                checkBox2.Checked = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            AppSetting.SetValue("chkValName", checkBox1.Checked.ToString());
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            AppSetting.SetValue("chkDelSuper", checkBox2.Checked.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length == 0)
            {
                MessageBox.Show("请输入 as3脚本！");
                return;
            }

            string orignalstr = richTextBox1.Text;
            // 如果一行同时有 var 和:就替换
            string[] strLineArr = orignalstr.Split(new string[] { "\n" }, StringSplitOptions.None);
            strLineArr = strLineArr.Where(s => !string.IsNullOrEmpty(s)).ToArray();

            for (int i = 0; i < strLineArr.Length; i++)
            {
                string linestr = strLineArr[i];
                if (linestr.Contains("function"))
                {
                    // 搜索返回类型
                    string typestr = Regex.Match(linestr, ":(?<value>.*?)").Groups["value"].Value;
                    if (typestr.Length == 0)
                    {
                        int nindex =linestr.IndexOf(':');
                        if(nindex>0)
                            typestr =linestr.Substring(nindex+1, linestr.Length-nindex-1);//) : "").Trim();
                    }
                    if (typestr.Length > 0)
                    {
                        linestr = linestr.Replace(":" + typestr, "");
                        linestr = linestr.Replace("function", typestr);
                        strLineArr[i] = linestr;
                    }
                }
                if (linestr.Contains("var") && linestr.Contains(":"))
                {
                    // 提取:后面的类型
                    string varstr = Regex.Match(linestr, ":(?<value>.*?) ").Groups["value"].Value;
                    if (varstr.Length > 0)
                    {
                        linestr = linestr.Replace(":"+varstr, "");
                        linestr = linestr.Replace("var", varstr);
                        strLineArr[i] = linestr;
                    }
                    varstr = Regex.Match(linestr, ":(?<value>.*?);").Groups["value"].Value;
                    if (varstr.Length > 0)
                    {
                        linestr = linestr.Replace(":" + varstr, "");
                        linestr = linestr.Replace("var", varstr);
                        if (linestr.Contains("Vector."))
                            linestr = linestr.Replace("Vector.", "List");
                        strLineArr[i] = linestr;
                    }
                }
                if (strLineArr[i].Contains("class"))
                {
                    linestr = strLineArr[i].Replace("extends", ":");
                    strLineArr[i] = linestr;
                }
                // 定位while
            }

            richTextBox2.Text = string.Join("\r\n", strLineArr);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string funcHead = "public override string getPrintStr()\n{\n";
            string funcTail = "\nreturn outstr;\n}\n";
            string sentence1 ="string outstr = string.Format(\"";
            string sentence2 = "";
            string sentence3 = "";

            if (richTextBox1.Text.Length == 0)
            {
                MessageBox.Show("请输入 as3脚本！");
                return;
            }

            string orignalstr = richTextBox1.Text;
            // 如果一行同时有 var 和:就替换
            string[] striparr = orignalstr.Split(new string[] { "\n" }, StringSplitOptions.None);
            striparr = striparr.Where(s => !string.IsNullOrEmpty(s)).ToArray();

            int ipara = 0;
            for (int i = 0; i < striparr.Length; i++)
            {
                string str = striparr[i];
                if (str.Trim().Length > 0)
                {
                    // 获取参数名
                    string typestr = Regex.Match(str, "private (?<value>.*?) ").Groups["value"].Value;
                    string parameter = Regex.Match(str, string.Format("{0} (?<value>.*?);", typestr)).Groups["value"].Value;
                    
                    if (typestr =="long" || typestr == "LongC")
                    {
                        sentence2 += string.Format("{0}={{{1}}};", parameter, ipara);
                        sentence3 += string.Format(",{0}.toString()", parameter);
                    }
                    else if (typestr.Contains("List"))
                    {
                        sentence2 += string.Format("{0}.cnt={{{1}}};", parameter, ipara);
                        sentence3 += string.Format(",{0}.Count", parameter);
                    }
                    else
                    {
                        sentence2 += string.Format("{0}={{{1}}};", parameter, ipara);
                        sentence3 += string.Format(",{0}", parameter);
                    }
                    ipara++;
                }
            }
            sentence2 += "\"\n";
            sentence3 += ");\n";

            // 
            string outstr = funcHead + sentence1 + sentence2 + sentence3 + funcTail;
            richTextBox2.Text = outstr;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length == 0)
            {
                MessageBox.Show("请输入 as3脚本！");
                return;
            }

            string orignalstr = richTextBox1.Text;
            // 如果一行同时有 var 和:就替换
            string[] strLineArr = orignalstr.Split(new string[] { "\n" }, StringSplitOptions.None);
            strLineArr = strLineArr.Where(s => !string.IsNullOrEmpty(s)).ToArray();

            try
            {
                for (int i = 0; i < strLineArr.Length; i++)
                {
                    string linestr = strLineArr[i];
                    if (linestr.Contains("while"))
                    {
                        // 找到while句的第二个参数
                        string para1 = Regex.Match(linestr, "\\<(?<value>.*?)\\)").Groups["value"].Value.Trim();
                        string para2 = Regex.Match(linestr, "\\((?<value>.*?)\\<").Groups["value"].Value.Trim();
                        if (string.IsNullOrEmpty(para1))
                            continue;
                        // 本行 替换为空行
                        strLineArr[i] = "";

                        int pstart = i - 1;
                        // 往上找到para1,para1并替换为"",
                        bool bok1 = false,bok2=false;
                        while (pstart >= 0&&!(bok1&&bok2))
                        {
                            if (strLineArr[pstart].Contains(para1)){
                                strLineArr[pstart] = ""; bok1 = true;
                            }

                            if (strLineArr[pstart].Contains(para2))
                            {
                                strLineArr[pstart] = ""; bok2 = true;
                            }

                            pstart--;
                        }

                        // 往下找this._positions[para2]并做简化
                        pstart = i + 1;
                        while (pstart < strLineArr.Length)
                        {
                            string str = strLineArr[pstart];
                            if (str.Contains(string.Format("[{0}]", para2)))
                            {
                                // 提取变量名
                                string varName = Regex.Match(str, "\\.(?<value>.*?)\\[").Groups["value"].Value;
                                // 获取其后读取的类型并拼接
                                string readtype = Regex.Match(str, "=(?<value>.*?);").Groups["value"].Value.Trim();
                                string strReadSent = "";
                                if (readtype == "readByte()")
                                    strReadSent = "readObjList<int,Byte>();";
                                else if (readtype == "readShort()")
                                    strReadSent = "readObjList<int,Short>();";
                                else if (readtype == "readInt()")
                                    strReadSent = "readObjList<int,int>();";
                                else if (readtype == "readLong()")
                                    strReadSent = "readObjList<LongC,LongC>();";
                                else if (readtype.Contains("readBean"))
                                {
                                    // 提取类型
                                    string strObjType = Regex.Match(readtype, "\\((?<value>.*?)\\)").Groups["value"].Value;
                                    if (!string.IsNullOrEmpty(strObjType))
                                    {
                                        strReadSent = string.Format("readObjList<{0},{0}>();", strObjType);
                                    }
                                }

                                strLineArr[pstart] = varName + " = " + strReadSent;
                                break;
                            } pstart++;
                        }

                        // 往下找 para2++并替换
                        // 往上找到para2,para2并替换为""
                        pstart = i + 1;
                        bok1 = false; bok2 = false;
                        bool bok3 = false;
                        while (pstart < strLineArr.Length && !(bok1 && bok2 && bok3))
                        {
                            if (strLineArr[pstart].Contains(para2))
                            {
                                strLineArr[pstart] = "";
                                bok1 = true;
                            }
                            if (strLineArr[pstart].Contains("}"))
                            {
                                strLineArr[pstart] = "";
                                bok2 = true;
                            }
                            if (strLineArr[pstart].Contains("{"))
                            {
                                strLineArr[pstart] = "";
                                bok3 = true;
                            }

                            pstart++;
                        }
                    }
                }
                // 整理 剔除空行
                List<string> linelist = strLineArr.ToList();
                int idel = linelist.RemoveAll(x => x.Trim().Length == 0);

                // 往下找 _loc2_++;并替换
                richTextBox2.Text = string.Join("\r\n", linelist);
            }
            catch (Exception ex)
            {
                ConsoleLog.Instance.writeInformationLog("ErrMsg="+ex.Message+";"+ex.StackTrace);
            }


        }
    }
}
