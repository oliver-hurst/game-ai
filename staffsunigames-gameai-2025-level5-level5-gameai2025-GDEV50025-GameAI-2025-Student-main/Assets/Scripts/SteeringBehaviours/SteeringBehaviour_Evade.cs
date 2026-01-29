using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviour_Evade : SteeringBehaviour
{
    [Header("Evade Properties")]
    [Header("Settings")]
    public MovingEntity m_EvadingEntity;
    public float m_EvadeRadius;

    [Space(10)]

    [Header("Debugs")]
    [SerializeField]
    protected Color m_Debug_RadiusColour = Color.yellow;

    public override Vector2 CalculateForce()
    {
        if (m_EvadingEntity)
        {
            Vector2 distance = (Vector2)m_EvadingEntity.transform.position - (Vector2)transform.position;
            if (distance.magnitude < m_EvadeRadius)
            {
                float combinedSpeed = m_Manager.m_Entity.m_MaxSpeed + m_EvadingEntity.m_Velocity.magnitude;
                float lookAheadTime = distance.magnitude / combinedSpeed;
                Vector2 futurePosition = (Vector2)m_EvadingEntity.transform.position + m_EvadingEntity.m_Velocity * lookAheadTime;
                m_DesiredVelocity = ((Vector2)transform.position - futurePosition).normalized * m_Manager.m_Entity.m_MaxSpeed;
                m_Steering = m_DesiredVelocity - m_Manager.m_Entity.m_Velocity;
                return m_Steering * m_Weight;
            }
           
        }

        return Vector2.zero;
    }

    protected override void OnDrawGizmosSelected()
    {
        if (Application.isPlaying)
        {
            if (m_Debug_ShowDebugLines && m_Active && m_Manager.m_Entity)
            {
                Gizmos.color = m_Debug_RadiusColour;
                Gizmos.DrawWireSphere(transform.position, m_EvadeRadius);

                base.OnDrawGizmosSelected();
            }
        }
    }
}
