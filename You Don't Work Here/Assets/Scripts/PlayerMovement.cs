using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float maxPlayerSpeed;
    public float timeToMaxVelocity;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private InputHandler inputHandler;
    private float currentXVelocity = 0f;
    private Vector2 inputVector = Vector2.zero;
    private float timeSinceLastFootstep;
    private bool leftFoot = false;
    public AudioSource leftFootAudio;
    public AudioSource rightFootAudio;

    private enum AnimationState
    {
        Idle,
        Running,
    }

    private AnimationState state;

    void Start()
    {
        Time.timeScale = 1;
        inputHandler = new InputHandler(GetComponent<PlayerInput>());
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        inputVector = inputHandler.GetActionValue<Vector2>(InputHandlerActions.Move);
        UpdateAnimationState();
    }

    private void FixedUpdate()
    {
        float smoothXVelocity = Mathf.SmoothDamp(rb.velocity.x, inputVector.x * maxPlayerSpeed, ref currentXVelocity, timeToMaxVelocity);
        //rb.velocity = new Vector2(inputVector.x * maxPlayerSpeed, rb.velocity.y);
        rb.velocity = new Vector2(smoothXVelocity, rb.velocity.y);
    }

    private void PlayWalkAudio()
    {
        if (timeSinceLastFootstep - Time.time > -1 * (maxPlayerSpeed / 3)) { return; }
        timeSinceLastFootstep = Time.time;
        if (leftFoot)
        {
            leftFoot = false;
            leftFootAudio.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
            leftFootAudio.Play();
        }
        else
        {
            leftFoot = true;
            leftFootAudio.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
            rightFootAudio.Play();
        }
    }

    private void UpdateAnimationState()
    {
        if (inputVector.x > 0.1f)
        {
            PlayWalkAudio();
            state = AnimationState.Running;
            sprite.flipX = false;
        }
        else if (inputVector.x < -0.1f)
        {
            PlayWalkAudio();
            state = AnimationState.Running;
            sprite.flipX = true;
        }
        else
        {
            state = AnimationState.Idle;
        }

        anim.SetInteger("state", (int)state);
    }
}
