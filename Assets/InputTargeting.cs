using Assets.Controllers;
using Assets.Models.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputTargeting : MonoBehaviour
{
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Left click
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity) && hit.transform.tag == "Ennemy")
            {
                var enemy = hit.collider.gameObject;
                var enemyStats = enemy.GetComponent<Stats>();

                if (Vector3.Distance(gameObject.transform.position, enemy.transform.position) >= GameController.Instance.player.stats.attackRange)
                {
                    enemyStats.health -= GameController.Instance.player.stats.attackDmg;
                    enemy.GetComponentInChildren<Slider>().value = enemyStats.health;
                    if (enemyStats.health <= 0)
                    {
                        GameController.Instance.player.stats.exp += enemyStats.exp;
                        GameController.Instance.player.stats.gold += enemyStats.gold;
                        GameController.Instance.player.NotifyAllObservers();
                        GameController.Instance.WaveController.Kill(enemy);
                    }
                }

            }
        }

    }
}
