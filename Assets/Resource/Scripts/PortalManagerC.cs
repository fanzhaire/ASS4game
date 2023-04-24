using UnityEngine;

public class PortalManagerC : MonoBehaviour
{
    public PortalC portalA1;
    public PortalC portalA2;
    public PortalC portalB1;
    public PortalC portalB2;
    public PortalC portalC1;
    public PortalC portalC2;
    public PortalC portalD1;
    public PortalC portalD2;

    void Start()
    {
        PairPortals(portalA1, portalA2);
        PairPortals(portalB1, portalB2);
        PairPortals(portalC1, portalC2);
        PairPortals(portalD1, portalD2);
    }

    private void PairPortals(PortalC portal1, PortalC portal2)
    {
        portal1.pairedPortal = portal2;
        portal2.pairedPortal = portal1;
    }
}
