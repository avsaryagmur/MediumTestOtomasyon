namespace MediumTestOtomasyon
{
    public static class BaseConfig
    {
        public static string MediumTestUrl = "https://www.yemeksepeti.com/istanbul";

        public static class Credentials //Kullanıcıya ait her şeyi bir arada tutacaktır.
        {
            public static string InvalidUsername = "Otomasyon"; //geçersiz kullanıcı
            public static string InvalidPassword = "123456";

            public static string ValidUsername = "gecerlikullanici@gmail.com"; //geçerli kullanıcı bilgileri
            public static string ValidPassword = "gercerlisifre";

            public static string EmptyUsername = " "; //boş girilme durumu için
            public static string EmptyPassword = "";
        }
    }
}
