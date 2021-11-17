using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Shooting : MonoBehaviourPunCallbacks
{

    public Camera camera;
    public GameObject projectile;
    private Vector3 destination;
    public Transform firePoint;
    public int ammo = 3;
    public float projectileSpeed = 12f;
    PhotonView PV;
    private bool isReloading = false;

    public void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    void Start()
    {    
        if (!PV.IsMine) {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            return;
        }
         if(ammo<=0)
         {
             StartCoroutine(reload());
             ammo = 3;
         }

         if (ammo > 0)
         {
             if(Input.GetButtonDown("Fire1"))
             {
                 ammo--;
                 aim();
             }
         }
         
    }

    IEnumerator reload()
    {
        isReloading = true;
        Debug.Log("reloading");
        yield return new WaitForSeconds(1f);
        isReloading = false;
    }

    public void aim()
    {
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit rayHit;
        if (Physics.Raycast(ray, out rayHit))
        {
            destination = rayHit.point;    
        }
        else
        {
            destination = ray.GetPoint(1000);
        }

        PV.RPC("shootProjectile", RpcTarget.All,destination);
    }

    [PunRPC]
    public void shootProjectile(Vector3 target )
    {
        var projectileObj = Instantiate(projectile,firePoint.position,Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (target - firePoint.position).normalized * projectileSpeed;
    }
}
