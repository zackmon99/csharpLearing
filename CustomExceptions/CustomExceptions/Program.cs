using System;

namespace CustomExceptions
{
    public class UserNotLoggedInException : Exception
    {
        public UserNotLoggedInException(string message) : base(message)
        {
        }

        public UserNotLoggedInException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    
    public class OddNumberException : Exception
    {
        public override string Message
        {
            get
            {
                return "Divisor cannot be an odd number.";
            }
        }
    }
    public class User
    {
        private bool _loggedIn;

        public bool LoggedIn
        {
            get
            {
                return _loggedIn;
            }

            set
            {
                _loggedIn = value;
            }
        }

        public bool Logout()
        {
            Console.WriteLine("Logging out");
            if (_loggedIn)
            {
                Console.WriteLine("User Logged out");
                return true;
            }
            else
            {
                return false;
            }
        }

    }
    class Program
    {
        
        static void Main(string[] args)
        {
            int x, y, z;

            Console.WriteLine("Is user logged in?");
            bool loggedIn = bool.Parse(Console.ReadLine());

            User user = new User();

            if (loggedIn)
            {
                user.LoggedIn = true;
            }
            else
            {
                user.LoggedIn = false;
            }

            Console.WriteLine("Enter two integers");
            x = int.Parse(Console.ReadLine());
            y = int.Parse(Console.ReadLine());

            try
            {
                if (y % 2 > 0)
                {
                    throw new OddNumberException();
                }

                z = x / y;
                Console.WriteLine(z);
            }
            catch (OddNumberException one)
            {
                Console.WriteLine(one.Message);
                Console.WriteLine("Logging out user");
                
                try
                {
                    if (!user.LoggedIn)
                    {
                        throw new UserNotLoggedInException("User not logged in", one);
                    }
                }
                catch (UserNotLoggedInException unlie)
                {
                    Console.WriteLine(unlie.Message + " during \'" + unlie.InnerException.Message + "\' exception");
                }
            }

            

            Console.WriteLine("End of program");
        }
    }
}
