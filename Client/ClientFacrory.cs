using Client.Auth;
using Client.Models;
using Client.NonAuth;

namespace Client
{
    public class ClientFacrory
    {
        public SchedulerClient CreateSchedulerClient(UserCr user)
        {
            var client = new SchedulerClient();
            client.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;
            client.ClientCredentials.UserName.UserName = user.Nickname;
            client.ClientCredentials.UserName.Password = user.Password;
            return client;
        }

        public NoValidationServiceClient CreateNoValidationClient()
        {
            var noValidationClient = new NoValidationServiceClient();
            noValidationClient.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;
            return noValidationClient;
        }
    }
}