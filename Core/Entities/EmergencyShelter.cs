namespace Core.Entities;

public class EmergencyShelter
{
    //Number of EmergencyShelter
    public int Id { get; set; }
    //Town of EmergencyShelter
    public string Town { get; set; }
    //Adress of EmergencyShelter
    public string Adress { get; set; }
    //Customers in EmergencyShelter
    public int CustomerAmount { get; set; }
    
    //Customer
    public List<Customer> Customers { get; set; }

}