using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    enum PasswordStrenght
    {
        easy,
        normal,
        hard
    }
    class Lab14
    {
        static void Main(string[] args)
        {
            /*string myString = "This is a test.";
            char[] separator = { ' ' };
            string[] myWords;
            myWords = myString.Split(separator);
            foreach (string word in myWords)
            {
                Console.WriteLine("{0}", word);
            }
            Console.ReadKey();*/
            Console.WriteLine("Enter 3 passwords in 1 line:");
            string passLine = Console.ReadLine();
            char[] delimiter = { ' ' };
            string[] parts = passLine.Split(delimiter);

            string[] passwords = new string[3];

            passwords[0] = generatePassword(PasswordStrenght.easy);
            passwords[1] = generatePassword(PasswordStrenght.normal);
            passwords[2] = generatePassword(PasswordStrenght.hard);

            Console.WriteLine("FDSfADDASFASF");
            for (int i = 0; i < parts.Length; i++)
            {
                if (passwords[i].Equals(parts[i])) {
                    Console.WriteLine("You guessed parts[i]");
                }
            }
            foreach(String p in passwords){
                Console.WriteLine(p);
            }
            Console.ReadKey();
        }
        static string generatePassword
            (PasswordStrenght passwordStrenght)
        {
            Random rnd = new Random();
            if (passwordStrenght == PasswordStrenght.easy) {
                const string valid = "abcdefghijklmnopqrstuvwxyz";
                int length = rnd.Next(1,7);
                StringBuilder sb = new StringBuilder();
                while (0 < length--) {
                    sb.Append(valid[rnd.Next(valid.Length)]);       
                }
                return sb.ToString();
            }
            if (passwordStrenght == PasswordStrenght.normal) {
                const string valid = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                int length = rnd.Next(6, 11);
                StringBuilder sb = new StringBuilder();
                while (0 < length--)
                {
                    sb.Append(valid[rnd.Next(valid.Length)]);
                }
                return sb.ToString();
            }
            if (passwordStrenght == PasswordStrenght.hard)
            {
                const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*";
                int length = rnd.Next(10, 20);
                StringBuilder sb = new StringBuilder();
                while (0 < length--)
                {
                    sb.Append(valid[rnd.Next(valid.Length)]);
                }
                return sb.ToString();
            }
            throw new ArgumentOutOfRangeException();
        }
    }
}
