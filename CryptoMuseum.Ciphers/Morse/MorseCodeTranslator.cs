using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

public static class MorseCodeTranslator
{
    private static readonly ReadOnlyDictionary<char, string> MorseCodeMap;
    private static readonly ReadOnlyDictionary<string, char> ReverseMorseCodeMap;
    
    static MorseCodeTranslator()
    {
        MorseCodeMap = GenerateMorseCodeMap();
        ReverseMorseCodeMap = GenerateReverseMorseCodeMap();
    }

    public static string FromMorse(string morseCode)
    {
        StringBuilder sentenceBuilder = new StringBuilder();
        string[] words = morseCode.Split('|');

        foreach (string word in words)
        {
            string[] letters = word.Trim().Split(' ');

            foreach (string letter in letters)
            {
                if (ReverseMorseCodeMap.TryGetValue(letter, out char character))
                {
                    sentenceBuilder.Append(character);
                }
            }

            sentenceBuilder.Append(' '); // Space between words
        }

        return sentenceBuilder.ToString().Trim();
    }

    public static string ToMorse(string sentence)
    {
        StringBuilder morseCodeBuilder = new StringBuilder();

        foreach (char character in sentence.ToUpper())
        {
            if (MorseCodeMap.TryGetValue(character, out string morseCode))
            {
                morseCodeBuilder.Append(morseCode);
                morseCodeBuilder.Append(" "); // Space between code chars
            }
            else if (character == ' ') // Words separator
            {
                morseCodeBuilder.Append("| "); // Words separator 
            }
            else
            {
                // Ignoring unknown chars
            }
        }

        return morseCodeBuilder.ToString().Trim();
    }

    private static ReadOnlyDictionary<char, string> GenerateMorseCodeMap()
    {
        var morseCodeMap = new Dictionary<char, string>
        {
            {'A', ".-"},
            {'B', "-..."},
            {'C', "-.-."},
            {'D', "-.."},
            {'E', "."},
            {'F', "..-."},
            {'G', "--."},
            {'H', "...."},
            {'I', ".."},
            {'J', ".---"},
            {'K', "-.-"},
            {'L', ".-.."},
            {'M', "--"},
            {'N', "-."},
            {'O', "---"},
            {'P', ".--."},
            {'Q', "--.-"},
            {'R', ".-."},
            {'S', "..."},
            {'T', "-"},
            {'U', "..-"},
            {'V', "...-"},
            {'W', ".--"},
            {'X', "-..-"},
            {'Y', "-.--"},
            {'Z', "--.."},
            {'0', "-----"},
            {'1', ".----"},
            {'2', "..---"},
            {'3', "...--"},
            {'4', "....-"},
            {'5', "....."},
            {'6', "-...."},
            {'7', "--..."},
            {'8', "---.."},
            {'9', "----."},
        };

        return new ReadOnlyDictionary<char, string>(morseCodeMap);
    }

    private static ReadOnlyDictionary<string, char> GenerateReverseMorseCodeMap()
    {
        var reverseMorseCodeMap = new Dictionary<string, char>();

        foreach (KeyValuePair<char, string> entry in MorseCodeMap)
        {
            reverseMorseCodeMap[entry.Value] = entry.Key;
        }

        return new ReadOnlyDictionary<string, char>(reverseMorseCodeMap);
    }
}