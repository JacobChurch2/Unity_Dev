using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Weapon")]
public class WeaponData : ItemData
{
	[Header("Weapon")]
	public float fireRate;
	public Vector3 spread = Vector3.one * 0.1f;
	public int rounds;
	public GameObject ammoPrefab;
}
