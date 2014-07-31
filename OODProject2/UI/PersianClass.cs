using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProject_2_.UI
{
    public static class PersianClass
    {
        /// <summary>
        /// متدی برای تبدیل اعداد انگلیسی به فارسی
        /// </summary>
        public static string ToPersianNumber(this string input)
        {
            if (input.Trim() == "") return "";

            //۰ ۱ ۲ ۳ ۴ ۵ ۶ ۷ ۸ ۹
            input = input.Replace("0", "۰");
            input = input.Replace("1", "۱");
            input = input.Replace("2", "۲");
            input = input.Replace("3", "۳");
            input = input.Replace("4", "۴");
            input = input.Replace("5", "۵");
            input = input.Replace("6", "۶");
            input = input.Replace("7", "۷");
            input = input.Replace("8", "۸");
            input = input.Replace("9", "۹");
            return input;
        }
    }
}
