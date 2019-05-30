using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour {

    //private string taskName;
    public string taskName;// { get; private set; }
    //private Member taskMember;
    public Member taskMember;// { get; private set; }
    //private int priority;
    public int priority;// { get; private set; }
    //private float timeEstimate;
    public float timeEstimate;// { get; private set; }
    public enum progressState { assigned, inProgress, done };
    //private progressState currentProgress;
    public progressState currentProgress;// { get; private set; }

    public void AddTask (string refTaskName, Member refTaskMember, int refPriority, float refTimeEstimate){
        taskName = refTaskName;
        taskMember = refTaskMember;
        priority = refPriority;
        timeEstimate = refTimeEstimate;

        currentProgress = progressState.assigned;
    }


   
}
