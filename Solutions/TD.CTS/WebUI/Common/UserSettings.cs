using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TD.CTS.WebUI.Common
{
    public class UserSettings
    {
        public UserSettings()
        {
            SelectedTheme = ThemeManager.DefaultTheme;
        }

        public Theme SelectedTheme { get; set; }
    }
}