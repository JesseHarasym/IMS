namespace IMS.Classes.MainClasses.Accounts
{
    class Admins : AccountBase
    {
        //admin class derives off of accounts base and sets access level accordingly
        public Admins(string name, string username, string password, string email) :
            base(name, username, password, email)
        {
            Name = name;
            Username = username;
            Password = password;
            Email = email;
            AccessLevel = 1;
        }
    }
}
