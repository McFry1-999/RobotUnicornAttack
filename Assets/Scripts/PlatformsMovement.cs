using UnityEngine;

public class PlatformsMovement : MonoBehaviour
{
    [SerializeField]

    private float speed = 2f;

    [SerializeField]

    private float speedincrease = 0.3f;

    private bool canMove = true;

    private bool CanMove { set => canMove = value; }

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


}
