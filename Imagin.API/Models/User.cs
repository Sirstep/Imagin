using System;
using System.Collections.Generic;
using Newtonsoft.Json;
// using Imagin.API.Models;

namespace Imagin.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Description { get; set; }
        
        [JsonIgnore]
        // [IgnoreDataMember]
        public ICollection<Photo> Photos { get; set; }
    }
}