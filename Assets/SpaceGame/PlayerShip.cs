using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            inventory.Use();
        }
        if(Input.GetButtonUp("Fire1"))
        {
            inventory.StopUse();
        }
    }
}
