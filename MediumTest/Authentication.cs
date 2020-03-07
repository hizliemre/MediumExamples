using System;

namespace MediumTest
{
    public class Authentication
    {
        public bool Login(string username)
        {
            if (string.IsNullOrEmpty(username) || username.Length < 4)
                throw new InvalidOperationException();

            return true;
        }
    }
}
