﻿using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneDictionary
{
    [Serializable]
    public class PhoneBook
    {
        public PhoneBook() { }

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(15)]
        public string TelephoneNumber { get; set; }
    }
}