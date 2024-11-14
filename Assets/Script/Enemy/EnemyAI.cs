using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;          // Referensi ke posisi pemain
    public float moveSpeed = 2f;      // Kecepatan bergerak enemy
    public float attackRange = 1f;    // Jarak di mana enemy mulai menyerang pemain
    public float damage = 1;        // Jumlah damage yang diberikan
    public float attackInterval = 1f; // Interval waktu antar serangan

    public Animator animatorEnemy;

    public GameObject Coin;

    public float blinkDuration;

    public Color originalColor;

    private bool isAttacking = false; // Apakah sedang menyerang pemain

    private SpriteRenderer EnemySprite;

    public float EnemyHP;

    public bool isDead;

    public TotalEnemy totalEnemy;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        EnemySprite = GetComponent<SpriteRenderer>();
        animatorEnemy = GetComponent<Animator>();
        originalColor = EnemySprite.color;
    }
    private void Update()
    {
        // Cek jarak antara enemy dan player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > attackRange)
        {
            // Jika belum mencapai attackRange, bergerak menuju pemain
            MoveTowardsPlayer();
        }
        else if (!isAttacking)
        {
            // Jika sudah di dalam jangkauan serang dan belum menyerang, mulai serangan
            StartCoroutine(AttackPlayer());
        }

        if(player.position.x - this.transform.position.x < 0f)
        {
            EnemySprite.flipX = true;
        } else
        {
            EnemySprite.flipX = false;
        }
    }

    private void OnDestroy()
    {
        Instantiate(Coin, transform.position, Quaternion.identity);
    }

    void MoveTowardsPlayer()
    {
        if (!isDead)
        {
            // Arahkan enemy ke pemain
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    public void TakeDamage(float Damage)
    {
        // Panggil fungsi blink ketika terkena hit
        StartCoroutine(BlinkEffect());

        EnemyHP -= Damage;

        if(EnemyHP <= 0f)
        {
            Death();
        }
    }

    private IEnumerator BlinkEffect()
    {
        // Set warna menjadi putih pucat untuk memberikan efek blink
        EnemySprite.color = new Color(1f, 1f, 1f, 0.8f);  // Set alpha menjadi 0.8 untuk efek pucat

        // Tunggu selama durasi blink
        yield return new WaitForSeconds(blinkDuration);

        // Kembalikan warna asli
        EnemySprite.color = originalColor;
    }

    public void Death()
    {
        isDead = true;
        totalEnemy.TotalEnemys--;
        StartCoroutine(DeathDelay());
    }

    public IEnumerator DeathDelay()
    {
        animatorEnemy.SetTrigger("Death");
        yield return new WaitForSeconds(1f);

        Destroy(this.gameObject);
    }

    IEnumerator AttackPlayer()
    {
        isAttacking = true;

        // Memberikan damage ke pemain
        PlayerMovements playerHealth = player.GetComponent<PlayerMovements>(); // Pastikan ada skrip PlayerHealth di player
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }

        // Tunggu sebelum menyerang lagi
        yield return new WaitForSeconds(attackInterval);
        isAttacking = false;
    }
}
