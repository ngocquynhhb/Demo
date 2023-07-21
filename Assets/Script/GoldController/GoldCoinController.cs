using UnityEngine;

public class GoldCoinController : MonoBehaviour
{
    private void Update()
    {
        if (!IsVisibleOnScreen())
        {
            Destroy(gameObject);
        }
    }

    private bool IsVisibleOnScreen()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        return (viewportPosition.x > 0 && viewportPosition.x < 1 && viewportPosition.y > 0 && viewportPosition.y < 1);
    }
    public void CollectGold()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.IncreaseGold();
        }

        Destroy(gameObject);
    }
}
