using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviour_Manager : MonoBehaviour
{
    public MovingEntity m_Entity { get; private set; }
    public float m_MaxForce = 500;
    public float m_RemainingForce;
    public List<SteeringBehaviour> m_SteeringBehaviours;

	private void Awake()
	{
        m_Entity = GetComponent<MovingEntity>();

        if(!m_Entity)
            Debug.LogError("Steering Behaviours only working on type moving entity", this);
    }

	public Vector2 GenerateSteeringForce()
    {
        Vector2 totalForce = Vector2.zero;
        m_RemainingForce = m_MaxForce;
        foreach(SteeringBehaviour sb in m_SteeringBehaviours)
        {
            if(sb.m_Active)
            {
                Vector2 force = sb.CalculateForce();
                float forceMagnitude = force.magnitude;
                if(forceMagnitude < m_RemainingForce)
                {
                    totalForce += force;
                    m_RemainingForce -= forceMagnitude;
                }
                else
                {
                    totalForce += force.normalized * m_RemainingForce;
                    m_RemainingForce = 0;
                    break;
                }
            }
        }
        return totalForce;

        //return m_SteeringBehaviours[0].CalculateForce();
        ;
    }

    public void EnableExclusive(SteeringBehaviour behaviour)
	{
        if(m_SteeringBehaviours.Contains(behaviour))
		{
            foreach(SteeringBehaviour sb in m_SteeringBehaviours)
			{
                sb.m_Active = false;
			}

            behaviour.m_Active = true;
		}
        else
		{
            Debug.Log(behaviour + " doesn't not exist on object", this);
		}
	}
    public void DisableAllSteeringBehaviours()
    {
        foreach (SteeringBehaviour sb in m_SteeringBehaviours)
        {
            sb.m_Active = false;
        }
    }

    public void AddSteeringBehaviour(SteeringBehaviour behaviour) 
    {
        m_SteeringBehaviours.Add(behaviour);
    }

    public void RemoveSteeringBehaviour(SteeringBehaviour behaviour)
    {
        m_SteeringBehaviours.Remove(behaviour);
    }
}
