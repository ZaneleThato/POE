using System.Drawing;
using System.IO;
using System.Media;
using System;

namespace Poe_prog2
{
    // Subclass handling ASCII art and audio playback
    public class AudioImage
    {
        public AudioImage()
        {
            DisplayArt(); // Displays ASCII image
            PlayGreetingAudio(); // Plays greeting audio
        }

        private void DisplayArt()
        {
            try
            {
                string fullLocation = AppDomain.CurrentDomain.BaseDirectory;
                string newLocation = fullLocation.Replace("bin\\Debug\\", "");
                string fullPath = Path.Combine(newLocation, "Logo2.jpg");

                Bitmap image = new Bitmap(fullPath);
                image = new Bitmap(image, new Size(150, 120));

                for (int height = 0; height < image.Height; height++)
                {
                    for (int width = 0; width < image.Width; width++)
                    {
                        Color pixelColor = image.GetPixel(width, height);
                        int gray = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                        char asciiChar = gray > 200 ? '-' : gray > 150 ? '*' : gray > 100 ? 'o' : gray > 50 ? '#' : '@';
                        Console.Write(asciiChar);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error displaying ASCII art: " + ex.Message);
            }
        }

        private void PlayGreetingAudio()
        {
            try 
            {
                string fullLocation = AppDomain.CurrentDomain.BaseDirectory;
                string newPath = fullLocation.Replace("bin\\Debug\\", "");
                string fullPath = Path.Combine(newPath, "greeting.wav");

                using (SoundPlayer play = new SoundPlayer(fullPath))
                {
                    play.PlaySync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing audio: " + ex.Message);
            }
        }
    }
} // End of AudioImage class