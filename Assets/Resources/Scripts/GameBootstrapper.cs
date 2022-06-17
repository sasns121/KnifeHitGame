using UnityEngine;

public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
{
    public static GameBootstrapper Instance;

    [SerializeField] private GamesInfo _gamesInfo;
    [SerializeField] private LoadingCurtain _curtain;
    [SerializeField] private BackGroundInit _backGround;
    [SerializeField] private KnifeFactory _knifeFactory;
    [SerializeField] private WheellInit _wheel;
    [SerializeField] private HUD _hud;

    private SceneLoader _sceneLoader;
    private string _currentLoadingScene;

    private void Awake()
    {
        if (Instance != null)
        {
            Instance._currentLoadingScene =  Instance._sceneLoader.Load(Instance._gamesInfo.SceneNames[0], Instance._curtain, Instance.OnGameLoaded);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
        _gamesInfo.Init();
        _sceneLoader = new SceneLoader(this);
        _currentLoadingScene = _sceneLoader.Load(_gamesInfo.SceneNames[0], _curtain, OnGameLoaded);
    }

    private void OnGameLoaded()
    {
        KnifeFactory newKnifeFactory = Instantiate(_knifeFactory);
        newKnifeFactory.GameKnifeInfo = _gamesInfo.GameKnifeInfos[_currentLoadingScene];
        newKnifeFactory.KnifeThrower = newKnifeFactory.GetComponent<KnifeThrower>();
        newKnifeFactory.PoolInitialized += OnPoolInitialized;

        BackGroundInit newBackGround = Instantiate(_backGround);
        newBackGround.Init(newKnifeFactory.GameKnifeInfo.BackGround);

        WheellInit newWheel = Instantiate(_wheel);
        newWheel.Init(newKnifeFactory.GameKnifeInfo.WheelSprite, newKnifeFactory.GameKnifeInfo.SpinSpeed);

        HUD newHud = Instantiate(_hud);
        newKnifeFactory.KnifeThrower.PoolEmpty += newHud.ActivateEndGameScreen;
        newHud.AddButtonAction(OnReloadGame, OnLoadNextGame, OnExitGame);
        newHud.GetComponent<Canvas>().worldCamera = Camera.main;

        newKnifeFactory.InitializePool();
    }
    private void OnPoolInitialized(KnifeFactory knifeFactory)
    {
        _curtain.Hide();
        knifeFactory.PoolInitialized -= OnPoolInitialized;
    }
    
    public void OnLoadNextGame()
    {
        string nextSceneName = _gamesInfo.GameKnifeInfos[_currentLoadingScene].NextSceneName;
        if (nextSceneName == "MainMenu")
            _currentLoadingScene = _sceneLoader.Load(nextSceneName, _curtain, OnMainMenuLoaded);
        else
            _currentLoadingScene = _sceneLoader.Load(nextSceneName, _curtain, OnGameLoaded);   
    }
    public void OnReloadGame()
    {
        _currentLoadingScene = _sceneLoader.Load(_currentLoadingScene, _curtain, OnGameLoaded);
    }
    public void OnExitGame()
    {
        _currentLoadingScene = _sceneLoader.Load("MainMenu", _curtain, OnMainMenuLoaded);
    }
    private void OnMainMenuLoaded()
    {
        _curtain.Hide();
    }
}
