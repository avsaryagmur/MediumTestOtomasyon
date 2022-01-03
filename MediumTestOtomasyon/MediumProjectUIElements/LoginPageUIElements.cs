using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MediumTestOtomasyon.MediumProjectUIElements
{
    public class LoginPageUIElements //public class yapılmalıdır.
    {
        public LoginPageUIElements(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this); //InitElements, sayfa yüklenir yüklenmez sayfadaki tüm  öğelerini başlatır.

        }

        [FindsBy(How = How.Id, Using = "UserName")] //hangi konum belirleyici ile bulunacağı belirtilir.
        public IWebElement Username { get; set; } //username ismi ile senaryolardan çağrılabilecek.

        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "ys-fastlogin-button")]
        public IWebElement LoginBtn { get; set; }


        [FindsBy(How = How.LinkText, Using = "Yeni Üyelik!")]
        public IWebElement NewAccount { get; set; }


        [FindsBy(How = How.CssSelector, Using = "#ys-fastlogin-button")]
        public IWebElement LoginBtnWithCSSPath { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='ys-fastlogin-button']")]
        public IWebElement LoginBtnWithXPath { get; set; }


        [FindsBy(How = How.XPath, Using = "//a[@href ='/sifremi-unuttum']")]
        public IWebElement ResetPassword { get; set; }

        [FindsBy(How=How.CssSelector, Using = "#login-form > div.form-group.has-error > div > small")] //Lütfen şifrenizi giriniz uyarısı
        public IWebElement PleaseEnterPasswordInfo { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[9]")] //Hatalı kullanıcı uyarısı
        public IWebElement InvalidUserInfo { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = @"body > div.ReactModalPortal > div > div")] //Login sonrası popup
        public IWebElement AfterLoginPopup { get; set; }
    }
}
