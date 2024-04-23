using UnityEngine;

public class FpsController : MonoBehaviour
{
    [SerializeField] private FpsView view;
    [SerializeField] private float fpsUpdateCooldownInSeconds = .5f;
    private float currentFps = 60f;
    private float timeSinceLastUpdate = 10f;

    private void Start()
    {
        PrefabSpawner.OnSpawn += UpdatePrefabCount;
    }

    private void Update()
    {
        currentFps = Mathf.Lerp(currentFps, 1f / Mathf.Max(.0001f,Time.smoothDeltaTime), .01f);
        timeSinceLastUpdate += Time.deltaTime;

        if (timeSinceLastUpdate >= fpsUpdateCooldownInSeconds)
            timeSinceLastUpdate = 0;
        else 
            return; 

        view.UpdateFpsText(currentFps);
    }

    private void UpdatePrefabCount(int prefabCount)
    {
        view.UpdatePrefabCountText(prefabCount);
    }
}
