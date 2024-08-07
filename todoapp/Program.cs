using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine($"จากโจทย์เรียงตามลำดับข้อ");

        string str = "ab";
        List<string> permutations = GetPermutations(str);
        string permutationResult = string.Join(",", permutations);
        Console.WriteLine($"1.ความเป็นไปได้ของตัวอักษรคือ: {permutationResult}");

        int[] numbers = { 0, 1, 0, 1, 0, 4, 4, 5, 4, 0 };
        List<int> result = CountOddOccurrence(numbers);
        string countOdd = string.Join(", ", result);
        Console.WriteLine($"2.เลขที่มีจำนวนครั้งที่พบเป็นจำนวนเลขคี่คือ: {countOdd}");

        string[] smiles = { ";]", ":[", ";*", ":$", ";-D" };
        int validSmileCount = IsValidSmile(smiles);
        Console.WriteLine($"3.จำนวนของรอยยิ้มที่ถูกคือ: {validSmileCount}");
    }

    static List<int> CountOddOccurrence(int[] numbers)
    {
         var counts = numbers.GroupBy(n => n)
                            .Select(g => new { Number = g.Key, Count = g.Count() })
                            .Where(x => x.Count % 2 != 0)
                            .Select(x => x.Number)
                            .ToList();

        return counts;
    }

    static int IsValidSmile(string[] smiles)
    {
        string[] validSmiles = { ":)", ":D", ";)", ":-)", ":-D", ";D", ";~)", ";-D" };
        int count = smiles.Where(s => validSmiles.Contains(s)).Count();
        return count;
    }

    public static List<string> GetPermutations(string str)
    {
        List<string> result = new List<string>();
        char[] arr = str.ToCharArray();
        int n = arr.Length;
        
        int[] indices = new int[n];

        for (int i = 0; i < n; i++)
        {
            indices[i] = 0;
        }

        result.Add(new string(arr));

        int j = 0;

        while (j < n)
        {
            if (indices[j] < j)
            {
                if (j % 2 == 0)
                {
                    Swap(ref arr[0], ref arr[j]);
                }
                else
                {
                    Swap(ref arr[indices[j]], ref arr[j]);
                }

                result.Add(new string(arr));
                indices[j]++;
                j = 0;
            }
            else
            {
                indices[j] = 0;
                j++;
            }
        }

        return result;
    }

    private static void Swap(ref char a, ref char b)
    {
        char temp = a;
        a = b;
        b = temp;
    }



}