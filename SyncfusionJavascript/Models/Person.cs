using Microsoft.AspNetCore.Mvc;

namespace SyncfusionJavascript.Models
{
    [ModelBinder(BinderType = typeof(CustomModelBinder))]
    public class Person
    {
        public Person(int id, string firstName, string lastName)
        {
            Id = id;
            var rnd = new Random().Next(10, 100);
            FirstName = firstName;
            LastName = lastName;
            City = nameof(City);
            Address = nameof(Address);
            Age = rnd;
            Birthdate = DateTime.Now.AddYears(-rnd);
            Status = true;
        }
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
