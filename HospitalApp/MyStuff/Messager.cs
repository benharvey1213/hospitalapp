using System;

namespace HospitalApp.MyStuff
{
    public class Messager
    {
        private HospitalDBEntities dbcontext = new HospitalDBEntities();

        public void SendMessage(string toName, string fromName, string message)
        {
            Message newMessage = new Message();
            newMessage.Date = DateTime.Now;
            newMessage.UserLoginNameTo = toName;
            newMessage.Message1 = message;
            newMessage.UserLoginNameFrom = fromName;

            dbcontext.Messages.Add(newMessage);
            dbcontext.SaveChanges();
        }
    }
}