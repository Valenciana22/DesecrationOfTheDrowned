using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoodScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        StartCoroutine(startCombat());
        

    }

     IEnumerator startCombat()
 {
     GetComponent<AudioSource>().Play();
     yield return new WaitForSeconds(1);
     Destroy(gameObject);
     SceneManager.LoadScene("SampleScene");
 }
}
