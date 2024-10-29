namespace CreationalPatterns.ChainOfRes
{
    internal class ChainOfResp
    {
        public void ChainOfRespDemo()
        {
            ISupportHandler levelOne = new LevelOneSupport();
            ISupportHandler levelTwo = new LevelTwoSupport();
            ISupportHandler levelThree = new LevelThreeSupport();
            levelOne.SetNext(levelTwo).SetNext(levelThree);

            levelOne.HandleRequest("simple issue");
            levelOne.HandleRequest("complex issue");
            levelOne.HandleRequest("very complex issue");
            levelOne.HandleRequest("unknown issue");
        }
    }
}
