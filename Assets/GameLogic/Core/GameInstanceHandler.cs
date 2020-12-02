using System;
using System.Collections;
using UnityEngine;

namespace TestProject.DevOOP.Core
{
    /// <summary>
    /// This class self create on game scene and instantiate main core class.
    /// </summary>
    /// <remarks>Use <see cref="RuntimeInitializeOnLoadMethodAttribute"/></remarks>
    /// <seealso cref="GameInitialization"/>
    internal sealed class GameInstanceHandler : MonoSingleton<GameInstanceHandler>
    {
        //TODO Подумать куда поместить все "Помошники"
        private NavigationHandler _navHandler;

        internal readonly Func<Units.BaseGameUnit, Vector3> GetMovePointForUnit;

        internal GameInstanceHandler()
        {
            GetMovePointForUnit += GetMovePoint;
        }
        //таже проблема...

        [RuntimeInitializeOnLoadMethod]
        internal static void GameInitialization()
        {
            _Debug.Log("Start Game!", DebugColor.green);
            var _self = GameInstanceHandler.Instance;
            _self.gameObject.name = ">>GameInstanceHandler<<";
        }

        private void Awake()
        {
            _navHandler = new NavigationHandler();
        }
        //все таже проблема...если будет много "Помошников", то будет грязь
        private Vector3 GetMovePoint(Units.BaseGameUnit unit)
        {
            return _navHandler.GetMovePoint(unit);
        }
    }
}