using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLeft : MonoBehaviour
{
    public static ShootLeft ShootLinstance;
    // Start is called before the first frame update
    private void Awake()
    {
        if(ShootLinstance == null)
        {
            ShootLinstance = this;
        }
        else
        {
            Destroy(ShootLinstance);
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
        if(bullet!=null)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
        }
        
    }
}
