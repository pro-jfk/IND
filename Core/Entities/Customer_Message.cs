﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Customer_Message
{
    public bool StatusReceived { get; set; }
    public bool StatusPrinted { get; set; }
    public DateTime DateReceived { get; set; }
    
        
    [ForeignKey("Message")]
    public string MessageID { get; set; }
    public Message Message { get; set; }
    
    [ForeignKey("Customer")]
    public int CustomerID { get; set; }
    public Customer Customer { get; set; }


}