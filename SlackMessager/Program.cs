using SlackMessager;
using static SlackMessager.Models.Slack;

const string token = "xoxp-4377893285173-4374238816214-4380866042418-1373f69e5c7e3de283d886113c393cdd";
Slack slack = new(token);
Console.Write("Welcome to Slack Message Sender\n\n");
while (true)
{
    var conversations = slack.GetConversations().Result;
    int i=1;
    foreach (var channel in conversations.channels)
    {
        Console.WriteLine($"{i++}) {channel.name}");
    }

    Console.Write("which channel do you want to send a message : ");
    var channelNumberStr = Console.ReadLine();

    if(!Int32.TryParse(channelNumberStr, out int channelNumber))
    {
        Console.WriteLine("Error, please try again!");
        continue;
    }

    string channelId = conversations.channels[channelNumber - 1].id;
    Console.WriteLine("Please write to message : ");

    slack.SendMessageAsync(new SlackMessage { channel = channelId, text = Console.ReadLine() });
    Console.WriteLine("");
}