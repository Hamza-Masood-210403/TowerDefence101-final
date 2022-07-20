using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class BossMovement : MonoBehaviour
{

	public Transform target;
	public static int bossWavepointIndex = 0;
	private Enemy enemy;

	void Start()
	{
		bossWavepointIndex = 0;
		enemy = GetComponent<Enemy>();
		target = Waypoints.points[0];
		//transform.position = transform.position + new Vector3(0, , 0);
		transform.rotation = Quaternion.Euler(new Vector3(90, 180, 0));
	}

	void Update()
	{
		Vector3 dir = target.position - transform.position + new Vector3(0,10.1f,0);
		transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 10.2f)
		{
			GetNextWaypoint();
		}

		enemy.speed = enemy.startSpeed;
	}

	void GetNextWaypoint()
	{
		if (bossWavepointIndex >= Waypoints.points.Length - 1)
		{
			EndPath();
			return;
		}

		bossWavepointIndex++;
		target = Waypoints.points[bossWavepointIndex];
		if (bossWavepointIndex == 1 || bossWavepointIndex == 3 || bossWavepointIndex == 7 || bossWavepointIndex == 9 || bossWavepointIndex == 11)
		{
			transform.rotation = Quaternion.Euler(new Vector3(90, 180, 0));
		}
		if (bossWavepointIndex == 2 || bossWavepointIndex == 8 || bossWavepointIndex == 10)
		{
			transform.rotation = Quaternion.Euler(new Vector3(90, 270, 0));
		}
		if (bossWavepointIndex == 4 || bossWavepointIndex == 6 || bossWavepointIndex == 12)
		{
			transform.rotation = Quaternion.Euler(new Vector3(90, 90, 0));
		}
		if (bossWavepointIndex == 5 || bossWavepointIndex == 13)
		{
			transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
		}
	}

	void EndPath()
	{
		PlayerStats.Lives--;
		WaveSpawner.EnemiesAlive--;
		Destroy(gameObject);
	}

}