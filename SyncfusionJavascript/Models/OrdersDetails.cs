using SyncfusionJavascript.Controllers;

namespace SyncfusionJavascript.Models;


public class OrdersDetails
{
    public int Id { get; set; }
    public int FirstName { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public int Age { get; set; }
    public DateTime Birthdate { get; set; }
    public StatusEnum Status { get; set; }
}

