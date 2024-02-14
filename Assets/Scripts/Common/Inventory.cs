using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] Item[] items;
    public Item currentItem {  get; private set; }
    private int itemIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentItem = items[itemIndex];
        currentItem.Equip();
    }

    public void Use()
    {
        currentItem?.Use();
    }

    public void StopUse()
    {
        currentItem?.StopUse();
    }

    public void nextItem()
    {
        if (itemIndex < items.Length - 1) 
        {
            itemIndex++;
        }
        else
        {
            itemIndex = 0;    
        }
        currentItem = items[itemIndex];
        currentItem.Equip();
    }

}
