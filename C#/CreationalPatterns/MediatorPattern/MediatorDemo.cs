namespace CreationalPatterns.MediatorPattern
{
    internal class MediatorDemo
    {
        public void MediatorDemoMethod()
        {
            IChatRoomMediator chatRoom = new Chatroom();
            User user1 = new(chatRoom,"Jim");
            User user2 = new(chatRoom,"Dwight");

            user1.SendMessage("Hey Dwight, There is an updog outside.");
            user2.SendMessage("What's updog?");
            user1.SendMessage("Nothing much, what about you?");
        }
    }
}
