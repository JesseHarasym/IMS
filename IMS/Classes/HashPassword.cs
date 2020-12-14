using System;
using System.Security.Cryptography;

namespace IMS.Classes
{
    class HashPassword
    {
        public string HashAccountPassword(string password)
        {
            //create salt value with cryptographic PRNG
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            //create the Rfc2898DeriveBytes and get the hash value
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            //combine the salt and password bytes to be used later 
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            //turn combined salt and hash into a string and send to database
            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            return savedPasswordHash;

        }

        public bool UnHashAccountPassword(string userEnteredPassword, string savedPasswordHashed)
        {
            bool matched = false;

            try
            {
                //extract bytes from password
                byte[] hashBytes = Convert.FromBase64String(savedPasswordHashed);

                //get salt for password
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);

                //apply hash on the user entered password
                var pbkdf2 = new Rfc2898DeriveBytes(userEnteredPassword, salt, 100000);
                byte[] hash = pbkdf2.GetBytes(20);

                //compare and see if they matched
                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] == hash[i])
                    {
                        matched = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an issue while trying to unhash the users password" + ex);
            }


            return matched;
        }
    }
}
