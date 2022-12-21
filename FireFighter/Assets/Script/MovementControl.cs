using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour
{
    
    public Vector3 targetPosition;
    public static float speed=3;
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem water;
    [SerializeField] private GameObject stopWall;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Stop"))
        {
            speed = 0;
            animator.SetBool("ReachedPoint",true);
            TurnPlayer();
            water.gameObject.SetActive(true);
            stopWall.SetActive(false);
        }

        if (collision.gameObject.CompareTag("NextLevel"))
        {
            speed = 0;
            animator.SetBool("Run",false);
            animator.SetBool("ReachedPoint",true);
            Debug.Log("bölüm bitti");
            collision.gameObject.SetActive(false);
        }
    }

    public void TurnPlayer()
    {
        gameObject.transform.rotation = new Quaternion(0f, 0f,0f,0f);
    }
    
    
}
