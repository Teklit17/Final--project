﻿using Google.Cloud.Firestore;

namespace Report_Generator_Domain.Models

{
    public class Account
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        [FirestoreProperty]
        public string Role { get; set; }

    }
}
