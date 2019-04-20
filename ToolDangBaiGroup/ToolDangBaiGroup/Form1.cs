using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Runtime.InteropServices;
using Keys = OpenQA.Selenium.Keys;
using System.Diagnostics;

namespace ToolDangBaiGroup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            radioButton1.Checked = true;
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {
                if (textBox1.Text != "" && textBox3.Text != "")
                {
                    label2.Text = "Luồng 1: Đang chạy...";
                    button1.Enabled = false;
                    Thread th_MainTool1 = new Thread(MainTool1);
                    th_MainTool1.IsBackground = true;
                    th_MainTool1.Start();
                    await Task.Delay(1000);
                    label3.Text = "Luồng 2: Đang chạy...";
                    Thread th_MainTool2 = new Thread(MainTool2);
                    th_MainTool2.IsBackground = true;
                    th_MainTool2.Start();
                    await Task.Delay(1000);
                    label4.Text = "Luồng 3: Đang chạy...";
                    Thread th_MainTool3 = new Thread(MainTool3);
                    th_MainTool3.IsBackground = true;
                    th_MainTool3.Start();

                    while (true)
                    {
                        await Task.Delay(20);
                        if (th_MainTool1.IsAlive != true)
                        {
                            label2.Text = "Luồng 1: Đã xong";
                        }
                        if (th_MainTool2.IsAlive != true)
                        {
                            label3.Text = "Luồng 2: Đã xong";
                        }
                        if (th_MainTool3.IsAlive != true)
                        {
                            label4.Text = "Luồng 3: Đã xong";
                        }
                        if (th_MainTool1.IsAlive != true && th_MainTool2.IsAlive != true && th_MainTool3.IsAlive != true)
                        {
                            button1.Enabled = true;
                            break;
                        }
                    }
                }
                else
                {
                    textBox1.Enabled = true;
                    MessageBox.Show("Chưa nhập đủ thông tin");
                    return;
                }
            }
            else if (radioButton2.Checked == true)
            {
                if (textBox2.Text != "" && textBox3.Text != "")
                {
                    label2.Text = "Luồng 1: Đang chạy...";
                    button1.Enabled = false;
                    Thread th_MainTool1 = new Thread(MainTool1);
                    th_MainTool1.IsBackground = true;
                    th_MainTool1.Start();
                    await Task.Delay(1000);
                    label3.Text = "Luồng 2: Đang chạy...";
                    Thread th_MainTool2 = new Thread(MainTool2);
                    th_MainTool2.IsBackground = true;
                    th_MainTool2.Start();
                    await Task.Delay(1000);
                    label4.Text = "Luồng 3: Đang chạy...";
                    Thread th_MainTool3 = new Thread(MainTool3);
                    th_MainTool3.IsBackground = true;
                    th_MainTool3.Start();

                    while (true)
                    {
                        await Task.Delay(20);
                        if (th_MainTool1.IsAlive != true)
                        {
                            label2.Text = "Luồng 1: Đã xong";
                        }
                        if (th_MainTool2.IsAlive != true)
                        {
                            label3.Text = "Luồng 2: Đã xong";
                        }
                        if (th_MainTool3.IsAlive != true)
                        {
                            label4.Text = "Luồng 3: Đã xong";
                        }
                        if (th_MainTool1.IsAlive != true && th_MainTool2.IsAlive != true && th_MainTool3.IsAlive != true)
                        {
                            button1.Enabled = true;
                            break;
                        }
                    }

                }
                else
                {
                    textBox1.Enabled = true;
                    MessageBox.Show("Chưa nhập đủ thông tin");
                    return;
                }
            }
        }

        void MainTool1()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(Application.StartupPath);
            service.HideCommandPromptWindow = true;
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("headless");
            options.AddArguments("--window-size=1024,800");
            options.AddArguments("--disable-notifications");
            ChromeDriver driver = new ChromeDriver(service, options);
            var filecookie = File.ReadAllLines(@"Files/Cookie1.txt");
            var cookie = filecookie[0].Split('|');
            var dem = 0;
            if (radioButton1.Checked == true)
            {
                cookie = filecookie[0].Split('|');
                dem = 1;
            }
            if (radioButton2.Checked == true)
            {
                cookie = filecookie[1].Split('|');
                dem = 2;
            }
            if (radioButton3.Checked == true)
            {
                cookie = filecookie[2].Split('|');
                dem = 3;
            }
            if (radioButton4.Checked == true)
            {
                cookie = filecookie[3].Split('|');
                dem = 4;
            }
            if (radioButton5.Checked == true)
            {
                cookie = filecookie[4].Split('|');
                dem = 5;
            }
            if (radioButton6.Checked == true)
            {
                cookie = filecookie[5].Split('|');
                dem = 6;
            }
            new Actions(driver).SendKeys(Keys.Enter).Perform();
            Cookie cookie1 = new Cookie(cookie[0], cookie[1]);
            Cookie cookie2 = new Cookie(cookie[2], cookie[3]);
            driver.Url = "https://www.facebook.com";
            Thread.Sleep(1500);
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept(); //for two buttons, choose the affirmative one
                                //alert.Dismiss(); //to cancel the affirmative decision
            }
            catch
            {

            }
            new Actions(driver).SendKeys(Keys.Enter).Perform();
            driver.Manage().Cookies.AddCookie(cookie1);
            driver.Manage().Cookies.AddCookie(cookie2);
            var groups = File.ReadAllLines(@"Files/Group1.txt");
            for (int i = 0; i < 10; i++)
            {
                if (dem % 2 == 0)
                {
                    string check = DangBai(driver, groups[10+i]);
                    if (check == "die")
                    {
                        richTextBox1.AppendText("\r\n" + "HT1 - Cookie " + (i + 1) + " die");
                        richTextBox1.ScrollToCaret();
                        check = string.Empty;
                        continue;
                    }
                    if (check == "error")
                    {
                        continue;
                    }
                }
                else
                {
                    string check = DangBai(driver, groups[i]);
                    if (check == "die")
                    {
                        richTextBox1.AppendText("\r\n" + "HT1 - Cookie " + (i + 1) + " die");
                        richTextBox1.ScrollToCaret();
                        check = string.Empty;
                        continue;
                    }
                    if (check == "error")
                    {
                        continue;
                    }
                }
            }
            driver.Close();
            driver.Quit();
        }

        void MainTool2()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(Application.StartupPath);
            service.HideCommandPromptWindow = true;
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("headless");
            options.AddArguments("--window-size=1024,800");
            options.AddArguments("--disable-notifications");
            ChromeDriver driver = new ChromeDriver(service, options);
            var filecookie = File.ReadAllLines(@"Files/Cookie2.txt");
            var cookie = filecookie[0].Split('|');
            var dem = 0;
            if (radioButton1.Checked == true)
            {
                cookie = filecookie[0].Split('|');
                dem = 1;
            }
            if (radioButton2.Checked == true)
            {
                cookie = filecookie[1].Split('|');
                dem = 2;
            }
            if (radioButton3.Checked == true)
            {
                cookie = filecookie[2].Split('|');
                dem = 3;
            }
            if (radioButton4.Checked == true)
            {
                cookie = filecookie[3].Split('|');
                dem = 4;
            }
            if (radioButton5.Checked == true)
            {
                cookie = filecookie[4].Split('|');
                dem = 5;
            }
            if (radioButton6.Checked == true)
            {
                cookie = filecookie[5].Split('|');
                dem = 6;
            }
            new Actions(driver).SendKeys(Keys.Enter).Perform();
            Cookie cookie1 = new Cookie(cookie[0], cookie[1]);
            Cookie cookie2 = new Cookie(cookie[2], cookie[3]);
            driver.Url = "https://www.facebook.com";
            Thread.Sleep(2000);
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept(); //for two buttons, choose the affirmative one
                                //alert.Dismiss(); //to cancel the affirmative decision
            }
            catch
            {

            }
            new Actions(driver).SendKeys(Keys.Enter).Perform();
            driver.Manage().Cookies.AddCookie(cookie1);
            driver.Manage().Cookies.AddCookie(cookie2);
            var groups = File.ReadAllLines(@"Files/Group2.txt");
            for (int i = 0; i < 10; i++)
            {
                if (dem % 2 == 0)
                {
                    string check = DangBai(driver, groups[10 + i]);
                    if (check == "die")
                    {
                        richTextBox1.AppendText("\r\n" + "HT1 - Cookie " + (i + 1) + " die");
                        richTextBox1.ScrollToCaret();
                        check = string.Empty;
                        continue;
                    }
                    if (check == "error")
                    {
                        continue;
                    }
                }
                else
                {
                    string check = DangBai(driver, groups[i]);
                    if (check == "die")
                    {
                        richTextBox1.AppendText("\r\n" + "HT1 - Cookie " + (i + 1) + " die");
                        richTextBox1.ScrollToCaret();
                        check = string.Empty;
                        continue;
                    }
                    if (check == "error")
                    {
                        continue;
                    }
                }
            }
            driver.Close();
            driver.Quit();
        }

        void MainTool3()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(Application.StartupPath);
            service.HideCommandPromptWindow = true;
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("headless");
            options.AddArguments("--window-size=1024,800");
            options.AddArguments("--disable-notifications");
            ChromeDriver driver = new ChromeDriver(service, options);
            var filecookie = File.ReadAllLines(@"Files/Cookie3.txt");
            var cookie = filecookie[0].Split('|');
            var dem = 0;
            if (radioButton1.Checked == true)
            {
                cookie = filecookie[0].Split('|');
                dem = 1;
            }
            if (radioButton2.Checked == true)
            {
                cookie = filecookie[1].Split('|');
                dem = 2;
            }
            if (radioButton3.Checked == true)
            {
                cookie = filecookie[2].Split('|');
                dem = 3;
            }
            if (radioButton4.Checked == true)
            {
                cookie = filecookie[3].Split('|');
                dem = 4;
            }
            if (radioButton5.Checked == true)
            {
                cookie = filecookie[4].Split('|');
                dem = 5;
            }
            if (radioButton6.Checked == true)
            {
                cookie = filecookie[5].Split('|');
                dem = 6;
            }
            new Actions(driver).SendKeys(Keys.Enter).Perform();
            Cookie cookie1 = new Cookie(cookie[0], cookie[1]);
            Cookie cookie2 = new Cookie(cookie[2], cookie[3]);
            driver.Url = "https://www.facebook.com";
            Thread.Sleep(1500);
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept(); //for two buttons, choose the affirmative one
                                //alert.Dismiss(); //to cancel the affirmative decision
            }
            catch
            {

            }
            new Actions(driver).SendKeys(Keys.Enter).Perform();
            driver.Manage().Cookies.AddCookie(cookie1);
            driver.Manage().Cookies.AddCookie(cookie2);
            var groups = File.ReadAllLines(@"Files/Group3.txt");
            for (int i = 0; i < 10; i++)
            {
                if (dem % 2 == 0)
                {
                    string check = DangBai(driver, groups[10 + i]);
                    if (check == "die")
                    {
                        richTextBox1.AppendText("\r\n" + "HT1 - Cookie " + (i + 1) + " die");
                        richTextBox1.ScrollToCaret();
                        check = string.Empty;
                        continue;
                    }
                    if (check == "error")
                    {
                        continue;
                    }
                }
                else
                {
                    string check = DangBai(driver, groups[i]);
                    if (check == "die")
                    {
                        richTextBox1.AppendText("\r\n" + "HT1 - Cookie " + (i + 1) + " die");
                        richTextBox1.ScrollToCaret();
                        check = string.Empty;
                        continue;
                    }
                    if (check == "error")
                    {
                        continue;
                    }
                }
            }
            driver.Close();
            driver.Quit();
        }


        string DangBai(ChromeDriver driver, string groups)
        {
            // string filename1 = @"C:\Users\BMJ_AD\Desktop\listener.txt";
            //FileStream traceLog = new FileStream(filename1, FileMode.OpenOrCreate);
            //TextWriterTraceListener listener = new TextWriterTraceListener(traceLog);
            string sttcookie = string.Empty;
            try
            {
                string link = string.Empty;
                if (radioButton1.Checked == true)
                {
                    link = textBox1.Text;
                }
                if (radioButton2.Checked == true)
                {
                    link = textBox2.Text;
                }
                if (radioButton3.Checked == true)
                {
                    link = textBox3.Text;
                }
                if (radioButton4.Checked == true)
                {
                    link = textBox4.Text;
                }
                if (radioButton5.Checked == true)
                {
                    link = textBox5.Text;
                }
                if (radioButton6.Checked == true)
                {
                    link = textBox6.Text;
                }
                driver.Url = groups;
                try
                {
                    var Checkcookie = driver.FindElementByXPath("//*[@data-testid='royal_login_button']");
                    return sttcookie = "die";
                }
                catch
                {

                }
                Thread.Sleep(3000);
                var curl = driver.Url;
                if (curl == "https://www.facebook.com/checkpoint/block/" || curl == "https://www.facebook.com/checkpoint/block")
                {
                    return sttcookie = "error";
                }
                try
                {

                    UnoElement.FindElementByXPath(driver, "//div[@class='_4ik4 _4ik5']", 25000).Click();
                    UnoElement.FindElementByXPath(driver, "//div[@class='_6rt4  _2ien' and text()='Page']").Click();
                }
                catch
                {
                    return sttcookie = "error";
                }


                Thread.Sleep(1500);
                driver.ExecuteScript("window.scrollBy(0,100)");
                Thread.Sleep(1500);

                var inputmes = UnoElement.FindElementByXPath(driver, "//*[@name='xhpc_message_text']");
                UnoElement.Click(inputmes);
                Thread.Sleep(1500);
                while (true)
                {
                    try
                    {

                        var emoi = UnoElement.FindElementByClassName(driver, "_3nc_");
                        UnoElement.Click(emoi);
                        var icon = UnoElement.FindElementByClassName(driver, "_5zfs");
                        UnoElement.Click(icon);
                        UnoElement.Click(icon);
                        UnoElement.Click(icon);
                        UnoElement.Click(icon);
                        UnoElement.Click(icon);
                        //listener.WriteLine("Bao vp before");
                        //listener.Flush();
                        UnoElement.FindElementByXPath(driver, "//span[@class='_5qtp' and text()='Write Post']", 5000).Click();

                        break;
                    }
                    catch
                    {
                        UnoElement.FindElementByXPath(driver, "//span[@class='_5qtp' and text()='Write post']", 5000).Click();
                        break;
                    }
                }
                //listener.WriteLine("Bao vp before 11111");
                UnoElement.FindElementByXPath(driver, "//*[@data-testid='react-composer-post-button']", 35000).Click();
                //listener.WriteLine("Bao vp after 11111");
                //listener.Flush();      
                try
                {
                                                                       
                    UnoElement.FindElementByXPath(driver, "//*[@action='cancel' and text()='Close']", 5000).Click();
                    Thread.Sleep(500);
                    return sttcookie = "error";
                }
                catch
                {

                }
                Thread.Sleep(5000);
                try
                {
                    var justnow = UnoElement.FindElementByXPath(driver, "//span[@class='timestampContent' and text()='Just now']", 25000);
                    UnoElement.Click(justnow, 15000);
                }
                catch
                {
                    return sttcookie = "error";
                }
                Thread.Sleep(2500);

                while (true)
                {
                    try
                    {
                        var buttonmenu = UnoElement.FindElementByXPath(driver, "//*[@data-testid='post_chevron_button']", 10000);
                        UnoElement.Click(buttonmenu, 15000);
                        UnoElement.FindElementByXPath(driver, "//div[@class='_41t5' and text()='Edit post']", 5000).Click();
                        break;
                    }
                    catch
                    {
                        return sttcookie = "error";
                    }
                }
                try
                {
                    var check3 = UnoElement.FindElementByXPath(driver, "//*[@action='cancel']");
                    check3.Click();
                    Thread.Sleep(500);
                }
                catch { }
                //var inputmes3 = UnoElement.FindElementByXPath(driver, "//*[@data-testid='status-attachment-mentions-input']", 20000);
                //var inputmes3 = UnoElement.FindElementByXPath(driver, "//*[@id='js_8s']/div[1]/div/div[1]/div/div[2]/div/div/div/div/div/div/div/div/div/div/div/span[5]");
                new Actions(driver).SendKeys(Keys.ArrowRight).SendKeys(Keys.ArrowRight).SendKeys(Keys.ArrowRight).SendKeys(Keys.ArrowRight).SendKeys(Keys.ArrowRight).Perform();
                new Actions(driver).SendKeys(Keys.Backspace).SendKeys(Keys.Backspace).SendKeys(Keys.Backspace).SendKeys(Keys.Backspace).SendKeys(Keys.Backspace).Perform();
                new Actions(driver).SendKeys(link).Perform();
                Thread.Sleep(1000);
                new Actions(driver).SendKeys(Keys.Enter).SendKeys(" " + textBox3.Text + " ").Perform();
                Thread.Sleep(1000);
                for (int m = 0; m < (textBox3.Text.Length + 3 + link.Length); m++)
                {
                    new Actions(driver).SendKeys(Keys.Backspace).Perform();
                }
                //inputmes3.SendKeys(Keys.Enter);
                //inputmes3.SendKeys(link);
                var btn = UnoElement.FindElementByXPath(driver, "//*[@data-testid='react-composer-post-button']", 15000);
                UnoElement.Click(btn, 15000);
                try
                {
                    var check2 = UnoElement.FindElementByXPath(driver, "//*[@action='cancel']");
                    check2.Click();
                    Thread.Sleep(1500);
                    driver.ExecuteScript("window.scrollBy(300,0)");
                    Thread.Sleep(1500);
                    var xx = UnoElement.FindElementByClassName(driver, "_51-u");
                    xx.Click();
                    var cf = UnoElement.FindElementByXPath(driver, "//*[@action='confirm']");
                    cf.Click();
                    return sttcookie = "error";
                }
                catch { }

                while (true)
                {
                    var check = UnoElement.FindElementByXPath(driver, "//*[@data-testid='react-composer-post-button']", 1000);
                    if (check == null)
                    {
                        Thread.Sleep(500);
                        GC.Collect();
                        return sttcookie = string.Empty;
                    }

                }
            }
            catch
            {
                return sttcookie = "error";
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var process2 in Process.GetProcessesByName("chromedriver"))
            {
                process2.Kill();
            }
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

}
