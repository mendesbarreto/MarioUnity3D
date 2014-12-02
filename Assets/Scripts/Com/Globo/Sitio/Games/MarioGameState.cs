﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

using AquelaFrameWork.Core;
using AquelaFrameWork.Core.Asset;
using AquelaFrameWork.Core.State;
using AquelaFrameWork.View;

public class MarioGameState : AState
{
    private AFStatesController m_characterAnimations;

    protected override void Awake()
    {
        m_stateID = AState.EGameState.GAME;
        Initialize(STATE_EVERYTHING);
    }

    override public void BuildState()
    {
        m_characterAnimations = CharacterFactory.Instance.buildHeroAnimation();

        Add(m_characterAnimations);
        base.BuildState();
    }

    public override void AFUpdate(double deltaTime)
    {
        m_characterAnimations.AdvanceTime(deltaTime);

        if (Input.GetKey("right"))
        {
            m_characterAnimations.transform.localScale = new UnityEngine.Vector3(3, 3, 3);
            m_characterAnimations.GoTo("small_walk");
            m_characterAnimations.transform.position = new Vector2(m_characterAnimations.transform.position.x + 0.05f, m_characterAnimations.transform.position.y);
        }
        else if (Input.GetKey("left"))
        {
            m_characterAnimations.transform.localScale = new UnityEngine.Vector3(-3, 3, 3);
            m_characterAnimations.transform.position = new Vector2(m_characterAnimations.transform.position.x - 0.05f, m_characterAnimations.transform.position.y);
            m_characterAnimations.GoTo("small_walk");
        }
        else
        {
            m_characterAnimations.GoTo("small_stop");
        }
            
        
        base.AFUpdate(deltaTime);
    }
}
