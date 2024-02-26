namespace App.Users.Data
{
    public class Class1Test
    {
        Dictionary<string, int> dic = new Dictionary<string, int>();
        public void test()
        {
            var vv =new string[] { "dog", "racecar", "car" };

            var result = LongestCommonPrefix(vv);
            Console.WriteLine(result);

        }
        public string LongestCommonPrefix(string[] strs)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (string item in strs)
            {
                if (string.IsNullOrEmpty(item))
                {
                    return "";
                }
                
                for (int i = 0; i < item.Length; i++)
                {
                    
                    for (int j = i + 2; j <= item.Length; j++)
                    {
                        string result = "";
                        result += item.Substring(i, j - i); ;
                        if (dic.ContainsKey(result))
                        {
                            dic[result]++;
                        }
                        else
                        {
                            dic.Add(result, 1);
                        }
                    }
                }
            }
            var max = dic
            .Where(kvp => !strs.Contains(kvp.Key)) // 排除在字符串数组中的键
            .OrderByDescending(kvp => kvp.Value)
            .ThenByDescending(kvp => kvp.Key.Length)
            .FirstOrDefault();
            var min = dic.Aggregate((l, r) => l.Value < r.Value ? l : r);
            if (max.Value != min.Value && max.Key != min.Key)
            {
                return max.Key;
            }
            else if (max.Key == min.Key)
            {
                return max.Key;
            }
            return "";
        }
    }
}