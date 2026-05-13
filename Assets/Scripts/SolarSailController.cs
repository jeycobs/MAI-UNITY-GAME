using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SolarSailController : MonoBehaviour
{
    [Header("Настройки ветра")]
    public Vector3 windDirection = new Vector3(0, 0, 1); // Ветер дует по оси Z
    public float windStrength = 40f;

    [Header("Ссылки")]
    public Transform sailTransform; // Наш SailPivot[Header("Управление")]
    public float sailRotationSpeed = 150f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        windDirection = windDirection.normalized; // Убеждаемся, что длина вектора = 1
    }

    void Update()
    {
        // Читаем движение мыши влево/вправо
        float mouseX = Input.GetAxis("Mouse X");
        // Крутим SailPivot вокруг оси Y (вверх)
        sailTransform.Rotate(Vector3.up, mouseX * sailRotationSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        // 1. Узнаем, насколько парус "смотрит" на ветер (Скалярное произведение)
        float windAngleDot = Vector3.Dot(sailTransform.forward, windDirection);

        // 2. Рассчитываем силу (тянет туда, куда повернут парус)
        Vector3 appliedForce = sailTransform.forward * windAngleDot * windStrength;

        // 3. Толкаем корабль
        rb.AddForce(appliedForce, ForceMode.Force);
    }
}