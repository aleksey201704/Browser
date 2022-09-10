using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser
{
    public partial class Form1 : Form
    {
       // public int[] countLabel { get; set; }
        public int widhtcount { get; set; } = 0;
        public Dictionary<string,string> factorymain { get; set; } = new Dictionary<string, string>(); 
        
        
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Первоначальные настройки
            Uri uri = new Uri("https://www.microsoft.com");
            webView21.Source = uri;
            comboBox1.SelectedIndex = 0;


        }



        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (e.KeyChar == 13 && comboBox1.SelectedIndex == 0 && textBox1.Text.Substring(0, 7) != "http://")
            {
                Uri urigoogle = new Uri($"https://www.google.com/search?q={textBox1.Text}");
                webView21.Source = urigoogle;
            }
            if (textBox1.Text.Length > 7 && e.KeyChar == 13)
            {
                if (textBox1.Text.Substring(0, 7) == "http://")
                {

                    Uri urinew = new Uri(textBox1.Text);
                    webView21.Source = urinew;
                }
            }

            if (e.KeyChar == 13 && comboBox1.SelectedIndex == 1)
            {
                Uri uriya = new Uri($"https://yandex.ru/search/?text={textBox1.Text}");
                webView21.Source = uriya;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Uri uri = new Uri("https://www.microsoft.com");
            webView21.Source = uri;
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (RightPanel.Visible) { RightPanel.Visible = false; return; }
            RightPanel.Visible = true;
            

            //MessageBox.Show(webView21.CoreWebView2.navi ToString());

        }

        
        private void btnFavorites_Click(object sender, EventArgs e)
        {

            PanelFavority.Visible = true;
            Label countLabel = new Label();
            countLabel.Name = $"countLabel{widhtcount}";// widhtcount.ToString();
            factorymain.Add(countLabel.Name, webView21.Source.ToString());
            widhtcount++;
            countLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            countLabel.Dock = System.Windows.Forms.DockStyle.Left;
            countLabel.Height = 32;
            countLabel.Width = 150;
            countLabel.BackColor = Color.WhiteSmoke;

            countLabel.Text = webView21.CoreWebView2.DocumentTitle;
            //countLabel.MouseMove +=this.CountLabel_MouseMove;
            countLabel.MouseMove += CountLabel_MouseMove;
            countLabel.MouseClick += CountLabel_MouseClick;
            countLabel.MouseLeave += CountLabel_MouseLeave;
            this.PanelFavority.Controls.Add(countLabel);
            

        }

        private void CountLabel_MouseMove(object sender, MouseEventArgs e)
        {
            Label countLabel = new Label();
            countLabel=sender as Label;
            countLabel.BackColor = Color.Silver;
            //countLabel.MouseLeave += CountLabel_MouseLeave;
           
            
        }

        private void CountLabel_MouseClick(object sender, MouseEventArgs e)
        {
            Label countLabel = new Label();
            countLabel = sender as Label;
            //MessageBox.Show(countLabel.Name);

            foreach (var item in factorymain)
            {
                if (countLabel.Name == item.Key)
                {
                    Uri uri = new Uri(item.Value);
                    webView21.Source = uri;
                }
            }
        }

        private void CountLabel_MouseLeave(object sender, EventArgs e)
        {
            Label countLabel = new Label();
            countLabel = sender as Label;
            countLabel.BackColor = Color.WhiteSmoke;
        }

        private void webView21_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {

            lstboxHistory.Items.Add(webView21.Source.ToString());

        }

        private void btnAddTab_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add("Новая вкладка");
            WebView2 webview22 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.tabControl1.TabPages[1].Controls.Add(webview22);
            webview22.Dock = DockStyle.Fill;
            Uri uri = new Uri("https://www.mail.ru");
            webview22.Source = uri;
        }

      
    }
}