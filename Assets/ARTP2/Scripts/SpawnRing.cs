using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnRing : MonoBehaviour
{
    [SerializeField] private GameObject RingPrefab;
    private GameObject RingInstance;

    private float Distance;

    // Start is called before the first frame update
    void Start()
    {
        if (!SpawnNewRing()) return;
        RegisterOnGoalScored(RingInstance);
    }

    private void RegisterOnGoalScored(GameObject RingInstance)
    {
        var Script = RingInstance.GetComponentInChildren<TriggerGoal>();
        if (!Script) return;
        Script.OnGoalScored += SpawnNewRingOnGoalScored;
    }

    private bool SpawnNewRing()
    {
        if (!RingPrefab)
        {
            RingInstance = null;
            return false;
        }

        Distance = Random.Range(10.0f, 30.0f);
        Vector3 SpawnLocation = transform.position + (transform.forward * Distance) - (transform.up * 4);
        RingInstance = Instantiate(RingPrefab, SpawnLocation, transform.rotation);
        return true;
    }

    private void SpawnNewRingOnGoalScored(object sender, TriggerGoal.OnGoalScoredEventArgs e)
    {
        StartCoroutine(SpawnNewRingCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnNewRingCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        if (RingInstance)
        {
            Destroy(RingInstance);
            RingInstance = null;
        }

        if (SpawnNewRing())
        {
            RegisterOnGoalScored(RingInstance);
        }
    }
}