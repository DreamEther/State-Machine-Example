﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;
using System;

// here we are specifying a type for T
public class SecondState : State<AI> // AI is the class that is going to be using this particular state
// AI script will be attached to each enemy, so they each subscribe to the methods of the StateMachine 
{

    private static SecondState _instance; // static variable can only be declared one time
   
   private SecondState()
   {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
   }
   
   //creating a Property for the class which returns _instance
   public static SecondState Instance
   {
       get{
           if (_instance == null)
           {
               new SecondState();
           }

           return _instance;
       }
   }
    public override void EnterState(AI _owner)
    {
        Debug.Log("Entering Second State");
    }
    public override void ExitState(AI _owner)
    {
          Debug.Log("Exiting Second State");
    }
    public  override void UpdateState(AI _owner)
    {
        if (_owner.switchState)
        {
            _owner.stateMachine.ChangeState(FirstState.Instance);
        }
    }
    

}
