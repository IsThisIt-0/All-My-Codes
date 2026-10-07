using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.VFX;

public class GraviticSwitch : MonoBehaviour

{
	//Player komponentit
    public Player player;
    public Rigidbody2D rb;
    public float JumpForce = 5f;
	public Animator playerAnimator;
	//Audio clipit
    public AudioClip Hyppy;
    public AudioClip TelePort;
    private AudioSource audioSc;
	//Ground checkerit
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
	//Painovoiman arvot
    public float GravityScale;
	public bool flipped;
	//Cooldown osat
    private float cooldownTimer = 0f;
    [Header("Huom! Pitaa olla sama kuin PlayerWarpissa!")]
    public float cooldownDuration = 1f;
	//Particle systeemi
	public ParticleSystem teleportEffect;



    void Start()
    {
        player = GetComponent<Player>();

        audioSc = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && cooldownTimer <= 0f)
        {
            rb.gravityScale *= GravityScale;
			teleportEffect.Play();
            if (rb.gravityScale > 0)
            {
				flipped = false;
                JumpForce = 0f;
                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (rb.gravityScale < 0)
            {
				flipped = true;
                JumpForce = 18f;
                gameObject.transform.localScale = new Vector3(1, -1, 1);
            }
            cooldownTimer = cooldownDuration;
            if (TelePort != null && audioSc != null)
            {
                audioSc.PlayOneShot(TelePort, 0.7f);
            }
        }

		
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector2.down * JumpForce, ForceMode2D.Impulse);
			playerAnimator.SetTrigger("Jump");
            if (Hyppy != null && audioSc != null)
            {
                audioSc.PlayOneShot(Hyppy);
            }
        }


        bool IsGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }


        GravityScale = -1;
    }
}