//
// Bachelor of Software Engineering
// Media Design School
// Auckland
// New Zealand
//
// (c) Media Design School
//
// File Name : EventManager.cs
// Description : Global Event Manager. Runs functions that are subscribed through the invoke.
// Author : Ethan Uy
// Mail : ethan.uy@mds.ac.nz
//

using UnityEngine;

public class EventManager : MonoBehaviour
{
    // Example
    public delegate void ExampleAction();
    public static event ExampleAction On_ExampleAction;

    public void InvokeExample()
    {
        if (On_ExampleAction != null)
            On_ExampleAction();
    }
}