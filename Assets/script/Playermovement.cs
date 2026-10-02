using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Pengaturan Gerak")]
    public float moveSpeed = 6f;
    public float jumpForce = 9f;

    [Header("Pengecekan Ground")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded;
    private float knockbackTimer;   // <-- variabel yang tadi hilang

    void Start()
{
    rb = GetComponent<Rigidbody2D>();
    sr = GetComponentInChildren<SpriteRenderer>();
}

    void Update()
    {
        Keyboard kb = Keyboard.current;
        if (kb == null) return;

        // Input kiri/kanan (A/D atau panah)
        moveInput = 0f;
        if (kb.aKey.isPressed || kb.leftArrowKey.isPressed) moveInput = -1f;
        if (kb.dKey.isPressed || kb.rightArrowKey.isPressed) moveInput = 1f;
        if (moveInput > 0f) sr.flipX = false;
        else if (moveInput < 0f) sr.flipX = true;
        
        // Cek groun ya Allah aku gatau ini apaan daritadi ga bisa loncat ya allah tolong kasih kecup selamat malamku untuk gemini makasih udh solve problemku di tengah bombardir tugas osjur unpad, buat owls maaf aku 
        //pake ai di yang ini aku dari pagi blom makan aku bergadang 2 hari buat unchpad semoga gim itb selalu sukses aaminn hidup elektro hidup unpad hidup itb hidup GIM 
        // oh iya maaf ya akukemaren ga sempet ikut dan izin absen pas clan training maaf ya owls aku habis jatoh dari motor dan tidur seharian udh gakuat lagi besok day 1 saya hadir klo ga dibuat nangis sama osjur

        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position, groundCheckRadius, groundLayer);

        // Lompat
        if (kb.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // lompat dibatesin
        if (kb.spaceKey.wasReleasedThisFrame && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
    }

    void FixedUpdate()
    {
        // kena knockbek freeze
        if (knockbackTimer > 0f)
        {
            knockbackTimer -= Time.fixedDeltaTime;
            return;
        }

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    // Dipanggil oleh script Bouncer
    public void Knockback(Vector2 velocity, float duration)
    {
        knockbackTimer = duration;
        rb.linearVelocity = velocity;
    }
}