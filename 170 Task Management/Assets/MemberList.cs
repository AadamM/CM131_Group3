using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MemberList : MonoBehaviour
{
    //Globally available
    private static MemberList instance;
    public List<GameObject> members;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform contentZone;
    //Singleton pattern 
    private void Awake()
    {
        //If it already exist destroy it
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            MemberList.instance.gameObject.SetActive(true);
            Destroy(gameObject);
        }
        

        //Don't destroy between scenes
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneUnloaded += Hide;
    }

    private void Hide(Scene arg0)
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add()
    {
        GameObject item = Instantiate(prefab, contentZone);
        item.transform.SetAsLastSibling();
        item.transform.SetSiblingIndex(item.transform.GetSiblingIndex() - 1);
        members.Add(item);
    }
}

