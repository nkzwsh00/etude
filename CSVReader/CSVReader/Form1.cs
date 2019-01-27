using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace CSVReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //csvから情報を取得 --> call function
            //labelに表示
            this.label1.Text = ReadCsv();
        }

        //csv取得関数
        private static string ReadCsv()
        {
            string str = "";
            var filePath = @"C:\Users\Shuntaro\OneDrive\atec\演習\practice.csv";
            if (File.Exists(filePath))
            {
                //using (var reader = new StreamReader(filePath, Encoding.UTF8))
                //{
                //    while (!reader.EndOfStream)
                //    {
                //        var line = reader.ReadLine();
                //        Console.WriteLine(line);
                //        str = line;
                //    }
                //}

                //
                //var sr = new System.IO.StreamReader(filePath, Encoding.UTF8);
                //while(sr.Peek() != -1)
                //{
                //    string[] lines;
                //    lines = sr.ReadLine().Split(',');
                //    for (int i=0; i < 3; i++)
                //    {
                //        Console.Write(lines[i]);
                //    }
                //    Console.WriteLine("");
                //}
                TextFieldParser parser = new TextFieldParser(filePath, Encoding.GetEncoding("Shift_JIS"));
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");// ","区切り
                                          //parser.SetDelimiters("\t");                    
                                          // タブ区切り(TSVファイルの場合)

                while (parser.EndOfData == false)
                {
                    string[] column = parser.ReadFields();

                    for (int i = 0; i < column.Length; i++)
                    {
                        str += column[i] + "\r\n";
                    }
                    // ☆配列をコレクションへ
                    str += "===\r\n";
                }
            }
            Console.WriteLine("Display to label:" + str);
            return str;
        }
    }
}
