using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public GameObject healthText;
    public float speed;
    public float rotateSpeed;
    public float damageRate;
    public float health;
    bool isDeath = false;

    public Rigidbody playerRb;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        healthText.GetComponent<Text>().text = "Health: " + health.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        if(isDeath == false)
        {
            //Moving and Facing Forward
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                animator.SetBool("IsWalkBool", true);
            }

            //Moving and Facing Backwards
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                animator.SetBool("IsWalkBool", true);
            }

            //IdleState
            else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                animator.SetBool("IsWalkBool", false);
            }

            //Moving and Facing Left
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, -90, 0);
                animator.SetBool("IsWalkBool", true);
            }

            //Moving and Facing Right
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                animator.SetBool("IsWalkBool", true);
            }

            //IdleState
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                animator.SetBool("IsWalkBool", false);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("AttackTrigger");
            }  
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (isDeath == false)
        {
            if (other.gameObject.tag == "Fire")
            {
                health -= damageRate * Time.deltaTime;
                healthText.GetComponent<Text>().text = "Health: " + health.ToString("0");
            }
            if (health <= 0)
            {
                animator.SetTrigger("DeadTrigger");
                isDeath = true;
            }
        }
    }
}
