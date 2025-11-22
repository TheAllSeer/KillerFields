using UnityEngine;

public class PlayerController:MonoBehaviour
{

    public float moveSpeed;
    public Animator anim;

    public float pickupRange = 1.5f;

    void Start()
    {
        
    }
    void Update()
    {
        Vector3 moveInput = new Vector3(0f, 0f, 0f);
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");


        moveInput.Normalize();
        transform.position += moveInput * moveSpeed * Time.deltaTime;

        anim.SetBool("isMoving", moveInput != Vector3.zero);
        
    }



}
