using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] float	MoveSpeed = 1000.0f;
	GameObject	FocalPoint;
	Rigidbody	RB_Player;

	// Start is called before the first frame update
	void	Start()
	{
		GetAllComponents();
	}

	void	GetAllComponents()
	{
		RB_Player = GetComponent<Rigidbody>();
		FocalPoint = GameObject.Find("FocalPoint");
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
		RB_Player.AddForce(FocalPoint.transform.forward * ForwardInput * MoveSpeed * Time.deltaTime);
	}
}
