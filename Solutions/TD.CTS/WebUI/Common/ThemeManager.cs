using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TD.CTS.WebUI.Common
{
    public static class ThemeManager
    {
        public static List<Theme> Themes { get; private set; }

        public static readonly Theme DefaultTheme;

        public static Theme GetTheme(string name)
        {
            return Themes.FirstOrDefault(t => t.Name == name) ?? DefaultTheme;
        }

        static ThemeManager()
        {
            Themes = new List<Theme>(){
                new Theme(){ Name = "default", Description = "Default" },
                new Theme(){ Name = "blueopal", Description = "Blue Opal" },
                new Theme(){ Name = "bootstrap", Description = "Bootstrap" },
                new Theme(){ Name = "silver", Description = "Silver" },
                new Theme(){ Name = "uniform", Description = "Uniform" },
                new Theme(){ Name = "metro", Description = "Metro" },
                new Theme(){ Name = "black", Description = "Black" },
                new Theme(){ Name = "metroblack", Description = "Metro Black" },
                new Theme(){ Name = "highcontrast", Description = "High Contrast" },
                new Theme(){ Name = "moonlight", Description = "Moonlight" },
                new Theme(){ Name = "flat", Description = "Flat" },
                new Theme(){ Name = "material", Description = "Material" },
                new Theme(){ Name = "materialblack", Description = "Material Black" }
            };

            DefaultTheme = GetTheme("material");
        }
    }
}