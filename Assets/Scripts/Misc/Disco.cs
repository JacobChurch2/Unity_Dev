using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disco : MonoBehaviour
{
    public Light discoLight;

    // Update is called once per frame
    void Update()
    {
        discoLight.color = Color.HSVToRGB(Random.value, 1.0f, 1.0f);
    }
}
