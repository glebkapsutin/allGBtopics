using System.Text.Json;

class Message
{
    public string name{ get; set;}

    public string message{ get; set;}

    public DateTime time { get; set;}

    public string ToJson()
    {
       return JsonSerializer.Serialize(this);
    }
    public Message(string n,string d)
    {
        this.name = n;
        this.message = d;
        this.time = DateTime.Now;
    }
    public static Message FromJson(string mes)
    {
        return JsonSerializer.Deserialize<Message>(mes);
    }

}