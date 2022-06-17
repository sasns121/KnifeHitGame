using UnityEngine;

public abstract class Knife : ScriptableObject
{
    [SerializeField] private int _throwForce;
    [SerializeField] private Sprite _knifeSprite;

    public Sprite KnifeSprite { get => _knifeSprite;}
    public int ThrowForce { get => _throwForce;}
}
