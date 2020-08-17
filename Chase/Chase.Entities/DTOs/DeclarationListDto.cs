using System;
using Chase.Entities.Notional;
namespace Chase.Entities.DTOs
{
    public class DeclarationListDto : IDto
    {
        public int Id { get; set; }
        public string Explanation { get; set; }
        public DateTime? DateTime { get; set; }
    }
}