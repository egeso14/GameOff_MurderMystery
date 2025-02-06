using UnityEngine;

public class DetectiveAnimations : MonoBehaviour
{
    Animator detectiveAnimator;
    // Hash Codes
    private static readonly int facingYHash = Animator.StringToHash("AnimFaceY");
    private static readonly int facingXHash = Animator.StringToHash("AnimFaceX");
    private static readonly int movingHash = Animator.StringToHash("Moving");
    private static readonly int lampOutHash = Animator.StringToHash("LampOut");
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        detectiveAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateMovementAnimationState(Vector2 movement)
    {
        if (movement == Vector2.zero)
        {
            detectiveAnimator.SetBool(movingHash, false);
        }
        else
        {
            Debug.Log(movement.x);

            detectiveAnimator.SetBool(movingHash, true);   
            detectiveAnimator.SetFloat(facingXHash, movement.x);
            detectiveAnimator.SetFloat(facingYHash, movement.y);
            
        }

    }
    

}
