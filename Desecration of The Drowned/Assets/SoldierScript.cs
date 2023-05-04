using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoldierScript : MonoBehaviour
{
    
    [Header("Stats")]
    public int health = 100;
    public int damage = 1;  
    /*what if the damage is dynamic and changes within a range, like 2-4 or 5-10 based of certain weapons
    or pick ups that you obtain. You will need to randomize these values. But only while you are shooting!
    Maybe like... on button press, release a projectile and on trigger randomize damage value. But damage needs
    to come from the character, not the projectile itself
    */

    [Header("Projectile")]
    public GameObject BulletPrefab;

    [Header("Movement")]
    public float speed = 1.0f;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Hello World!");
        rb2d = GetComponent<Rigidbody2D>(); //This is how rigidbody get instantiated and movement is allowed
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            //Shoots a bullet horizontally to the right
            //Debug.Log("You are trying to shoot");
            //GenerateBullets();
            GetComponent<AudioSource>().pitch = Random.Range(0.5f, 1f);
            GetComponent<AudioSource>().Play();
            Vector2 currentPosition = new Vector2(transform.position.x + 1,transform.position.y);
            GameObject newBullet = Instantiate(BulletPrefab,currentPosition,Quaternion.identity);
            Destroy(newBullet,2);
            
        }
        //GetComponent<Transform>().position += new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0) * speed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        //====standard rigidbody2d movement method, you should probably use something like this!
        rb2d.MovePosition(transform.position + (new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")) * Time.fixedDeltaTime * speed));
        
        //GetComponent<Rigidbody2D>().MovePosition(transform.position + (new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")) * Time.fixedDeltaTime * speed));
    }

    private void OnTriggerEnter2D(Collider2D other) {

       /* if(other.tag == "Sun"){
            score += 1;
            points.text = score.ToString();
            transform.localScale *= 1.025f;
            other.GetComponent<SunCollapse>().Consume();
            
        } */
        if(other.tag == "Enemy"){
            Debug.Log("You got hit!");
            //Maybe you can grab a parameter from the enemy to see how much damage it deals instead of hardcoding it 
            health -= 5; 
            //health -= GetComponent<DrownedSoldierScript>().damage; //Damage will be able to scale this way

            //SceneManager.LoadScene("MainMenu");
        }

        

    }

    /*void GenerateBullets(){

        StartCoroutine(GenerateBulletsRoutine());
    
        IEnumerator GenerateBulletsRoutine(){
            Debug.Log("GENERATION START!");
            //while(true){ //goes forever
                Vector2 currentPosition = new Vector2(transform.position.x,transform.position.y); //random position
                //yield return new WaitForSeconds(0.5f);
                GameObject newBullet = Instantiate(BulletPrefab,currentPosition,Quaternion.identity);
                Destroy(newBullet,1);
            //}

        }
    } */
}
