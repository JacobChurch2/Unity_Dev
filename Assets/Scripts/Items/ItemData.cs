using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
	EQUIPMENT,
	WEAPON,
	AMMO
}

public enum UsageType
{
	SINGLE,
	AUTO,
	BURST,
	STREAM
}

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
	[Header("Item")]
	public string id;
	public string description;
	public Sprite icon;
	public bool allowMultiple;
	public bool equipable;

	public UsageType usageType;
	
	public string animTriggerName;
	public string animEquipName;

	public float[] rigLayerWeight;
	
	public GameObject itemPrefab;
	public GameObject pickupPrefab;
}
