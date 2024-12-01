using UnityEngine;

public class ShapeBehaviour : MonoBehaviour
{
    public Vector3 targetLocation;
    private Rigidbody2D rb2d;
    public Shape shape;
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = shape.sprite;
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        Vector3 toTarget = targetLocation - transform.position;
        if (toTarget.magnitude > 1) { 
            if ((shape.type == Shape.Type.Square) || (shape.type == Shape.Type.Triangle))
            {

            
                rb2d.velocity = toTarget.normalized * shape.speed;

           
            }
            else if (shape.type == Shape.Type.Rhombus)
            {
                rb2d.velocity = (toTarget.normalized + 2*(new Vector3(-toTarget.y, toTarget.x, 0).normalized) * Mathf.Sin(Time.time*2)) * shape.speed;
            }
    }
        else
        {
                rb2d.velocity = Vector3.zero;
        }
    }


}
