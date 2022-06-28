using Mirror;
using UnityEngine;
using ShockSprint.Configs;

namespace ShockSprint.Network
{
    public class PlayerNetwork : NetworkBehaviour
    {
        public bool IsLocalPlayer 
        {
            get
            {
                return isLocalPlayer;
            }
        }

        public override void OnStopLocalPlayer()
        {
            Camera.main.transform.SetParent(transform.parent);
            Camera.main.transform.localPosition = MainConfig.Instance.CameraOffset;
        }
    }
}
