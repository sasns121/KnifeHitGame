using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader 
{
    private readonly ICoroutineRunner _coroutineRunner;

    public SceneLoader(ICoroutineRunner coroutineRunner) =>
        _coroutineRunner = coroutineRunner;

    public string Load(string name, LoadingCurtain curtain, Action onLoaded = null)
    {
        _coroutineRunner.StartCoroutine(LoadScene(name, curtain, onLoaded));
        return name;
    }

    public IEnumerator LoadScene(string name, LoadingCurtain curtain, Action onLoaded = null)
    {
        curtain.Show();
        AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);
        yield return new WaitUntil(() => waitNextScene.isDone);
        onLoaded?.Invoke();
    }
}
