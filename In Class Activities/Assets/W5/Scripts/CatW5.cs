using UnityEngine;

public class CatW5 : MonoBehaviour
{
    [SerializeField] private bool _flipWSControls;
    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] private float _turnSpeed = 1.0f;
    [SerializeField] private Animator _animator;

    private string _isWalkingName = "IsWalking";

    private void Update()
    {
        // STEP 1 & 2 ---------------------------------------------------------
        // Get W/S input (forward/backward)
        float moveInput = Input.GetAxis("Vertical");

        // If flip controls is true, reverse input direction
        if (_flipWSControls)
        {
            moveInput = -moveInput;
        }

        // Move the cat forward/backward along the Z-axis
        Vector3 translation = Vector3.forward * moveInput * _moveSpeed * Time.deltaTime;
        transform.Translate(translation);

        // STEP 1 & 2 ---------------------------------------------------------
        // Rotate the cat left/right with A and D
        float rotation = Input.GetAxis("Horizontal") * _turnSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        // Update walking animation
        if (translation.magnitude != 0.0f || rotation != 0.0f)
        {
            _animator.SetBool(_isWalkingName, true);
        }
        else
        {
            _animator.SetBool(_isWalkingName, false);
        }
    }
}
