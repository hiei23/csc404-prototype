
using UnityEngine;


public class PlayerController3 : MonoBehaviour
{
	public GameObject otherPlayer;
	//public PlayerScript p2script = otherPlayer.GetComponent<PlayerController3>();
    public GameObject model;
    public float speed = 40.0F;
    public float climbSpeed = 20.0F;
    public float jumpSpeed = 5.0F;
    public float maxSpeed = 20.0F;
    //public bool isClimbing;
	//public float throwspeed = 2.0F;
	//public float slingheight = 25.0F;
    public float RotateSpeed = 30f;
	public float pounceHeight = 25.0F;
	public float addPounceHeight = 2.5F;
	public float pounceSpeed = 50.0F;
	public float addPounceSpeed = 5.0F;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Rigidbody rb;
	private Rigidbody rb2;
	//private int timer;
	//private bool slingState = false;
	private bool pounceState;
    private Animator animator;
    private int curr_state;

    void Awake()
    {
        //controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
		rb2 = otherPlayer.GetComponent<Rigidbody>();
        //isClimbing = false;
        rb.isKinematic = false;
        animator = model.GetComponent<Animator>();
        animator.speed = 0.25f;
    }


    void FixedUpdate()
    {
        rb.isKinematic = false;
        float h = 0.0f;
        float v = 0.0f;
        float d = 0.0f;
        //if (!isClimbing)
            //curr_state = 0;
        Vector3 delta = new Vector3(0, 0, 0);
        GameObject other;
        if (gameObject.tag.Equals("Player1"))
        {
            h = Input.GetAxisRaw("HorizontalP1");
            v = Input.GetAxisRaw("VerticalP1");
            other = GameObject.FindWithTag("Player2");
        }
        else
        {
            h = -Input.GetAxisRaw("HorizontalP2");
            v = Input.GetAxisRaw("VerticalP2");
            other = GameObject.FindWithTag("Player1");
        }
      
        moveDirection = new Vector3(h, d, v);
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);
        moveDirection.y = 0;
        moveDirection *= speed;

        if (moveDirection != Vector3.zero)
            curr_state = 1;
        

        //////////////////////////////////////////////////

        
        Vector3 epsilon = Vector3.up * Input.GetAxisRaw("Axis4P1");
        //if (Input.GetAxisRaw("Axis4P2") > Input.GetAxisRaw("Axis4P1"))
        //    epsilon = Vector3.up * Input.GetAxisRaw("Axis4P2");

        //this line made the cats rotate endlessly!!
        //transform.Rotate(epsilon * RotateSpeed * Time.deltaTime);

        /////////////////////////////////////////////

        if (((gameObject.tag.Equals("Player1") && Input.GetButtonDown("JumpP1")) || (gameObject.tag.Equals("Player2") && Input.GetButtonDown("JumpP2"))) && CheckGround())
		{
			//rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
			//rb.velocity = rb.velocity + new Vector3(0, jumpSpeed, 0);
            moveDirection = new Vector3(0, jumpSpeed * 100, 0);
		}
		
        /*if (((gameObject.tag.Equals("Player1") && Input.GetButton("ReturnP1")) || (gameObject.tag.Equals("Player2") && Input.GetButton("ReturnP2"))))
        {
            delta = other.transform.position - transform.position;
            h = delta.x == 0 ? 0 : (delta.x > 0 ? 1 : -1);
            v = delta.y == 0 ? 0 : (delta.y > 0 ? 1 : -1);
            d = delta.z == 0 ? 0 : (delta.z > 0 ? 1 : -1);
            moveDirection = new Vector3(h, d, v);
            moveDirection *= speed;
        }*/
		
		/*if (((gameObject.tag.Equals("Player1") && Input.GetButton("ThrowP1")) || (gameObject.tag.Equals("Player2") && Input.GetButton("ThrowP2"))) && CheckGround())
        {
            delta = rb.position - rb2.position;
            h = delta.x == 0 ? 0 : (delta.x > 0 ? 1 : -1);
            v = delta.y == 0 ? 0 : (delta.y > 0 ? 1 : -1);
            d = delta.z == 0 ? 0 : (delta.z > 0 ? 1 : -1);
			//moveDirection = new Vector3.MoveTowards(transform.position, otherPlayer.transform.position.y+throwspeed, speed*Time.deltaTime);
            moveDirection = new Vector3(h, d+throwspeed, v);
            moveDirection *= speed;
			rb.isKinematic = true;
			timer = 0;
        }*/
		
        /*if (isClimbing)
        {
            moveDirection = new Vector3(h, 0, v);
            moveDirection.y = moveDirection.magnitude * climbSpeed;
        } else if (!CheckGround())
            curr_state = 2;*/
	
        if (((gameObject.tag.Equals("Player1") && Input.GetButton("GroundP1")) || (gameObject.tag.Equals("Player2") && Input.GetButton("GroundP2"))) && CheckGround())
        {
            moveDirection = new Vector3(h, d, v);
            moveDirection *= speed / 4;
            moveDirection = Camera.main.transform.TransformDirection(moveDirection);
            moveDirection.y = 0;
            //rb.isKinematic = true;
            //transform.Translate(moveDirection * Time.deltaTime);
        }
		
		if (((gameObject.tag.Equals("Player1") && Input.GetButtonUp("GroundP1")) || (gameObject.tag.Equals("Player2") && Input.GetButtonUp("GroundP2"))) && CheckGround())
		{
			rb.velocity = transform.rotation * new Vector3(0, pounceHeight, pounceSpeed);
            moveDirection = rb.velocity;
			//slingState = true;
			//Debug.Log(slingState);
			//transform.Translate(moveDirection * Time.deltaTime);
		}
		
		//can't get this to work atm
		/*if (slingState && CheckGround() && (!Input.GetButton("GroundP1") || !Input.GetButton("GroundP1")))
		{
			slingState = false;
			Debug.Log(slingState);
		}*/
		
        else
        {
            if (rb.velocity.magnitude > maxSpeed && (v != 0 || h != 0))
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
            else
            {
				/*if (((gameObject.tag.Equals("Player1") && Input.GetButton("ThrowP1")) || (gameObject.tag.Equals("Player2") && Input.GetButton("ThrowP2"))) && CheckGround())
				{
					rb2.AddForce(moveDirection * Time.deltaTime * 100);
				}*/
				
				//can't seem to get this to work atm
				/*else if (slingState && (Vector3.Distance(rb.position, rb2.position) <= 20))
				{
					float distance = Vector3.Distance(rb.position, rb2.position);
					rb2.isKinematic = false;
					Debug.Log(slingState);
					Debug.Log(rb2.isKinematic);
					Debug.Log(distance);
				}*/
				rb.AddForce(moveDirection * Time.deltaTime * 100);
				
            }
        }

        animator.SetInteger("State", curr_state);
        
        /*if (moveDirection == Vector3.zero) {
            animator.SetInteger("State", 0);
            Debug.Log("idle");
        }
        else {
            animator.SetInteger("State", 1);
            Debug.Log("move");
        }*/
            

        if (moveDirection != Vector3.zero && moveDirection.y == 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            float rotationSpeed = 50.0f;
            Quaternion newRotation = Quaternion.Lerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                 
            //Apply the rotation
            rb.MoveRotation(newRotation);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        /*if (other.gameObject.tag == "Climbable")
        {
            isClimbing = true;
            rb.useGravity = false;
            Debug.Log("Collision enter box\n");
        }*/

		if (other.gameObject.tag == "Snack")
        {
            pounceHeight += addPounceHeight;
            pounceSpeed += addPounceSpeed;
			otherPlayer.GetComponent<PlayerController3>().pounceHeight += addPounceHeight;
            otherPlayer.GetComponent<PlayerController3>().pounceSpeed += addPounceSpeed;
        }
    }

    /*void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Climbable")
        {
            isClimbing = false;
            rb.useGravity = true;
            Debug.Log("Collision Exit\n");
        }
    }*/

    private bool CheckGround()
    {
        Vector3 down = transform.TransformDirection(Vector3.down);
        return Physics.Raycast(transform.position, down, 2.5f);
    }

    
}
