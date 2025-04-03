using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Poe_prog2
{
    public class Questions
    {
        private ArrayList questions = new ArrayList
        {
            "who are you",
            "what do you do",
            "what is phishing",
            "i think i've been hacked",
            "how do i stay safe online",
            "what is identity theft",
            "how do i create a strong password",
            "what is ransomware",
            "what is malware"
        };

        private ArrayList responses = new ArrayList
        {
            "I am an AI chatbot that can teach you to be safe online.",
            "My function is to assist you in cybersecurity.",
            "Phishing is a trick used by cybercriminals to steal your personal information...",
            "Don't panic! Immediately disconnect from the internet...",
            "Stay safe online by using strong passwords...",
            "Identity theft happens when someone steals your personal information...",
            "A strong password is like a strong lock on your door...",
            "Ransomware is like a digital kidnapper—it locks your files...",
            "Malware is like a digital virus that sneaks into your device..."
        };

        private ArrayList ignoreList = new ArrayList { "bye", "no", "change", "name", "tell" };
        private List<string> securityTopics = new List<string> { "password", "security", "cybersecurity", "phishing", "safety", "AI chatbot","Internet","Information", "Ransomware", "Malware" };
        private List<string> securityTips = new List<string>
        {
            "Use a mix of letters, numbers, and symbols in your password.",
            "Never share your password with anyone.",
            "Enable two-factor authentication wherever possible.",
            "Be cautious of phishing emails and messages."
        };

        private Random random = new Random();

        public string DisplayWelcomeText()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("_____________________________");
            Console.WriteLine("*****************************");
            Console.WriteLine("_____________________________");
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine("Welcome! What is your name?");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("_____________________________");
            Console.WriteLine("*****************************");
            Console.WriteLine("_____________________________");

            
            string userName;

            do
            {
               
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(":User -> ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                userName = Console.ReadLine()?.Trim(); // Remove extra spaces

                // Input Validation
                if (string.IsNullOrEmpty(userName))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("AI Bot -> Name cannot be empty. Please enter a valid name.");
                    continue;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(userName, @"^[a-zA-Z\s]+$"))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("AI Bot -> Please enter a name using only letters.");
                    continue;
                }

                break; // Exit loop if name is valid

            } while (true);


           
          
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*****************************************************************");
            Console.WriteLine("=================================================================");
            Console.WriteLine("Hello, " + userName + "! How can I be of assistance today?");
            Console.WriteLine("=================================================================");
            Console.WriteLine("*****************************************************************");
            Console.ForegroundColor = ConsoleColor.White;
            return userName;
        }

        public void InteractWithUser(string userName)
        {
            string userInput;
            do
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($":{userName} -> ");
                userInput = Console.ReadLine().ToLower();

                // Input Validation
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("*****************************************************************");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("AI Bot -> Please enter a valid question.");
                    continue;  // Skip to the next iteration
                }

                if (!Regex.IsMatch(userInput, @"^[a-zA-Z\s?]+$"))
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("*****************************************************************");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("AI Bot -> I only understand words, please enter a proper question.");
                    continue;
                }

                if (userInput.Length < 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("*****************************************************************");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("AI Bot -> Your question is too short. Try again with more details.");
                    continue;
                }


                if (securityTopics.Any(topic => userInput.Contains(topic)))
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("*****************************************************************");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("AI Bot -> ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(securityTips[random.Next(securityTips.Count)]);
                }
                else if (responses.Cast<string>().Any(response => response.StartsWith(userInput + ":")))
                {
                    string answer = responses.Cast<string>().First(response => response.StartsWith(userInput + ":"));
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("*****************************************************************");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("AI Bot -> ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(answer.Split(':')[1]);
                }
                else if (ignoreList.Cast<string>().Any(word => userInput.Contains(word)))
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("*****************************************************************");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("AI Bot ->");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" I cannot assist with that.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("*****************************************************************");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("AI Bot ->");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I'm not sure about that. Can you ask me something related to cybersecurity?");
                }


            } while (userInput != "exit");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Thank you for the visit, come again soon!");
        }
    }
}
