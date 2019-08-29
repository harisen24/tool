using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        static bool flag = false;
        System.Diagnostics.Process m_p;
            public Form1()
        {
            System.Diagnostics.Process p;
            System.Diagnostics.ProcessStartInfo info;
            info = new System.Diagnostics.ProcessStartInfo();

            string strCurDir = System.Environment.CurrentDirectory;

            info.FileName = strCurDir + @"\jre\bin\java.exe";
            info.Arguments = @" -Dsolr.log=P:\Solr\logs -Dsolr.data.dir=P:\Solr\logs -jar C:\QAtool\AnswerAssist\start.jar";
            info.WorkingDirectory = strCurDir + @"\AnswerAssist\";
            //info.CreateNoWindow = false;
            //info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //info.UseShellExecute = true;
            //info.RedirectStandardOutput= true;

            p = System.Diagnostics.Process.Start(info);

            InitializeComponent();
            m_p = p;


            //string output = p.StandardOutput.ReadToEnd(); // 標準出力の読み取り

            //output = output.Replace("\r\r\n", "\n"); // 改行コードの修正
            //System.Diagnostics.Debug.Write(output); // ［出力］ウィンドウに出力
            webBrowser1.Navigate("http://localhost:8983/AnswerAssist/");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (flag == false)
            {
                webBrowser1.Navigate("http://localhost:8983/AnswerAssist/");
                flag = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://localhost:8983/AnswerAssist/");
        }
        

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_p.Kill();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_p.CloseMainWindow())
            {
                return ;
            }
            else
                m_p.Kill();
        }
        

        private void 更新F5ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            webBrowser1.Navigate("http://localhost:8983/AnswerAssist/");
        }
        

        private void 更新F5ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://localhost:8983/AnswerAssist/");

        }

        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_p.CloseMainWindow())
            {
                return;
            }
            else
                m_p.Kill();

        }
    }

    
}
