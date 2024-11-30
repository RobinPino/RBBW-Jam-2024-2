using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static Vector3 xy(Vector3 vector)
    {
        return new Vector3(vector.x, vector.y, 0);
    }

    public static Vector3 z(Vector3 vector)
    {
        return new Vector3(0, 0, vector.z);
    }

    public static Vector3 xz(Vector3 vector)
    {
        return new Vector3(vector.x, 0, vector.z);
    }

    public static void TryAdd<T>(List<T> list, T item)
    {
        if (!list.Contains(item))
        {
            list.Add(item);
        }
    }

    public static void TryRemove<T>(List<T> list, T item)
    {
        if (list.Contains(item))
        {
            list.Remove(item);
        }
    }

    public static int RandomSign()
    {
        return Random.Range(0, 2) * 2 - 1;
    }

    public static T RandomObjectFromRelFreq<T>(List<T> Objects) where T : HasRelativeFrequency
    {

        float TotalFrequency = 0;
        foreach (T Object in Objects)
        {
            TotalFrequency += Object.RelativeFrequency;
        }

        float randomValue = Random.Range(0, TotalFrequency);

        float currentFrequency = 0;
        T chosenObject = Objects[0]; //Default to first if we fail to get one

        foreach (T Object in Objects)
        {
            currentFrequency += Object.RelativeFrequency;
            if (randomValue < currentFrequency)
            {
                chosenObject = Object;
                break;
            }
        }

        return chosenObject;
    }

    public static IEnumerator AnimateFloat(float intensity, float duration, AnimationCurve curve, System.Action<float> changeFunction, float startValue)
    {
        float t = 0f;
        while (t < duration)
        {
            float value = curve.Evaluate(t / (duration * curve.keys[curve.keys.Length - 1].time)) * intensity;
            changeFunction?.Invoke(value + startValue);

            yield return new WaitForSeconds(0.01f);
            t += 0.01f;
        }
    }
    //Couldn't get this to work as IEnumerators can't be passed by reference.
}

public class HasRelativeFrequency
{
    public float RelativeFrequency;
}