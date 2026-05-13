using UnityEngine;

public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SolarSailController>() != null)
        {
            // Ищем GameManager на сцене и вызываем победное меню!
            FindObjectOfType<GameManager>().ShowWinMenu();
        }
    }
}