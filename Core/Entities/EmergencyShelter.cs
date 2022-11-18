namespace Core.Entities;

public class EmergencyShelter
{
    public string ID { get; set; }
    public string Town { get; set; }
    public string Adress { get; set; }
    public int CustomerAmount { get; set; }
    
    public List<Customer> Customers { get; set; }

}