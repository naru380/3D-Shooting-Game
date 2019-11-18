using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpGaugeController : MonoBehaviour
{
    private GameObject zombie;
    private Slider hpGauge;
    private GameObject gameDirector;

    // Start is called before the first frame update
    void Start()
    {
        zombie = GameObject.Find("Zombie");
        zombie = transform.parent.parent.gameObject;
        hpGauge = GetComponent<Slider>();
        hpGauge.maxValue = zombie.GetComponent<ZombieController>().hp;
        gameDirector = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        hpGauge.value = zombie.GetComponent<ZombieController>().hp;
        if(hpGauge.value <= 0)
        {
            gameDirector.GetComponent<GameDirector>().killZombie();
            Destroy(zombie.gameObject);
        }
    }
}
