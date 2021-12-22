using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRight : MonoBehaviour
{
    public static ShootRight ShootRinstance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (ShootRinstance == null)
        {
            ShootRinstance = this;
        }
        else
        {
            Destroy(ShootRinstance);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShootBullet()
    {
        GameObject bullet = ObjectPoolManager.PoolInstance.GetPooledObject("bullet");
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
    }
}
