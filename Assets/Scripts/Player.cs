using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
	[SerializeField] TMP_Text scoreText;
	[SerializeField] TMP_Text gameOverScoreText;
	[SerializeField] FloatVariable health;
	[SerializeField] PhysicCharacterController characterController;
	[SerializeField] GameObject deathPrefab = null;

	[Header("Events")]
	[SerializeField] IntEvent scoreEvent = default;
	[SerializeField] VoidEvent playerDeadEvent;

	private int score = 0;

	public int Score
	{
		get { return score; }
		set
		{
			score = value;
			scoreText.text = score.ToString();
			scoreEvent.RaiseEvent(score);
		}
	}

	private void OnEnable()
	{
		//characterController.enabled = false;
	}

	private void Start()
	{
		//health.value = 50;
	}

	public void AddPoints(int points)
	{
		Score += points;
	}

	public void TakeDamage(float damage)
	{
		health.value -= damage;
		GetComponent<AudioSource>().Play();
		if (health.value < -0)
		{
			playerDeadEvent.RaiseEvent();
			//characterController.enabled = false;
			Instantiate(deathPrefab, transform.position, Quaternion.identity);

		}
	}

	public void Heal(float healAmount)
	{
		health.value += healAmount;
		Math.Clamp(health.value, 0, 100);
	}

	public void OnRespawn(GameObject respawn)
	{
		characterController.enabled = true;
		transform.position = respawn.transform.position;
		transform.rotation = respawn.transform.rotation;
		characterController.Reset();
	}

	public void GameOver()
	{
		gameOverScoreText.text = "Points: " + score.ToString();
		characterController.enabled = false;
		characterController.Reset();
	}
}
