using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ToolDangBaiGroup
{
    class UnoElement
    {
        public static IWebElement FindElementById(ChromeDriver driver,  string id, int timeout = 15000)
        {
            IWebElement element = null;

            var s = new Stopwatch();
            s.Start();

            while (s.Elapsed < TimeSpan.FromMilliseconds(timeout))
            {
                Thread.Sleep(5);
                try
                {
                    element = driver.FindElementById(id);
                    return element;
                }
                catch (NoSuchElementException)
                {
                    continue;
                }
            }
            s.Stop();
            return element;
        }

        public static IWebElement FindElementByClassName(ChromeDriver driver, string classname, int timeout = 15000)
        {
            IWebElement element = null;
            var s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromMilliseconds(timeout))
            {
                Thread.Sleep(5);
                try
                {
                    element = driver.FindElementByClassName(classname);
                    return element;
                }
                catch (NoSuchElementException)
                {

                }
            }
            s.Stop();
            return element;
        }

        public static IWebElement FindElementByCssSelector(ChromeDriver driver, string css, int timeout = 15000)
        {
            IWebElement element = null;
            var s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromMilliseconds(timeout))
            {
                Thread.Sleep(5);
                try
                {
                    element = driver.FindElementByCssSelector(css);
                    return element;
                }
                catch (NoSuchElementException)
                {

                }
            }
            s.Stop();
            return element;
        }

        public static IWebElement FindElementByXPath(ChromeDriver driver, string xpath, int timeout = 15000)
        {
            IWebElement element = null;
            var s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromMilliseconds(timeout))
            {
                Thread.Sleep(5);
                try
                {
                    element = driver.FindElementByXPath(xpath);
                    return element;
                }
                catch (NoSuchElementException)
                {

                }
            }
            s.Stop();
            return element;
        }

        public static void Click(IWebElement element, int timeout = 15000)
        {
            var s = new Stopwatch();
            s.Start();
            while (true)
            {
                Thread.Sleep(5);
                try
                {
                    element.Click();
                    break;
                }
                catch
                {
                    
                }
                if(s.Elapsed >= TimeSpan.FromMilliseconds(timeout))
                {
                    throw new System.InvalidOperationException("Khong Click duoc");
                }
            }
            s.Stop();
        }
    }
}
