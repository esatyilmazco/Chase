using Chase.Entities.Tangible;

namespace Chase.Entities.DTOs
{
    public class AppUserListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public Duty Duty { get; set; }

        
    }
}