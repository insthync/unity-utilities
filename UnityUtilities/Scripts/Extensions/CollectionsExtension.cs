using System;
using System.Collections.Generic;

public static class CollectionsExtension
{
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        System.Random rnd = new System.Random();
        while (n > 1)
        {
            int k = (rnd.Next(0, n) % n);
            n--;
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static List<TValue> ToValuesList<TKey, TValue>(this IDictionary<TKey, TValue> list)
    {
        List<TValue> returnList = new List<TValue>();
        var enumerator = list.GetEnumerator();
        while (enumerator.MoveNext())
            returnList.Add(enumerator.Current.Value);
        return returnList;
    }

    public static string GetString<TKey, TValue>(this IDictionary<TKey, TValue> list, TKey key, string defaultValue = "")
    {
        TValue result;
        try
        {
            if (list.TryGetValue(key, out result))
                return Convert.ToString(result);
            else
                return defaultValue;
        }
        catch
        {
            return defaultValue;
        }
    }

    public static short GetShort<TKey, TValue>(this IDictionary<TKey, TValue> list, TKey key, short defaultValue = 0)
    {
        string resultString = GetString(list, key);
        short outResult = 0;
        if (short.TryParse(resultString, out outResult))
            return outResult;
        else
            return defaultValue;
    }

    public static int GetInt<TKey, TValue>(this IDictionary<TKey, TValue> list, TKey key, int defaultValue = 0)
    {
        string resultString = GetString(list, key);
        int outResult = 0;
        if (int.TryParse(resultString, out outResult))
            return outResult;
        else
            return defaultValue;
    }

    public static long GetLong<TKey, TValue>(this IDictionary<TKey, TValue> list, TKey key, long defaultValue = 0)
    {
        string resultString = GetString(list, key);
        long outResult = 0;
        if (long.TryParse(resultString, out outResult))
            return outResult;
        else
            return defaultValue;
    }

    public static float GetFloat<TKey, TValue>(this IDictionary<TKey, TValue> list, TKey key, float defaultValue = 0)
    {
        string resultString = GetString(list, key);
        float outResult = 0;
        if (float.TryParse(resultString, out outResult))
            return outResult;
        else
            return defaultValue;
    }

    public static double GetDouble<TKey, TValue>(this IDictionary<TKey, TValue> list, TKey key, double defaultValue = 0)
    {
        string resultString = GetString(list, key);
        double outResult = 0;
        if (double.TryParse(resultString, out outResult))
            return outResult;
        else
            return defaultValue;
    }

    public static bool GetBool<TKey, TValue>(this IDictionary<TKey, TValue> list, TKey key, bool defaultValue = false)
    {
        string resultString = GetString(list, key).ToLower();
        bool outResult = false;
        if (resultString.Equals("1"))
            resultString = "true";
        if (resultString.Equals("0"))
            resultString = "false";
        if (bool.TryParse(resultString, out outResult))
            return outResult;
        else
            return defaultValue;
    }
}