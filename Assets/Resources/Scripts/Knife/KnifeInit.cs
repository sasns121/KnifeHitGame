using UnityEngine;

[RequireComponent(typeof(KnifeMover))]
[RequireComponent(typeof(KnifeViewer))]
[RequireComponent(typeof(KnifeTriggerHit))]
public class KnifeInit : MonoBehaviour
{

    private KnifeViewer _knifeViewer;
    private KnifeMover _knifeMover;
    private KnifeTriggerHit _knifeTriggerHit;
  
    public KnifeMover KnifeMover { get => _knifeMover; }
    public KnifeTriggerHit KnifeTriggerHit { get => _knifeTriggerHit; }

    public void Init(Sprite sprite,float Force,Transform startTarget)
    {
        _knifeViewer = GetComponent<KnifeViewer>();
        _knifeMover = GetComponent<KnifeMover>();
        _knifeTriggerHit = GetComponent<KnifeTriggerHit>();
        _knifeViewer.Init(sprite);
        _knifeMover.Init(Force, startTarget);
    }
    public void ActivateKnife(bool isLast)
    {
        gameObject.SetActive(true);
        _knifeMover.IsStarted = true;
        _knifeTriggerHit.IsActive = true;
        _knifeTriggerHit.IsLast = isLast;
    }
}
