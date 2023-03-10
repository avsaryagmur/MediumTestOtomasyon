using System;
using MediumTestOtomasyon.MediumProjectUIElements;
using OpenQA.Selenium;
using System.Threading;
using Xunit;

namespace MediumTestOtomasyon.MediumProjectScenarios
{
    public class Login : IDisposable // Test classına IDisposable interface'i implement edilir.
    {
        public IWebDriver Driver { get; set; }
        public LoginPageUIElements LoginPageUI { get; }
        public Login()
        {
            try
            {
                Driver = BaseActions.InitializedDriver(); // bu methot ile testler başlarken ilk çalıştırılır. Driver ve chrome ayağa kalkar.
                LoginPageUI = new LoginPageUIElements(Driver); // UI elementlerini kullanabilmek için tanımlama yapıldı.
            }
            catch (Exception e)
            {
                Console.WriteLine("Chrome Başlarken Hata alındı..." + e);
            }
        }
        [Fact]
        public void Login_ShouldReturnFail_WhenUserNull()
        {
            BaseActions.LoginWithTheUsernameAndPassword(Driver, BaseConfig.Credentials.EmptyUsername, BaseConfig.Credentials.EmptyPassword);
            Assert.Equal("Lütfen şifrenizi giriniz.", LoginPageUI.PleaseEnterPasswordInfo.Text); // Assert ile metin karşılaştırması yapılır.

            BaseActions.TakeScreenshot("Login_ShouldReturnFail_WhenUserNull", Driver);
        }
        [Fact]
        public void Login_ShouldReturnFail_WhenUserInValid()
        {
            BaseActions.LoginWithTheUsernameAndPassword(Driver, BaseConfig.Credentials.InvalidUsername, BaseConfig.Credentials.InvalidPassword);
            Thread.Sleep(10000);
            Assert.True(LoginPageUI.InvalidUserInfo.Displayed); // Assert ile popup açıldı mı kontrol edilir.
            BaseActions.TakeScreenshot("Login_ShouldReturnFail_WhenUserInValid", Driver);
        }
        [Fact]
        public void Login_ShouldReturnSuccess_WhenUserValid()
        {
            BaseActions.LoginWithTheUsernameAndPassword(Driver, BaseConfig.Credentials.ValidUsername, BaseConfig.Credentials.ValidPassword);
            Thread.Sleep(10000);
            Assert.True(LoginPageUI.AfterLoginPopup.Displayed); //Assert ile login sonrası banabi,mahalle vb seçim yaptığımız popup kontrol edilir.
            BaseActions.TakeScreenshot("Login_ShouldReturnSuccess_WhenUserValid", Driver);
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
