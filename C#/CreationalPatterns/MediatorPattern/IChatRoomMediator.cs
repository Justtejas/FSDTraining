namespace CreationalPatterns.MediatorPattern
{
    public interface IChatRoomMediator
    {
        void ShowMessage(User user, string message);
    }
    public class Chatroom : IChatRoomMediator
    {
        public void ShowMessage(User user, string message)
        {
            string time = DateTime.Now.ToString("HH:MM:ss");
            string sender = user.Name;
            Console.WriteLine($"{time} : {sender} : {message}");
        }
    }

    public class User
    {
        private IChatRoomMediator _chatRoomMediator;
        public string Name { get; set; }
        public User(IChatRoomMediator mediator,string name)
        {
            _chatRoomMediator = mediator;
            Name = name;
        }
        public void SendMessage(string message)
        {
            _chatRoomMediator.ShowMessage(this,message);
        }
    }

}
