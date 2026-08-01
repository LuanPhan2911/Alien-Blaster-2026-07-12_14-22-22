using System.Collections;
using UnityEngine;

public class KnockbackReceiver : MonoBehaviour
{

    private Rigidbody2D _rb;

    [SerializeField] private float _baseKnockbackForce = 10f;
    [SerializeField] private float _baseKnockbackDuration = 0.2f;


    public bool IsKnockbacked { get; private set; }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Knockback(Vector2 direction)
    {
        if (IsKnockbacked) return;
        float force = _baseKnockbackForce;
        float duration = _baseKnockbackDuration;
        StartCoroutine(KnockbackCoroutine(direction, force, duration));
    }
    public void Knockback(Vector2 direction, float force, float duration)
    {
        if (IsKnockbacked) return;
        StartCoroutine(KnockbackCoroutine(direction, force, duration));
    }

    private IEnumerator KnockbackCoroutine(Vector2 direction, float force, float duration)
    {

        IsKnockbacked = true;
        _rb.linearVelocity = Vector2.zero; // Reset current velocity

        _rb.AddForce(direction.normalized * force, ForceMode2D.Impulse);

        yield return new WaitForSeconds(duration);

        ResetKnockback();

    }


    private void ResetKnockback()
    {
        IsKnockbacked = false;
    }
}
