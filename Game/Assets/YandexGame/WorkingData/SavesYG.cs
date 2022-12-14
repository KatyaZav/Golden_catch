
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
        public int Diamonds = 0;

        public bool isGetGold = false;
        public bool isWasGame = false;
    }
}
