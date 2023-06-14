using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Games.Data.Models
{
    public class User
    {
        [Key]
        public int Id 
        { 
            get;
            set; 
        }

        [Required]
        [MaxLength(30)]
        public string Username 
        { 
            get; 
            set; 
        }

        [MaxLength(20)]
        public string FirstName
        {
            get;
            set;
        }

        [MaxLength(20)]
        public string LastName
        {
            get;
            set;
        }

        public int Age
        {
            get; 
            set;
        }

        [MaxLength(20)]
        public string Password
        {
            get;
            set;
        }

        [MaxLength(30)]
        public string Email
        {
            get; 
            set;
        }

        public string Gender
        {
            get;
            set;
        }

        public decimal Money
        {
            get; 
            set;
        }

        public User(string username, string firstName, string lastName, int age, string password, string email,string gender)
        {
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Password = password;
            this.Email = email;
            this.Gender = gender;
            this.Money = 100;
        }
    }
}
