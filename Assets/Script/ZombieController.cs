using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private GameObject player;
    //private CharacterController zombieController;
    private Animator animator;
    private float walkSpeed = 2.0f;
    private float maxWalkSpeed = 5.0f;
    public float hp = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        //zombieController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distination = player.transform.position;
        if ((distination - transform.position).magnitude > 10.0f)
        {
            animator.SetFloat("Speed", 2.0f);
            Vector3 direction = (distination - transform.position).normalized;
            transform.LookAt(new Vector3(distination.x, transform.position.y, distination.z));
            Vector3 velocity = direction * walkSpeed;
            // Vector3 velocity = new Vector3(direction.x, 0, direction.z);
            /*
            velocity.y += Physics.gravity.y * Time.deltaTime;
            zombieController.Move(velocity * Time.deltaTime);
            */
            /*
            if ((Mathf.Abs((GetComponent<Rigidbody>().velocity + velocity).magnitude) < maxWalkSpeed)) {
                // GetComponent<Rigidbody>().AddForce(velocity);
            }
            */
            //GetComponent<Rigidbody>().velocity = velocity;
            if ((Mathf.Abs(GetComponent<Rigidbody>().velocity.magnitude) < maxWalkSpeed))
            {
                // GetComponent<Rigidbody>().AddForce(velocity);
            }
            GetComponent<Rigidbody>().AddForce(velocity);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            animator.SetFloat("Speed", 0.0f);
        }
    }

    public void Hit()
    {
        hp -= 5.0f;
    }
}
