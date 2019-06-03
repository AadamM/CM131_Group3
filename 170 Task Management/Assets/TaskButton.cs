using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class TaskButton : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
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

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging!");
        transform.position = Input.mousePosition;
        return;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        PointerEventData pe = new PointerEventData(EventSystem.current);
        pe.position = Input.mousePosition;
        List<RaycastResult> objectsHit = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pe, objectsHit);

        foreach (var hit in objectsHit)
        {
            if(hit.gameObject.name == "In Progress Scroll View")
            {
                Debug.Log("Dropped In Progress");
                this.task.currentProgress  = Task.progressState.inProgress;
                transform.SetParent(hit.gameObject.GetComponentInChildren<VerticalLayoutGroup>().transform);

            }

            if (hit.gameObject.name == "Assigned Scroll View")
            {

                Debug.Log("Dropped Assigned");
                this.task.currentProgress = Task.progressState.assigned;

                transform.SetParent(hit.gameObject.GetComponentInChildren<VerticalLayoutGroup>().transform);
            }

            if(hit.gameObject.name == "Done Scroll View")
            {
                Debug.Log("Dropped Done");
                this.task.currentProgress = Task.progressState.done;

                transform.SetParent(hit.gameObject.GetComponentInChildren<VerticalLayoutGroup>().transform);
            }
        }

        return;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Dragg Start");
        transform.SetParent(FindObjectOfType<Canvas>().transform);
        return;
    }
}
