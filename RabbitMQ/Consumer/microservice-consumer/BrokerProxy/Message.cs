using System;

[Serializable]
public class Message
{
    public Message()
    {
    }
    public DateTime ProducedAt { get; set; }
    public Guid MessageId { get; set; }
    public object Data { get; set; } 
}