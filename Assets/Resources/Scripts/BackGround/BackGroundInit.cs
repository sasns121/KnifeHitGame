using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BackGroundInit : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    public void Init(Sprite backGroundSprite)
    {
        _spriteRenderer=GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = backGroundSprite;
    }
}
