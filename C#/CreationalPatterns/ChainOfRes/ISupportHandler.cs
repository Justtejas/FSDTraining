namespace CreationalPatterns.ChainOfRes
{
    public interface ISupportHandler
    {
        void HandleRequest(string issue);
        ISupportHandler SetNext(ISupportHandler next);
    }

    public abstract class SupportHandler : ISupportHandler
    {
        private ISupportHandler _nextHandler;
        public ISupportHandler SetNext(ISupportHandler nextHandler)
        {
            _nextHandler = nextHandler;
            return _nextHandler;
        }
        public virtual void HandleRequest(string issue)
        {
            if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(issue);
            }
        }
    }

    public class LevelOneSupport : SupportHandler
    {
        public override void HandleRequest(string issue)
        {
            if(issue == "simple issue")
            {
                Console.WriteLine("Level one support");
            }
            else
            {
                base.HandleRequest(issue);
            }
        }
    }
    public class LevelTwoSupport : SupportHandler
    {
        public override void HandleRequest(string issue)
        {
            if(issue == "complex issue")
            {
                Console.WriteLine("Level two support");
            }
            else
            {
                base.HandleRequest(issue);
            }
        }
    }
    public class LevelThreeSupport : SupportHandler
    {
        public override void HandleRequest(string issue)
        {
            if(issue == "very complex issue")
            {
                Console.WriteLine("Level three support");
            }
            else
            {
                base.HandleRequest(issue);
            }
        }
    }
}
