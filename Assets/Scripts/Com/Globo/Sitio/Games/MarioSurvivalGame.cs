#define NGUI

using UnityEngine;
using System.Collections;

using AquelaFrameWork.Core;
using AquelaFrameWork.Core.State;
using AquelaFrameWork.Core.Asset;
using AquelaFrameWork.View;

public class MarioSurvivalGame :  AFEngine 
{


    // Initialize your game
    public override void Initialize()
    {
        // You need create a StateManger
        m_stateManager = AFObject.Create<AFStateManager>();

        // You need a factory of states to initialize your engine, here is where you will declarate all your states.
        m_stateManager.Initialize( new MarioGameStateFactory() );


        //AFStatesController st = CharacterFactory.Instance.BuildHeroAnimation(tras.gameObject);
        //st.GetState("small_walk").gameObject.transform.position = new Vector2(0, -5);
        AFSingleTransition tras = AFObject.Create<AFSingleTransition>();
        SpriteRenderer sr = tras.gameObject.AddComponent<SpriteRenderer>();
        sr.sprite = AFAssetManager.Instance.CreateSpriteFromTexture("Common/High/loadingscreen");
        sr.transform.localScale = new Vector3(5,5,5);
        m_stateManager.AddTransition(tras);

        //Call the Init of AFEngine
        base.Initialize();

        //Sending the state to game state
        m_stateManager.GotoState(AState.EGameState.GAME);
    }	
}
