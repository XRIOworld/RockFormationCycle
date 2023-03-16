using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class HandLocomotion : MonoBehaviour
{
    public Transform player;
    public OVRHand hand;
    public float moveSpeed = 1.0f;
    public float activationThreshold = 0.9f;
    public float maxDistance = 10.0f;

    void Update()
    {
        if (hand.GetFingerIsPinching(OVRHand.HandFinger.Index) && hand.GetFingerIsPinching(OVRHand.HandFinger.Thumb) && hand.GetFingerIsPinching(OVRHand.HandFinger.Middle))
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= maxDistance && hand.GetFingerPinchStrength(OVRHand.HandFinger.Index) > activationThreshold && hand.GetFingerPinchStrength(OVRHand.HandFinger.Thumb) > activationThreshold && hand.GetFingerPinchStrength(OVRHand.HandFinger.Middle) > activationThreshold)
            {
                // Calculate the target direction based on the hand's position and rotation
                Vector3 targetDirection = hand.transform.position - player.position;
                targetDirection.y = 0; // Make sure the movement is in the XZ plane only
                targetDirection.Normalize(); // Normalize the direction vector

                // Move the player in the target direction
                player.position += targetDirection * moveSpeed * Time.deltaTime;
            }
        }
    }
}

