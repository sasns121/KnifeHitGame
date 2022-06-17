using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeelSpinner))]
public class WheellInit : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private WeelSpinner _weelSpinner;
    public void Init(Sprite wheelSprite, float speenSpeed)
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _weelSpinner = GetComponent<WeelSpinner>();
        _spriteRenderer.sprite = wheelSprite;
        _weelSpinner.SpinSpeed = speenSpeed;
    }
}
