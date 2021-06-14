using UnityEngine;

namespace GenerationGirl
{
	public class ColumnPool : MonoBehaviour
	{
		public GameObject columnPrefab;
		public int columnPoolSize = 5;
		public float spawnRate = 3f;
		public float columnMin = -1f;
		public float columnMax = 3.5f; 

		private GameObject[] columns;
		private int currentColumn = 0;

		private Vector2 objectPoolPosition = new Vector2(-15, -25);
		public float spawnXPosition = 10f;
		private float spawnYPosition => Random.Range(columnMin, columnMax);

		private float timeSinceLastSpawned;

		private void Start()
		{
			timeSinceLastSpawned = 0f;
			CreatePool();
		}

		private void CreatePool()
		{
			columns = new GameObject[columnPoolSize];
			for (int i = 0; i < columnPoolSize; i++)
			{
				columns[i] = Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
			}
		}

		private void Update()
		{
			timeSinceLastSpawned += Time.deltaTime;

			if (GameManager.instance.isGameOver == false && timeSinceLastSpawned >= spawnRate)
			{
				timeSinceLastSpawned = 0f;

				columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);

				currentColumn++;

				if (currentColumn >= columnPoolSize)
				{
					currentColumn = 0;
				}
			}
		}
	}
}
