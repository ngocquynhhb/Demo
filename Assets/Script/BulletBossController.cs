using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBossController : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

}
