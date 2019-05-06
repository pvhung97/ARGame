using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public float defaultSpeed = 8f;
    public float speed = 8f;

    Vector3 movement;
    Vector3 rotate;
    Animator anim;
    Rigidbody playerRigidBody;
    int floorMask;
    float camRayLength = 100f;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");
        float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        float v = CrossPlatformInputManager.GetAxisRaw("Vertical");

        Move(h, v);
        Turning(h, v);
        Animating(h, v);
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidBody.MovePosition(transform.position + movement);

    }

    void Turning(float h, float v)
    {
        /*Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        
        if(Physics.Raycast(camRay,out floorHit, camRayLength, floorMask) )
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidBody.MoveRotation(newRotation);
        }*/
        rotate.Set(h, 0f, v);
        if(rotate!= Vector3.zero)
        {
            playerRigidBody.rotation = Quaternion.LookRotation(rotate);
        }
        
        
    }

    void Animating(float h,float v)
    {
        if(h != 0f || v!= 0f)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
        
    }


    public void Boost()
    {
        speed = 12f;
        Invoke("NormalSpeed", 10);
    }

    public void NormalSpeed()
    {
        speed = defaultSpeed;
    }

    public void SpeedUpgrade()
    {
        speed = 10f;
        defaultSpeed = 10f;
    }
}
