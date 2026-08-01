using UnityEngine;

public class RotationY : MonoBehaviour
{

    [SerializeField] private float rotationSpeed = 100f;


    private void Update()
    {
        // rotation y axis from 0 to 360 degrees with lerp
        float t = Mathf.PingPong(Time.time * rotationSpeed / 360f, 1f);

        float rotationY = Mathf.Lerp(0f, 360f, t);

        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
    }
}
