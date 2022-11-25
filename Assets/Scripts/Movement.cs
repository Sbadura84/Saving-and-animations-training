using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    private float horizontalMove, verticalMove;
    public Stats stats;
    public float gravity = -9.81f;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public Camera cam;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

    }
    private void FixedUpdate()
    {
        #region Movement
        Vector3 move = new Vector3(horizontalMove*stats.speed*Time.deltaTime, 0f, verticalMove*stats.speed*Time.deltaTime);
        controller.Move(move);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        #endregion


        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        Vector3 pointToLook = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        transform.LookAt(pointToLook);
    }
    
}
