using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float movementSpeed;
    CharacterController characterController;
    public float turnTime = 0.1f;
    public float turnVelocity;
    public Animator anim;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

    }

    private void PlayerMovement()
    {
        float vertical = SimpleInput.GetAxisRaw("Horizontal");
        float horizontal = SimpleInput.GetAxisRaw("Vertical");
        var movement = new Vector3(vertical, 0, horizontal).normalized;
        if (movement.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            characterController.Move(movement * movementSpeed * Time.deltaTime);
            anim.SetBool("Walk", true);


        }
        else if (movement.magnitude <= 0)
        {
            anim.SetBool("Walk", false);

        }
    }
}
