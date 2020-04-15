using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] float	MoveSpeed = 500.0f;
	Rigidbody	RB_Enemy;
	GameObject	Player;

	// Start is called before the first frame update
	void	Start()
	{
		GetAllComponents();
	}

	void	GetAllComponents()
	{
		RB_Enemy = GetComponent<Rigidbody>();
		Player = GameObject.Find("Player");
	}

	// Update is called once per frame
	void	Update()
	{
		// standardize strength - normalize magnitude
		RB_Enemy.AddForce((Player.transform.position - transform.position).normalized * MoveSpeed * Time.deltaTime);
	}
}
