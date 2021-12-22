using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTargetLeft : MonoBehaviour
{
    public Transform targetEnemy;
    public float range = 1f;
    public float armTurnSpeed = 10f;
    public float NextShot = -1f;
    public float fireRate = 0.5f;
    public bool canShot = true;

    public string enemyTag = "Enemy";
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemiesArray = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        
        foreach(GameObject enemy in enemiesArray)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            targetEnemy = nearestEnemy.transform;
           
        }
        else
        {
            targetEnemy = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (targetEnemy == null)
            return;
        Vector3 dir = targetEnemy.position - transform.position;

        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * armTurnSpeed);
        transform.rotation = rotation;
        Mathf.Clamp(transform.rotation.eulerAngles.y, -45, 0);
        if(Time.time > NextShot)
        {
            canShot = true;
        }
        if(Input.GetKeyDown(KeyCode.Space) && canShot == true)
        {
            ShootLeft.ShootLinstance.ShootBullet();
            NextShot = Time.time + fireRate;
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, range);
    }

}
