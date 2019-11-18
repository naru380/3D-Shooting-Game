using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGenerator : MonoBehaviour
{
    public GameObject zombiePrefab;
    private GameObject zombies;
    private Terrain field;
    GameObject zombie;
    public int maxZombieNum = 10;

    // Start is called before the first frame update
    void Start()
    {
        zombies = new GameObject("Zombies");
        field = GameObject.Find("Field").GetComponent<Terrain>();
    }

    // Update is called once per frame
    void Update()
    {
        // float terrainY = field.SampleHeight(new Vector3(140, 100, 140));
        // Debug.Log(terrainY.ToString());
        if (zombies.transform.childCount < maxZombieNum)
        {
            float randX = Random.Range(field.GetPosition().x, field.GetPosition().x + field.terrainData.size.x);
            float randZ = Random.Range(field.GetPosition().z, field.GetPosition().z + field.terrainData.size.z);
            float fieldY = field.SampleHeight(new Vector3(randX, 0, randZ));

            // Debug.Log(new Vector3(randX, fieldY, randZ));

            zombie = Instantiate(zombiePrefab) as GameObject;
            zombie.transform.SetParent(zombies.transform);
            zombie.name = "Zombie";
            zombie.transform.position = new Vector3(randX, fieldY, randZ);
            // Debug.Log(zombie.transform.position);
        }
    }
}
