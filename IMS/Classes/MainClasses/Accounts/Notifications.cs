namespace IMS.Classes.MainClasses.Accounts
{
    //basic class to track notifications for admins
    public class Notifications
    {
        public string Message;
        public bool Dismissed;
        public string MessageType;
        public int ProductId;

        public Notifications(string message, bool dismissed, string messageType, int productId)
        {
            Message = message;
            Dismissed = dismissed;
            MessageType = messageType;
            ProductId = productId;
        }
    }
}
