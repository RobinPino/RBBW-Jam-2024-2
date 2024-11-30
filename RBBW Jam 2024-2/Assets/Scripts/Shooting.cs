using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Vector3 MousePosition;
    private Camera MainCamera;

    public GameObject Bullet;
    public Transform BulletTransform;

    public bool CanFire;

    private float Timer;
    public float ShootingCooldown;



    void Start()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {
        MousePosition = MainCamera.ScreenToWorldPoint(Input.mousePosition);

        float ZRotation = Mathf.Atan2(MousePosition.y, MousePosition.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, ZRotation - 90);

        if (!CanFire)
        {
            Timer += Time.deltaTime;

            if (Timer > ShootingCooldown)
            {
                CanFire = true;
                Timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && CanFire)
        {
            CanFire = false;
            Instantiate(Bullet, BulletTransform.position, Quaternion.identity);
        }
    }
}
