using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.CTS.Data;
using TD.CTS.Data.Entities;
using TD.CTS.Data.Filters;
using TD.CTS.MsSqlData;

namespace TD.CTS.Auth
{
    public class Authenticator
    {
        public User User { get; private set; }

        private MsSqlDataProvider dataProvider;
        public IDataProvider DataProvider { get { return dataProvider; } }

        public bool NeedChangePassword { get { return User.NeedChangePassword; } }

        private static string CreateConnectionString(string username, string password)
        {
            return ConfigurationManager.ConnectionStrings["CTS"].ConnectionString
                        + "UID=" + username + ";PWD=" + password;
        }

        public bool Authenticate(Credentials credentials)
        {
            string connectionString = CreateConnectionString(credentials.Username, credentials.Password);

            var provider = new MsSqlDataProvider(connectionString);

            if (provider.TestConnection())
            {
                dataProvider = provider;
                User = provider.GetItem(new UserDataFilter { Login = credentials.Username });
                return true;
            }

            return false;
        }

        public bool ChangePassword(ChangePassword data)
        {
            if (dataProvider.ChangePassword(data.OldPassword, data.NewPassword))
            {
                dataProvider = new MsSqlDataProvider(CreateConnectionString(User.Login, data.NewPassword));
                return true;
            }
            return false;
        }
    }
}
