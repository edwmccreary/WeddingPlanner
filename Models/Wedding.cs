using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId {get;set;}

        [Required(ErrorMessage = "A wedding must have 2 wedders")]
        public string WedderOne {get;set;}

        [Required(ErrorMessage = "A wedding must have 2 wedders")]
        public string WedderTwo {get;set;}

        [Required(ErrorMessage = "A wedding must have a date")]
        [NoPastDateTime]
        public DateTime Date {get;set;}

        [Required(ErrorMessage = "A wedding must have an address")]
        public string Address {get;set;}

        [Required(ErrorMessage = "The User ID of this wedding is missing")]
        public int UserId {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public User user {get;set;}

        public List<RSVP> Guests {get;set;}
    }

    public class NoPastDateTime : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value is DateTime)
            {
                DateTime checkMe = (DateTime)value;

                if(checkMe < DateTime.Now)
                {
                    return new ValidationResult("date must not be in the past");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return new ValidationResult("entered value is not a date");
            }
        }
    }
}