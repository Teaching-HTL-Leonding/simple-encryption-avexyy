string plaintext = Console.ReadLine()!;

string ciphertext = Encrypt(plaintext, -7);
Console.WriteLine(ciphertext);
plaintext = Decrypt(ciphertext, -7);
Console.WriteLine(plaintext);

string Decrypt(string ciphertext, int shift)
{
    return Encrypt(ciphertext, -shift);
}

string Encrypt(string plaintext, int shift)
{
    string result = "";
    for (int i = 0; i < plaintext.Length; i++)
    {
        if (char.IsLetter(plaintext[i]))
        {
            int shifted = plaintext[i] + shift;
            if ((char.IsLower(plaintext[i]) && shifted > 'z')
                || (char.IsUpper(plaintext[i]) && shifted > 'Z'))
            {
                shifted -= 26;
            }
            else if ((char.IsLower(plaintext[i]) && shifted < 'a')
                || (char.IsUpper(plaintext[i]) && shifted < 'A'))
            {
                shifted += 26;
            }

            result += char.ConvertFromUtf32(shifted);
        }
        else
        {
            result += plaintext[i];
        }
    }

    return result;
}