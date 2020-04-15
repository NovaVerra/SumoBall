using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
	/** Game State */
	float	Level = 1;

	/** Game Config */
	[SerializeField] GameObject	Enemy;
	[SerializeField] Transform	Parent;
	float	SpawnRange = 9.0f;

	// Start is called before the first frame update
	void	Start()
	{
		SpawnEnemyWave(Level);
	}

	// Update is called once per frame
	void	Update()
	{
		
	}

	Vector3	GenerateSpawnPos()
	{
		float	X_SpawnPos = Random.Range(-SpawnRange, SpawnRange);
		float	Z_SpawnPos = Random.Range(-SpawnRange, SpawnRange);
		Vector3	SpawnPos = new Vector3(X_SpawnPos, 0.0f, Z_SpawnPos);
		return SpawnPos;
	}

	void	SpawnEnemy()
	{
		GameObject	EnemyInstance = Instantiate(Enemy, GenerateSpawnPos(), Quaternion.identity);
		EnemyInstance.transform.parent = Parent;
	}

	void	SpawnEnemyWave(float NumOfEnemies)
	{
		for (int Index = 0; NumOfEnemies < 3; Index++)
		{
			SpawnEnemy();
		}
		Level++;
	}
}
