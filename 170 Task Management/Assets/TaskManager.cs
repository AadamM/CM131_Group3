using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TaskManager : MonoBehaviour
{


    public GameObject assignedScrollViewContent;
    public GameObject inProgressScrollViewContent;
    public GameObject doneScrollViewContent;


    public TaskButton taskButtonPrefab;

    Task[] tasks;
    // Start is called before the first frame update
    void Start()
    {
        tasks = FindObjectsOfType<Task>();

        foreach (Task task in tasks){
            TaskButton newButton = null;
            switch (task.currentProgress)
            {
                case Task.progressState.assigned:
                    newButton = Instantiate(taskButtonPrefab, assignedScrollViewContent.transform);
                    break;
                case Task.progressState.done:
                    newButton = Instantiate(taskButtonPrefab, doneScrollViewContent.transform);

                    break;
                case Task.progressState.inProgress:
                    newButton = Instantiate(taskButtonPrefab, inProgressScrollViewContent.transform);
                    break;

            }

            if (newButton)
            {
                newButton.UpdateWithTask(task);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
