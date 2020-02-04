using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Commons
{
    public static IEnumerator DelayedAction(UnityAction lambda, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        lambda.Invoke();
    }
    
    public static IEnumerator DelayedNextFrame(UnityAction lambda)
    {
        yield return new WaitForEndOfFrame();
        lambda.Invoke();
    }
}