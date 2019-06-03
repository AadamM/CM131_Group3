using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TaskManager : MonoBehaviour
{


    public GameObject assignedScrollViewContent;
    public GameObject inProgressScrollViewContent;
    public GameObject doneScrollViewContent;

    public Slider progressSlider;
    public TaskButton taskButtonPrefab;

    Task[] tasks;
    // Start is called before the first frame update

    void Update()
    {
        int numDone = 0;
        int numNotDone = 0;

        foreach (Task task in tasks)
        {
            switch (task.currentProgress)
            {
                case Task.progressState.inProgress:
                    numNotDone++;
                    break;
                case Task.progressState.done:
                    numDone++;
                    break;
                case Task.progressState.assigned:
                    numNotDone++;
                    break;
            }
        }
        Debug.Log("NumDone: " + numDone);
        progressSlider.value = (float)numDone / (numDone + numNotDone);
    }
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

    
}
