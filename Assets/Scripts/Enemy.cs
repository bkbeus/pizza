using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private float enemyHealth;
    [SerializeField]private  float speed;
    private int killMoney;
    private int damage;
    private GameObject targetTile;
    private void Awake(){
        Enemies.enemies.Add(gameObject);
    }

    private void Start() {
        initializeEnemy();
    }
    private void initializeEnemy(){
        targetTile = MapGen.startTile;
    }
    public void takeDamage(float amount){
        enemyHealth -= amount;
        if (enemyHealth <= 0){
            die();
        }
    }
    private void die(){
        Enemies.enemies.Remove(gameObject);
        Destroy(transform.gameObject);
    }
    private void moveEnemy(){
        transform.position = Vector3.MoveTowards(transform.position,targetTile.transform.position,speed * Time.deltaTime);

    }
    private void checkPosition(){
        if (targetTile != null && targetTile != MapGen.endTile){
            float distance = (transform.position - targetTile.transform.position).magnitude;
            if(distance < 0.001f){
                int currentIndex = MapGen.pathTiles.IndexOf(targetTile);
                targetTile = MapGen.pathTiles[currentIndex +1 ];
            }
        }

    }
    private void Update() {
        checkPosition();
        moveEnemy();
        takeDamage(0);
    }
}
