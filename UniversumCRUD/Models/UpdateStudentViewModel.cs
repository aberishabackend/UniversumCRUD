using UniversumCRUD.Models.Domain;

namespace UniversumCRUD.Models
{
    public class UpdateStudentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Department { get; set; }
    }
}
