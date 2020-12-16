using IMS.Classes.MainClasses.Accounts;

namespace IMS.Classes
{
    public class Users : AccountBase
    {
        //user class derives off of accounts base and sets access level accordingly
        public Users(string name, string username, string password, string email) :
            base(name, username, password, email)
        {
            Name = name;
            Username = username;
            Password = password;
            Email = email;
            AccessLevel = 0;
        }
    }
}
