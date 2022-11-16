using static SlackMessager.Models.Slack;

namespace SlackMessager.Models
{
    internal class Slack
    {
        public class SlackMessageResponse
        {
            public bool ok { get; set; }
            public string error { get; set; }
            public string channel { get; set; }
            public string ts { get; set; }
        }

        public class SlackMessage
        {
            public string channel { get; set; }
            public string text { get; set; }
            //public bool as_user { get; set; }
            //public SlackAttachment[] attachments { get; set; }
        }

        public class SlackAttachment
        {
            public string fallback { get; set; }
            public string text { get; set; }
            public string image_url { get; set; }
            public string color { get; set; }
        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class GetConversations_Channel
        {
            public string id { get; set; }
            public string name { get; set; }
            public bool is_channel { get; set; }
            public bool is_group { get; set; }
            public bool is_im { get; set; }
            public bool is_mpim { get; set; }
            public bool is_private { get; set; }
            public int created { get; set; }
            public bool is_archived { get; set; }
            public bool is_general { get; set; }
            public int unlinked { get; set; }
            public string name_normalized { get; set; }
            public bool is_shared { get; set; }
            public bool is_org_shared { get; set; }
            public bool is_pending_ext_shared { get; set; }
            public List<object> pending_shared { get; set; }
            public string context_team_id { get; set; }
            public object updated { get; set; }
            public object parent_conversation { get; set; }
            public string creator { get; set; }
            public bool is_ext_shared { get; set; }
            public List<string> shared_team_ids { get; set; }
            public List<object> pending_connected_team_ids { get; set; }
            public bool is_member { get; set; }
            public GetConversations_Topic topic { get; set; }
            public GetConversations_Purpose purpose { get; set; }
            public List<object> previous_names { get; set; }
            public int num_members { get; set; }
        }

        public class GetConversations_Purpose
        {
            public string value { get; set; }
            public string creator { get; set; }
            public int last_set { get; set; }
        }

        public class GetConversations_ResponseMetadata
        {
            public string next_cursor { get; set; }
        }

        public class GetConversations_Root
        {
            public bool ok { get; set; }
            public List<GetConversations_Channel> channels { get; set; }
            public GetConversations_ResponseMetadata response_metadata { get; set; }
        }

        public class GetConversations_Topic
        {
            public string value { get; set; }
            public string creator { get; set; }
            public int last_set { get; set; }
        }


    }
}
