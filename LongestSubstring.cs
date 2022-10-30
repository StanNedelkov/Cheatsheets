using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCoteTests
{
    public class LongestSubstring
    {
        public int LengthOfLongestSubstring(string s)
        {

            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            HashSet<char> hSet = new HashSet<char>();
            int max = 0;
            int i = 0;
            int j = 0;

            while (i < s.Length)
            {
                if (!hSet.Contains(s[i]))
                {
                    hSet.Add(s[i]);
                    i++;

                }
                else
                {
                    max = Math.Max(max, hSet.Count);
                    hSet.Remove(s[j]);
                    j++;
                }
            }
            max = Math.Max(max, hSet.Count);
            return max;

        }
    }
}

