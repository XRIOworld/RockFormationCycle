using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class handSpawnObject : MonoBehaviour
{
    [SerializeField] private OVRHand m_Hand = null;
    [SerializeField] private GameObject[] m_ObjectPrefabs = new GameObject[3];
    [SerializeField] private float m_SpawnSpeed = 5.0f;
    [SerializeField] private float m_MaxSpawnDistance = 10.0f;
    [SerializeField] private Vector3 m_SpawnRange = new Vector3(2.0f, 2.0f, 2.0f);
    [SerializeField] private GameObject m_TrailPrefab = null;

    private bool m_LastIndexPinchState = false;
    private List<Vector3> m_TrailPositions = new List<Vector3>();

    private void Update()
    {
        bool indexPinch = m_Hand.GetFingerIsPinching(OVRHand.HandFinger.Index);

        if (indexPinch && !m_LastIndexPinchState)
        {
            Vector3 handPos = m_Hand.transform.position;
            Vector3 handForward = m_Hand.transform.forward;

            Vector3 spawnPos = handPos + handForward * m_MaxSpawnDistance;
            Vector3 spawnDirection = handForward;
            Vector3 upwardForce = Vector3.up * m_SpawnSpeed;

            // Choose a random object prefab from the first three in the array
            int randomIndex = Random.Range(0, m_ObjectPrefabs.Length);
            GameObject objPrefab = m_ObjectPrefabs[randomIndex];

            // Instantiate the object at the spawn position and direction
            GameObject obj = Instantiate(objPrefab, spawnPos, Quaternion.LookRotation(spawnDirection));

            // Apply a force to the object in the spawn direction with the specified speed
            obj.GetComponent<Rigidbody>().AddForce(spawnDirection * m_SpawnSpeed, ForceMode.VelocityChange);

            // Apply an upward force to the object with the specified speed
            obj.GetComponent<Rigidbody>().AddForce(upwardForce, ForceMode.VelocityChange);

            // Create a TrailRenderer as a child of the spawned object
            GameObject trail = Instantiate(m_TrailPrefab, obj.transform);
            TrailRenderer trailRenderer = trail.GetComponent<TrailRenderer>();

            // Set the width of the trail
            trailRenderer.widthMultiplier = 0.1f;
            // Set the time each point in the trail is visible
            trailRenderer.time = 0.1f;

            // Add the positions of the finger and the spawned object to the TrailRenderer
            m_TrailPositions.Clear();
            m_TrailPositions.Add(handPos);
            m_TrailPositions.Add(obj.transform.position);
            trailRenderer.SetPositions(m_TrailPositions.ToArray());
        }

        m_LastIndexPinchState = indexPinch;
    }
}
