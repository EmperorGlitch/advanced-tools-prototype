using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
            SceneManager.LoadSceneAsync(0);
        else if (Input.GetKeyUp(KeyCode.Alpha2))
            SceneManager.LoadSceneAsync(1);
        else if (Input.GetKeyUp(KeyCode.Alpha3))
            SceneManager.LoadSceneAsync(2);
        else if (Input.GetKeyUp(KeyCode.Alpha4))
            SceneManager.LoadSceneAsync(3);
        else if (Input.GetKeyUp(KeyCode.Alpha5))
            SceneManager.LoadSceneAsync(4);
        else if (Input.GetKeyUp(KeyCode.Alpha6))
            SceneManager.LoadSceneAsync(5);
        else if (Input.GetKeyUp(KeyCode.Alpha7))
            SceneManager.LoadSceneAsync(6);
    }
}