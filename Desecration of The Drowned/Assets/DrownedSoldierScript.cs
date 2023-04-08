using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrownedSoldierScript : MonoBehaviour
{
    [Header("Stats")]
    public int health = 20;
    public int damage = 5; 

    [Header("Movement")]
    public float speed = 1.0f; //This is not doing anything at the moment but will kick in when I add AI Movement

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
