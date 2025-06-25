using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22_Decode_Morse_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            var code = ".... . -.--   .--- ..- -.. .";

            var message = MorseCodeDecoder.Decode(code);
            Console.WriteLine(message);

            Console.ReadLine();
        }
    }

    public class MorseCodeDecoder
    {
        public static string Decode(string morseCode)
        {
            morseCode = morseCode.Trim();

            string message = "";
            var amount = 0;
            int i = 0;
            bool endFlag = true;

            //for (int i = 0; i + morseCode.IndexOf(' ', i) < morseCode.Length; i += amount + 1)
            //{
            while(endFlag)
            {
                var separatorIndex = morseCode.IndexOf(' ', i);
                char cha;

                if (separatorIndex - i == 0) //space case
                {
                    cha = ' ';
                    amount = 1;
                }
                else if (separatorIndex == -1) //the last character case 
                {
                    amount = morseCode.Length - i; 
                    cha = MorseCodeDecoder.Get(morseCode.Substring(i, amount));
                    endFlag = false;
                }
                else
                {
                    amount = separatorIndex - i;
                    cha = MorseCodeDecoder.Get(morseCode.Substring(i, amount));
                }

                message += cha;

                i += amount + 1;
            }

            return message;
        }

        public static char Get(string code)
        {
            return MorseCodeMap[code];
        }

        public static readonly Dictionary<string, char> MorseCodeMap = new Dictionary<string, char>()
        {
            [".-"] = 'A',
            ["-..."] = 'B',
            ["-.-."] = 'C',
            ["-.."] = 'D',
            ["."] = 'E',
            ["..-."] = 'F',
            ["--."] = 'G',
            ["...."] = 'H',
            [".."] = 'I',
            [".---"] = 'J',
            ["-.-"] = 'K',
            [".-.."] = 'L',
            ["--"] = 'M',
            ["-."] = 'N',
            ["---"] = 'O',
            [".--."] = 'P',
            ["--.-"] = 'Q',
            [".-."] = 'R',
            ["..."] = 'S',
            ["-"] = 'T',
            ["..-"] = 'U',
            ["...-"] = 'V',
            [".--"] = 'W',
            ["-..-"] = 'X',
            ["-.--"] = 'Y',
            ["--.."] = 'Z',
            ["-----"] = '0',
            [".----"] = '1',
            ["..---"] = '2',
            ["...--"] = '3',
            ["....-"] = '4',
            ["....."] = '5',
            ["-...."] = '6',
            ["--..."] = '7',
            ["---.."] = '8',
            ["----."] = '9'
        };
    }
}
