using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabs = new GameObject[2];
    private int poolSize = 10;
    [SerializeField] private List<GameObject> poolObjects;
    private int activeObjectsCount = 0;
    private float positionX = 4f;
    private float positionZ = 3.5f;
    public TextMeshProUGUI objectsInSceneText;
    private bool gameActive = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddToPool(poolSize);
        StartCoroutine(SpawnPrefabs());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPrefabs() 
    {
        while (gameActive)
        {
            yield return new WaitForSeconds(2);
            if (activeObjectsCount < 10) 
            {
                GameObject temporal = FirstDesactivate();
                temporal.transform.position = RandomPosition();
                temporal.SetActive(true);
                activeObjectsCount+=1;
                objectsInSceneText.text = "Objects In Scene: " + activeObjectsCount;
            }  
        }
    }

    void AddToPool(int apoolSize) 
    {
        for (int i = 0; i < apoolSize; i++)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            GameObject spawnPrefab = prefabs[randomIndex];
            GameObject prefabObject;
            prefabObject = Instantiate(spawnPrefab, Vector3.zero,Quaternion.identity);
            prefabObject.SetActive(false);
            poolObjects.Add(prefabObject);
        }
    }

    Vector3 RandomPosition() 
    {
        float randomPositionX = Random.Range(-positionX, positionX );
        float randomPositionZ = Random.Range(-positionZ, positionZ);
        Vector3 positonprefab = new Vector3(randomPositionX, 0.25f, randomPositionZ);
        return positonprefab;
    }

    public GameObject FirstDesactivate()
    {
        //.count devuelve el tamaño de la lista  
        for (int i = 0; i < poolObjects.Count; i++)
        {  
            if (!poolObjects[i].activeInHierarchy)
            {
                return poolObjects[i];
            }
        }

        AddToPool(1);
        return poolObjects.Last<GameObject>();
    }




 }
