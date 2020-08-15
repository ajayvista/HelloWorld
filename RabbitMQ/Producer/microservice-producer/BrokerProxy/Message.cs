using System;

namespace Producer.BrokerProxy
{
    [Serializable]
    /// <summary>
    /// Message structure 
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Timestamp in each message when it was constructed
        /// </summary>
        /// <value></value>
        public DateTime ProducedAt { get; set; }

        /// <summary>
        /// Each message must have unique id
        /// </summary>
        /// <value></value>
        public Guid MessageId { get; set; }

        /// <summary>
        /// Message payload
        /// </summary>
        /// <value></value>
        public object Data { get; set; } 
    }
}