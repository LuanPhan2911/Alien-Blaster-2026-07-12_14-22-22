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

    public void ReceiveKnockback(Vector2 direction, float force, float duration)
    {
        if (IsKnockbacked) return;
        IsKnockbacked = true;
        _rb.linearVelocity = Vector2.zero; // Reset current velocity
        Debug.Log(direction.normalized * force);
        _rb.AddForce(direction.normalized * force, ForceMode2D.Impulse);
        Invoke(nameof(ResetKnockback), duration);
    }
    public void ReceiveKnockback(Vector2 direction)
    {
        ReceiveKnockback(direction, _baseKnockbackForce, _baseKnockbackDuration);
        Invoke(nameof(ResetKnockback), _baseKnockbackDuration);
    }



    private void ResetKnockback()
    {
        IsKnockbacked = false;
    }
}
