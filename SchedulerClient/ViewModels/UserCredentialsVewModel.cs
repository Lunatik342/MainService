using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using SchedulerClient.Models;

namespace SchedulerClient.ViewModels
{
    public class UserCredentialsVewModel
    {

        public UserCredentials UserCredentials { get; private set; }
        public UserCredentialsVewModel()
        {
            UserCredentials = new UserCredentials();
        }

        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??(_addCommand = new RelayCommand(obj =>
                  {
                      MessageBox.Show(UserCredentials.Nickname);
                      var passwordBox = obj as PasswordBox;
                      if (passwordBox != null)
                      {
                          UserCredentials.Password = passwordBox.SecurePassword;
                          //Auth.SchedulerClient client = new Auth.SchedulerClient();
                          //client.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;
                          //client.ClientCredentials.UserName.UserName = UserCredentials.Nickname;
                          //client.ClientCredentials.UserName.Password = passwordBox.Password;
                          try
                          {
                              //var res = client.GetUserInformation();
                          }
                          catch (FaultException)
                          {
                              MessageBox.Show("Karappa");
                          }

                      }
                  }));
            }
        }

    }
}