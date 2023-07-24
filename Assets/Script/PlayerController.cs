using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IDataPresistent
{
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    private bool isJumping = false;
    public Text napdan;

    public BulletPooling bulletPool;

    public float bulletForce = 15f;

    public GameObject bulletPosition;

    public Animator animator;
    [SerializeField] private SimpleFlash flashEffect;

    public int shotsFired = 0; // Số lượng đạn đã bắn
    public int shotsPerReload = 5; // Số lượng đạn cần bắn trước khi nạp lại
    public float reloadTime = 3f; // Thời gian nạp đạn (giây)
    public GameObject reloadIndicator; // Chỉ báo nạp đạn

    private bool isReloading = false; // Đang nạp đạn
    private bool canShoot = true;

    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FireBullet()
    {
        
        if (isReloading || !canShoot)
            return;

        // Lấy một viên đạn từ object pool
        GameObject bullet = bulletPool.GetPooledBullet();

        if (bullet != null)
        {
            bullet.transform.position = bulletPosition.transform.position;
            bullet.SetActive(true);

            // Lấy tham chiếu tới Rigidbody2D của viên đạn
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

            // Tính toán hướng di chuyển và khoảng cách dựa trên hai điểm pivot
            Vector2 moveDirection = (GameObject.FindGameObjectWithTag("Pivot").transform.position - bulletPosition.transform.position).normalized;

            // Áp dụng lực đẩy theo hướng của nòng súng
            bulletRigidbody.AddForce(moveDirection * bulletForce, ForceMode2D.Force);

            shotsFired++;

            if (shotsFired >= shotsPerReload)
            {
                StartCoroutine(Reload());
            }
        }
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        canShoot = false;

        // Hiển thị chỉ báo nạp đạn
        reloadIndicator.SetActive(true);

        yield return new WaitForSeconds(reloadTime);

        // Nạp đạn xong
        shotsFired = 0;

        // Ẩn chỉ báo nạp đạn
        reloadIndicator.SetActive(false);

        isReloading = false;
        canShoot = true;

    }

    private void Update()
    {
        if (isJumping)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SoundManager.PlaySound("gunshot");
                FireBullet();
            }
            return;
        }

        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput != 0)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.PlaySound("gunshot");
            FireBullet();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        if (collision.gameObject.CompareTag("Rai") || collision.gameObject.CompareTag("BigRai") 
            || collision.gameObject.CompareTag("bossbullet") || collision.gameObject.CompareTag("Drone"))
        {
            collision.gameObject.SetActive(false);
            flashEffect.Flash();
            FindObjectOfType<GameManager>().DecreaseDrone();
        }

    }

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition= this.transform.position;
    }
    public void OnJumpButtonClicked()
    {
        if (!isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            SoundManager.PlaySound("jumping1");
            isJumping = true;
        }
    }

    public void OnShootButtonClicked()
    {

        if (canShoot)
        {
            napdan.text = "";

            SoundManager.PlaySound("gunshot");
            FireBullet();
        }
        else
        {
            napdan.text = "Đang nạp đạn";
        }

    }
   /* public void StopAnimation()
    {
        animator.enabled = false; 

    }*/
}
