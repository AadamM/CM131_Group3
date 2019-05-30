using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TaskButton : MonoBehaviour
{

    public GameObject TaskDetailViewPrefab;
    public Task task;

    public Text taskName;
    public Text info;



    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowDetailedView);

        if(task != null)
        {
            UpdateWithTask(task);
        }
       
    }


    public void UpdateWithTask(Task task)
    {
        this.task = task;
        taskName.text = task.taskName;
        info.text = "Priority: " + task.priority + "  Time: " + task.timeEstimate;
       
    }

    public void ShowDetailedView()
    {
        var view = Instantiate(TaskDetailViewPrefab, FindObjectOfType<Canvas>().transform).GetComponent<TaskDetailedView>();
        view.transform.position = transform.position;
        view.SetTask(task);
        
    }
}
