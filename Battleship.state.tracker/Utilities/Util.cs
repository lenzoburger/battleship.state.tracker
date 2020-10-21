namespace Battleship.state.tracker.Utilities
{
    public static class Util
    {
        private static char nextLetter = 'A';

        public static char GetNextLetter()
        {
            char currentLetter = nextLetter;
            if (currentLetter == 'z')
                nextLetter = 'A';
            else if (currentLetter == 'Z')
                nextLetter = 'a';
            else
                nextLetter = (char)(((int)currentLetter) + 1);

            return currentLetter;
        }

        public static void ResetSuffixCounters()
        {
            nextLetter = 'A';
        }

    }
}