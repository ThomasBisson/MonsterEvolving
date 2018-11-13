using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathUtils : MonoBehaviour {

    #region CONVERTIONS
    public static long MapUlongToLong(ulong ulongValue)
    {
        return unchecked((long)ulongValue + long.MinValue);
    }

    public static ulong MapLongToUlong(long longValue)
    {
        return unchecked((ulong)(longValue - long.MinValue));
    }
    #endregion

    #region PERCENT_CALCUL
    public static float PercentValueFromAnotherValue(float value, float total)
    {
        return ((value * 100f) / total) / 100f;
    }

    public static int PercentValueFromAnotherValue(int value, int total)
    {
        return ((value * 100) / total) / 100;
    }

    public static uint PercentValueFromAnotherValue(uint value, uint total)
    {
        return ((value * 100) / total) / 100;
    }

    public static long PercentValueFromAnotherValue(long value, long total)
    {
        return ((value * 100) / total) / 100;
    }

    public static ulong PercentValueFromAnotherValue(ulong value, ulong total)
    {
        return ((value * 100) / total) / 100;
    }

    public static int PercentValue(int percent, int total)
    {
        return (percent/100) * total;
    }
    #endregion
}
