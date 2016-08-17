using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace WindowsFormsApplication1
{
    public partial class browser : Form
    {
        public browser()
        {
            InitializeComponent();
            this.webBrowser1.ProgressChanged+=new WebBrowserProgressChangedEventHandler(webBrowser1_ProgressChanged);
        }

        private void button5_Click(object sender, EventArgs e) // Кнопка Искать
        {
            webBrowser1.Navigate(comboBox1.Text);
            comboBox1.Items.Add(comboBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e) // Кнопка Назад
        {
            webBrowser1.GoBack();
        }

        private void button2_Click(object sender, EventArgs e) // Кнопка Вперед
        {
            webBrowser1.GoForward();
        } 

        private void button3_Click(object sender, EventArgs e) // Кнопка Обновить 
        {
            webBrowser1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e) // Кнопка Остановить 
        {
            webBrowser1.Stop();
        }

        private void button6_Click(object sender, EventArgs e) // Кнопка Домой
        {
            webBrowser1.GoHome();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            Form1 main = this.Owner as Form1;
            main.tabControl1.SelectedTab.Text = webBrowser1.DocumentTitle;
            WebRequest web_request = (HttpWebRequest)System.Net.WebRequest.Create("http://" + webBrowser1.Document.Url.Host.ToString() + "/favicon.ico");
            System.Net.HttpWebResponse web_response = (HttpWebResponse)web_request.GetResponse();
            System.IO.Stream web_stream = web_response.GetResponseStream();
            Image image = Image.FromStream(web_stream);
            main.imageList1.Images.Add(image);
            main.tabControl1.SelectedTab.ImageIndex = main.imageList1.Images.Count - 1;

        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e) // Прогресс бар
        {
            if (e.CurrentProgress >= 0 && e.CurrentProgress <= 100)
            {
                toolStripProgressBar1.Value = (int)e.CurrentProgress;
            }

            toolStripStatusLabel1.Text = webBrowser1.StatusText;
            
        }

        private void button11_Click(object sender, EventArgs e) // Кнопка избранное 
        {
            panel1.Visible = true;
            button11.Visible = false;
            textBox2.Text = comboBox1.Text;
            listBox1.Items.Clear();
            using (StreamReader reader = new StreamReader("C:\\browser.ini"))
            {
                string z = reader.ReadLine();
                for (int j = 0; j < Convert.ToDouble(z); j++)
                    listBox1.Items.Add(reader.ReadLine());

            }
        }

        private void button10_Click(object sender, EventArgs e) // Кнопка закрыть панель
        {
            panel1.Visible = false;
            button11.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e) // Кнопка добавить избранную закладку
        {
            listBox1.Items.Add(textBox1.Text + "|" + textBox2.Text);
            using (StreamWriter sw = new StreamWriter("C:\\browser.ini"))
            {
                sw.WriteLine(listBox1.Items.Count.ToString());
                for (int j = 0; j < listBox1.Items.Count; j++)
                    sw.WriteLine(listBox1.Items[j]);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e) // Настройка панели избранных
        {
        string str = listBox1.SelectedItem.ToString();
        string newstr = "";
        int flag = 0; //flag определяет разделитель |
        char c;
        int k = str.Length;
        //Выделяем из строки адрес сайта
        for (int j = 0; j < k; j++)
            {
                c = str[j]; 
                if (flag != 0) newstr += c;
                if (c == '|') flag = 1;
            }
        //Подставляем в адресную строку адрес сайта
        comboBox1.Text = newstr;
        }

        private void button9_Click(object sender, EventArgs e) // Кнопка удалить избранное
        {
            // Проверяем, есть ли в списке выделенная строка
            if (listBox1.SelectedIndex == -1)
                // Если нет, то выводим сообщение.
                MessageBox.Show("Нет выделенной строки");
            else
                // Иначе .. Удаляем выделенную строку
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            //Сохраняем новый список в файле
            using (StreamWriter sw = new StreamWriter("C:\\browser.ini"))
            {
                sw.WriteLine(listBox1.Items.Count.ToString());
                for (int j = 0; j < listBox1.Items.Count; j++)
                    sw.WriteLine(listBox1.Items[j]);
            }
        }

        private void чтоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void здесьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void писатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void домойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("google.com");
        }

        private void yadnexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("Yandex.ru");
        }

        private void youtubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("youtube.com");
        }

        private void vkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("vk.com");
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about mains  = new about();
            mains.Show();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about mains = new about();
            mains.Show();
        }

       
        
    }
}
