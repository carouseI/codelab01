using UnityEngine;
using System.Collections;

public class GunShooter : MonoBehaviour
{
    #region //attempt 1
    public Rigidbody projectile;
    public float speed = 20;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("Mouse 0"); //show msg when left mouse is used
            Rigidbody instantiatedProjectile = Instantiate(projectile,          //instantiate object
                                                           transform.position,  //3D pos
                                                           transform.rotation)  //reference conversions to rb
                                                           as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed)); //move object
        }
    }
    #endregion

    #region //attempt 2
    //public GameObject spawnPoint;
    //public GameObject ExplosionPrefab;
    //public Rigidbody projectilePrefab;


    //// Use this for initialization
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //    if (Input.GetButtonDown("Fire1"))
    //    {
    //        Rigidbody hitPlayer;
    //        hitPlayer = Instantiate(projectilePrefab, transform.position, transform.rotation) as Rigidbody;
    //        hitPlayer.velocity = transform.TransformDirection(Vector3.forward * 100);
    //        //            Physics.IgnoreCollision ( projectilePrefab.collider, transform.root.collider );


    //    }


    //    for (var i = 0; i < Input.touchCount; ++i)
    //    {
    //        if (Input.GetTouch(i).phase == TouchPhase.Began)
    //        {
    //            Rigidbody clone;
    //            clone = Instantiate(projectilePrefab, transform.position, transform.rotation) as Rigidbody;
    //            clone.velocity = transform.TransformDirection(Vector3.forward * 200);
    //            //            Physics.IgnoreCollision ( projectilePrefab.collider, transform.root.collider );


    //        }
    //    }
    //}
    #endregion
}