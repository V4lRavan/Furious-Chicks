using System.Collections;
using UnityEngine;


[SelectionBase]
public class Enemy : MonoBehaviour
{
    [SerializeField] Sprite Death;
    [SerializeField] ParticleSystem particles;
    AudioSource deathSound;
    bool isDead;

    IEnumerator Start()
    {
        while (isDead == false)
        {
            float delay = Random.Range(5, 30);

            yield return new WaitForSeconds(delay);
        }
        if (GetComponent<AudioSource>()== null)
        {
            Debug.Log("sdjkfhnsjf");
        }
      
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (DeathFromCollision(collision))
        {
            StartCoroutine(Die());
           
        }
    }

    bool DeathFromCollision(Collision2D collision)
    {
        if (isDead)
        
            return false;
        
            

        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird != null)
        {
            Score.score += 10;
            return true;
        }
           
        
           

        if (collision.contacts[0].normal.y < -0.5)
        
            return true;
        
            

        return false;
    }

    IEnumerator Die()
    {
      
        isDead = true;
        GetComponent<AudioSource>().Play();
        GetComponent<Animator>().enabled= false;
        GetComponent<SpriteRenderer>().sprite = Death;
        particles.Play();
        yield return new WaitForSeconds(1);
        Score.score += 5;
        gameObject.SetActive(false);
    }
}