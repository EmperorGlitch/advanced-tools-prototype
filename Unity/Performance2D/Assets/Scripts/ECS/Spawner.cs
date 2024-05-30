using Unity.Entities;

public struct Spawner : IComponentData
{
    public Entity prefab;
    public double spawnRate;
    public double nextSpawn;
    public bool isStarted;
    public int currentPrefabsCount;
    public int selectedPrefabsCount;
    public int prefabsCountIncrement;
    public float radius;
}