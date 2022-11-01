using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LeetCoteTests
{
    public class _3Sum
    {
        public int [] combinations = new int[3];
        public IList<IList<int>> list = new List<IList<int>>();
        public IList<IList<int>> ThreeSum(int[] nums)
        { 
            GenCombinations(0, 0, nums);

            for (int i = 0; i < list.Count; i++)
            {
                var arr = list[i];
                for (int j = i+1; j < list.Count; j++)
                {
                    var arr2 = list[j];
                    int both = arr.Intersect(arr2).Count();
                    var temp1 = new List<int>(arr).OrderBy(x => x).ToList();
                    var temp2 = new List<int>(arr2).OrderBy(x => x).ToList();
                    if (both == 3 || both != 0 && both != 3 && temp1[0] == temp2[0] && temp1[1] == temp2[1] && temp1[2] == temp2[2])
                    {
                        list.RemoveAt(j);
                        j--;
                        continue;
                    }
                }
            }
                return list;
        }

            private void GenCombinations(int idx, int elementStart, int[] nums)
            {
                if (idx >= combinations.Length)
                {
                if (combinations.Sum() == 0)
                {
                    list.Add(combinations.ToList());
                }
                    return;
                }
                for (int i = elementStart; i < nums.Length; i++)
                {
                    combinations[idx] = nums[i];
                    GenCombinations(idx + 1, i + 1, nums);
                }
               
            }
        
    }
}
