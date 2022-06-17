using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class KnifeViewer : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    public void Init(Sprite sprite){
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = sprite;
    }
}
