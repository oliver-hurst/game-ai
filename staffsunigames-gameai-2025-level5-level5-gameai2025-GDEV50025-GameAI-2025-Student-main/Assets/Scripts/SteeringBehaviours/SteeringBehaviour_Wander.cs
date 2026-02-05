using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviour_Wander : SteeringBehaviour
{
    [Header("Wander Properties")]
    [Header("Settings")]
    public float m_WanderRadius = 2; 
    public float m_WanderOffset = 2;
    public float m_AngleDisplacement = 15;

    Vector2 m_CirclePosition;
    Vector2 m_PointOnCircle;
    float m_Angle = 0.0f;

    [Space(10)]

    [Header("Debugs")]
    [SerializeField]
    protected Color m_Debug_RadiusColour = Color.yellow;
    [SerializeField]
    protected Color m_Debug_EntityToCentreColour = Color.cyan;
    [SerializeField]
    protected Color m_Debug_CenteToPointColour = Color.green;
    [SerializeField]
    protected Color m_Debug_PointToEntityColour = Color.magenta;


    public override Vector2 CalculateForce()
    {
       //Vector2 force = base.CalculateForce();   
        m_CirclePosition = (Vector2)transform.position + m_Manager.m_Entity.m_Velocity.normalized * m_WanderOffset;
        m_Angle += Random.Range(-m_AngleDisplacement, m_AngleDisplacement);
        float radianAngle = m_Angle * Mathf.Deg2Rad;
        m_PointOnCircle = m_CirclePosition + new Vector2(Mathf.Cos(radianAngle), Mathf.Sin(radianAngle)) * m_WanderRadius;
        m_DesiredVelocity = (m_PointOnCircle - (Vector2)transform.position).normalized * m_Manager.m_Entity.m_MaxSpeed;
        m_Steering = m_DesiredVelocity - m_Manager.m_Entity.m_Velocity;
        return m_Steering * m_Weight;
            

        //return Vector2.zero;
    }

	protected override void OnDrawGizmosSelected()
	{
        if (Application.isPlaying)
        {
            if (m_Debug_ShowDebugLines && m_Active && m_Manager.m_Entity)
            {
                Gizmos.color = m_Debug_RadiusColour;
				Gizmos.DrawWireSphere(m_CirclePosition, m_WanderRadius);

                Gizmos.color = m_Debug_EntityToCentreColour;
				Gizmos.DrawLine(transform.position, m_CirclePosition);

                Gizmos.color = m_Debug_CenteToPointColour;
				Gizmos.DrawLine(m_CirclePosition, m_PointOnCircle);

                Gizmos.color = m_Debug_PointToEntityColour;
				Gizmos.DrawLine(transform.position, m_PointOnCircle);

                base.OnDrawGizmosSelected();
			}
        }
	}
}
