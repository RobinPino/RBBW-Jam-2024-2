
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour

{   public Vector3 targetLocation;
    [SerializeField] int speed;
    private Rigidbody2D rb2d;
    
  void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toTarget = targetLocation - transform.position;
        if (toTarget.magnitude > speed) {
            rb2d.velocity = toTarget.normalized * speed;

        }
        else
        {
            rb2d.velocity = Vector3.zero;
        }
    }
}
