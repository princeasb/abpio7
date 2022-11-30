namespace SchoolAut0mater
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;

    public static partial class StringExtensions
    {
        public static List<string> AddRanges(this List<string> items, List<string> nItems)
        {
            items.AddRange(nItems);
            return items;
        }

        public static string NullIfEmpty(this string s) => string.IsNullOrEmpty(s) ? null : s;
        public static string NullIfWhiteSpace(this string s) => string.IsNullOrWhiteSpace(s) ? null : s;

        // public static string Coalesce(params string[] strings) => strings.FirstOrDefault(s => !string.IsNullOrEmpty(s));    
        public static string Coalesce(this string str, params string[] strings) => (new[] { str }).Concat(strings).FirstOrDefault(s => !string.IsNullOrEmpty(s));

        /// <summary>
        /// Usage:
        /// string navigationTitle = model?.NavigationTitle.
        ///     Coalesce(() => RemoteTitleLookup(model?.ID)). // Expensive!
        ///     Coalesce(() => model?.DisplayName);
        /// </summary>
        /// <param name="s"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static string Coalesce(this string s, Func<string> func) => String.IsNullOrEmpty(s) ? func() : s;

        public static string OrDefault(this string str, string @default = default) => string.IsNullOrEmpty(str) ? @default : str;
        public static object OrDefault(this string str, object @default) => string.IsNullOrEmpty(str) ? @default : str;

        public static object IfNotSame(this object @this, object @new) => @this == null ? @new ?? default : @new == null && @this.Equals(@new) ? @new : @this;

        public static string RemoveWhiteSpaces(this string str) => new Regex(@"\s+").Replace(str ?? "", String.Empty);
        public static string RemoveNonAlphaNumeric(this string str) => new Regex(@"[^a-zA-Z0-9 -]").Replace(str ?? "", String.Empty);

        public static string ToAlphaNumericOnly(this string input) => new Regex("[^a-zA-Z0-9]").Replace(input ?? "", "");
        public static string ToAlphaOnly(this string input) => new Regex("[^a-zA-Z]").Replace(input ?? "", "");
        public static string ToNumericOnly(this string input) => new Regex("[^0-9]").Replace(input ?? "", "");
        public static string ToMobileNumber(this string[] input) => string.Join(",", input.Select(i => i.ToMobileNumber())).Trim(',');
        public static string ToMobileNumber(this string input) => new Regex("[^0-9-,]").Replace(input ?? "", "").Trim(',');


        public static Nullable<Guid> ToGuid(this string value)
        {
            if (String.IsNullOrEmpty(value)) { return null; }
            Guid id = default;
            if (Guid.TryParse(value, out id)) { return id; }
            return null;
        }

        public static string FormatWith(this string value, params object[] args) => String.Format(value, args);
        // public static string ToCamelCase(this string input) => Char.ToLowerInvariant(input[0]) + input[1..];
        public static string FromPascalCase(this string input) => Regex.Replace(input, "(\\B[A-Z])", " $1");
        public static string ToHumanFromPascal(this string s)
        {
            if (2 > s.Length) { return s; }
            var sb = new StringBuilder();
            var ca = s.ToCharArray();
            sb.Append(ca[0]);
            for (int i = 1; i < ca.Length - 1; i++)
            {
                char c = ca[i];
                if (char.IsUpper(c) && (char.IsLower(ca[i + 1]) || char.IsLower(ca[i - 1]))) { sb.Append(' '); }
                sb.Append(c);
            }
            sb.Append(ca[ca.Length - 1]);
            return sb.ToString();
        }

        /// <summary>
        /// ToTitleCase (upper-cases the first letter of each word)
        /// Use the current thread's culture info for conversion
        /// </summary>
        public static string ToTitleCase(this string str) => Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());

        /// <summary>
        /// ToTitleCase (upper-cases the first letter of each word)
        /// Overload which uses the culture info with the specified name
        /// </summary>
        public static string ToTitleCase(this string str, string cultureInfoName) => new CultureInfo(cultureInfoName).TextInfo.ToTitleCase(str.ToLower());

        /// <summary>
        /// ToTitleCase (upper-cases the first letter of each word)
        /// Overload which uses the specified culture info
        /// </summary>
        public static string ToTitleCase(this string str, CultureInfo cultureInfo) => cultureInfo.TextInfo.ToTitleCase(str.ToLower());


        //// Convert the string to Pascal case.
        //public static string ToPascalCase(this string the_string)
        //{
        //    // If there are 0 or 1 characters, just return the string.
        //    if (the_string == null) return the_string;
        //    if (the_string.Length < 2) return the_string.ToUpper();
        //
        //    // Split the string into words.
        //    string[] words = the_string.Split(
        //        new char[] { },
        //        StringSplitOptions.RemoveEmptyEntries);
        //
        //    // Combine the words.
        //    string result = "";
        //    foreach (string word in words) { result += word.Substring(0, 1).ToUpper() + word.Substring(1); }
        //
        //    return result;
        //}

        // Capitalize the first character and add a space before
        // each capitalized letter (except the first character).
        public static string ToProperCase(this string the_string)
        {
            // If there are 0 or 1 characters, just return the string.
            if (the_string == null) return the_string;
            if (the_string.Length < 2) return the_string.ToUpper();

            // Start with the first character.
            string result = the_string.Substring(0, 1).ToUpper();

            // Add the remaining characters.
            for (int i = 1; i < the_string.Length; i++)
            {
                if (char.IsUpper(the_string[i])) result += " ";
                result += the_string[i];
            }

            return result;
        }

        public static string TakeSingle(this string[] arr, int idx) => (arr.Length < idx + 1) ? default(string) : arr?[idx];
        public static decimal? ToDecimal(this string d)
        {
            if (string.IsNullOrEmpty(d)) { return null; }
            try { return (decimal?)Convert.ToDecimal(d); } catch { }
            return null;
        }

        public static List<int> SplitToIntList(this string list, char separator = ',')
        {
            int result = 0;
            return (from s in list.Split(separator)
                    let isint = int.TryParse(s, out result)
                    let val = result
                    where isint
                    select val).ToList();
        }
        public static int SplitAndSum(this string list, char separator = ',') => list.SplitToIntList(separator).Sum();

    }

    public static partial class StringExtensions
    {

        //public static string ToBase64Encode(this string plainText)
        //{
        //    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        //    return System.Convert.ToBase64String(plainTextBytes);
        //}

        //public static string ToBase64Decode(this string base64EncodedData)
        //{
        //    var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        //    return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        //}

        public static string ToBase64(this string text) => ToBase64(text, Encoding.UTF8);
        public static string ToBase64(this string text, Encoding encoding)
        {
            if (string.IsNullOrEmpty(text)) { return text; }
            byte[] textAsBytes = encoding.GetBytes(text);
            return Convert.ToBase64String(textAsBytes);
        }

        public static bool TryParseBase64(this string text, out string decodedText) => TryParseBase64(text, Encoding.UTF8, out decodedText);
        public static bool TryParseBase64(this string text, Encoding encoding, out string decodedText)
        {
            if (string.IsNullOrEmpty(text)) { decodedText = text; return false; }
            try
            {
                byte[] textAsBytes = Convert.FromBase64String(text);
                decodedText = encoding.GetString(textAsBytes);
                return true;
            }
            catch (Exception)
            {
                decodedText = null;
                return false;
            }
        }

        public static string GetRandomPassword(int length)
        {
            const string chars = "23456789abcdefhjkmnprstuvwxyzABCDEFGHJKMNPQRSTUVWXYZ";

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
        }
    }
}