using System.Collections.Generic;
using UnityEngine;

public class ConveyorManager : MonoBehaviour
{
    public static bool canStart = false;
    
    [SerializeField] private float spawnTimer;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Transform endPosition;
    [SerializeField] private GameObject[] itemPrefabs;
    [SerializeField] private Material[] itemMaterials;

    private List<GameObject> spawnedItems;
    private float _currentSpawnTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnedItems = new List<GameObject>();
        _currentSpawnTimer = spawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canStart) return;
        
        _currentSpawnTimer -= Time.deltaTime;

        if (_currentSpawnTimer <= 0f)
        {
            _currentSpawnTimer = spawnTimer;
            var spawnedItem = SpawnConveyorItem();
            spawnedItem.GetComponent<MeshRenderer>().material = GetMaterial();
            var conveyorItem = spawnedItem.GetComponent<ConveyorItem>();
            conveyorItem.SetEndPosition(endPosition);
            conveyorItem.OnDestroyed += HandleObjectDestroyed;
            spawnedItems.Add(spawnedItem);
            
        }
    }

    private GameObject SpawnConveyorItem()
    {
         return Instantiate(GetItemPrefab(), spawnPosition.position + new Vector3(0, .5f, 0),
             Quaternion.identity);
    }

    private GameObject GetItemPrefab()
    {
        return itemPrefabs[Random.Range(0, itemPrefabs.Length)];
    }

    private Material GetMaterial()
    {
        return itemMaterials[Random.Range(0, itemMaterials.Length)];
    }
    private void HandleObjectDestroyed(GameObject obj)
    {
        spawnedItems.Remove(obj);
    }
}

