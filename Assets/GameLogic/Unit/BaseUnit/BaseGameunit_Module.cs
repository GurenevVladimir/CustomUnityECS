using System;
using System.Collections.Generic;
using UnityEngine;

using TestProject.DevOOP.Units.Modules;
using TestProject.DevOOP.Settings;

namespace TestProject.DevOOP.Units
{
    public abstract partial class BaseGameUnit : MonoBehaviour, IUpdatable
    {
        [SerializeField] private UnitSettingSO _unitSetting;

        // текущий список всех модулей Юнита
        private IList<IUnitModule> _unitModuleList;

        public IUnitModule CreateUnitModule(Type moduleType,Transform parent)
        {
            var module = new GameObject(moduleType.ToString());
            module.transform.SetParent(parent);
            module.transform.localPosition = Vector3.zero;
            return (IUnitModule)module.AddComponent(moduleType);
        }

        partial void CreateUnitModules()
        {
            _unitModuleList = new List<IUnitModule>();
            //todo take modules from SO unit settings
            try
            {
                if(_unitSetting is null)
                {
                    CustomDebug.LogMessage($"Exeption! У юнита нет файла настройки - <b>{gameObject.name}</b>!", DebugColor.red);
                    throw new Exception();
                }
                print("!!!");
                for(int i = 0; i < _unitSetting.GetUnitModulesLenght(); ++i)
                {
                    _unitModuleList.Add(CreateUnitModule(_unitSetting.GetTypeByIndex(i), this.transform));
                    _unitModuleList[i].AddModule(AddUnitEvent);
                }
            }
            catch(Exception e)
            {
                Debug.unityLogger.LogException(e);
                Debug.Break();
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }
}