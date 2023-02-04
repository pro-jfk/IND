using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Common;

namespace Core.Entities;
/// <summary>
/// In case multiple customers are connected to multiple messages
/// </summary>
public class CustomerMessage : BaseEntity
{
    //Customer

    public int CustomerId { get; set; }

    public Customer Customer { get; set; }
    //Message

    public int MessageId { get; set; }
    public Message Message { get; set; }


    //If message is received by Customer
    public bool StatusReceived { get; set; }

    //If message is printed by Customer
    public bool StatusPrinted { get; set; }

    //Time when message was received by Customer
    public DateTime DateReceived { get; set; }

    public int TimesPrinted { get; set; }
}