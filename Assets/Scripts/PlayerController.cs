using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	/** Game State*/
	bool	b_HasPowerUp = false;

	/** Game Config */
	[SerializeField] float	MoveSpeed = 1000.0f;
	[SerializeField] float	PowerupStrength = 10.0f;
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

	void	OnTriggerEnter(Collider TriggerObject)
	{
		if (TriggerObject.CompareTag("Powerup"))
		{
			b_HasPowerUp = true;
			Destroy(TriggerObject.gameObject);
			StartCoroutine(PowerupCountdownRoutine());
		}
	}

	IEnumerator	PowerupCountdownRoutine()
	{
		yield return new WaitForSeconds(4);
		b_HasPowerUp = false;
	}

	void	OnCollisionEnter(Collision CollisionObject)
	{
		if (CollisionObject.gameObject.CompareTag("Enemy") && b_HasPowerUp)
		{
			Rigidbody	RB_Enemy = CollisionObject.gameObject.GetComponent<Rigidbody>();
			Vector3		AwayFromPlayer = CollisionObject.gameObject.transform.position - transform.position;

			RB_Enemy.AddForce(AwayFromPlayer * PowerupStrength, ForceMode.Impulse);
			Debug.Log("Collided with " + gameObject.name + " with power up set to " + b_HasPowerUp);
		}
	}
}
