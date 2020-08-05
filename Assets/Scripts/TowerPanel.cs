using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPanel : MonoBehaviour
{
    public static TowerIndex towerNumber;
    [SerializeField]List<Button> buttons;
    private void Start()
    {
        towerNumber = TowerIndex.Pistol;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {       
            SetPistol();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetTwin();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetGun();
        }
    }
    public void SetPistol()
    {
        buttons[0].interactable = false;
        SetOtherButtonsActive(0);
        towerNumber = TowerIndex.Pistol;
    }
    public void SetTwin()
    {
        buttons[1].interactable = false;
        SetOtherButtonsActive(1);
        towerNumber = TowerIndex.Twin;
    }
    public void SetGun()
    {
        buttons[2].interactable = false;
        SetOtherButtonsActive(2);
        towerNumber = TowerIndex.Gun;
    }
    private void SetOtherButtonsActive(int index)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if(i!=index)
            {
                buttons[i].interactable = true;
            }
        }
    }
}
