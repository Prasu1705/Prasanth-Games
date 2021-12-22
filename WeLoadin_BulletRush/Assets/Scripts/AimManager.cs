using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimManager : MonoBehaviour
{
    LookAtEnemy[] lookAtEnemies;
    List<GameObject> enemiesList = new List<GameObject>();
    public GameObject closestEnemy;
    public float maxRange = 1000;
    public string enemyTag = "Enemy";

    // Start is called before the first frame update
    void Start()
    {
        lookAtEnemies = this.GetComponentsInChildren<LookAtEnemy>();
        Enemy[] enemiesInScene = FindObjectsOfType<Enemy>();
        foreach(Enemy enemy in enemiesInScene)
        {
            enemiesList.Add(enemy.gameObject);
            Debug.Log(enemy.gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Shoot();
        }

        ClosestEnemy();
    }

    void ClosestEnemy()
    {
        float range = maxRange;
        foreach (GameObject enemyGameObject in enemiesList)
        {
            float dist = Vector3.Distance(enemyGameObject.transform.position, PlayerManager.Instance.player.transform.position);
            if (dist < range)
            {
                range = dist;
                closestEnemy = enemyGameObject;
            }
        }

        foreach (LookAtEnemy lookAtEnemy in lookAtEnemies)
        {
            lookAtEnemy.enemy = closestEnemy;
        }
    }

    void Shoot()
    {
        print("Fire!");
        if (closestEnemy != null && LookAtEnemy.canShoot == true)
        {
            print(closestEnemy.name);
            print(LookAtEnemy.canShoot.ToString());
            enemiesList.Remove(closestEnemy);
            closestEnemy.GetComponent<Enemy>().Die();
        }
    }
}