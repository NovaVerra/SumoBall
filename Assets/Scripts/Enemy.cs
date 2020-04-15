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
		MovementManager();
	}

	void	MovementManager()
	{
		MoveTowardsPlayer();
	}

	void	MoveTowardsPlayer()
	{
		// standardize strength - normalize magnitude
		Vector3	ForwardMovement = (Player.transform.position - transform.position).normalized;
		RB_Enemy.AddForce(ForwardMovement * MoveSpeed * Time.deltaTime);
	}
}
