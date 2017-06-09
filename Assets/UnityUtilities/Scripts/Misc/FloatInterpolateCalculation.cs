using UnityEngine;

[System.Serializable]
public class FloatInterpolateCalculation
{
    public int maxLevel;
    public float minValue;
    public float maxValue;
    public float growthValue;

    public float[] GenerateValueArray()
    {
        float[] input = new float[maxLevel];
        for (int i = 0; i < input.Length; ++i)
        {
            float value = CalculateInterpolate(minValue, maxValue, i + 1, maxLevel, growthValue);
            input[i] = value;
        }
        return input;
    }

    public static float CalculateInterpolate(float min_attr, float max_attr, int current_level, int max_level, float growth_factor)
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
            return min_attr + ((max_attr - min_attr) * Mathf.Pow((float)(current_level - 1) / (float)(max_level - 1), growth_factor));
        }
    }
}
