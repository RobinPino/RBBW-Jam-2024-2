using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 MousePosition;
    private Camera MainCamera;
    private Rigidbody2D RigidBody;
    public float BulletSpeed;

    [SerializeField] EventChannelSO enemyKillChannel;

    void Start()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        RigidBody = GetComponent<Rigidbody2D>();

        MousePosition = MainCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 Direction = MousePosition - transform.position;
        Vector3 Rotation = transform.position - MousePosition;

        RigidBody.velocity = new Vector2(Direction.x, Direction.y).normalized * BulletSpeed;
        float ZRotation = Mathf.Atan2(Rotation.y, Rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, ZRotation + 180);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit!");

            enemyKillChannel.Invoke(this);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
