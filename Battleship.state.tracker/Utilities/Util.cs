namespace Battleship.state.tracker.Utilities
{
    public static class Util
    {
        public const string GameOverString =
            @"
                
                    _______      ___      .___  ___.  _______   ______   ____    ____  _______ .______      
                    /  _____|    /   \     |   \/   | |   ____| /  __  \  \   \  /   / |   ____||   _  \     
                |  |  __     /  ^  \    |  \  /  | |  |__   |  |  |  |  \   \/   /  |  |__   |  |_)  |    
                |  | |_ |   /  /_\  \   |  |\/|  | |   __|  |  |  |  |   \      /   |   __|  |      /     
                |  |__| |  /  _____  \  |  |  |  | |  |____ |  `--'  |    \    /    |  |____ |  |\  \----.
                    \______| /__/     \__\ |__|  |__| |_______| \______/      \__/     |_______|| _| `._____|
                                                                                    

            ";

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