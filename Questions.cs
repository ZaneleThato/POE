using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace POE
{
    public class Questions
    {
        private readonly MemoryManager memoryManager = new MemoryManager();

        private Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>()
        {
            { "who are you", new List<string> {
                "I am an AI chatbot that can teach you to be safe online.",
                "I'm your cybersecurity assistant here to help you stay safe online."
            }},
            { "what do you do", new List<string> {
                "My function is to assist you in cybersecurity matters.",
                "I provide information and tips about online safety and security."
            }},
            { "phishing", new List<string> {
                "Phishing is a trick used by cybercriminals to steal your personal information...",
                "Phishing attacks often come as emails or messages pretending to be from trusted sources...",
                "Watch for suspicious links and requests for personal information - these are signs of phishing."
            }},
        };

        private Dictionary<string, string> sentimentResponses = new Dictionary<string, string>()
        {
            { "worried", "I understand this can be concerning. Let me help you with some clear guidance." },
            { "scared", "It's okay to feel this way. Cybersecurity can be intimidating, but I'll help you." },
            { "angry", "I hear your frustration. Let's work through this together." },
            { "happy", "Great to see you're enthusiastic about security! Let's keep that energy going." }
        };

        private List<string> securityTopics = new List<string> {
            "password", "security", "cybersecurity", "phishing", "safety",
            "malware", "ransomware", "privacy", "hack", "virus"
        };

        private List<string> securityTips = new List<string>
        {
            "Use a mix of letters, numbers, and symbols in your password.",
            "Never share your password with anyone.",
            "Enable two-factor authentication wherever possible.",
            "Be cautious of phishing emails and messages.",
            "Regularly update your software to patch security vulnerabilities."
        };

        private Dictionary<string, string> userMemory = new Dictionary<string, string>();
        private Random random = new Random();

        public string DisplayWelcomeText()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("_____________________________");
            Console.WriteLine("*****************************");
            Console.WriteLine("_____________________________");
            Console.ForegroundColor = ConsoleColor.White;
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
                userName = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(userName))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("AI Bot -> Name cannot be empty. Please enter a valid name.");
                    continue;
                }

                if (!Regex.IsMatch(userName, @"^[a-zA-Z\s]+$"))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("AI Bot -> Please enter a name using only letters.");
                    continue;
                }

                break;
            } while (true);

            userMemory["name"] = userName;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*****************************************************************");
            Console.WriteLine("=================================================================");
            Console.WriteLine($"Hello, {userName}! How can I be of assistance today?");
            Console.WriteLine("Tip: Type 'history' to see your previous conversations.");
            Console.WriteLine("=================================================================");
            Console.WriteLine("*****************************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            return userName;
        }

        public void InteractWithUser(string userName)
        {
            string userInput;
            memoryManager.EnsureFileExists();

            do
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($":{userName} -> ");
                userInput = Console.ReadLine()?.ToLower();

                if (string.IsNullOrEmpty(userInput))
                {
                    ShowResponse("Please enter a valid question.");
                    continue;
                }

                if (userInput == "exit") break; 

                var logEntries = new List<string> { $"{userName}: {userInput}" };

                string botResponse = ProcessUserInput(userInput);
                logEntries.Add($"Bot: {botResponse}");

                ShowResponse(botResponse);
                memoryManager.SaveConversation(logEntries);

            } while (true);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Thank you for the visit, {userName}! Come again soon!");
        }

        private string ProcessUserInput(string userInput)
        {
            if (userInput == "history")
            {
                var history = memoryManager.GetHistory();
                if (history.Count == 0)
                    return "Your chat history is currently empty.";

                return string.Join(Environment.NewLine, history);
            }

            var sentiment = sentimentResponses.Keys.FirstOrDefault(s => userInput.Contains(s));
            if (sentiment != null)
                return sentimentResponses[sentiment];

            if (userInput.Contains("interested in") || userInput.Contains("i like"))
            {
                var topic = securityTopics.FirstOrDefault(t => userInput.Contains(t));
                if (topic != null)
                {
                    userMemory["interest"] = topic;
                    return $"I'll remember you're interested in {topic}. Here's a tip: {securityTips[random.Next(securityTips.Count)]}";
                }
            }

            if (userMemory.ContainsKey("interest") &&
                (userInput.Contains("tell me more") || userInput.Contains("what else")))
            {
                var topic = userMemory["interest"];
                return GetRandomResponse(topic);
            }

            var matchedQuestion = keywordResponses.Keys.FirstOrDefault(q => userInput.Contains(q));
            if (matchedQuestion != null)
                return GetRandomResponse(matchedQuestion);

            if (securityTopics.Any(topic => userInput.Contains(topic)))
                return securityTips[random.Next(securityTips.Count)];

            return "I'm not sure about that. Can you ask me something related to cybersecurity?";
        }

        private string GetRandomResponse(string key)
        {
            if (keywordResponses.ContainsKey(key))
                return keywordResponses[key][random.Next(keywordResponses[key].Count)];

            return securityTips[random.Next(securityTips.Count)];
        }

        private void ShowResponse(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("*****************************************************************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("AI Bot -> ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
