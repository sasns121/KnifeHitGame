using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Button[] _restarts;
    [SerializeField] private Button[] _nexts;
    [SerializeField] private Button[] _quits;
    [SerializeField] private GameObject _EndGameScreenContainer;
    [SerializeField] private GameObject _LoseGameScreenContainer;

    public void ActivateEndGameScreen(KnifeThrower knifeThrower,bool isGoodEnd)
    {
        if(isGoodEnd)
            StartCoroutine(DoFadeIn(_EndGameScreenContainer));
        else
            StartCoroutine(DoFadeIn(_LoseGameScreenContainer));
        knifeThrower.PoolEmpty -= ActivateEndGameScreen;
    }

    public void AddButtonAction(UnityAction restart, UnityAction next, UnityAction quit)
    {
        foreach(Button restartBut in _restarts)
            restartBut.onClick.AddListener(restart);
        foreach (Button nextBut in _nexts)
            nextBut.onClick.AddListener(next);
        foreach (Button quitBut in _quits)
            quitBut.onClick.AddListener(quit);
    }
    private IEnumerator DoFadeIn(GameObject screen)
    {
        CanvasGroup canvasGroup= screen.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        screen.SetActive(true);
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += 0.1f;
            yield return new WaitForSeconds(0.03f);
        }

    }
}
