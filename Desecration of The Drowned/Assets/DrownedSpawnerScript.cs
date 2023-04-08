using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrownedSpawnerScript : MonoBehaviour
{
    [Header("Stats")]
    public int health = 2150;
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

    private void OnTriggerEnter2D(Collider2D other) {

       /* if(other.tag == "Sun"){
            score += 1;
            points.text = score.ToString();
            transform.localScale *= 1.025f;
            other.GetComponent<SunCollapse>().Consume();
            
        } */
        if(other.tag == "Bullet"){
            Debug.Log("Enemy just got hit got hit!");
            //Maybe you can grab a parameter from the bullet to see how much damage it deals instead of hardcoding it 
            health -= 5;
             //health -= GetComponent<SoldierScript>().damage; //Damage will be able to scale this way 
             if(health <= 0){
                Destroy(gameObject);
             }

            //SceneManager.LoadScene("MainMenu");
        }
    }
}
