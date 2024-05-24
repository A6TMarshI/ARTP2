using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerGoal : MonoBehaviour
{
    public event EventHandler<OnGoalScoredEventArgs> OnGoalScored;

    public class OnGoalScoredEventArgs : EventArgs
    {
        public float Score;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        var AudioSource = GetComponent<AudioSource>();
        if (AudioSource && AudioSource.clip)
        {
            AudioSource.Play();
        }
        OnGoalScored(this, new OnGoalScoredEventArgs { Score = 10.0f });
    }
}