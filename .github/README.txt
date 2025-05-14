# 🛡️ CyberSecurity Assistant Bot

Welcome to the **CyberSecurity Assistant Bot** – an interactive console-based chatbot built with C# and .NET to help users learn about online safety, security threats, and best practices in a fun and engaging way.

## 📦 Features

- 💬 Natural chat flow with keyword detection
- 🧠 Chat history saved and retrieved via file system
- 🧠 Sentiment-based responses (friendly bot vibes included!)
- 🖼️ ASCII image rendering from JPEG
- 🔊 Plays an audio greeting to welcome the user
- 🔐 Cybersecurity tips and awareness prompts

## 🛠️ Tech Stack

- C# (.NET)
- Console App
- System.Drawing for ASCII art
- System.Media for audio playback
- Basic file I/O for chat history

## 📂 Project Structure

- `MemoryManager.cs` – Handles saving and retrieving chat logs
- `Questions.cs` – Manages user interaction, keyword detection, and responses
- `Menu.cs` – Entry point to launch the bot
- `AudioImage.cs` – Converts image to ASCII and plays a WAV greeting
- `CyberSecurityAssistant.cs` – Main class with exception handling

## ▶️ Getting Started

1. Clone the repository.
2. Ensure you have:
   - `.NET 6.0 SDK` (or compatible version)
   - A console that supports Unicode output
3. Place `Logo2.jpg` and `greeting.wav` in the project root folder.
4. Run the project via Visual Studio or use:
   ```bash
   dotnet run
