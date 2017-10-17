using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyString
{
    public class Str
    {
        const int MAX_LENGTH = 256;
        private char[] str;

        public int Lenght()
        {
            return str.Length;
        }

        public char this[int index]
        {
            get
            {
                return str[index];
            }
            set
            {
                str[index] = value;
            }
        }

        private bool IsIncorrectData(int start, int end)
        {
            return start > Lenght() || end > Lenght() 
                || start < 0 || end < 0 || start > end;
        }

        public Str Substr(int start, int end)
        {
            if(IsIncorrectData(start, end))
            {
                throw new Exception("Некорректный индекс!");
            }

            var newStr = new Str(end - start + 1);
            for (int i = start; i <= end; i++)
            {
                newStr[i - start] = this[i];
            }
            return newStr;
        }

        public void swap(ref Str b)
        {
            Str temp = new Str(b);
            b = new Str(this);
            this.str = temp.str;
        }

        public static Str operator +(Str s1, Str s2)
        {
            int L = s1.str.Length + s2.str.Length;

            var sumstr = new Str(L);

            for (int i = 0; i < s1.str.Length; i++)
            {
                sumstr[i] = s1[i];
            }
            for (int i = 0; i < s2.str.Length; i++)
            {
                sumstr[s1.str.Length + i] = s2[i];
            }
            return sumstr;
        }

        public static bool operator ==(Str s1, Str s2)
        {
            if (s1.str.Length != s2.str.Length)
            {
                return false;
            }
            for (int i = 0; i < s1.str.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator !=(Str s1, Str s2)
        {
            return !(s1 == s2);
        }

        public override string ToString()
        {
            return new string(str);
        }

        public int Find(String findstr)
        {
            if (Lenght() < findstr.Length)
            {
                return -1;
            }

            for (int i = 0; i < Lenght() - findstr.Length; i++)
            {
                for (int j = 0; j < findstr.Length; j++)
                {
                    if(str[i + j] == findstr[j])
                    {
                        if (j == findstr.Length - 1)
                        {
                            return i;
                        }
                    }
                }
            }
            return -1;
        }

        public int FindSymbol(char symbol)
        {
            for (int i = 0; i < Lenght(); i++)
            {
                if (str[i] == symbol)
                {
                    return i;
                }
            }
            return -1;
        }

        public Str(Str previousMyString)
        {
            str = new char[previousMyString.str.Length];
            for (int i = 0; i < previousMyString.str.Length; i++)
            {
                str[i] = previousMyString.str[i];
            }
        }

        public Str()
        {
            str = new char[MAX_LENGTH];
        }

        public Str(int initSize)
        {
            str = new char[initSize];
        }

        public Str(String StdStr)
        {
            str = new char[StdStr.ToCharArray().Length];
            str = StdStr.ToCharArray();
        }

        public Str(char[] arr)
        {
            str = new char[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                str[i] = arr[i];
            }
        }
    }
}
