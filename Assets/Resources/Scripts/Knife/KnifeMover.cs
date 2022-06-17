using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class KnifeMover : MonoBehaviour
{
    private float _throwForce;
    [SerializeField] private float _startSpeed;

    private bool _isStarted;
    private Rigidbody2D _rigidbody2D;
    private Transform _startTarget;

    public bool IsStarted { get => _isStarted; set => _isStarted = value; }

    public event UnityAction<bool, KnifeMover> CameOnStartPoint;

    public void Init(float throwForce, Transform startTarget)
    {  
        _throwForce = throwForce;
        _startTarget = startTarget;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (IsStarted)
            TryToMoveToStartPoint();
    }
    public void TryToMoveToStartPoint()
    {
        if(transform.position!=_startTarget.position)
            transform.position = Vector3.MoveTowards(transform.position,_startTarget.position, _startSpeed * Time.deltaTime);
        else
        {
            IsStarted = false;
            CameOnStartPoint?.Invoke(true, this);
           
        }
    }

    public void ThrowKnife()
    {
        _rigidbody2D.AddForce(Vector2.up * _throwForce, ForceMode2D.Impulse);
    }
}
