using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public Animator anim;
    public float speed = 10f;
    public Transform groundCheck;
    float groundDistance = 0.4f;
    public LayerMask groundMask;

    float gravity = -9.81f;
    [SerializeField]float climbSpeed = 30.0f;
    Vector3 velocity;
    bool isOnGround = false;
    public  bool isClimbing = false;

    public List<Transform> points; //points in the next climbing zone
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        Debug.Log(other.name);
        if (other.tag == "Wall")
        {
            isClimbing = true;
        }


        Debug.Log(other.transform.name);
        if (other.tag == "Pick Up")
        {
            Destroy(other.gameObject);
            GameData._instance.coins++;

        }
    }
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.tag);
        //if (other.tag == "Wall")
        //{
        //    isClimbing = true;
        //    Debug.Log("staying climb zone");
        //}

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wall")
        {
            isClimbing = false;
            Debug.Log("exit climb zone");
        }

        
    }
    public void  CheckCloseDistance()
    {
        if (isClimbing == false)
        {
            var closest = points.OrderBy(t => Vector3.Distance(t.position, transform.position))
                               .FirstOrDefault();

            Debug.Log(closest.position);
            transform.position = closest.position;
            isClimbing = true;
            //characterController.Move(closest.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        foreach (var point in points)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawCube(point.position, Vector3.one * 5);
        }
        var nClosest = points.OrderBy(t => Vector3.Distance(t.position, transform.position))
                           .FirstOrDefault();

        //Debug.Log(nClosest.position);
        Gizmos.color = Color.cyan;
        Gizmos.DrawCube(nClosest.position, Vector3.one * 5);
        
    }

    public void Climbing()
    {
        Vector3 moveDir = Vector3.zero;
        if (isClimbing == true)
        {
            Debug.Log("Jump");
            anim.SetBool("isClimbing", true);

            moveDir += transform.up * Time.deltaTime * climbSpeed;
            Debug.Log(moveDir.y);
            transform.Translate(moveDir);
            //characterController.Move(moveDir);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //float horizontalmove = Input.GetAxis("Horizontal"); //-1 ,  1 0 = not moving
        //float verticalmove = Input.GetAxis("Vertical");

        //Vector3 moveDir = new Vector3(horizontalmove, 0, verticalmove);//transform.right * horizontalmove + transform.forward * verticalmove;

        //if (horizontalmove == 0 && verticalmove == 0)
        //    anim.SetBool("isMoving", false);
        //else
        //    anim.SetBool("isMoving", true);
        //Vector3 moveDir = Vector3.zero;
        if (isClimbing)
        {
            if (Input.GetButton("Jump"))
            {
                //Debug.Log("Jump");
                //float jumpValue = Input.GetAxis("Jump");

                //if(jumpValue == 0)
                //    anim.SetBool("isClimbing", false);
                //else
                //    anim.SetBool("isClimbing", true);

                //moveDir += transform.up * Time.deltaTime * climbSpeed* jumpValue;
                //characterController.Move(moveDir);
                
            }
           
        }
        else
        {
            //Debug.Log("Not Climbing");
            //isOnGround = Physics.CheckSphere(groundCheck.position, groundDistance,
            //groundMask);

            //if (isOnGround && velocity.y < 0)
            //    velocity.y = -2f;

            //anim.SetBool("isClimbing", false);
            //characterController.Move(moveDir * speed * Time.deltaTime);

            //velocity.y += gravity * Time.deltaTime * Time.deltaTime;
            //characterController.Move(velocity);
            
        }

    }
}
