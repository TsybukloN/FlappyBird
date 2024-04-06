using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class Bird_Controller : MonoBehaviour
{
    public Rigidbody2D rigi;
    public Animator animator;
    public float jumpForce;
    public TextMeshProUGUI PointText;
    
    public GameObject GameOverScreen;

    public int Points;
    public static bool GameOver;
    public static bool IsStarted;

    void Start()
    {
        Debug.Log("Starting of controlling");
        GameOver = false;
        Points = 0;
        IsStarted = false;

        GameOverScreen.SetActive(false);
    }

    void Update()
    {
        if (GameOver)
        {
            return;
        }

        if (Input.GetButtonDown("Jump"))
        {
            IsStarted = true;
            animator.SetBool("isJump", true);
            rigi.velocity = new Vector2(rigi.velocity.x, jumpForce);
        }
        else
        {
            animator.SetBool("isJump", false);
        }

        PointText.text = "Points: " + Points.ToString();

        if(!IsStarted)
        {
            rigi.gravityScale = 0;
        }
        else
        { 
            rigi.gravityScale = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PointZone"))
        {
            Points++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOverScreen.SetActive(true);
        GameOver = true;
    }

    public void RestartButtonClicked()
    {
        SceneManager.LoadScene("FlappyBird");
    }
}
