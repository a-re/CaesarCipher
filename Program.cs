using System;
using System.Text;
using System.Collections.Generic;
class Program
{
    static readonly char[] alpha = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    static void Main(string[] args)
    {
        CaesarHash("hey", GenerateIV());
    }

    /* A cool little hashing function that uses CaesarEncypt() */
    public static string CaesarHash(string str, byte[] iv)
    {
        byte[] outBytes = new byte[256];
        /* 16 rounds of hashing, with 2 CaesarEncrypts() per round */
        for (int x = 0; x < 16; x++)
        {
            int div = str.Length / 2;
            byte[] i1 = CaesarEncrypt(str.Substring(0, div), 3);
            byte[] i2 = CaesarEncrypt(str.Substring(div), 3);
            byte[] y = new byte[i1.Length];
            for (int x1 = 0; x1 < i1.Length; x1++)
            {
                y[x1] ^= x1 % 2 == 0 ? i1[x1] : i2[x1]; 
            }
        }
    }

    public static byte[] GenerateIV()
    {
        Random r = new Random();
        byte[] iv = new byte[256];
        for (int x = 0; x < 256; x++)
        {
            iv[x] = (byte)(r.Next(byte.MaxValue));
        }
        return iv;
    }

    public static byte[] CaesarEncrypt(string str, int rot, bool? lower = null) /* A nullable boolean! */
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
        return ASCIIEncoding.ASCII.GetBytes(outC);
    }
}