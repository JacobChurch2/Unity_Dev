using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Animations.Rigging;

public class Weapon : Item
{
	[SerializeField] WeaponData weaponData;
	[SerializeField] Animator animator;
	//[SerializeField] RigBuilder rigBuilder;
	[SerializeField] Transform ammoTransform;

	private int ammoCount = 0;
	private bool weaponReady = false;

	private IEnumerator autoFireCoroutine;

	private void Start()
	{
		autoFireCoroutine = AutoFire();
		if (ammoTransform == null) ammoTransform = transform;
	}

	public override ItemData GetData() {  return weaponData; }

	public override void Equip()
	{
		base.Equip();
		weaponReady = true;
		if (weaponData.animEquipName != "") animator.SetBool(weaponData.animEquipName, true);
		for(int i = 0; i < weaponData.rigLayerWeight.Length; i++)
		{
			//rigBuilder.layers[i].rig.weight = weaponData.rigLayerWeight[i];
		}
	}

	public override void Unequip()
	{
		base.Unequip();
		if (weaponData.animEquipName != "") animator.SetBool(weaponData.animEquipName, false);
	}

	public override void Use()
	{
		if (!weaponReady) return;

		// trigger weapon animation if trigger name set and animator exists
		// ammo will be created through animation event
		if (weaponData.animTriggerName != "" && animator != null) 
		{ 
			animator.SetTrigger(weaponData.animTriggerName);
			weaponReady = false;
		}
		else
		{
			// create ammo prefab
			if (weaponData.usageType == UsageType.SINGLE || weaponData.usageType == UsageType.BURST)
			{
				Instantiate(weaponData.ammoPrefab, ammoTransform.position, ammoTransform.rotation);
				if (weaponData.fireRate > 0)
				{
					weaponReady = false;
					StartCoroutine(ResetFireTimer());
				}
			}
			else
			{
				StartCoroutine(autoFireCoroutine);
			}
		}
	}

	public override void StopUse()
	{
		if (weaponData.usageType == UsageType.SINGLE || weaponData.usageType == UsageType.BURST) weaponReady = true;
		StopCoroutine(autoFireCoroutine);

	}

	public override bool isReady()
	{
		// check if ammo exists or weapon does not have rounds
		return weaponReady && (ammoCount > 0 || weaponData.rounds == 0);
	}

	public override void OnAnimEventItemUse()
	{
		// create ammo prefab
		Instantiate(weaponData.ammoPrefab, ammoTransform.position, ammoTransform.rotation);
	}

	IEnumerator ResetFireTimer()
	{
		yield return new WaitForSeconds(weaponData.fireRate);
		weaponReady = true;
	}

	IEnumerator AutoFire()
	{
		while (true)
		{
			Instantiate(weaponData.ammoPrefab, ammoTransform.position, ammoTransform.rotation);
			yield return new WaitForSeconds(weaponData.fireRate);
		}
	}
}
