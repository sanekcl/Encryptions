using System;

namespace Caesar
{
    class Encoder
    {
        public string ALPHABETENG ="ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public string VigenereDecode(string inputSTR, string inputKEY)
        {
            inputSTR.ToUpper();
            inputKEY.ToUpper();
            string newSTR = "";
            for (int i = 0; i < inputSTR.Length; i++)
            {
                char SymbolSTR = inputSTR[i];
                char SymbolKEY = inputKEY[i];
                int strID = ALPHABETENG.IndexOf(SymbolSTR);
                int keyID = ALPHABETENG.IndexOf(SymbolKEY);
                if (!char.IsLetter(SymbolSTR))
                {
                    newSTR += (char)(inputSTR[i]);
                }
                else
                {
                    int codeID = (strID+ ALPHABETENG.Length - keyID) % ALPHABETENG.Length;
                    newSTR += ALPHABETENG[codeID];
                }
            }
            return newSTR;
        }
        public string VigenereEncode(string inputSTR, string inputKEY)
        {
            inputSTR.ToUpper();
            inputKEY.ToUpper();
            string newSTR = "";
            for (int i = 0; i < inputSTR.Length; i++)
            {
                char SymbolSTR = inputSTR[i];
                char SymbolKEY = inputKEY[i];
                int strID = ALPHABETENG.IndexOf(SymbolSTR);
                int keyID = ALPHABETENG.IndexOf(SymbolKEY);
                if (!char.IsLetter(SymbolSTR))
                {
                    newSTR += (char)(inputSTR[i]);
                }
                else
                {
                    int codeID = (strID + keyID) % ALPHABETENG.Length;
                    newSTR += ALPHABETENG[codeID];
                }
            }
            return newSTR;
        }
        public string CaesarEncode(string inputSTR, int inputKEY)
        {
            string newALPHABETENG=ALPHABETENG+ALPHABETENG.ToLower();

            string newSTR = "";
            for (int i = 0; i < inputSTR.Length; i++)
            {
                char Symbol = inputSTR[i];
                int ID = newALPHABETENG.IndexOf(Symbol);
                if (!char.IsLetter(Symbol))
                {
                    newSTR += (char)(inputSTR[i]);
                }
                else
                {
                    int codeID = (newALPHABETENG.Length+ID+inputKEY) % newALPHABETENG.Length;
                    //Console.WriteLine($"Код {codeID}");
                    newSTR +=newALPHABETENG[codeID];
                }
            }
            return newSTR;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Encoder encoder = new Encoder();
        repeat: Console.WriteLine("1. Цезарь.");
            Console.WriteLine("2. Виженер.");
            int choose = Convert.ToInt32(Console.ReadLine());
            if (choose==1)
            {
                Console.WriteLine("Введите строку");
                string str = Console.ReadLine();
                Console.WriteLine("Введите ключ");
                int key = Convert.ToInt32(Console.ReadLine());
                str = encoder.CaesarEncode(str, key);
                Console.WriteLine($"ЗАШИФРОВАНО: {str}");
                Console.WriteLine($"РАСШИФРОВАНО: {encoder.CaesarEncode(str, -key)}");
                Console.ReadKey();
            }
            else if(choose==2)
            {
                Console.WriteLine("Введите строку");
                string str = Console.ReadLine();
                Console.WriteLine("Введите ключ");
                string key = Console.ReadLine();
                string newkey = "";
                for (int i = 0,j=0; i < str.Length; i++)
                {
                    if (!char.IsLetter(str[i]))
                    {
                        newkey += str[i];
                    }
                    else
                    {
                        if (j==key.Length)
                        {
                            j = 0;
                        }
                        newkey += key[j];
                        j++;
                    }
                }
                Console.WriteLine(str);
                Console.WriteLine(newkey);
                str = encoder.VigenereEncode(str, newkey);
                Console.WriteLine(str);
                Console.WriteLine(encoder.VigenereDecode(str, newkey));
            }
            else
            {
                Console.Clear();
                goto repeat;
            }
        }
    }
}
