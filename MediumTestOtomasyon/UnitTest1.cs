using MediumTestOtomasyon.MediumProjectUIElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace MediumTestOtomasyon
{
    public class UnitTest1
    {
        public IWebDriver Driver { get; }
        public LoginPageUIElements LoginPageUI { get; }

        public UnitTest1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(BaseConfig.MediumTestUrl);
            driver.Manage().Window.Maximize();

            LoginPageUI = new LoginPageUIElements(driver);

        }

        [Fact]
        public void Test1()
        {

            LoginPageUI.Username.SendKeys("aaaa");
            LoginPageUI.Password.SendKeys("bbbb");
            LoginPageUI.ResetPassword.Click();
            /*

*/


            // driver.Quit();
        }
    }
}
