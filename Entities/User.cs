using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Entities;

namespace WinFormsApp1.Models
{
    public partial class User : IEntity
    {
        public string GetEntityName() { return "Item"; }
        public Guid id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool is_superuser { get; set; }
        public bool is_staff { get; set; }
        public bool is_active { get; set; }
        public DateTime last_signed_at { get; set; }
        public DateTime registered_at { get; set; }
        [Alias("phone_number")]
        public string name { get; set; }

        public User(Guid id, string firstName,
            string lastName, bool is_superuser,
            bool is_staff, bool is_active,
            DateTime last_signed_at, DateTime registered_at,
            string phoneNumber)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.is_superuser = is_superuser;
            this.is_staff = is_staff;
            this.is_active = is_active;
            this.last_signed_at = last_signed_at;
            this.registered_at = registered_at;
            this.name = phoneNumber;
            

        }
    }
}
