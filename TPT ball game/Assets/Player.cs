using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Player : MonoBehaviour
{
    public float Speed;
    public TMP_Text ScoreText;
    public TMP_Text WinText;
    public GameObject Gate;
    public Rigidbody rb;
    public int Score;

    void SetScoreText()
    {
        ScoreText.text = "Score: " + Score.ToString();
        if (Score == 10)
        {
            WinText.text = "You won! Press R to restart or ESC to quit";
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Score = 0;
        SetScoreText();
        WinText.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * Speed * Time.deltaTime);

        //restart

        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        //Quit game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            Score += 1;
            SetScoreText();
            if (Score >= 5)
            {
                Gate.gameObject.SetActive(false);
            }
        }

        if (other.gameObject.CompareTag("Danger"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
