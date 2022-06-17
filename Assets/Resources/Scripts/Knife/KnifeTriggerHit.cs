using UnityEngine;
using UnityEngine.Events;

public class KnifeTriggerHit : MonoBehaviour
{

    public event UnityAction<KnifeTriggerHit> HitAnowerKnife;
    public event UnityAction<KnifeTriggerHit> HitWheel;

    private bool _isActive;
    private bool _isLast;

    public bool IsActive { get => _isActive; set => _isActive = value; }
    public bool IsLast { get => _isLast; set => _isLast = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitWheel?.Invoke(this);
        DeactivateKnife(collision);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (TryGetComponent( out KnifeInit knifeInit) && IsActive)
        {
            if (knifeInit)
            {
                HitAnowerKnife?.Invoke(this);
                DeactivateKnife(collision);
            }
        }
    }
    private void DeactivateKnife(Collider2D collision)
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        transform.parent = collision.transform;
        IsActive = false;
    }
    private void DeactivateKnife(Collision2D collision)
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        transform.parent = collision.transform;
        IsActive = false;
    }
}
