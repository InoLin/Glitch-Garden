using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian : MonoBehaviour
{
    public GameObject projectile, gun; //A.存放拋射物、發射位置
    private Animator animator; //D.宣告m_Animator
    GameObject projectileParent; //E.
    const string PROJECTILE_PARENT_NAME = "Projectiles"; //E.
    public GameObject guardVFX;

    private void Start()
    {
        CreateProjectileParent(); //E.執行生成projectileParent的方法
        animator = GetComponent<Animator>(); //D.獲取Animator的Component
    }

    //A.產生拋射物的方法
    public void fire()
    {
        //E.
        GameObject newProjectile =
            Instantiate(projectile, gun.transform.position, gun.transform.rotation);
        //E.把新生拋射物變成projectileParent的子物件
        newProjectile.transform.parent = projectileParent.transform;
    }

    //E.生成projectileParent的方法
    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    public void SpawnGuardVFX()
    {
        Instantiate(guardVFX, transform.position, transform.rotation);
    }
}
