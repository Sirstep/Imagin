using Newtonsoft.Json;
using Imagin.API.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Imagin.API.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedUsers()
        {
            var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);
            foreach (var user in users)
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("password", out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Username = user.Username.ToLower();

                string[] words = user.Description.Split(' ');
                foreach (Photo p in user.Photos)
                {
                    Random rand = new Random();
                    for (int i = 0; i < rand.Next(1, 9); i++){
                        p.Tags = p.Tags + ' ' +  words[rand.Next(i, i + 1)];
                    }
                    p.Tags = p.Tags.TrimStart(' ');
                    // System.Console.WriteLine(p.Tags);
                }

                _context.Users.Add(user);
            }
            _context.SaveChanges();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}