using System.Collections;
using UnityEngine;

public class OneWayPlatformPassThrough : MonoBehaviour
{
    [SerializeField] private Collider2D _platformCollider;



    public void PassThrough(Collider2D playerColider, float duration)
    {
        StartCoroutine(PassThroughCoroutine(playerColider, duration));
    }

    private IEnumerator PassThroughCoroutine(Collider2D playerColider, float duration)
    {
        Physics2D.IgnoreCollision(playerColider, _platformCollider, true);

        yield return new WaitForSeconds(duration);

        Physics2D.IgnoreCollision(playerColider, _platformCollider, false);

    }


}