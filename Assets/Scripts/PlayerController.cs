using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GM;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;
    public float gameSpeed=1;
    private int movingLane = 1; //left-0;middle-1;right-2;
    public int laneDistance;
    readonly private float jumpforce = 10;
    readonly private float gravity = -20;

    private void Awake()
    {
        GlobalManager.PlayerController = this;
        gameSpeed = forwardSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {   
        string state = GlobalManager.GameManager.GetState().ToString();
        if(state == "Play")
        {
            if(gameSpeed<maxSpeed)
                gameSpeed += 0.1f * Time.deltaTime;

            direction.z = gameSpeed;
            if (controller.isGrounded)
            {
                direction.y = -1;
                if (Input.GetKeyDown(KeyCode.UpArrow) || GlobalManager.SwipeManager.SwipeUp())
                {
                    Jump();
                }
            }
            else
            {
                direction.y += gravity * Time.deltaTime;
            }


            if (Input.GetKeyDown(KeyCode.DownArrow) || GlobalManager.SwipeManager.SwipeDown())
            {
                if(transform.localScale.y>0.5)
                    StartCoroutine(Slide());
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) || GlobalManager.SwipeManager.SwipeRight())
            {
                ChangeLane("right");
            }

            else if (Input.GetKeyDown(KeyCode.LeftArrow) || GlobalManager.SwipeManager.SwipeLeft())
            {
                ChangeLane("left");
            }

            Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
            switch (movingLane)
            {
                case 0:
                    targetPosition += Vector3.left * laneDistance;
                    break;
                case 2:
                    targetPosition += Vector3.right * laneDistance;
                    break;
                default:
                    break;

            }
            if (transform.position == targetPosition)
                return;
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.sqrMagnitude)
                controller.Move(moveDir);
            else
                controller.Move(diff);
        } else
        {
            if(state != "Pause")
                gameSpeed = forwardSpeed;
            direction.z = 0;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }
    private void ChangeLane (string direction)
    {
        if(direction == "left")
        {
            movingLane = movingLane <= 1 ? 0 : 1;
        } else if (direction == "right")
        {
            movingLane = movingLane >= 1 ? 2 : 1;
        }
    }

    private void Jump()
    {
        direction.y = jumpforce;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            GlobalManager.GameManager.ChangeState("Lose");
            GlobalManager.UIManager.SwitchPanel();
            transform.position = (new Vector3(transform.position.x, transform.position.y, transform.position.z + 1));
        }
    }

    private IEnumerator Slide()
    {
        transform.localScale = new Vector3(1,0.5f,1);

        yield return new WaitForSeconds(1.3f);
        
        transform.localScale = new Vector3(1, 1, 1);
    }
}
