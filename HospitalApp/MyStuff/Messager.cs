using System;

namespace HospitalApp.MyStuff
{
    // this class handles interaction with the database to create a new message
    public class Messager
    {
        private HospitalDBEntities dbcontext = new HospitalDBEntities();

        // adds a message to the database
        public void SendMessage(string toName, string fromName, string message)
        {
            Message newMessage = new Message();
            newMessage.Date = DateTime.Now;
            newMessage.UserLoginNameTo = toName;
            newMessage.Message1 = message;
            newMessage.UserLoginNameFrom = fromName;
            newMessage.InFromBox = true;
            newMessage.InToBox = true;

            dbcontext.Messages.Add(newMessage);
            dbcontext.SaveChanges();
        }
    }
}