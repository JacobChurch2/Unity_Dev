using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Interactable
{
    [SerializeField] Action action;
    [SerializeField] private Inventory inventory;

	public float health = 100;

	private void Start()
	{
		if(action != null)
        {
			action.onEnter += OnInteractStart;
			action.onStay += OnInteractActive;
        }
	}

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
	public override void OnInteractActive(GameObject gameObject)
	{
		//
	}

	public override void OnInteractEnd(GameObject gameObject)
	{
		//
	}

	public override void OnInteractStart(GameObject gameObject)
	{
		//
	}

}
