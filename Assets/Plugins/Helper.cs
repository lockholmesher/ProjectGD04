using UnityEngine;
using System.Collections.Generic;
public class Helper
{
    public static float NormalizeAngle(float angle)
    {        
        angle = angle % 360;
        if(angle < 0)angle += 360;
        return angle;
    }

    public static bool RollRate(float rate)
    {
        return Random.Range(0, 101) <= rate;
    }

    public static T[] GetRandomInList<T>(List<T> list, int number)
    {
        T[] temp = list.ToArray();
        for (int t = 0; t < temp.Length; t++ )
        {
            T tmp = temp[t];
            int r = Random.Range(t, temp.Length);
            temp[t] = temp[r];
            temp[r] = tmp;
        }

        T[] result = new T[number];
        int count = number < temp.Length ? number : temp.Length;
        for(int i = 0; i < count; i++)
        {
            result[i] = temp[i];
        }
        return result;
    }

    public static float AngleFromToBy0D(float fromX, float fromY, float toX, float toY)
    {
        float angle = 0;
        float x = toX - fromX;
        float y = toY - fromY;
        angle = Mathf.Atan2(y, x) *  Mathf.Rad2Deg;

        return angle;
    }
}