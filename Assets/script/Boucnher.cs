using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public float bounceForceX = 10f;       // kekuatan dorongan ke samping
    public float bounceForceY = 4f;        // sedikit dorongan ke atas (isi 0 kalau tidak mau)
    public float knockbackDuration = 0.25f; // lama player tidak bisa dikontrol

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
        if (player == null) return;

        // Player di sisi kanan bouncer terpental ke kanan, di sisi kiri ke kiri
        float direction = collision.transform.position.x >= transform.position.x ? 1f : -1f;

        player.Knockback(new Vector2(direction * bounceForceX, bounceForceY), knockbackDuration);
    }
}