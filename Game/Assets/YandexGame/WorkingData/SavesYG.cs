
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        public bool isFirstSession = true;
        public string language = "ru";
        public bool feedbackDone;
        public bool promptDone;

        // Ваши сохранения
        public int RecordCount = 0;
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        public bool isGetGold = false;
        public bool isWasGame = false;
    }
}
