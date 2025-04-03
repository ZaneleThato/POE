namespace Poe_prog2
{
    // Menu class that manages user interactions and calls other subclasses
    public class Menu
    {
        private AudioImage audioImage;
        private Questions questions;
        private string userName;

        public Menu()
        {
            audioImage = new AudioImage(); // Handles ASCII art and audio
            questions = new Questions(); // Handles user interactions
            userName = questions.DisplayWelcomeText(); // Captures the user's name
            StartInteraction();
        }

        private void StartInteraction()
        {
            questions.InteractWithUser(userName); // Initiates chat interaction
        }
    }
}    // End of Menu class
