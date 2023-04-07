//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using OculusSampleFramework;

//public class HandLocomotion : MonoBehaviour
//{
//    public Transform player;
//    public OVRHand hand;
//    public float moveSpeed = 1.0f;
//    public float activationThreshold = 0.9f;
//    public float maxDistance = 10.0f;

//    void Update()
//    {
//        if (hand.GetFingerIsPinching(OVRHand.HandFinger.Index) && hand.GetFingerIsPinching(OVRHand.HandFinger.Thumb) && hand.GetFingerIsPinching(OVRHand.HandFinger.Middle))
//        {
//            float distance = Vector3.Distance(player.position, transform.position);
//            if (distance <= maxDistance && hand.GetFingerPinchStrength(OVRHand.HandFinger.Index) > activationThreshold && hand.GetFingerPinchStrength(OVRHand.HandFinger.Thumb) > activationThreshold && hand.GetFingerPinchStrength(OVRHand.HandFinger.Middle) > activationThreshold)
//            {
//                Calculate the target direction based on the hand's position and rotation
//                Vector3 targetDirection = hand.transform.position - player.position;
//                targetDirection.y = 0; // Make sure the movement is in the XZ plane only
//                targetDirection.Normalize(); // Normalize the direction vector

//                Move the player in the target direction
//                player.position += targetDirection * moveSpeed * Time.deltaTime;
//            }
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
public class HandLocomotion : MonoBehaviour
{
    public Transform player;
    public OVRHand leftHand;
    public OVRHand rightHand;
    public float moveSpeed = 1.0f;
    public float activationThreshold = 0.9f;
    public float maxDistance = 10.0f;

    void Update()
    {
        bool leftPinch = leftHand.GetFingerIsPinching(OVRHand.HandFinger.Index) && leftHand.GetFingerIsPinching(OVRHand.HandFinger.Thumb) && leftHand.GetFingerIsPinching(OVRHand.HandFinger.Middle);
        bool rightPinch = rightHand.GetFingerIsPinching(OVRHand.HandFinger.Index) && rightHand.GetFingerIsPinching(OVRHand.HandFinger.Thumb) && rightHand.GetFingerIsPinching(OVRHand.HandFinger.Middle);

        if (leftPinch && rightPinch)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            float pinchStrength = (leftHand.GetFingerPinchStrength(OVRHand.HandFinger.Index) + leftHand.GetFingerPinchStrength(OVRHand.HandFinger.Thumb) + leftHand.GetFingerPinchStrength(OVRHand.HandFinger.Middle) +
                rightHand.GetFingerPinchStrength(OVRHand.HandFinger.Index) + rightHand.GetFingerPinchStrength(OVRHand.HandFinger.Thumb) + rightHand.GetFingerPinchStrength(OVRHand.HandFinger.Middle)) / 6.0f;

            if (distance <= maxDistance && pinchStrength > activationThreshold)
            {
                Vector3 targetDirection = (leftHand.transform.position + rightHand.transform.position) / 2.0f - player.position;
                targetDirection.y = 0;
                targetDirection.Normalize();

                player.position += targetDirection * moveSpeed * Time.deltaTime;
            }
        }
    }
}

