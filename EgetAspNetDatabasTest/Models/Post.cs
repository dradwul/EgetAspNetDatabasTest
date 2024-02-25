﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgetAspNetDatabasTest.Models
{
    public class Post
    {
        public int PostId { get; set; } // Primärnyckel
        public string PostData { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; } // Främmande nyckel
        public int PostDownvotes { get; set; }
        public int PostUpvotes { get; set; }

        // Navigationsegenskap: Varje inlägg är kopplat till en användare
        public User User { get; set; }
    }
}
