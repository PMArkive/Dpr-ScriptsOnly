using UnityEngine;

namespace Dpr.Field.Walking
{
    public class UgWalkingAIManager : WalkingAIManager
    {
        protected override WalkingCharacterController AddController(GameObject go)
        {
            return go.AddComponent<UgPokeController>();
        }
    }
}