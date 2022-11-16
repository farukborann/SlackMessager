using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using static SlackMessager.Models.Slack;

namespace SlackMessager
{
    class Slack
    {
        private readonly HttpClient client;
        private string token;
        
        public Slack(string token)
        {
            client = new HttpClient();
            this.token = token;
        }

        public async Task SendMessageAsync(SlackMessage msg)
        {
            var content = JsonConvert.SerializeObject(msg);
            var httpContent = new StringContent(
                content,
                Encoding.UTF8,
                "application/json"
            );

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.PostAsync("https://slack.com/api/chat.postMessage", httpContent);

            var responseJson = await response.Content.ReadAsStringAsync();

            SlackMessageResponse messageResponse =
                JsonConvert.DeserializeObject<SlackMessageResponse>(responseJson);

            if (messageResponse.ok == false)
            {
                throw new Exception(
                    "Failed to send message. error: " + messageResponse.error
                );
            }
        }

        public async Task<GetConversations_Root> GetConversations()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var responseStr = await client.GetAsync("https://slack.com/api/conversations.list").Result.Content.ReadAsStringAsync();
            GetConversations_Root? response = JsonConvert.DeserializeObject<GetConversations_Root>(responseStr);
            return response;
        }
    }

}