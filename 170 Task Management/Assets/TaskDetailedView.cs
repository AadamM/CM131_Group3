using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TaskDetailedView : MonoBehaviour
{

    public GameObject priorityInput;
    public GameObject timeInput;

    public Text mainText;
    public Text infoText;

    public Button reviewButton;

    Task task;

    public void SetTask(Task task)
    {
        this.task = task;
        mainText.text = task.taskName;
        infoText.text = "Priority: " + task.priority + "\nTime: " + task.timeEstimate;

    }

    public void SetAllowEdits(bool canEdit = true)
    {
        if (canEdit)
        {
            priorityInput.SetActive(true);
            var inputField = priorityInput.GetComponent<InputField>();
            inputField.placeholder.GetComponent<Text>().text = task.priority.ToString();

            timeInput.SetActive(true);
            inputField = timeInput.GetComponent<InputField>();
            inputField.placeholder.GetComponent<Text>().text = task.timeEstimate.ToString();

            reviewButton.GetComponentInChildren<Text>().text = "Submit";
            reviewButton.onClick.AddListener(() => { gameObject.SetActive(false); });
        }
    }


}
