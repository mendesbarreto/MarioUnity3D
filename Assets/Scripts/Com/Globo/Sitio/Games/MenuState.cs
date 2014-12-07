using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AquelaFrameWork.Core.State;

public class MenuState : AState
{
    public override void BuildState()
    {
        System.Threading.Thread.Sleep(5000);
        
        base.BuildState();
    }
}
