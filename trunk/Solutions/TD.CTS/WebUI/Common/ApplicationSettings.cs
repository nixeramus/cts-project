using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TD.Common.Web.Mvc;
using TD.CTS.Auth;
using TD.CTS.Data;
using TD.CTS.Data.Entities;

namespace TD.CTS.WebUI.Common
{
    public class ApplicationSettings
    {
        private static SessionRepository<Authenticator> authRepository = new SessionRepository<Authenticator>();
        public static Authenticator Authenticator
        {
            get
            {
                if (authRepository.HasValue)
                    return authRepository.Value;

                return null;
            }
            set
            {
                authRepository.Value = value;
            }
        }

        private static SessionRepository<UserSettings> userSettingsRepository = new SessionRepository<UserSettings>();
        public static UserSettings UserSettings
        {
            get
            {
                if (!userSettingsRepository.HasValue)
                {
                    userSettingsRepository.Value = new UserSettings();
                }

                return userSettingsRepository.Value; 
            }
        }

        public static void Clear()
        {
            authRepository.Clear();
            userSettingsRepository.Clear();
        }

        //private static SessionRepository<IDataProvider> dataProviderRepository = new SessionRepository<IDataProvider>();
        //public static IDataProvider DataProvider 
        //{ 
        //    get 
        //    {
        //        if (!dataProviderRepository.HasValue)
        //        {
        //            User currentUser = CurrentUser;
        //            string connectionString = ConfigurationManager.ConnectionStrings["CTS"].ConnectionString
        //                + "UID=" + currentUser.Login + ";PWD=" + currentUser.Password;
                    
        //            dataProviderRepository.Value = new TD.CTS.MsSqlData.DataProvider(connectionString);
        //        }

        //        return dataProviderRepository.Value;  
        //    } 
        //}

        //private static SessionRepository<User> currentUserRepository = new SessionRepository<User>();
        //public static User CurrentUser
        //{
        //    get
        //    {
        //        if (!currentUserRepository.HasValue)
        //        {
        //            currentUserRepository.Value = new User() { FullName = "Иванов И.И.", Login = "cts", Password="Cts_L0g1n" };//DataProvider.GetItem<User>();
        //        }

        //        return currentUserRepository.Value;
        //    }
        //}

        //private static SessionRepository<string> selectedThemeRepository = new SessionRepository<string>();

        //public static string SelectedTheme
        //{
        //    get
        //    {
        //        if (!selectedThemeRepository.HasValue)
        //        {
        //            selectedThemeRepository.Value = Theme.DefaultTheme.Name;
        //        }

        //        return selectedThemeRepository.Value;
        //    }

        //    set
        //    {
        //        selectedThemeRepository.Value = Theme.GetTheme(value).Name;
        //    }
        //}
      
    }
}