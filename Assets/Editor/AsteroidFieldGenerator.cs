using UnityEngine;
using UnityEditor;

public class AsteroidFieldGenerator : EditorWindow
{
    GameObject asteroidPrefab;
    int asteroidCount = 150;
    float fieldRadius = 300f;
    float minScale = 1f;
    float maxScale = 8f;

 [MenuItem("Tools/Генератор Астероидов")]
    public static void ShowWindow()
    {
        GetWindow<AsteroidFieldGenerator>("Генератор Астероидов");
    }

    void OnGUI()
    {
        GUILayout.Label("Настройки поля астероидов", EditorStyles.boldLabel);
        
        asteroidPrefab = (GameObject)EditorGUILayout.ObjectField("Префаб астероида", asteroidPrefab, typeof(GameObject), false);
        asteroidCount = EditorGUILayout.IntSlider("Количество", asteroidCount, 10, 1000);
        fieldRadius = EditorGUILayout.FloatField("Радиус (Ширина поля)", fieldRadius);
        minScale = EditorGUILayout.FloatField("Мин. размер", minScale);
        maxScale = EditorGUILayout.FloatField("Макс. размер", maxScale);

        if (GUILayout.Button("Сгенерировать поле"))
        {
            GenerateField();
        }
    }

    void GenerateField()
    {
        if (asteroidPrefab == null) 
        {
            Debug.LogWarning("Пожалуйста, назначьте префаб астероида!");
            return;
        }

        GameObject parent = new GameObject("Asteroid_Field");

        for (int i = 0; i < asteroidCount; i++)
        {
            // Случайная позиция
            Vector3 randomPos = Random.insideUnitSphere * fieldRadius;
            
            // Сплющиваем сферу в "блин", чтобы астероиды были примерно на одной высоте с кораблем
            randomPos.y *= 0.1f; 
            // Сдвигаем всё поле вперед по оси Z, чтобы корабль стартовал до поля
            randomPos.z += fieldRadius; 

            GameObject ast = (GameObject)PrefabUtility.InstantiatePrefab(asteroidPrefab);
            ast.transform.position = randomPos;
            ast.transform.rotation = Random.rotation;
            
            float scale = Random.Range(minScale, maxScale);
            ast.transform.localScale = new Vector3(scale, scale, scale);
            
            // ДЕЛАЕМ ОБЪЕКТЫ СТАТИЧНЫМИ (нужно для запекания света)
            ast.isStatic = true; 
            ast.transform.SetParent(parent.transform);
        }
    }
}