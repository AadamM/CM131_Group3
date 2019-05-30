using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour {

    private string taskName;
    private Member taskMember;
    private int priority;
    private float timeEstimate;
    private enum progressState { assigned, inProgress, done };
    private progressState currentProgress;

    public void AddTask (string refTaskName, Member refTaskMember, int refPriority, float refTimeEstimate){
        taskName = refTaskName;
        taskMember = refTaskMember;
        priority = refPriority;
        timeEstimate = refTimeEstimate;

        currentProgress = progressState.assigned;
    }
}
