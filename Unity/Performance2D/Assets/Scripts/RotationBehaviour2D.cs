using UnityEngine;

public class RotationBehaviour2D : MonoBehaviour
{
    private float rotationSpeed = 2.0f;

    private void Start()
    {
        rotationSpeed = Random.Range(-10, 10f);
    }

    private void Update()
    {
        float currentRotation = transform.eulerAngles.z;
        float newRotation = currentRotation + (rotationSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Euler(0, 0, newRotation);
    }
}
