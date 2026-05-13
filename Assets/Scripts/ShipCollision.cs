using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipCollision : MonoBehaviour
{
   
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ФИЗИЧЕСКИЙ УДАР! Врезались в: " + collision.gameObject.name + " | Тег: " + collision.gameObject.tag);
        CheckDefeat(collision.gameObject);
    }

    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("ВЫ ВЫИГРАЛИ! Астероиды пройдены!: " + other.gameObject.name + " | Тег: " + other.gameObject.tag);
        CheckDefeat(other.gameObject);
    }

    void CheckDefeat(GameObject hitObject)
    {
        if (hitObject.CompareTag("Asteroid"))
        {
            Debug.Log("ПОРАЖЕНИЕ! Перезагрузка сцены...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}