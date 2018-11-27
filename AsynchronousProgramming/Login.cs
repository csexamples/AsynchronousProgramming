using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousProgramming
{
    public class Login
    {
        public string LoginMessage { get; set; }

        public string Content { get; set; }

        public async void StartLogin()
        {
            try
            {
                var loginResult = await LoginAsync();
                var content = await FetchContent();

                LoginMessage = loginResult;
                Content = content;
            }
            catch (Exception)
            {
                LoginMessage = "Internal Error";
            }

            Console.WriteLine(LoginMessage);

            Console.WriteLine(Content);
        }

        public async Task<string> FetchContent()
        {
            using (var client = new HttpClient())
            {
                var httpMessage = await client.GetAsync("http://www.filipekberg.se/rss/");

                var content = await httpMessage.Content.ReadAsStringAsync();

                return content;
            }
        }

        public async Task<string> LoginAsync()
        {
            try
            {
                var loginTask = Task.Run(() =>
                {
                    Thread.Sleep(2000);

                    return "Login Successful";
                });

                var logTask = Task.Delay(2000);

                var purchaseTask = Task.Delay(1000);

                await Task.WhenAll(loginTask, logTask, purchaseTask);

                return loginTask.Result;
            }
            catch (Exception)
            {
                return "Login Failed";
            }
        }
    }
}
