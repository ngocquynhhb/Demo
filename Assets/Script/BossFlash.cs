using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFlash : MonoBehaviour
{
    [SerializeField] private SimpleFlash flashEffect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            flashEffect.Flash();
        }
    }
}
