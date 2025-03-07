using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PigScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapstrength;
    public LogicScript logic;
    public SoundManager soundmanager;
    public bool birdisalive = true;
    public float UpperLimit = 9;
    public float LowerLimit = -8;
    public int collisioncount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        soundmanager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) == true && birdisalive)
        {
            myRigidbody.linearVelocity = Vector2.up * flapstrength;
            soundmanager.PlayHopSound();

        }
        if (transform.position.y > UpperLimit || transform.position.y < LowerLimit)
        {
            collisioncount++;
            GameOver();
            if (collisioncount == 1)
            {
                soundmanager.PlayGameOver();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisioncount++;
        GameOver();
        soundmanager.PlayCollisionSound();
        if(collisioncount == 1)
        {
            soundmanager.PlayGameOver();
        }
        
    }
    private void GameOver()
    {
        logic.GameOver();
        birdisalive = false;
    }
}
