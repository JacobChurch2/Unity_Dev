using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
	public virtual bool isEquipped { get; set; } = false;

	public virtual void Equip()
	{
		gameObject.SetActive(true);
		isEquipped = true;
	}

	public virtual void Unequip()
	{
		gameObject.SetActive(false);
		isEquipped = false;
	}

	public abstract ItemData GetData();
	public abstract bool isReady();
	public abstract void Use();
	public abstract void StopUse();
	public abstract void OnAnimEventItemUse();
}
