using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour
{        
    private Vector2 direction;
    [SerializeField] private float snakeSpeed;
    [SerializeField] private GameObject tailPrefab;
    private List<GameObject> tails = new List<GameObject>();

    private void Start()
    {
        Time.timeScale = 0.1f;
        direction = Vector2.up;
        tails.Add(gameObject);
        tails.Add(tailPrefab);
    }
    private void Update()    
    {        
        GetUserInput();
       
    }
    private void FixedUpdate()
    {
        SnakeMove();
        MoveTail();
    }

    public void SnakeMove()
    {
        float x, y;
        x = transform.position.x + direction.x*snakeSpeed;
        y = transform.position.y + direction.y*snakeSpeed;
        transform.position = new Vector2(x, y);
    }

    private void GetUserInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }
    }

    public void CreateTail()
    {
        GameObject newtail = Instantiate(tailPrefab);
        newtail.transform.position = tails[tails.Count - 1].transform.position;
        tails.Add(newtail);
    }
  

    private void MoveTail()
    {
        for (int i = tails.Count-1; i >0; i--)
        {
            tails[i].transform.position = tails[i - 1].transform.position;
        }
    } 

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            RestartGame();
        }

        if (collision.gameObject.CompareTag("Tail"))
        {
            RestartGame();
        }
    }
}
