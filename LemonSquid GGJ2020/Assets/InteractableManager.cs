using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableManager : MonoBehaviour
{
    public string playerName = "Palmer";
    public int seed = 0;

    [SerializeField] private InteractableBase[] interactables;
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();

    [SerializeField] private int spawnCount;


    // Start is called before the first frame update
    void Start()
    {

       seed = playerName.GetHashCode();
        Random.seed = seed;

       spawnCount = Mathf.Clamp(spawnCount, 0, spawnPoints.Count);

        for (int i = 0; i < spawnCount; ++i)
        {
            Transform locationInfo = GetSpawnPoint();

            if (locationInfo != null)
            {
                Instantiate(GetRandomInteractable(), locationInfo.position, locationInfo.rotation);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    GameObject GetRandomInteractable()
    {
        return interactables[Random.Range(0, interactables.Length)].gameObject;
    }

    Transform GetSpawnPoint()
    {
        int num = Random.Range(0, spawnPoints.Count);
        Transform trn = spawnPoints[num];
        spawnPoints.RemoveAt(num);
        return trn;

    }




}
