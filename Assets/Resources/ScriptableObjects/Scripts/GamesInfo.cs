using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New AllGameData", menuName = "AllGamesData", order = 54)]
public class GamesInfo : ScriptableObject
{
    [SerializeField] private Dictionary<string, GameKnifeInfo> _gameKnifeInfos=new Dictionary<string, GameKnifeInfo>();
    [SerializeField] private GameKnifeInfo[] _gameKnifeInfosList;

    private string[] _sceneNames;

    public void Init()
    {
        _sceneNames = new string[_gameKnifeInfosList.Length];
        for (int i = 0; i < _gameKnifeInfosList.Length; i++)
        {
            _sceneNames[i] = _gameKnifeInfosList[i].SceneName;
            _gameKnifeInfos.Add(SceneNames[i], _gameKnifeInfosList[i]);
        }
    }
    public Dictionary<string, GameKnifeInfo> GameKnifeInfos { get => _gameKnifeInfos;}
    public string[] SceneNames { get => _sceneNames; }
}
