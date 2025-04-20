using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Entities;

namespace WinFormsApp1.Models
{
    [Alias("users")]
    public partial class User : IEntity
    {
        public string GetEntityName() { return "Item"; }
        [NonChange]
        [Alias("user_id")]
        public Guid id { get; set; }
        [Alias("first_name")]
        public string firstName { get; set; }
        [Alias("last_name")]
        public string lastName { get; set; }
        [Alias("is_superuser")]
        [NonChange]
        public bool is_superuser { get; set; }
        [Alias("is_staff")]
        [NonChange]
        public bool is_staff { get; set; }
        [Alias("is_active")]
        public bool is_active { get; set; }
        [Alias("last_signed_at")]
        [NonChange]
        public DateTime last_signed_at { get; set; }
        [Alias("registered_at")]
        [NonChange]
        public DateTime registered_at { get; set; }
        [Alias("phone_number")]
        [NonChange]
        public string name { get; set; }
        public User() { }
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
