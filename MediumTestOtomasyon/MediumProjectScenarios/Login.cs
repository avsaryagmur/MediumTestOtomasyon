using System;
using System.Threading;
using MediumTestOtomasyon.MediumProjectUIElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace MediumTestOtomasyon.MediumProjectScenarios
{
    public class Login: IDisposable // Test classına IDisposable interface'i implement edilir.
    {
        public IWebDriver Driver { get; set; }
        public LoginPageUIElements LoginPageUI { get; }

        public Login()
        {
            try
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl(BaseConfig.MediumTestUrl); // Config dosyasından test edeceğimiz sayfa URL'ine gidilir.
                driver.Manage().Window.Maximize(); // Chrome sayfası full ekran yaptırıldı.

                LoginPageUI = new LoginPageUIElements(driver); // UI elementlerini kullanabilmek için tanımlama yapıldı.
            }
            catch (Exception e)
            {
                Console.WriteLine("Chrome Başlarken Hata alındı..." + e);

            }
        }


        [Fact]
        public void Login_ShouldReturnFail_WhenUserNull()
        {
            LoginPageUI.Username.SendKeys(BaseConfig.Credentials.EmptyUsername);
            LoginPageUI.Username.SendKeys(BaseConfig.Credentials.EmptyPassword);

            LoginPageUI.LoginBtn.Click();

            Assert.Equal("Lütfen şifrenizi giriniz.", LoginPageUI.PleaseEnterPasswordInfo.Text); // Assert ile metin karşılaştırması yapılır.
            Driver.Quit();
        }

        [Fact]
        public void Login_ShouldReturnFail_WhenUserInValid()
        {
            LoginPageUI.Username.SendKeys(BaseConfig.Credentials.InvalidUsername);
            LoginPageUI.Password.SendKeys(BaseConfig.Credentials.InvalidPassword);

            LoginPageUI.LoginBtn.Click();
            Thread.Sleep(10000);

            Assert.True(LoginPageUI.InvalidUserInfo.Displayed); // Assert ile popup açıldı mı kontrol edilir.


        }

        [Fact]
        public void Login_ShouldReturnSuccess_WhenUserValid()
        {
            LoginPageUI.Username.SendKeys(BaseConfig.Credentials.ValidUsername);
            LoginPageUI.Password.SendKeys(BaseConfig.Credentials.ValidPassword);

            LoginPageUI.LoginBtn.Click();
            Thread.Sleep(10000);

            Assert.True(LoginPageUI.AfterLoginPopup.Displayed); //Assert ile login sonrası banabi,mahalle vb seçim yaptığımız popup kontrol edilir.

        }


        public void Dispose() // Tüm test methodları çalıştıktan sonra en son bu class'a uğrar.
        {
            try
            {
              Driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Chrome Durduruluken Hata alındı..." + e);

            }
        }
    }
}
