using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableManager : SingletonBase<InteractableManager>
{
    public string playerName = "Palmer";
    public int seed = 0;

    [SerializeField] private InteractableBase[] interactables;
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();

    [SerializeField] private int spawnCount;


    InteractableBase brokenObject;
    public bool hasBrokenObject { get { return brokenObject != null; } }


    // Start is called before the first frame update
    void Start()
    {
        SpawnRepairObjects();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnRepairObjects()
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


    public void SetBrokenObject(InteractableBase interactable)
    {
        if (brokenObject == null)
        {
            GameManager.Instance.StartTimer();
            brokenObject = interactable;
        }
    }




}
