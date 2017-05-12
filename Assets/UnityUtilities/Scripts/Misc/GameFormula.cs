using UnityEngine;

public static class GameFormula
{
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
