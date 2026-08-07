using UnityEngine;

public class BrickBreakParticle : MonoBehaviour
{




    private void Start()
    {
        float duration = GetComponent<ParticleSystem>().main.duration;

        Destroy(gameObject, duration);
    }
}
