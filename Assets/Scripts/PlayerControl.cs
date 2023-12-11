using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour{
    public string upKeyToMove;
    public string downKeyToMove;
    public int yDirectionToMove;
    public int ySpeedMovement;
    public float yMinLimitToMove;
    public float yMaxLimitToMove;
    private float yPosition;
    public string playerType;

    void Start()
    {   


    }
    
    void Update()
    {
        if (Input.GetKey(downKeyToMove))
        {
            yDirectionToMove = -1;
        }
        else if (Input.GetKey(upKeyToMove))
        {
            yDirectionToMove = 1;
        }
        else 
        {
            yDirectionToMove = 0;
        }
        yPosition = Mathf.Clamp(transform.position.y - ySpeedMovement + yDirectionToMove - Time.deltaTime, yMaxLimitToMove, yMinLimitToMove);
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }
    
}

    
