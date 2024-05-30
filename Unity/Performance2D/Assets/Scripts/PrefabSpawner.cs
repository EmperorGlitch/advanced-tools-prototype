using System;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public static event Action<int> OnSpawn;
    [SerializeField] private GameObject prefab;
    [SerializeField] private int maxSpawnedPrefabsPerFrame;
    private bool isStarted;
    private int currentPrefabsCount;
    private int selectedPrefabsCount;
    private int prefabsCountIncrement;

    private float radius = 1;

    private void Start()
    {
        isStarted = false;
        prefabsCountIncrement = 100;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isStarted = true;

            selectedPrefabsCount += prefabsCountIncrement;

            radius += 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (prefabsCountIncrement < 10000)
                prefabsCountIncrement *= 10;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (prefabsCountIncrement > 100)
                prefabsCountIncrement /= 10;
        }

        if (isStarted && selectedPrefabsCount > currentPrefabsCount)
        {
            int spawnedCount = Mathf.Min(maxSpawnedPrefabsPerFrame, selectedPrefabsCount - currentPrefabsCount);

            for (int i = 0; i < spawnedCount; i++)
            {
                Vector3 position = new Vector3(radius * MathF.Cos(2 * (float)Math.PI * i / spawnedCount), 
                radius * MathF.Sin(2 * (float)Math.PI * i / spawnedCount), 0);

                Instantiate(prefab, position, Quaternion.identity);
                currentPrefabsCount++;
            }

            OnSpawn?.Invoke(currentPrefabsCount);
        }
    }
}
