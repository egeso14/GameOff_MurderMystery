using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class StateObjectTemplateCreator : EditorWindow
{
    
    static ObjectStateSpecifiers[] specifierEnums;
    static Type[] specifierType;

    private string className = "StateObjectTemplate";

    // for internal use

    private List<Type> fieldTypeProviders = new List<Type>();


   [MenuItem("Tools/State Object Template Creator")] 
    public static void ShowWindow()
    {
        GetWindow(typeof(StateObjectTemplateCreator));
    }

    private void OnGUI()
    {
        fieldTypeProviders = AppDomain.CurrentDomain.GetAssemblies()
           .SelectMany(assembly => assembly.GetTypes())
           .Where(type => typeof(IInteractionCallbackServiceProvider.Get).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
           .ToList();
    }

    public static List<Type> GetImplementingTypes<TInterface>()
    {
        // Get all types in the current assembly
        Assembly assembly = Assembly.GetExecutingAssembly();

        // Find types that implement the specified interface
        return assembly.GetTypes()
            .Where(type => typeof(IInteractionCallbackServiceProvider).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
            .ToList();
    }

}
