using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] float	MoveSpeed = 1000.0f;
	Rigidbody	RB_Player;

	// Start is called before the first frame update
	void	Start()
	{
		GetAllComponents();
	}

	void	GetAllComponents()
	{
		RB_Player = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void	Update()
	{
		InputManager();
	}

	void	InputManager()
	{
		ForwardHandler();
	}

	void	ForwardHandler()
	{
		float	ForwardInput = Input.GetAxis("Vertical");
		RB_Player.AddForce(Vector3.forward * ForwardInput * MoveSpeed * Time.deltaTime);
	}
}
