using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]private float range;
    [SerializeField]private float damage;
    [SerializeField]private float reload;
    private float NextTimeToShoot;
    public GameObject currentTarget;
    

    void Start()
    {
        NextTimeToShoot = Time.time;
    }
    private void updateNearestTarget(){
        GameObject currentNearestEnemy = null;
        float distance = Mathf.Infinity;

        foreach (GameObject enemy in Enemies.enemies) {
            if (enemy != null){
            float _distance = (transform.position - enemy.transform.position).magnitude;
            if (_distance < distance){
                distance = _distance;
                currentNearestEnemy = enemy;
            }
            }

        }
        if (distance <= range){
            currentTarget = currentNearestEnemy;
        }
        else {currentTarget = null;}
    }
    protected virtual void shoot(){
            Enemy ememyScript = currentTarget.GetComponent<Enemy>();
            ememyScript.takeDamage(damage);  
    }
  
    void Update()
    {
        updateNearestTarget();
        if (Time.time > NextTimeToShoot){
            if (currentTarget != null){
                 shoot();
                 NextTimeToShoot = Time.time + reload;
            }
        }
       
    }
}
