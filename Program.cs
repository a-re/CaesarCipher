using System;
using System.Collections.Generic;
class Program
{
    static readonly char[] alpha = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    static void Main(string[] args)
    {
        Console.WriteLine(CaesarEncrypt("hello", 2));
        Console.ReadKey();
    }

    public static string CaesarEncrypt(string str, int rot)
    {
        char[] inStr = str.ToLower().ToCharArray();
        char[] outC = new char[inStr.Length];
        Dictionary<char, int> dict = new Dictionary<char, int>();
        for (int x = 0; x < alpha.Length; x++) { dict.Add(alpha[x], x); }
        for (int i = 0; i < inStr.Length; i++)
        {
            int l;
            dict.TryGetValue(inStr[i], out l);
            outC[i] = inStr[i].Equals(' ') ? ' ' : alpha[(l + rot) % alpha.Length];
        }
        return new string(outC);
    }
}