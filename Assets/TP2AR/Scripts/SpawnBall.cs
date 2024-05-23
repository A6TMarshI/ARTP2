using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] private GameObject Prefab;
    [SerializeField] [Range(0, 100.0f)] private float Speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            if (!Prefab) return;
            var PrefabInstance = Instantiate(Prefab);
            if (!PrefabInstance) return;
            var RigidBody = PrefabInstance.GetComponent<Rigidbody>();
            if (!RigidBody) return;
            RigidBody.AddForce(PrefabInstance.transform.forward * Speed, ForceMode.Impulse);
        }
    }
}