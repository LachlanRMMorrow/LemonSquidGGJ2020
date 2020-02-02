using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableManager : SingletonBase<InteractableManager>
{
    [System.Serializable]
    public class RepairRequired
    {
        public RepairRequired()
        {
            amount = 0;
            complete = false;
        }


        public RepairInteractable item;

        public int amountRequired;
        // [HideInInspector] 
        public int amount;

        public bool complete;

        public void FoundItem()
        {
            Debug.Log("Found");
            amount++;
            if (amount >= amountRequired)
            {
                complete = true;
            }
        }

        public string GetDescription()
        {
            string str = "";

            if (complete)
                str += "<s>";

            str += "Find " + amount + "/" + amountRequired + " " + item.itemName;
            if (complete)
                str += "</s>";

            return str;
        }

    }



    public string playerName = "Palmer";
    public int seed = 0;

    [SerializeField] private InteractableBase[] interactables;
    [SerializeField] public RepairRequired[] repairRequired;
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();

    public GameObject rubblePrefab;
    public GameObject sparkle;
    public GameObject confetti;


    [SerializeField] private int spawnCount;


    BreakableInteractable m_brokenObject;
    public BreakableInteractable brokenObject { get { return m_brokenObject; } }
    public bool hasBrokenObject { get { return m_brokenObject != null; } }

    // Start is called before the first frame update
    void Start()
    {
        // SpawnRepairObjects();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnRepairObjects()
    {
        seed = PlayerPrefs.GetString(playerName).GetHashCode();
        Random.seed = seed;


        for (int i = 0; i < InteractableManager.Instance.repairRequired.Length; ++i)
        {
            for (int j = 0; j < InteractableManager.Instance.repairRequired[i].amountRequired; ++j)
            {
                Transform locationInfo = GetSpawnPoint();

                if (locationInfo != null)
                {
                    RepairInteractable obj = Instantiate(InteractableManager.Instance.repairRequired[i].item, locationInfo.position, locationInfo.rotation);
                    obj.sparkle = Instantiate(sparkle, locationInfo.position, locationInfo.rotation);
                    obj.sparkle.transform.SetParent(obj.transform);
                }
            }
        }



        spawnCount = Mathf.Clamp(spawnCount, 0, spawnPoints.Count);

        for (int i = 0; i < spawnCount; ++i)
        {
            Transform locationInfo = GetSpawnPoint();

            if (locationInfo != null)
            {
                RepairInteractable obj = Instantiate(GetRandomInteractable(), locationInfo.position, locationInfo.rotation).GetComponent<RepairInteractable>();
                obj.sparkle = Instantiate(sparkle, locationInfo.position, locationInfo.rotation);
                obj.sparkle.transform.SetParent(obj.transform);
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


    public void SetBrokenObject(BreakableInteractable interactable)
    {
        if (m_brokenObject == null)
        {
            GameManager.Instance.StartTimer();
            UIManager.Instance.DisplayCurrentObjective(true);
            m_brokenObject = interactable;
            m_brokenObject.Break();

            repairRequired = m_brokenObject.neededItems;

            rubblePrefab = Instantiate(rubblePrefab, interactable.transform.position, interactable.transform.rotation);


            m_brokenObject.GetComponentInChildren<MeshRenderer>().enabled = false;

            SpawnRepairObjects();
            OnItemsUpdate?.Invoke();
        }
    }





    public bool CollectItem(RepairInteractable item)
    {
        if (item == null)
            return false;

        for (int i = 0; i < repairRequired.Length; i++)
        {
            if (repairRequired[i].item != null)
            {
                if (!repairRequired[i].complete)
                {
                    if (repairRequired[i].item.ID == item.ID)
                    {
                        repairRequired[i].FoundItem();
                        OnItemsUpdate?.Invoke();

                        if (CheckRepair())
                        {
                            Debug.Log("DONE");
                            GameManager.Instance.Complete(true);
                        }
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public bool CheckRepair()
    {
        bool done = true;
        for (int i = 0; i < repairRequired.Length; ++i)
        {
            if (!repairRequired[i].complete)
                done = false;
        }

        if (done)
        {
            rubblePrefab.SetActive(false);
            m_brokenObject.GetComponentInChildren<MeshRenderer>().enabled = true;
            return true;
        }

        return false;
    }




    public static System.Action OnItemsUpdate;



}
