using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviour_Pursuit : SteeringBehaviour
{

    [Header("Pursuit Properties")]
    [Header("Settings")]
    public MovingEntity m_PursuingEntity;

    public override Vector2 CalculateForce()
    {
        if (m_PursuingEntity)
        {
            Vector2 distance = m_PursuingEntity.transform.position - transform.position;
            float combinedSpeed = m_Manager.m_Entity.m_MaxSpeed + m_PursuingEntity.m_Velocity.magnitude;
            float lookAheadTime = distance.magnitude / combinedSpeed;
            Vector2 futurePosition = (Vector2)m_PursuingEntity.transform.position + m_PursuingEntity.m_Velocity * lookAheadTime;
            m_DesiredVelocity = (futurePosition - (Vector2)transform.position).normalized * m_Manager.m_Entity.m_MaxSpeed;
            m_Steering = m_DesiredVelocity - m_Manager.m_Entity.m_Velocity;
            return m_Steering * m_Weight;


            
        }

        return Vector2.zero;
    }
}
