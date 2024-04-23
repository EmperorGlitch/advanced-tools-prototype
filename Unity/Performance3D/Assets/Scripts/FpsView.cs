using UnityEngine;
using TMPro;

public class FpsView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI prefabCountText;
    [SerializeField] private TextMeshProUGUI fpsText;

    public void UpdatePrefabCountText(int prefabCount)
    {
        prefabCountText.SetText($"Count: {prefabCount}");
    }

    public void UpdateFpsText(float currentFps)
    {
        fpsText.SetText($"FPS: {currentFps.ToString("0.0")}");
    }
}
