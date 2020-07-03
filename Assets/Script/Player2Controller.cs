using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2Controller : MonoBehaviour
{
    private Animator myAnimator;
    private Vector3 velocity;
    Rigidbody rb;
    private float move_speed = 1.1f;
    private float runSpeed = 2.5f;
    private bool runFlag = false;
    private Transform player;
    public float rotateSpeed = 10.0F;
    public float seigenMai = -48.0f;
    public float seigenPra = 48.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        velocity = new Vector3(moveHorizontal, 0, moveVertical);
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveForward = cameraForward * moveVertical + Camera.main.transform.right * moveHorizontal;
        if (Input.GetButton("Run"))
        {
            runFlag = true;
            rb.velocity = moveForward * runSpeed + new Vector3(0, rb.velocity.y, 0);
            // rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
        else
        {
            runFlag = false;
            rb.velocity = moveForward * move_speed + new Vector3(0, rb.velocity.y, 0);
        }

        if (velocity.magnitude > 0f)
        {
            if (runFlag)
            {
                this.myAnimator.SetFloat("Speed", 2.5f);
            }
            else
            {
                this.myAnimator.SetFloat("Speed", 1.1f);
            }
        }
        else
        {
            this.myAnimator.SetFloat("Speed", 0f);
        }

        //player.position = new Vector3
           // (Mathf.Clamp(player.position.x, -48.0f, 48.0f), player.position.y, Mathf.Clamp(player.position.z, -48.0f, 48.0f));
        SeigenArea();

        if (Mathf.Abs(moveHorizontal) + Mathf.Abs(moveVertical) > 0.1F)
        {
            Vector3 camToPlayer = player.position - Camera.main.transform.position;
            float inputAngle = Mathf.Atan2(moveHorizontal, moveVertical) * Mathf.Rad2Deg;
            float cameraAngle = Mathf.Atan2(camToPlayer.x, camToPlayer.z) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, inputAngle + cameraAngle, 0);
            player.rotation = Quaternion.Slerp(player.rotation, targetRotation, Time.deltaTime * rotateSpeed);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Goal")
        {
            PlayerPrefs.SetInt("stage1Clear", 1);
        }else if (col.gameObject.name == "Goal2")
        {
            PlayerPrefs.SetInt("stage2Clear", 2);
        }
        if (col.gameObject.tag == "Goal")
        {
            SceneManager.LoadScene("Menu");
        }
    }
    public void SeigenArea()
    {
        player.position = new Vector3
            (Mathf.Clamp(player.position.x, seigenMai, seigenPra), player.position.y, Mathf.Clamp(player.position.z, seigenMai, seigenPra));
    }
}
