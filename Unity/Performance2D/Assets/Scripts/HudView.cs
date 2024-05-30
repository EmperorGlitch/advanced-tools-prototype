using UnityEngine;
using TMPro;

public class HudView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sceneText;
    [SerializeField] private TextMeshProUGUI prefabCountText;
    [SerializeField] private TextMeshProUGUI fpsText;

    public void UpdateSceneText(string sceneNane)
    {
        sceneText.SetText($"Scene: {sceneNane}");
    }

    public void UpdatePrefabCountText(int prefabCount)
    {
        prefabCountText.SetText($"Count: {prefabCount}");
    }

    public void UpdateFpsText(float currentFps)
    {
        fpsText.SetText($"FPS: {currentFps.ToString("0.0")}");
    }
}
