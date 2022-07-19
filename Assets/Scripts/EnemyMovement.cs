using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

	private Transform target;
	private int wavepointIndex = 0;
	private Enemy enemy;

	void Start()
	{
		enemy = GetComponent<Enemy>();
		target = Waypoints.points[0];
		transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
	}

	void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}

		enemy.speed = enemy.startSpeed;
	}

	void GetNextWaypoint()
	{
		if (wavepointIndex >= Waypoints.points.Length - 1)
		{
			EndPath();
			return;
		}

		wavepointIndex++;
		target = Waypoints.points[wavepointIndex];
		if (wavepointIndex == 1|| wavepointIndex == 3 || wavepointIndex == 7 || wavepointIndex == 9 || wavepointIndex == 11)
		{
			transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
		}
		if (wavepointIndex == 2 || wavepointIndex == 8 || wavepointIndex == 10)
		{
			transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
		}
		if (wavepointIndex == 4 || wavepointIndex == 6 || wavepointIndex == 12)
		{
			transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
		}
		if (wavepointIndex == 5 || wavepointIndex == 13)
		{
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
		}
	}

	void EndPath()
	{
		PlayerStats.Lives--;
		WaveSpawner.EnemiesAlive--;
		Destroy(gameObject);
	}

}
