using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator anim;
    private Animationscript animatorIDs;

    private void Start()
    {
        anim = GetComponent<Animator>();
        animatorIDs = GameObject.FindGameObjectWithTag("GameController").GetComponent<Animationscript>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;
        transform.position += movement * moveSpeed * Time.deltaTime;

        if (movement.magnitude > 0f)
        {
            anim.SetBool(animatorIDs.IsMoving, true);
            anim.SetFloat(animatorIDs.Speed, 1f);
        }
        else
        {
            anim.SetBool(animatorIDs.IsMoving, false);
            anim.SetFloat(animatorIDs.Speed, 0f);
        }

        if (movement.magnitude == 0f && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            if (moveHorizontal > 0f)
            {
                anim.Play(animatorIDs.TurnRight);
            }
            else if (moveHorizontal < 0f)
            {
                anim.Play(animatorIDs.TurnLeft);
            }
        }
    }
}