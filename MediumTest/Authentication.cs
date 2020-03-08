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

        public bool Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || username.Length < 4)
                throw new InvalidOperationException();

            if (string.IsNullOrEmpty(password) || password.Length < 4)
                throw new InvalidOperationException();

            return true;
        }
    }
}
