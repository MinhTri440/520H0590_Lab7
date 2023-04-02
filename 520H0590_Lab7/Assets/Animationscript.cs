using Unity.VisualScripting;
using UnityEngine;

public class Animationscript : MonoBehaviour
{
    public int Speed;
    public int IsMoving;
    public int TurnLeft;
    public int TurnRight;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        Speed = Animator.StringToHash("Speed");
        IsMoving = Animator.StringToHash("IsMoving");
        TurnLeft = Animator.StringToHash("TurnOnSpotLeftA");
        TurnRight = Animator.StringToHash("TurnOnSpotRightA");
    }
}
