using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class COR : MonoBehaviour
{
    [SerializeField] float time = 3;
    [SerializeField] bool go = false;

    Coroutine timerCoroutine;

    void Start()
    {
        timerCoroutine = StartCoroutine(Timer(time));
        StartCoroutine("StoryTime");
        StartCoroutine(WaitAction());
    }

    void Update()
    {
        //time -= Time.deltaTime;
        //if (time < 0)
        //{
        //    time = 3;
        //    print("Tick");
        //}
    }

    IEnumerator Timer(float time)
    {
        while(true)
        {
            yield return new WaitForSeconds(time);
            //check perception
            print("Tick");
        }
        //yield return null;
    }

    IEnumerator StoryTime()
    {
        print("ello'");
        yield return new WaitForSeconds(2);
        print("Welcome to the new world");
        yield return new WaitForSeconds(2);
        print("Time to die!");

        StopCoroutine(timerCoroutine);
        yield return null;
    }

    IEnumerator WaitAction()
    {
        yield return new WaitUntil(() => go);
        print("go");
        yield return null;
    }
}
