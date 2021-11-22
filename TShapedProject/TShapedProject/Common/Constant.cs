using TShapedProject.Utilities;

namespace TShapedProject.Common
{
    public class Constant
    {
        public class DemoQA
        {
            public static string APP_URL = "https://demoqa.com/books";
            public static string PROFILE_URL = "https://demoqa.com/profile";
            public static string USERNAME = "truongtn";
            public static string PASSWORD = "Demo@123";
            public static string GIT_POCKET_GUIDE = "Git Pocket Guide";
            public static string LEARN_JAVASCRIPT = "Learning JavaScript Design Patterns";
            public static string DESIGNING_EVOLVABLE = "Designing Evolvable Web APIs with ASP.NET";
        }

        public class AutomationPractice
        {
            public static string APP_URL = "http://automationpractice.com/index.php";
            public static string EMAIL = $"truong_{StringExtensions.RandomString(5)}@gmail.com";
            public static string PASSWORD = "demo@123";
            public static string FIRSTNAME = "Truong";
            public static string LASTNAME = "Tran";
            public static string ADDRESS = "Hanoi";
            public static string CITY = "Hanoi";
            public static string STATE = "North Carolina";
            public static string POST_CODE = "27006";
            public static string MOBILE_PHONE = "01234567890";
            public static string Alias = "My Address";
            public static string SUB_MENU_TSHIRTS = "T-shirts";
        }
    }
}
