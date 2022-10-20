using Microsoft.AspNetCore.Mvc;

namespace SyncfusionJavascript.Models
{
    [ModelBinder(BinderType = typeof(CustomModelBinder))]
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Status { get; set; } 
    }
}
