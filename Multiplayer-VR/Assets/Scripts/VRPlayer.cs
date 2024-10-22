using System.Collections;
using System.Collections.Generic;
using Fusion;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public struct RigState : INetworkStruct
{
    public Vector3 playAreaPosition;
    public Quaternion playAreaRotation;
    public Vector3 leftHandPosition;
    public Quaternion leftHandRotation;
    public Vector3 rightHandPosition;
    public Quaternion rightHandRotation;
    public Vector3 headsetPosition;
    public Quaternion headsetRotation;
}

public class VRPlayer : NetworkBehaviour
{
    public GameObject Local;
    public GameObject Network;

    public XROrigin Rig;
    public XRInputModalityManager Hands;
    
    [Networked] public RigState VRigInfo { get; set; }
    
    // Start is called before the first frame update
    public override void Spawned()
    {
        Local.SetActive(Runner.IsClient);
        Network.SetActive(!Runner.IsClient);
    }

    // StateAuthority calls update
    public override void FixedUpdateNetwork()
    {
        
    }
}
