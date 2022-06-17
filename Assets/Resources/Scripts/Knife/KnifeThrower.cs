using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnifeThrower:MonoBehaviour
{
    [SerializeField] private Transform _pool;
    [SerializeField] private Transform _startTarget;

    private KnifeInit _currentKnife;
    private bool _knifeIsReady;
    private bool _isGameEnded;
    private Queue<KnifeInit> _queueKnife = new Queue<KnifeInit>();

    public Queue<KnifeInit> QueueKnife { get => _queueKnife; }
    public Transform StartTarget { get => _startTarget; }
    public Transform Pool { get => _pool; }

    public event UnityAction<KnifeThrower, bool> PoolEmpty;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _knifeIsReady && !_isGameEnded)
        {
            _currentKnife.KnifeMover.ThrowKnife();
            _knifeIsReady = false;
            ShowNextKnife();
        }
    }

    public void ShowNextKnife()
    {
        if (QueueKnife.Count == 0)
            return;
        _currentKnife = QueueKnife.Dequeue();
        if (QueueKnife.Count == 0)
            _currentKnife.ActivateKnife(isLast: true);
        else
            _currentKnife.ActivateKnife(isLast: false);
    }

    private void EndGame(bool isGoodEnd)
    {
        _isGameEnded = true;
        PoolEmpty?.Invoke(this, isGoodEnd);

    }


    public void OnCameOnStartPoint(bool isFinised, KnifeMover knifeMover)
    {
        _knifeIsReady = isFinised;
        knifeMover.CameOnStartPoint -= OnCameOnStartPoint;
    }
    public void OnHitAnowerKnife(KnifeTriggerHit knifeTriggerHit)
    {
        _knifeIsReady = false;
        QueueKnife.Clear();
        EndGame(false);
        knifeTriggerHit.HitAnowerKnife -= OnHitAnowerKnife;
    }

    public void OnHitWheell(KnifeTriggerHit knifeTriggerHit)
    {
        if (knifeTriggerHit.IsLast)
            EndGame(true);
    }
}
