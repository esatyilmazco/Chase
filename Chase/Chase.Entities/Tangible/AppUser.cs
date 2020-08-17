using System.Collections.Generic;
using Chase.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Chase.Entities.Tangible
{
    public class AppUser : IdentityUser<int>, IEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        //Çalışsan Bir'den fazla görev alabilir.Çok olan Nesne.
        public List<Duty> Duties { get; set; }
        public List<Declaration> Declarations { get; set; }
        public  List<Message> Messages { get; set; }
        // public string Email { get; set; }


    }
}