using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; // Kecepatan peluru
    public float lifetime = 2f; // Waktu sebelum peluru dihancurkan otomatis

    public float damage;

    private void Start()
    {
        // Menghancurkan peluru setelah waktu tertentu agar tidak terus berjalan tanpa batas
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Menggerakkan peluru ke depan berdasarkan arah lokalnya
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyAI enemy = collision.gameObject.GetComponent<EnemyAI>();

            enemy.TakeDamage(damage);

            Destroy(this.gameObject);
        }
    }
}
