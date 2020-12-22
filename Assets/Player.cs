using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public string currentColor;
    public float speed = 10f;
    public Rigidbody2D rb;

    public GameObject [] Obstacles;
    public SpriteRenderer sr;

    public Text scoreText;
    private int score;


     void Start()
    {
        RandomColor();
        score = 0;
    }

    void OnTriggerEnter2D  (Collider2D col){
        
            
            if (col.CompareTag ("switchColor")){
            RandomColor ();

            int ran = Random.Range (0,4);

            Instantiate ( Obstacles [ran], 
            new Vector3 (transform.position.x, transform.position.y + 6.0f, transform.position.z),
            transform.rotation
            );
            Destroy (col.gameObject);
            return;
            }

             if (col.CompareTag ("score")){
            score++;
            scoreText.text = score.ToString ();
            Destroy (col.gameObject);
            Instantiate ( col.gameObject, 
            new Vector3 (transform.position.x, transform.position.y + 6.0f, transform.position.z),
            transform.rotation
            );
            return;
            }

            if (col.tag != currentColor ){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

          
           
    }
    private void RandomColor()
    {
        sr = GetComponent<SpriteRenderer>();
        int rand = Random.Range (0,3);
    
        switch (rand)
        {
            case 0:
                currentColor = "blue";
                sr.color = new Color (53f/256f, 226f/256f, 243f/256f);
                break;
            case 1:
                currentColor = "yellow";
                sr.color = new Color(246f/256f, 223f/256f, 14f/256f);
                break;
            case 2:
                currentColor = "pink";
                sr.color = new Color(255f/256f, 0f/256f, 128f/256f );
                break;
            case 4:
                currentColor = "purple";
                sr.color = new Color(140f/256f, 19f/256f, 251f/256f);
                break;
        }
    }
        

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            rb.velocity = Vector2.up * speed ;
        }

        PassTheCam ();
    }
    
    void PassTheCam (){
        Vector3 camera = FindObjectOfType<Camera>().transform.position;

        if (transform.position.y < camera.y - 5f){
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
        }
    }

}
