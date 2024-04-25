using UnityEngine;

public class RotationBehaviour3D : MonoBehaviour
{
    private float rotationSpeed = 2.0f;

    private void Start()
    {
        rotationSpeed = Random.Range(-10, 10f);
    }

    private void Update()
    {

        int randomAxis = Random.Range(0, 3);

        Vector3 rotationAxis = Vector3.zero;
        rotationAxis[randomAxis] = 1;

        float newRotation = rotationSpeed * Time.deltaTime;
        transform.Rotate(rotationAxis, newRotation);
    }
}
