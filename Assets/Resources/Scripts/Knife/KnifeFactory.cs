using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(KnifeThrower))]
public class KnifeFactory : MonoBehaviour
{
    [SerializeField] private KnifeInit _knifeTamplate;
    private GameKnifeInfo _gameKnifeInfo;

    private KnifeThrower _knifeThrower;

    public GameKnifeInfo GameKnifeInfo { get => _gameKnifeInfo; set => _gameKnifeInfo = value; }
    public KnifeThrower KnifeThrower { get => _knifeThrower; set => _knifeThrower = value; }

    public event UnityAction<KnifeFactory> PoolInitialized;

    public void InitializePool()
    {
        
        for (int i = 0; i < GameKnifeInfo.KnifeCapacity; i++)
        {
            KnifeInit newKnife = Instantiate(_knifeTamplate, KnifeThrower.Pool);
            newKnife.Init(GameKnifeInfo.Knife.KnifeSprite, GameKnifeInfo.Knife.ThrowForce, KnifeThrower.StartTarget);
            KnifeThrower.QueueKnife.Enqueue(newKnife);
            newKnife.gameObject.SetActive(false);
            newKnife.KnifeMover.CameOnStartPoint += KnifeThrower.OnCameOnStartPoint;
            newKnife.KnifeTriggerHit.HitAnowerKnife += KnifeThrower.OnHitAnowerKnife;
            newKnife.KnifeTriggerHit.HitWheel += KnifeThrower.OnHitWheell;
        }
        PoolInitialized?.Invoke(this);
        KnifeThrower.ShowNextKnife();
    }
}
