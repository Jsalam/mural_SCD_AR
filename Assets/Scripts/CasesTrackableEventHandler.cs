using UnityEngine;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
/// This is based on the Vuforia DefaultCasesTrackableEventHandler
/// This override activates the method to show the cases 
/// </summary>
public class CasesTrackableEventHandler : DefaultTrackableEventHandler{

    public GameObject CasesManager;
    protected override void OnTrackingFound(){
        base.OnTrackingFound();
        CasesManager.GetComponent<CasesManager>().ShowCases();

    }

    protected override void OnTrackingLost(){
        base.OnTrackingLost();
    }
}
