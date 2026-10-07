using UnityEngine;
using UnityEngine.InputSystem;

public class HeadBob : MonoBehaviour
{
    public PlayerMover playerInput;

    private Vector2 moveInput;
    private Vector3 startPos;

    public float Amount = 0.002f;
    public float Frequency = 10f;
    public float Smooth = 10f;

    public AudioClip[] sounds;
    private AudioSource source;

    private float lastBobValue = 0f;
    private bool stepReady = true;

    void Start()
    {
        startPos = transform.localPosition;
        source = GetComponent<AudioSource>();
    }

    void LateUpdate()   
    {
        moveInput = playerInput.MoveInput;

        if (moveInput.magnitude > 0.1f)
            StartHeadBob();
        else
            StopHeadbob();
    }

    private void StartHeadBob()
    {
        float bob = Mathf.Sin(Time.time * Frequency);

        // STEP DETECTION
        if (bob < lastBobValue && stepReady)
        {
            PlayFootstep();
            stepReady = false;
        }
        if (bob > lastBobValue)
        {
            stepReady = true;
        }

        lastBobValue = bob;

        // Smooth target position
        Vector3 targetPos = startPos;
        targetPos.y += bob * Amount * 1.4f;
        targetPos.x += Mathf.Sin(Time.time * (Frequency / 2f)) * Amount * 1.6f;

        // Smooth movement
        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            targetPos,
            Smooth * Time.deltaTime
        );
    }

    private void StopHeadbob()
    {
        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            startPos,
            Smooth * Time.deltaTime
        );
    }

    private void PlayFootstep()
    {
        if (sounds.Length == 0) return;
        source.PlayOneShot(sounds[Random.Range(0, sounds.Length)]);
    }
}
