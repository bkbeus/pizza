using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundControl : MonoBehaviour
{
   public GameObject enemey;
   public float timeBetweenWaves;
   public float timeBeforeRoundStarts;
   public float timeVariable;
   public bool isRoundGoing;
   public bool isIntermission;
   public bool isStartOfRound;
   public int round;
   
   private void Start() {
    isRoundGoing = false;
    isIntermission = false;
    isStartOfRound = true;
    timeVariable = Time.time + timeBeforeRoundStarts;
    round = 1;
   }
   private void SpawnEnemies(){
     StartCoroutine("ISpawnEnemies");
   }
   IEnumerator ISpawnEnemies(){
    for (int i = 0; i < round; i++){
            GameObject newEnemy = Instantiate(enemey,MapGen.startTile.transform.position,Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
   }
   private void Update() {
    if(isStartOfRound){
        if (Time.time >= timeVariable){
            isStartOfRound = false;
            isRoundGoing = true;
            return;
        }
    }
    else if (isIntermission){
        if (Time.time >= timeVariable){
            isIntermission = false;
            isRoundGoing = true;
            SpawnEnemies();
        }
    }
    else if (isRoundGoing){
        if (Enemies.enemies.Count > 0){

        }
        else {
            isIntermission = true;
            isRoundGoing = false;
            timeVariable = Time.time + timeBetweenWaves;
            round = round + 1;
        }
    }
   }
}
