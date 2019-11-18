using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject explosionMoblidePrefab;
    GameObject player;
    GameObject zombie;
    float bulletSpeed = 1000.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Vector3 playerDir = ray.direction.normalized;
            Vector3 playerPos = player.transform.position;
            
            /*
            GameObject bullet = Instantiate(bulletPrefab) as GameObject;
            bullet.transform.position = playerPos + new Vector3(playerDir.x, 0, playerDir.z) * 6.5f;
            bullet.GetComponent<Rigidbody>().velocity = new Vector3(playerDir.x, 0, playerDir.z) * bulletSpeed;
            */

            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.collider.tag == "Zombie")
                {
                    //zombie = GameObject.FindWithTag("Zombie");
                    zombie = hit.collider.gameObject;
                    // Debug.Log(zombie);
                    zombie.GetComponent<ZombieController>().Hit();
                }
            }

            GameObject shootEffect = Instantiate(explosionMoblidePrefab) as GameObject;
            shootEffect.transform.SetParent(player.transform);
            // shootEffect.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
            shootEffect.GetComponent<ParticleSystemMultiplier>().multiplier = 0.001f;
            shootEffect.transform.localPosition = new Vector3(0.3f, 0, 1.2f);
            Debug.Log(shootEffect.transform.position);
            Debug.Log(shootEffect.transform.localPosition);
            Destroy(shootEffect, shootEffect.GetComponentInChildren<ParticleSystem>().main.duration);
        }
    }
}
