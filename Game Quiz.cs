using System;
using System.Collections.Generic;

public class CPHInline
{
    private static Dictionary<string, string> videoGameQuiz = new Dictionary<string, string>()
    {
        // PlayStation Games
        {"Which character is known as the 'Ghost of Sparta' in a famous PlayStation series?", "Kratos"},
        {"What racing game series is well known on PlayStation for its realistic driving experience?", "Gran Turismo"},
        {"Which game features Nathan Drake, a treasure hunter, exploring ancient ruins?", "Uncharted"},

        // Xbox Games
        {"In which Xbox game do you play as a super soldier named 'Master Chief'?", "Halo"},
        {"Which Xbox game series features Marcus Fenix fighting against the Locust Horde?", "Gears of War"},

        // Nintendo Games
        {"What is the name of the famous green-clad hero in the Legend of Zelda series?", "Link"},
        {"Which Nintendo character is a plumber known for saving Princess Peach?", "Mario"},
        {"In which Nintendo game can you drive karts on crazy tracks and throw items at other racers?", "Mario Kart"},
        {"What game allows you to catch, train, and battle creatures on a Nintendo console?", "Pokemon"},

        // Resident Evil Series
        {"What is the name of the fictional city where the original Resident Evil game takes place?", "Raccoon City"},
        {"Which Resident Evil character is known for her iconic blue outfit and surviving the mansion incident?", "Jill Valentine"},
        {"What virus causes the outbreak in Resident Evil 4?", "Las Plagas"},
        {"Who is the main antagonist in Resident Evil 7: Biohazard?", "Eveline"},
        {"What is the name of the large vampire lady in Resident Evil Village?", "Lady Dimitrescu"},
        {"In Resident Evil 2, who are the two main playable characters?", "Leon and Claire"},
        {"What is the primary goal of the main characters in Resident Evil 3: Nemesis?", "Escape Raccoon City"},
        {"Which Resident Evil game features the character Albert Wesker as a primary antagonist?", "Resident Evil 5"},
        {"What are the B.O.W.s in Resident Evil known for?", "Bio-Organic Weapons"},
        {"Which character is known for their relationship with Chris Redfield and for being part of the BSAA?", "Jill Valentine"},
        {"What is the main setting of Resident Evil Code: Veronica?", "Rockfort Island"},
        {"In Resident Evil 0, who is the main character that teams up with Rebecca Chambers?", "Billy Coen"},
        {"What is the main type of enemy introduced in Resident Evil 4?", "Los Ganados"},
        {"In Resident Evil 6, which two characters have a cooperative campaign involving the city of Edonia?", "Leon and Helena"},
        {"What unique gameplay feature was introduced in Resident Evil 7: Biohazard?", "First-person perspective"},
        {"In Resident Evil Village, what is the main objective of Ethan Winters?", "To rescue his daughter, Rose"},
        {"What type of enemy is the 'Lycan' in Resident Evil Village?", "Werewolf-like creature"},
        {"Which Resident Evil title is set in a snowy environment featuring the character Chris Redfield?", "Resident Evil 5"},
        {"Who is the creator of the T-Virus?", "Dr. William Birkin"},
        {"What year was the original Resident Evil game released?", "1996"},
        {"In Resident Evil 4, what does the merchant sell to the player?", "Weapons and upgrades"},
        {"Which Resident Evil game features the character Sherry Birkin?", "Resident Evil 2"},
        {"What is the name of the Umbrella Corporation's flagship bio-organic weapon that was designed as an experimental parasite?", "T-Virus"},
        {"In Resident Evil 3: Nemesis, what is the name of the creature that pursues Jill throughout the game?", "Nemesis"},
        {"What are the primary enemies faced in Resident Evil: Revelations?", "Creatures known as 'Omnidroids'"},
        {"What is the name of the ship that serves as the main setting for Resident Evil: Revelations?", "Queen Zenobia"},
        {"Who is the lead character in Resident Evil 2 Remake?", "Leon S. Kennedy"},
        {"What are the zombies in Resident Evil known as when they are created from the T-Virus?", "Zombies"},
        {"In Resident Evil 5, what is the name of the organization Chris and Sheva are trying to stop?", "Tricell"},
        {"In Resident Evil Village, what is the name of the main antagonist who controls the Lycans?", "Alcina Dimitrescu"},
        {"Which character is known for their role in the original Resident Evil and appears in the first two games?", "Chris Redfield"},
        {"What is the significance of the Red and Blue herbs in the Resident Evil series?", "They are used for healing and enhancing health."},

        // Other Games
        {"In the game Fortnite, what are the large-scale, 100-player matches called?", "Battle Royale"},
        {"Which game allows you to explore a post-apocalyptic world overrun by 'Clickers'?", "The Last of Us"},
        {"What game set in Norse mythology stars Kratos and his son Atreus?", "God of War"},
        {"Which action RPG features the Hunter fighting terrifying beasts in the city of Yharnam?", "Bloodborne"},
        {"In which game do you control a Witcher named Geralt of Rivia?", "The Witcher 3"},
        {"What is the name of the character in Red Dead Redemption 2 known for his loyalty to Dutch Van Der Linde?", "Arthur Morgan"},
        {"Which stealth action-adventure series follows an assassin and features historical settings?", "Assassin's Creed"},
        {"In which game do you build and explore an open-world sandbox made of blocks?", "Minecraft"},
        {"Which first-person shooter game is set in a futuristic city and features wall-running and giant mechs?", "Titanfall"},
        {"Which game set in ancient Greece allows players to control an assassin with a hidden blade?", "Assassin's Creed Odyssey"},
        {"Which action-adventure game features a space bounty hunter named Samus Aran?", "Metroid"},
        {"Which battle royale game is known for its ping system and Legends with unique abilities?", "Apex Legends"}
    };

    private string currentQuestion; // To store the current question
    private string currentAnswer; // To store the correct answer

    public bool Execute()
    {
        // Command ID to trigger the quiz
        CPH.TryGetArg("commandId", out Guid commandId);
        
        // Check if the Command ID matches the one for starting the quiz
        if (commandId == Guid.Parse("7784d0f1-c640-49b4-b2c9-d454d6cfb8d1")) // Replace with your actual Command ID for !quiz
        {
            // Start the quiz
            StartQuiz();
        }
        // Check if the Command ID matches the one for answering the quiz
        else if (commandId == Guid.Parse("3d806b5e-3c0c-436b-842c-4fe9b791ee05")) // Replace with your actual Command ID for !answerquiz
        {
            // Check the user's answer
            CheckAnswer();
        }

        return true; // Indicate that the script ran successfully
    }

    private void StartQuiz()
    {
        // Randomly select a quiz question
        Random rand = new Random();
        List<string> keys = new List<string>(videoGameQuiz.Keys);
        currentQuestion = keys[rand.Next(keys.Count)];
        currentAnswer = videoGameQuiz[currentQuestion];

        // Send the question to chat
        CPH.SendMessage($"Here's your question: {currentQuestion}");

        // Update the question in OBS
        string quizScene = "Game Scene"; // Replace with your actual scene name
        string quizSource = "Game Question"; // Replace with your actual source name
        CPH.ObsSetGdiText(quizScene, quizSource, $"{currentQuestion}");

       
    }

   
    private void CheckAnswer()
    {
        // Get the user's answer and user from the chat
        CPH.TryGetArg("rawInput", out string userAnswer);
        CPH.TryGetArg("user", out string user);

        // Check if currentAnswer is null or empty
        if (string.IsNullOrEmpty(currentAnswer))
        {   
            CPH.SendMessage("There is no current question to answer. Please start a new quiz with !quiz.");
            return;
        }

        // Check the user's answer
        if (string.Equals(userAnswer, currentAnswer, StringComparison.OrdinalIgnoreCase))
        {
            // Wait for 20 seconds before sending the answer
            CPH.Wait(20000);

            // Send the correct answer message
            CPH.SendMessage($"Correct, @{user}! The answer is indeed {currentAnswer}.");

            // Update the answer in OBS
            string resultScene = "Game Scene"; // Replace with your actual scene name
            string resultSource = "Game Quiz Answer"; // Replace with your actual source name
            CPH.ObsSetGdiText(resultScene, resultSource, $"{currentAnswer}");
        }
        else
        {
            // Wait for 40 seconds before sending the incorrect answer message
            CPH.Wait(40000);

            // Send the incorrect answer message
            CPH.SendMessage($"Oops, @{user}, that's incorrect! The correct answer was {currentAnswer}.");
            
            // Update the answer in OBS
            string resultScene = "Game Scene"; // Replace with your actual scene name
            string resultSource = "Game Quiz Answer"; // Replace with your actual source name
            CPH.ObsSetGdiText(resultScene, resultSource, $"Incorrect Answer: {currentAnswer}");
        }

        // Reset the question
        currentQuestion = null;
        currentAnswer = null;
    }
}
