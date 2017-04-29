using System;
using System.Collections.Generic;
using System.IdentityModel.Metadata;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestClient.NoValidationService;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {


            NoValidationServiceClient n = new NoValidationServiceClient();
            n.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;
            var myUnivercity = n.GetUnivercities("Туполева").First();
            var cities = n.GetCities();
            var myCity = cities.First(city => city.Name.Contains("Казань"));
            if (myCity != null && myUnivercity != null)
            {
                var res =
                    n.Register(new UserCrDto()
                    {
                        Nickname = "Asd",
                        Password = "Asd1",
                        Description = "Asd",
                        Email = "Asd@mail.com",
                        Group = "Asd",
                        Name = "AsdAsd",
                        Surname = "Aasdsa"
                    }
                    );
                if (res.ActionResult == ActionResult.IncorrectParameter)
                {
                    foreach (var error in res.Errors)
                    {
                        Console.WriteLine(error.Variable + " " + error.CheckStatus);
                    }
                }
                else
                {
                    Console.WriteLine(res.CreatedObject.Id);
                }
                Console.ReadLine();
            }




            //var client = new SchedulerClient.SchedulerClient();
            //client.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;
            //client.ClientCredentials.UserName.UserName = "asdasd";
            //client.ClientCredentials.UserName.Password = "Asd1";
            //var res =
            //    client.EditUser(new UserCrDto()
            //    {
            //        Nickname = "asdasd",
            //        Password = "Asd1",
            //        CityId = myCity.Id,
            //        UniversityId = myUnivercity.Id,
            //        Name = "ahwaw",
            //        Phone = "8950945371",
            //        Email = "lunatik2000@inbox.ru",
            //        Surname = "Бакиев",
            //        Group = "4402",
            //        Description = "Умный и скромный парень"
            //    });
            //if (res.ActionResult == (AuthService.ActionResult) ActionResult.IncorrectParameter)
            //{
            //    foreach (var error in res.Errors)
            //    {
            //        Console.WriteLine(error.Variable + " " + error.CheckStatus);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(res.CreatedObject.Id);
            //}
            //Console.ReadLine();

            //var channelRole =
            //    client.EditEvent(new EventDto
            //    {
            //        EventId = 3,
            //        ChannelId = 2,
            //        Descrition = "111111111111",
            //        EventTime = new DateTime(2017, 6, 5),
            //        ImportanceId = 1,
            //        Title = "Karappa"
            //    });
            //Console.WriteLine(channelRole.ActionResult);
            //Console.ReadLine();
            ////var r = client.GetEvents(2, 1, DateTime.Now, 1);
            ////foreach (var eventDto in r)
            ////{
            ////    Console.WriteLine(eventDto.ImportanceId);
            ////}
            ////Console.ReadLine();
        }
    }
}
