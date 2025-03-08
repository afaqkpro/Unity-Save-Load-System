using SaveLoadSystem;
using newplayer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSaveData : MonoBehaviour
{
    
    public Healthcontroller healthController;  

    private PlayerData MyData = new PlayerData();
    private moveplayer fpsController;

    private void Awake()
    {
        fpsController = GetComponent<moveplayer>();

        
        if (healthController == null)
        {
            Debug.LogError("Healthcontroller is not assigned in PlayerSaveData script.");
        }
    }

    
    void LateUpdate()
    {
        
        var transform1 = transform;
        MyData.PlayerPosition = transform1.position;
        MyData.PlayerRotation = transform1.rotation;

        
        if (healthController != null)
        {
            MyData.CurrentHealth = healthController.playerHealth; 
        }

        
        if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            SaveGameManager.CurrentSaveData.PlayerData = MyData;
            SaveGameManager.SaveGame();
        }

        
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            fpsController.enabled = false;
            SaveGameManager.LoadGame();
            MyData = SaveGameManager.CurrentSaveData.PlayerData;
            transform.position = MyData.PlayerPosition;
            transform.rotation = MyData.PlayerRotation;

            
            if (healthController != null)
            {
                healthController.playerHealth = MyData.CurrentHealth;  
                healthController.healthBar.value = healthController.playerHealth / healthController.totlaHealth; 
            }

            
            Invoke(nameof(EnableController), 0.25f);
        }
    }

    private void EnableController()
    {
        fpsController.enabled = true;
    }
}

[System.Serializable]
public struct PlayerData
{
    public Vector3 PlayerPosition;
    public Quaternion PlayerRotation;
    public float CurrentHealth;  
}
