using MediumTestOtomasyon.MediumProjectUIElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace MediumTestOtomasyon
{
    public static class BaseActions
    {
        public static IWebDriver InitializedDriver()
        {
            ChromeOptions options = new ChromeOptions();
            //     options.AddUserProfilePreference("download.default_directory", BaseConfig.CarlistonOtomasyonDownloadDirectory);
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(BaseConfig.MediumTestUrl); // Config sınıfında tanımlı URL kullanıldı.
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); // 5sn bekleme konuldu.
            driver.Manage().Window.Maximize(); //Chrome kranı maxiumum boyuta getirildi.
            return driver;
        }


        public static void LoginWithTheUsernameAndPassword(IWebDriver driver, string username, string password)
        {
            LoginPageUIElements loginPage = new LoginPageUIElements(driver);

            loginPage.Username.SendKeys(username);
            loginPage.Password.SendKeys(password);
            loginPage.LoginBtn.Click();
            Thread.Sleep(5000); // 5sn bekleme konuldu.
        }
    }
}
