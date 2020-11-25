using System;
using System.Collections.Generic;

using TestProject.DevOOP.Units.Modules;

namespace TestProject.DevOOP
{
    internal sealed class GameUtility 
    {
       internal static GameUtility Instance
        {
            get
            {
                if(_instance is null)
                {
                    _instance = new GameUtility();
                }
                return _instance;
            }
        }

        private static GameUtility _instance;
        private IDictionary<ModuleType, Type> _moduleStorage;

        private GameUtility()
        {
            _moduleStorage = new Dictionary<ModuleType, Type>()
            {
                { ModuleType.Physics, typeof(UnitPhysicModule)}
            };
        }

        internal Type GetModuleType(ModuleType typeKey)
        {
            try
            {
                if (!_moduleStorage.TryGetValue(typeKey, out var module))
                {
                    CustomDebug.LogMessage($"Exeption! В списке конвертора нет модуля - <b>{typeKey}</b>!", DebugColor.red);
                    throw new Exception();
                }
                return module;
            }
            catch (Exception e)
            {
                UnityEngine.Debug.unityLogger.LogException(e);
                UnityEngine.Debug.Break();
                UnityEditor.EditorApplication.isPlaying = false;
                return null;
            }
        }
    }
}