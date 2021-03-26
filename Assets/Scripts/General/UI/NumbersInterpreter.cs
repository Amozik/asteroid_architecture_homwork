using UnityEngine;

namespace General.UI
{
    public static class NumbersInterpreter
    {
        private static string[] _names = { "", "K", "M", "B", "T" };

        public static string Format(double number)
        {
            if (number == 0) return "0";

            number = Mathf.Round((float) number);
            
            var i = 0;
            while (i + 1 < _names.Length && number >= 1000d)
            {
                number /= 1000d;
                i++;
            }
            return $"{number:#.##}{_names[i]}" ;
        }
    }
}