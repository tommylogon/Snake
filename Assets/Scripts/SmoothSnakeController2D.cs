using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField, Tooltip("Max speed, in units per second, that the character moves.")]
    float speed = 1;

    [SerializeField, Tooltip("The snake parts")]
    List<Transform> bodyParts;

    private BoxCollider2D boxCollider;


    private Vector2Int gridPosition;
    private Vector2Int gridMoveDirection;

    private Vector2 velocity;
    private List<Vector2> turnPosition;
    
    
    private float gridMoveTimer;
    private float gridMoveTimerMax;

    
    // Start is called before the first frame update

    private void Awake()
    {
        gridPosition = new Vector2Int(10, 10);
        turnPosition = new List<Vector2>();
        //gridMoveTimerMax = 0.5f;
        //gridMoveTimer = gridMoveTimerMax;
        //gridMoveDirection = new Vector2Int(1, 0);
    }
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        transform.position = new Vector3(gridPosition.x, gridPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= 20 || transform.position.x <= 0)
        {
            velocity.x = 0;
            velocity.y = Mathf.Round( Random.Range(-1, 1));
        }
        if (transform.position.y >= 20 || transform.position.y <= 0)
        {
            velocity.y = 0;
            velocity.x = Mathf.Round( Random.Range(-1, 1));
        }
        float moveHorozontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        if(moveHorozontal != 0 && velocity.x == 0)
        {
            velocity.x = speed * moveHorozontal;
            velocity.y = 0;
            SetTurnPoint();
        }
        if(moveVertical != 0 && velocity.y == 0)
        {
            velocity.y = speed * moveVertical;
            velocity.x = 0;
            SetTurnPoint();
        }
        //gridMoveTimer += Time.deltaTime;
        //if(gridMoveTimer > gridMoveTimerMax)
        //{
        //    gridPosition += gridMoveDirection;
        //    gridMoveTimer -= gridMoveTimerMax;
        //}

        transform.Translate(velocity * Time.deltaTime); // = new Vector3(gridPosition.x, gridPosition.y);
        MoveBody();

    }

    private void SetTurnPoint()
    { 
        turnPosition.Add(new Vector2(transform.position.x, transform.position.y));
        
    }

    private void MoveBody()
    {
        for(int i = 0; i < bodyParts.Count; i++)
        {
            if(i == 0 && Vector3.Distance(bodyParts[i].position, transform.position) > 1.1) 
            {
                if(turnPosition.Count > 0)
                {
                    bodyParts[i].transform.position = Vector2.Lerp(bodyParts[i].transform.position, turnPosition[0], speed * Time.deltaTime);
                }
                else
                {
                    bodyParts[i].transform.position = Vector2.Lerp(bodyParts[i].transform.position, transform.position, speed * Time.deltaTime);
                }
                
               
            }
            if(i > 0 && Vector3.Distance(bodyParts[i].position, bodyParts[i - 1].position) > 1.1)
            {
                bodyParts[i].transform.position = MoveSegments(bodyParts[i].transform.position, bodyParts[i - 1].position);
            }
            if(Vector3.Distance(bodyParts[i].position, turnPosition[0]) > 0.5 && i == bodyParts.Count - 1 && turnPosition.Count>0)
            {
                turnPosition.RemoveAt(0);
            }
        }
    }
    private Vector2 MoveSegments(Vector3 sourcePosition,Vector3 targetPosistion)
    {
        return Vector2.Lerp(sourcePosition, targetPosistion, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        velocity.y = 0;
        velocity.x = 0;
    }
}
