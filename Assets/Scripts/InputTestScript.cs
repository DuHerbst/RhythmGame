using UnityEngine;
using UnityEngine.InputSystem;

public class InputTestScript : MonoBehaviour
{
    NewInputActions newInputActions;

    void Awake()
    {
        newInputActions = new NewInputActions();
    }

    void OnEnable()
    {
        newInputActions.Enable();
        
        // A key
        newInputActions.Player.AKey.performed += testKeyA;
        newInputActions.Player.AKey.canceled += testKeyCanceledA;
        
        // D key
        newInputActions.Player.DKey.performed += testKeyD;
        newInputActions.Player.DKey.canceled += testKeyCanceledD;
        
        // G key
        newInputActions.Player.GKey.performed += testKeyG;
        newInputActions.Player.GKey.canceled += testKeyCanceledG;
        
        // J key
        newInputActions.Player.JKey.performed += testKeyJ;
        newInputActions.Player.JKey.canceled += testKeyCanceledJ;
        
        // L key
        newInputActions.Player.LKey.performed += testKeyL;
        newInputActions.Player.LKey.canceled += testKeyCanceledL;
    }
    void OnDisable()
    {
        newInputActions.Disable();
        
        // A key
        newInputActions.Player.AKey.performed -= testKeyA;
        newInputActions.Player.AKey.canceled -= testKeyCanceledA;
        
        // D key
        newInputActions.Player.DKey.performed -= testKeyD;
        newInputActions.Player.DKey.canceled -= testKeyCanceledD;
        
        // G key
        newInputActions.Player.GKey.performed -= testKeyG;
        newInputActions.Player.GKey.canceled -= testKeyCanceledG;
        
        // J key
        newInputActions.Player.JKey.performed -= testKeyJ;
        newInputActions.Player.JKey.canceled -= testKeyCanceledJ;
        
        // L key
        newInputActions.Player.LKey.performed -= testKeyL;
        newInputActions.Player.LKey.canceled -= testKeyCanceledL;
    }
    
    // Performed input tests
    void testKeyA(InputAction.CallbackContext ctx)
    {
        Debug.Log("A Key is Working!!!!");
    }

    void testKeyD(InputAction.CallbackContext ctx)
    {
        Debug.Log("D Key is Working!!!!");
    }
    
    void testKeyG(InputAction.CallbackContext ctx)
    {
        Debug.Log("G Key is Working!!!!");
    }
    
    void testKeyJ(InputAction.CallbackContext ctx)
    {
        Debug.Log("J Key is Working!!!!");
    }
    
    void testKeyL(InputAction.CallbackContext ctx)
    {
        Debug.Log("L Key is Working!!!!");
    }

    
    //canceled input tests
    void testKeyCanceledA(InputAction.CallbackContext ctx)
    {
        Debug.Log("Canceled A is Working!!!!");
    }
    
    void testKeyCanceledD(InputAction.CallbackContext ctx)
    {
        Debug.Log("Canceled D is Working!!!!");
    }
    void testKeyCanceledG(InputAction.CallbackContext ctx)
    {
        Debug.Log("Canceled G is Working!!!!");
    }

    void testKeyCanceledJ(InputAction.CallbackContext ctx)
    {
        Debug.Log("Canceled J is Working!!!!");
    }
    void testKeyCanceledL(InputAction.CallbackContext ctx)
    {
        Debug.Log("Canceled L is Working!!!!");
    }
    
    
    
    
    
}
