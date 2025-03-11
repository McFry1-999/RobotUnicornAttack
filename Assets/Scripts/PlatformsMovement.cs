using System;
using UnityEngine;
using UnityEngine.Events;

public class PlatformsMovement : MonoBehaviour
{
    [SerializeField]

    private float Initialspeed = 2f;

    [SerializeField]

    private float speedincrease = 0.3f;

    [SerializeField]
    private UnityEvent<int> onScoreChanged;

    private bool canMove = true;

    private bool CanMove { set => canMove = value; }

    private Vector3 startingPosition;

    private float speed;

    private Vector3 MoveDistance;

    public void Start()
    {
        startingPosition = transform.position;
        speed = Initialspeed;
    }

    private void Update()
    {
        if(canMove)
        {
            MovePlatforms();
        }
    }

    private void MovePlatforms()
    {
        Vector3 distancetoMove = Vector3.left * speed * Time.deltaTime;
        transform.position += distancetoMove;
        MoveDistance += distancetoMove;
        onScoreChanged?.Invoke(Math.Abs((int)MoveDistance.x));
        

    }

    public void IncreaseSpeed()
    {
        speed += speedincrease;
    }

    public void StopMovement()
    {
        canMove = false;
    }

    public void StartMovement()
    {
        canMove = true;
    }

    public void Restart()
    {
        transform.position = startingPosition;
        speed = Initialspeed;
        MoveDistance = Vector3.zero;
        StartMovement();
    }


}
