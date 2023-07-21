using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab của đạn
    public float targetX = -7.27f; // Vị trí x của mục tiêu
    public float targetY = -3.91f; // Vị trí y của mục tiêu
    public float bulletSpeed = 10f; // Tốc độ của đạn
    public float fireInterval = 3f; // Khoảng thời gian giữa các lần bắn

    private void Start()
    {
        StartCoroutine(ShootBullets());
    }

    private IEnumerator ShootBullets()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireInterval);

            // Tạo đạn và thiết lập hướng di chuyển
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Vector3 targetPosition = new Vector3(targetX, targetY, transform.position.z);
            Vector3 direction = (targetPosition - transform.position).normalized;
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
        }
    }
}
