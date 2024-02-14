using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Enemy
{
	[SerializeField] private Weapon weapon;
	[SerializeField] private float minFireRate;
	[SerializeField] private float maxFireRate;

	private void Start()
	{
		weapon.Equip();
		StartCoroutine("FireTimerCR");
	}

	IEnumerator FireTimerCR()
	{
		while (true)
		{
			float time = Random.Range(minFireRate, maxFireRate);
			yield return new WaitForSeconds(time);
			weapon.Use();
			weapon.StopUse();
		}
	}
}
