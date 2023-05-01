class Programm
{
    static string Inversion(string str)
    {
        string strInv = "";

        string strUpper=str.ToUpper();
        string strLower=str.ToLower();

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == strUpper[i]) strInv += strLower[i].ToString();
            else strInv += strUpper[i].ToString();
        }

        return strInv;
    }

    static string OneUpper(string str, int k)
    {
        string strUpper = str.ToUpper();
        string glass = "";
        for (int i = 0; i < str.Length; i++)
        {
            if (i != k) glass += str[i];
            else
            {
                glass += strUpper[i];
            }
        }
        return glass;
    }

    static string iFirstToUpper(string str, int i)
    {
        for(int k = 0; k <= i; k++)
        {
            str = OneUpper(str, k);
        }
        return str;
    }

    static string SumOfCases(string str1, string str2)
    {
        string sum = "";
        string strUpper=str1.ToUpper();
        string strLower=str1.ToLower();
        for(int i =0;i< str1.Length;i++)
        {
            if (str1[i] == strUpper[i] || str2[i] == strUpper[i]) sum += strUpper[i];
            else sum += strLower[i];
        }
        return sum;
    }

    static void Main(string[] args)
    {
        string str = "a1b2";
        int CountL = str.Count(s => char.IsLetter(s));

        int n;
        if (CountL <= 2) n = 30;
        else n = CountL * CountL * 4;

        string[] answer = new string[n];
        answer[0] = str.ToLower();
        answer[1] = str.ToUpper();

        int k = 0;
        for(int i=0; k < CountL; i++)
        {
            if (char.IsLetter(str[i])) 
            { 
                answer[2 + k] = OneUpper(str, i);
                k++;
            }
        }

        k = 0;
        for(int i =0; k < CountL; i++)
        {
            if (char.IsLetter(str[i]))
            {
                answer[2 + CountL + k] = iFirstToUpper(str, i);
                k++;
            }
        }

        k = 0;
        int j = 0;
        for(int i=0; j <= CountL; i++)
        {
            answer[2 + CountL * 2 + k] = SumOfCases(answer[2 + j], answer[2 + CountL + i]);
            k++;
            if (i >= CountL)
            {
                i = 0;
                j++;
            }
        }

        for(int i=0;i < CountL * 2 + CountL * CountL; i++)
        {
            answer[2 + CountL * 2 + CountL * CountL + i] = Inversion(answer[2 + i]);
        }

        string[] answ = answer.Distinct().ToArray();
        
        for (int i = 0; i < answ.Length; i++)
        {
            Console.WriteLine(answ[i]);
        }
    }
}