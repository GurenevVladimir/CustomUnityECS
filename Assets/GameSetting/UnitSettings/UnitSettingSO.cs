using UnityEngine;
using System;
using TestProject.DevOOP.Units.Modules;

namespace TestProject.DevOOP.Settings
{
    [CreateAssetMenu(fileName ="NewUnitSeting", menuName = "Game/Setting/Unit")]
    public sealed class UnitSettingSO : ScriptableObject
    {
       [SerializeField]private ModuleType[] useUnitModulesType;

        public Type GetTypeByIndex(int index)
        {
            Type currentType = default;
            if(index < useUnitModulesType.Length)
            {
                currentType = GameUtility.Instance.GetModuleType( useUnitModulesType[index] );
            }
            return currentType;
        }

        public int GetUnitModulesLenght()
        {
            return useUnitModulesType.Length;
        }
    }
}

