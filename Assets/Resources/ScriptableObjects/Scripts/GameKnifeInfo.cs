using UnityEngine;


[CreateAssetMenu(fileName = "New GameInfo", menuName = "GameData", order = 51)]
public class GameKnifeInfo : ScriptableObject
{
    [SerializeField] private string _sceneName;
    [SerializeField] private string _nextSceneName;
    [SerializeField] private Knife _knife;
    [SerializeField] private int _knifeCapacity;
    [SerializeField] private Sprite _backGround;
    [SerializeField] private Sprite _wheelSprite;
    [SerializeField] private float _spinSpeed;

    public int KnifeCapacity { get => _knifeCapacity;}
    public Knife Knife { get => _knife; }
    public Sprite BackGround { get => _backGround; }
    public Sprite WheelSprite { get => _wheelSprite; }
    public float SpinSpeed { get => _spinSpeed; }
    public string SceneName { get => _sceneName; }
    public string NextSceneName { get => _nextSceneName;}
}
