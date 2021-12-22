using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    float enemyRotationSpeed = 4.0f, enemyMoveSpeed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.LookRotation(PlayerManager.Instance.player.transform.position - gameObject.transform.position), enemyRotationSpeed * Time.deltaTime);
            gameObject.transform.position += gameObject.transform.forward * enemyMoveSpeed * Time.deltaTime;
        }
    }
}
