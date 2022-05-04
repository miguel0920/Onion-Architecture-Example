using Domain.Common;

namespace Domain.Entities
{
    public class Customer : AuditableBaseEntity
    {
        private int _age;

        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthdayDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Age
        {
            get
            {
                if (_age <= 0)
                {
                    _age = new DateTime(DateTime.Now.Subtract(BirthdayDate.HasValue ? BirthdayDate.Value : DateTime.Now).Ticks).Year - 1;
                }
                return _age;
            }
        }
    }
}