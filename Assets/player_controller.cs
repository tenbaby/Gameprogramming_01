using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_controller : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 10.0f;
    float maxWalkSpeed = 2.0f;
    float threshold = 0.2f;


    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }

        // 점프
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }
        if (Input.GetMouseButtonDown(0) && this.rigid2D.velocity.y == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        // 좌우이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key -= 1;
        if (Input.acceleration.x > this.threshold) key = 1;
        if (Input.acceleration.x < -this.threshold) key = -1;

        // 속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // 스피드 제한
        if(speedx < this.maxWalkSpeed) 
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        this.animator.speed = speedx / 2.0f;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("골");
        SceneManager.LoadScene("ClearScene");
        
    }
    
    
}
