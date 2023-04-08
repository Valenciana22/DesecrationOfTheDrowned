using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrownedSpawnerScript : MonoBehaviour
{
    public GameObject drownedPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GenerateDrowned();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateDrowned(){

        StartCoroutine(GenerateDrownedRoutine());
    
        IEnumerator GenerateDrownedRoutine(){
            Debug.Log("GENERATION START!");
            while(true){ //goes forever
                //Vector2 randomPosition = new Vector2(Random.Range(-10f,13f),6.8f); //random position
                Vector2 randomPosition = new Vector2(transform.position.x + Random.Range(-2f,2f),transform.position.y + Random.Range(-2f,2f));
                yield return new WaitForSeconds(5f);
                GameObject newDrowned = Instantiate(drownedPrefab,randomPosition,Quaternion.identity);
                //Destroy(newDrowned,10);
            }

        }
    }
}
