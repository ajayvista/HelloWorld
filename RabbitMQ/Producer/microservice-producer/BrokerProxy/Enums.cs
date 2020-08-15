using System;
using System.ComponentModel;

namespace Producer.BrokerProxy
{

    /// <summary>
    /// Added in case of multiple exchange and logic can be build upon
    /// </summary>
    public enum ExchangeType
    {
        [Description("_exchange")]
        SampleExchange=0
    }
}
