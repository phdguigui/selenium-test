using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest
{
    [TestClass]
    public class EnvironmentTests
    {

        public IWebDriver driver;

        private void OpenBrowser ()
        {
            driver = new ChromeDriver();
        }
        private void Click (string xPath)
        {
            driver.FindElement(By.XPath($@"{xPath}")).Click();
        }
        private void Type (string xPath, string text)
        {
            driver.FindElement(By.XPath(xPath)).SendKeys(text);
        }

        public void Login()
        {
            driver.Navigate().GoToUrl("https://twitter.com/");

            Thread.Sleep(1000);
            Click("/html/body/div/div/div/div[2]/main/div/div/div[1]/div/div/div[3]/div[5]/a");
            Thread.Sleep(2000);
            Type("/html/body/div/div/div/div[1]/div[2]/div/div/div/div/div/div[2]/div[2]/div/div/div[2]/div[2]/div/div/div/div[5]/label/div/div[2]/div/input", "iamthronus");
            Click("/html/body/div/div/div/div[1]/div[2]/div/div/div/div/div/div[2]/div[2]/div/div/div[2]/div[2]/div/div/div/div[6]");
            Thread.Sleep(2000);
            Type("/html/body/div/div/div/div[1]/div[2]/div/div/div/div/div/div[2]/div[2]/div/div/div[2]/div[2]/div[1]/div/div/div[3]/div/label/div/div[2]/div[1]/input", "Andréhumilde1@");
            Click("/html/body/div/div/div/div[1]/div[2]/div/div/div/div/div/div[2]/div[2]/div/div/div[2]/div[2]/div[2]/div/div[1]/div/div/div");

            Thread.Sleep(5000);
            var element = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/header/div/div/div/div[1]/div[1]/h1/a/div"));
            var location = element.Location;
        }

        [TestMethod]
        public void AOpenURL()
        {
            try
            {
                OpenBrowser();

                driver.Navigate().GoToUrl("https://twitter.com/");
                Thread.Sleep(1000);
                var element = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/main/div/div/div[1]/div/div/div[3]/div[5]/a"));
                var location = element.Location;

                Assert.IsNotNull(location);
                location.X.Should().NotBe(0);
                location.Y.Should().NotBe(0);
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void BLogin()
        {
            try
            {
                OpenBrowser();
                Login();

                Thread.Sleep(5000);
                var element = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/header/div/div/div/div[1]/div[1]/h1/a/div"));
                var location = element.Location;

                Assert.IsNotNull(location);
                location.X.Should().NotBe(0);
                location.Y.Should().NotBe(0);
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void COpenSidePages()
        {
            try
            {
                OpenBrowser();
                Login();

                Click("/html/body/div[1]/div/div/div[2]/header/div/div/div/div[1]/div[2]/nav/a[1]");
                Click("/html/body/div[1]/div/div/div[2]/header/div/div/div/div[1]/div[2]/nav/a[2]");
                Click("/html/body/div[1]/div/div/div[2]/header/div/div/div/div[1]/div[2]/nav/a[3]");
                Click("/html/body/div[1]/div/div/div[2]/header/div/div/div/div[1]/div[2]/nav/a[4]");
                Click("/html/body/div[1]/div/div/div[2]/header/div/div/div/div[1]/div[2]/nav/a[5]");
                Click("/html/body/div[1]/div/div/div[2]/header/div/div/div/div[1]/div[2]/nav/a[6]");
                Click("/html/body/div[1]/div/div/div[2]/header/div/div/div/div[1]/div[2]/nav/a[7]");
                Click("/html/body/div[1]/div/div/div[2]/header/div/div/div/div[1]/div[2]/nav/a[8]");
                Thread.Sleep(1000);
                Click("/html/body/div[1]/div/div/div[1]/div[2]/div/div/div/div/div/div[2]/div[2]/div/div[2]");
                Click("/html/body/div[1]/div/div/div[2]/header/div/div/div/div[1]/div[2]/nav/a[9]");

                Thread.Sleep(1000);
                var element = driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/main/div/div/div/div[1]/div/div[3]/div/div/div/a/div/div[2]/div/img"));
                var location = element.Location;

                Assert.IsNotNull(location);
                location.X.Should().NotBe(0);
                location.Y.Should().NotBe(0);
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void DTweet()
        {
            OpenBrowser();
            Login();

            Type("/html/body/div[1]/div/div/div[2]/main/div/div/div/div[1]/div/div[3]/div/div[2]/div[1]/div/div/div/div[2]/div[1]/div/div/div/div/div/div/div/div/div/div/label/div[1]/div/div/div/div/div/div[2]/div", "Automated test");
            Click("/html/body/div[1]/div/div/div[2]/main/div/div/div/div[1]/div/div[3]/div/div[2]/div[1]/div/div/div/div[2]/div[2]/div[2]/div/div/div/div[3]");
        }
    }
}