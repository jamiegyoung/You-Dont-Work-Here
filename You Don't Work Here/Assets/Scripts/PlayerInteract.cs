using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{

    public LayerMask interactableMask;
    public LayerMask blockingMask;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    private InputHandler inputHandler;
    private InteractionInformer interactionInformer;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        inputHandler = new InputHandler(GetComponent<PlayerInput>());
        rb = GetComponent<Rigidbody2D>();
        interactionInformer = transform.Find("InteractionInformer").GetComponent<InteractionInformer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, GetDirectionVector(), .5f, interactableMask + blockingMask);
        if (hit.collider == null)
        {
            interactionInformer.Hide();
            return;
        }

        Vector3 hitPos = hit.collider.transform.position;
        // Hit blocking, not interactableZ
        Interactable interactable = hit.collider.GetComponent<Interactable>();
        if (interactable == null)
        {
            interactionInformer.Hide();
            return;
        }
        Vector2 interactionInformerPos = new(hitPos.x, hitPos.y + hit.collider.bounds.size.y - 1f);
        interactionInformer.Show(interactionInformerPos, inputHandler.GetBindingDisplayString(InputHandlerActions.Interact));

        if (inputHandler.WasPressedThisFrame(InputHandlerActions.Interact))
        {
            interactable.Interact(gameObject);
        }
    }

    private Vector2 GetDirectionVector()
    {
        if (sprite.flipX)
        {
            return Vector2.left;
        }
        else
        {
            return Vector2.right;
        }
    }
}
