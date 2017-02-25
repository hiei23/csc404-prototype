using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float speed = 10.0F;
    public float climbSpeed = 5.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public bool isClimbing;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Rigidbody rb;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        isClimbing = false;
        rb.isKinematic = true;
    }


    void Update()
    {
        float h = 0.0f;
        float v = 0.0f;
        if (gameObject.tag.Equals("Player1"))
        {
            h = Input.GetAxisRaw("HorizontalP1");
            v = Input.GetAxisRaw("VerticalP1");
        }
        else
        {
            h = -Input.GetAxisRaw("HorizontalP2");
            v = Input.GetAxisRaw("VerticalP2");
        }

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(h, 0, v);
            moveDirection *= speed;
            if ((gameObject.tag.Equals("Player1") && Input.GetButton("JumpP1")) || (gameObject.tag.Equals("Player1") && Input.GetButton("JumpP2")))
                moveDirection.y = jumpSpeed;
            if ((gameObject.tag.Equals("Player1") && Input.GetButton("GroundP1")) || (gameObject.tag.Equals("Player1") && Input.GetButton("GroundP2")))
                moveDirection = Vector3.zero;
        }
        if (isClimbing)
        {
            moveDirection = new Vector3(h, 0, v);
            moveDirection.y = moveDirection.magnitude * climbSpeed;
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        if (moveDirection != Vector3.zero && moveDirection.y == 0)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(moveDirection),
                Time.deltaTime * speed
            );
        }
        controller.Move(moveDirection * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        HitDirection d = ReturnDirection(other.gameObject, this.gameObject);
        if (other.gameObject.tag == "Wall" && (d != HitDirection.Top || d != HitDirection.Bottom))
        {
            isClimbing = true;
            Debug.Log("Collision enter box\n");
        }
    }

    void OnCollisionExit(Collision other)
    {
        HitDirection d = ReturnDirection(other.gameObject, this.gameObject);
        if (other.gameObject.tag == "Wall" || d == HitDirection.Top || d == HitDirection.Bottom)
        {
            isClimbing = false;
            Debug.Log("Collision Exit\n");
        }
    }

    private enum HitDirection { None, Top, Bottom, Forward, Back, Left, Right }
    private HitDirection ReturnDirection(GameObject Object, GameObject ObjectHit)
    {

        HitDirection hitDirection = HitDirection.None;
        RaycastHit MyRayHit;
        Vector3 direction = (Object.transform.position - ObjectHit.transform.position).normalized;
        Ray MyRay = new Ray(ObjectHit.transform.position, direction);

        if (Physics.Raycast(MyRay, out MyRayHit))
        {

            if (MyRayHit.collider != null)
            {

                Vector3 MyNormal = MyRayHit.normal;
                MyNormal = MyRayHit.transform.TransformDirection(MyNormal);

                if (MyNormal == MyRayHit.transform.up) { hitDirection = HitDirection.Top; }
                if (MyNormal == -MyRayHit.transform.up) { hitDirection = HitDirection.Bottom; }
                if (MyNormal == MyRayHit.transform.forward) { hitDirection = HitDirection.Forward; }
                if (MyNormal == -MyRayHit.transform.forward) { hitDirection = HitDirection.Back; }
                if (MyNormal == MyRayHit.transform.right) { hitDirection = HitDirection.Right; }
                if (MyNormal == -MyRayHit.transform.right) { hitDirection = HitDirection.Left; }
            }
        }
        return hitDirection;
    }
}
