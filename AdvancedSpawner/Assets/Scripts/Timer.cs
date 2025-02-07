using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public void DoActionRepeating(Action action, float timePeriod) =>
        StartCoroutine(DoActionRepeatingCoroutine(action, timePeriod));

    private IEnumerator DoActionRepeatingCoroutine(Action action, float timePeriod)
    {
        WaitForSeconds wait = new(timePeriod);
        bool isActive = true;

        while (isActive)
        {
            action?.Invoke();

            yield return wait;
        }
    }


}
