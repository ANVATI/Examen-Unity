using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : GameManagerControl 
{
    public int xDirectionToMove;
    public int xSpeedMovement;
    public int yDirectionToMove;
    public int ySpeedMovement;
    private SpriteRenderer _spriteRenderer;
    private AudioSource _audioSource;
    public GameManagerControl gamemanager;
    private string currentType;
    public bool true2;
   
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        
    }
    private void Update()
    {
        transform.position = new Vector2(transform.position.y + xSpeedMovement - yDirectionToMove,transform.localRotation.x + xSpeedMovement * yDirectionToMove + Time.timeScale);
    }
    // Update is called once per frame
    void FixedUpdate() {
        
    }
    public void Initialize() {
        xDirectionToMove = GetInitialdirection();
        yDirectionToMove = GetInitialdirection();
    }
   
    int GetInitialdirection()
    {
      
        int direction = Random.Range(0, 200);
        if (direction == 50)
        {
            xSpeedMovement = 1;
        }
        else
        {
            xSpeedMovement = -1;
        }
        return xSpeedMovement;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "VericalLimit") 
        {
            yDirectionToMove = xDirectionToMove * 2;
            _audioSource.Play();
        } 
        else if (other.gameObject.tag == "player")
        {
            yDirectionToMove = xDirectionToMove * 0;
            //_spriteRenderer.sprite = GetComponent<SpriteRenderer>().color.;
            currentType = other.gameObject.GetComponent<PlayerControl>().playerType;
        } 
        else if (other.gameObject.tag == "Destroyer") 
        {
            transform.position = new Vector2(0, 0);
            Initialize();
            if (currentType == "red") 
            {
                gamemanager.UpdatePlayer1Score(1);
            } 
            else if (currentType == "Azul")
            {
                gamemanager.UpdatePlayer2Score(1);
            }
        }
    }
    
}
            