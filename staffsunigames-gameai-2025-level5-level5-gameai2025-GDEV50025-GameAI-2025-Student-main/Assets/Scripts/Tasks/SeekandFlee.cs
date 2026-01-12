using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekandFlee : MovingEntity
{
	SteeringBehaviour_Manager m_SteeringBehaviours;
	SteeringBehaviour_Flee m_Flee;
	SteeringBehaviour_Seek m_Seek;

    protected override void Awake()
	{
		base.Awake();

		m_Flee = GetComponent<SteeringBehaviour_Flee>();

		m_SteeringBehaviours = GetComponent<SteeringBehaviour_Manager>();

		if (!m_SteeringBehaviours)
			Debug.LogError("Object doesn't have a Steering Behaviour Manager attached", this);

		if (!m_Flee)
			Debug.LogError("Object doesn't have a Seek Steering Behaviour attached", this);

        m_Seek = GetComponent<SteeringBehaviour_Seek>();

        if (!m_Seek)
            Debug.LogError("Object doesn't have a Seek Steering Behaviour attached", this);
    }

	protected void Start()
	{
		m_Flee.m_FleeTarget = GameObject.Find("Player").transform;
	}

	protected override Vector2 GenerateVelocity()
	{
		return m_SteeringBehaviours.GenerateSteeringForce();
	}

    private void Update()
    {
        if (Maths.Magnitude((Vector2)transform.position - m_Seek.m_TargetPosition) < 0.5f)
        {
            m_Seek.m_TargetPosition = TileGrid.GetRandomWalkableTile(2).transform.position;
        }
    }
}
