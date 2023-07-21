using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float animationSpeed = 0.2f;
    private bool bossRaiAppeared = false; // Biến để kiểm tra BossRai đã xuất hiện hay chưa

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (!bossRaiAppeared) // Kiểm tra nếu BossRai chưa xuất hiện
        {
            meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
        }
    }

    public void BossRaiAppeared() // Phương thức để đặt bossRaiAppeared thành true
    {
        bossRaiAppeared = true;
    }
}

