using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using toio;

public class FunctionTesting : MonoBehaviour
{
    public ConnectType connectType;
    private CubeManager cm;

    public Cube cube1;
    // Start is called before the first frame update
    async void Start()
    {
        cm = new CubeManager(connectType);
        cube1 = await cm.SingleConnect();
    }

    public void move(){
        cube1.TargetMove(targetX:200, targetY:750, targetAngle:0, maxSpd:20, targetMoveType: Cube.TargetMoveType.RoundBeforeMove, targetRotationType: Cube.TargetRotationType.NotRotate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
