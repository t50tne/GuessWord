internal class GussWord
{
    static void Main(string[] args)
    {
        StartGame();
        
    }
    static void StartGame()
    {
        Console.WriteLine("Let's try to guess name of the fruit, which is hidden.");
        string[] fruitArray = { "Apple", "Apricot", "Avocado", "Banana", "Black", "currant", "Blackberry", 
                                "Blueberry", "Carambola", "Cashew apple", "Cherry", "Cloudberry", "Coconut",
                                "Cranberry", "Custard apple", "Damson", "Dates", "Dragonfruit", "Elderberry",
                                "Fig", "Feijoa", "Goji berry", "Grapes", "Grapefruit", "Grewia", "Guava",
                                "Hanepoot", "Huckleberry", "Jackfruit", "Jamun", "Jicama", "Jujube", "kiwano",
                                "Kiwi", "Lemon", "Longan", "Loquat", "Lychee", "Mango", "Malay apple", "Melon",
                                "Monk fruit", "Mulberry", "Muskmelon", "Nance", "Olive", "Orange", "Palm fruit",
                                "Papaya", "Passion fruit", "Peach", "Pear", "Persimmon", "Pineapple", "Plum",
                                "Pomegranate", "Prickly pear", "Pumpkin", "Quince", "Raspberry", "Red currant",
                                "Sapodilla", "Satsuma", "Shaddock", "Soursop", "Spanish cherry", "Strawberry",
                                "Sugarcane", "Surinam cherry", "Tamarillo", "Tamarind" };

        Random randomFruit = new Random();
        int index = randomFruit.Next(0, fruitArray.Length);
        char[] fruit = fruitArray[index].ToLower().ToCharArray();
        Compare(fruit);
    }

    static string GetUserLetter()
    {
        Console.WriteLine("\nEnter letter or whole word");
        return Console.ReadLine().ToLower();
    }
    static void Compare(char[] fruit)
    {
        char[] tempArr = new char[fruit.Length];
        int counter = 0;

        string userWord;
        string hiddenWord;

        bool noMatches;

        for (int i = 0; i < tempArr.Length; i++)
        {
            tempArr[i] = '*';
        }

        do
        {
            userWord = GetUserLetter().ToString();
            hiddenWord = new string(fruit);
            noMatches = true;

            char letter = userWord[0];

            for (int i = 0; i < hiddenWord.Length; i++)
            {
                if (hiddenWord[i].Equals(letter) && tempArr[i] == '*')
                {
                    tempArr[i] = hiddenWord[i];
                    counter++;
                    noMatches = false;
                }
            }
                if (noMatches)
                {
                    Console.WriteLine("hidden fruit name does not contain your letter\n");
                }
                if (hiddenWord.Equals(userWord))
                {
                    Victory();
                    DrawArray(userWord.ToCharArray());
                    break;
                }
                if (counter == fruit.Length)
                {
                    Victory();
                    DrawArray(hiddenWord.ToCharArray());
                    return;
                }
                Console.WriteLine();
                DrawArray(tempArr);
            
        } while (counter < fruit.Length);
    }

    static void DrawArray(char[] fruit)
    {
        Console.Write("The fruit is: ");
        for (int i = 0; i < fruit.Length; i++)
        {
            Console.Write(fruit[i]);
        }
    }
    static void Victory()
    {
        Console.WriteLine("Congratulation you guessed the fruit name");
    }
}
