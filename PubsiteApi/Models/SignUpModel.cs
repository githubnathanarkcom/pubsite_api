﻿using System;

namespace PubsiteApi.Models
{
    public class SignUpModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }            
        public bool acceptTerms { get; set; }
        public string siteName { get; set; }

    }
}