using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //verdiğimiz şifrenin Hash ini olusturmaya yarıyor
        public static  void CreatePaswordHash(string password,out byte[]passwordHash,out byte[]passwordSalt)
        {
            using(var hmca= new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmca.Key;
                passwordHash = hmca.ComputeHash(Encoding.UTF8.GetBytes(password));

            }
        }

        //sonradan giren birinn doğru olup olmadını hash konrol eden yapıdır
        public static bool VerifyPasswordHash(string password,  byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmca = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
               var ComputedHash = hmca.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < ComputedHash.Length; i++)
                {
                    if (ComputedHash[i] == passwordHash[i])
                    {
                        return false;
                    }

                }
                return true;
            }
         
        }
    }
}
