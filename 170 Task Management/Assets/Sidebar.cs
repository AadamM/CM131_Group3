using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Sidebar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchToScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void SwitchToGraphs()
    {
        SceneManager.LoadScene(1);
    }

    public void SwitchToPeople()
    {
        SceneManager.LoadScene(2);
    }
    
}
