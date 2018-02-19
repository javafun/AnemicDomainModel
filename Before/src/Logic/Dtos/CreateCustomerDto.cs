using System.ComponentModel.DataAnnotations;

namespace Logic.Dtos
{
    public class CreateCustomerDto
    {
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
    }
}
