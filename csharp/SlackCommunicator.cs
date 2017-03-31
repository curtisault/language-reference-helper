public class SlackCommunicator
{

    private readonly Uri _uri;
    private readonly Encoding _encoding = new UTF8Encoding();

    // address for the webhook you make in the slack webapp
    private const string _webAddrPost = "https://hooks.slack.com/services/{get/from/slack}";

    // address for uploading
    private const string _webAddrUpload = "https://slack.com/api/files.upload";

    // you have to find this from the slack admin panel for whatever profile you want to use
    // (this isn't necessary but is useful if you upload a file to Slack and need to point to a user)
    private readonly Dictionary<string, string> _userToken = new Dictionary<string, string>
    {
        {@"curtis",@"?token=xoxp-get-from-slack-webapp"}
    };

    public void UploadFile() { }

    public SlackCommunicator()
    {
        _uri = new Uri(_webAddrPost);
    }

    public String WebAddrPost
    {
        get { return _webAddrPost; }
    }

    public String WebAddrUpload
    {
        get { return _webAddrUpload; }
    }

    public String SlackUserToken(string user)
    {
        return _userToken[user];
    }

    public Dictionary<string, string> Channels = new Dictionary<string, string>()
    {
        // for testing purposes you may want to change to send yourself personal messages
        {"channel_1","#channel_1"},
        {"channel_2","#channel_2"},
        {"user-direct","@user_name_here"}
    };

    public void PostErrorNotification(Exception ex)
    {
        Payload payload = new Payload();
        payload.Username = "ClientPortal-webhook";
        payload.IconUrl = "http://i.imgur.com/some_img.png"; // image from the interwebz
        payload.Channel = Channels["channel_1"];
        payload.Text = ex.ToString();

        PostMessage(payload);
    }

    public void PostCustomErrorNotification(string msg)
    {
        Payload payload = new Payload();
        payload.Username = "ClientPortal-webhook";
        payload.IconUrl = "http://i.imgur.com/some_img.png"; // image from the interwebz
        payload.Channel = Channels["clientportal"];
        payload.Text = msg;

        PostMessage(payload);
    }

    //Post a message using a Payload object
    public void PostMessage(Payload payload)
    {
        string payloadJson = JsonConvert.SerializeObject(payload);

        using (WebClient client = new WebClient())
        {
            NameValueCollection data = new NameValueCollection();
            data["payload"] = payloadJson;

            var response = client.UploadValues(_uri, "POST", data);

            //The response text is usually "ok"
            string responseText = _encoding.GetString(response);
        }
    }

    //This class serializes into the Json payload required by Slack Incoming WebHooks
    public class Payload
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
