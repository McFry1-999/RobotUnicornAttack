using UnityEngine;

public class PlatformsMovement : MonoBehaviour
{
    [SerializeField]

    private float Initialspeed = 2f;

    [SerializeField]

    private float speedincrease = 0.3f;

    private bool canMove = true;

    private bool CanMove { set => canMove = value; }

    private Vector3 startingPosition;

    private float speed;

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
        transform.position += Vector3.left * speed * Time.deltaTime;

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
        StartMovement();
    }


}
