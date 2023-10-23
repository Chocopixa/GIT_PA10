using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Rigidbody thisRB;
    private float Jumpforce = 9f;
    public static int score;
    public Text scoretxt;

    void Start()
    {
        score = 0;
        thisRB = GetComponent<Rigidbody>();
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        limitspeed();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisRB.AddForce(Vector3.up * Jumpforce, ForceMode.Impulse);
            thisAnimation.Play();
        }
        UpdateText();
    }
    
    private void limitspeed()
    {
        if(thisRB.velocity.y >= 8f)
        {
            thisRB.velocity = new Vector3(thisRB.velocity.x, 8f, thisRB.velocity.z);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("bottom"))
        {
            SceneManager.LoadScene("lose");
        }
    }
    public static void AddScore(int scoreToAdd)
    {
        Player.score += scoreToAdd;
    }
    private void UpdateText()
    {
        scoretxt.text = "Score" + score.ToString();
    }
}
