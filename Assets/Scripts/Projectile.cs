using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Lifetime")]
    public float lifetime = 3f; // seconds before auto deactivate

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Launch(Vector3 direction, float speed)
    {
        // Reset physics before reuse
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Straight bullet
        rb.useGravity = false;
        rb.linearVelocity = direction * speed;

        CancelInvoke();
        Invoke(nameof(Deactivate), lifetime);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            // Notify game manager kill count
            GameManager.Instance.AddKill();
        }

        Deactivate();
    }
}
