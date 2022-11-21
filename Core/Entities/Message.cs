﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Message
{
 
    public string Id { get; set; }
    public string Type { get; set; }
    //public string Employee { get; set; } => FK
    public DateTime DateSent { get; set; }
    public string FileURL { get; set; }
    
    
    public int customer { get; set; }
    public Customer Customer { get; set; }

}