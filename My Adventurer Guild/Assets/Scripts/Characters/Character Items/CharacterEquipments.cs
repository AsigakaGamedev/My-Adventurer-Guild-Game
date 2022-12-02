using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipments : MonoBehaviour
{
    [SerializeField] private EquipmentsContainer[] equipmentsContainers;

    public void EquipItem(ItemEquipable item)
    {
        foreach (EquipmentsContainer equipments in equipmentsContainers)
        {
            if (equipments.EquipmentType == item.Item.ItemType && equipments.EquipedItem == null)
            {
                equipments.EquipItem(item);
                return;
            }
        }
    }

    public void DequipItem(ItemEquipable item)
    {
        foreach (EquipmentsContainer equipments in equipmentsContainers)
        {
            if (equipments.EquipmentType == item.Item.ItemType && equipments.EquipedItem == item)
            {
                equipments.DequipItem(item);
                return;
            }
        }
    }
}
