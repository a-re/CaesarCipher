using System;
using System.Collections.Generic;
class Program
{
    static readonly char[] alpha = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    static void Main(string[] args)
    {
        Console.WriteLine(CaesarEncrypt("Hello", 1));
        Console.ReadKey();
    }

    public static string CaesarEncrypt(string str, int rot, bool? lower = null) /* A nullable boolean! */
    {
        int l, len = alpha.Length;
        char[] inStr = lower == null ? str.ToCharArray() : (bool)lower ? str.ToLower().ToCharArray() : str.ToUpper().ToCharArray();
        char[] outC = new char[inStr.Length];
        Dictionary<char, int> dict = new Dictionary<char, int>();
        for (int x = 0; x < len; x++) { dict.Add(alpha[x], x); }
        for (int i = 0; i < inStr.Length; i++)
        {
            dict.TryGetValue(inStr[i], out l);
            outC[i] = inStr[i].Equals(' ') ? ' ' : char.IsUpper(inStr[i]) ? alpha[l + rot % ((len / 2) + len / 2)] : alpha[(l + rot) % (len / 2)]; 
        }
        return new string(outC);
    }
}