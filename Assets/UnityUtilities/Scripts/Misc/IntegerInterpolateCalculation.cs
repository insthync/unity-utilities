using UnityEngine;

[System.Serializable]
public class IntegerInterpolateCalculation
{
    public int maxLevel;
    public int minValue;
    public int maxValue;
    public float growthValue;

    public int[] GenerateValueArray()
    {
        int[] input = new int[maxLevel];
        for (int i = 0; i < input.Length; ++i)
        {
            int value = CalculateInterpolate(minValue, maxValue, i + 1, maxLevel, growthValue);
            input[i] = value;
        }
        return input;
    }

    public static int CalculateInterpolate(int min_attr, int max_attr, int current_level, int max_level, float growth_factor)
    {
        if (current_level < 1)
            current_level = 1;
        if (max_level < 2)
            max_level = 2;

        if (current_level > max_level)
        {
            return CalculateInterpolate(min_attr, max_attr, max_level, max_level, growth_factor);
        }
        else
        {
            return min_attr + Mathf.CeilToInt((max_attr - min_attr) * Mathf.Pow((float)(current_level - 1) / (float)(max_level - 1), growth_factor));
        }
    }
}
