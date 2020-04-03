using System.Collections.Generic;
using System.Web.Mvc;

namespace FightCorona.Business.Services
{
    public class LanguageService
    {
        public static List<SelectListItem> GetLanguageOptions()
        {
            return new List<SelectListItem>
            {
                 new SelectListItem
                {
                    Text = "English",
                    Value = ""

                },
                new SelectListItem
                {
                    Text = "বাংলা",
                    Value = "bn"
                },
                new SelectListItem
                {
                    Text = "हिंदी",
                    Value = "hi"
                },
                 new SelectListItem
                {
                    Text = "ಕನ್ನಡ",
                    Value = "kn"
                },
               new SelectListItem
                {
                    Text = "മലയാളം",
                    Value = "ml"
                },
                new SelectListItem
                {
                    Text = "தமிழ்",
                    Value = "ta"
                },
               new SelectListItem
                {
                    Text = "తెలుగు",
                    Value = "te"
                }
            };
        }
    }
}
