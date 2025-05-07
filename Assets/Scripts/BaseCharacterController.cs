using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.InputSystem.InputAction;

//BaseCharacter is the base of a character
public class BaseCharacterController : MonoBehaviour
{
    private Vector2 movementInput;
    [SerializeField] private float movementSpeed;
    [Range(0,1)][SerializeField] private float slowedFactor;
    private bool isSlowed;
    private bool isPlayerPaused;
    private Vector3Int currentPosition;
    private Vector3Int lastEncounterPosition;

    public Tilemap tilemap
    {
        get
        {
            if (m_tilemap == null) m_tilemap = FindObjectOfType<Tilemap>();
            return m_tilemap;
        }
    }
    private Tilemap m_tilemap;  

    private void Start()
    {
        isSlowed = false;
        isPlayerPaused = false;
    }

    /// <summary>
    /// Movement is called by the input system when the player moves the joystick or presses the arrow keys
    /// </summary>
    /// <param name="ctx">Context provided by Unity Input</param>
    public void Movement(CallbackContext ctx)
    {
        //movementInput is set by unity events
        movementInput = ctx.ReadValue<Vector2>(); //comment
    }

    //This is now a FIXEDupdate
    private void FixedUpdate()
    {
        if (isPlayerPaused) return;
        //var actualmovementSpeed = isSlowed ? movementSpeed * slowedFactor : movementSpeed;
        var actualmovementSpeed = movementSpeed;
        if (isSlowed) actualmovementSpeed *= slowedFactor;
        {
            
        }
        transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * Time.deltaTime * actualmovementSpeed);
        currentPosition = tilemap.WorldToCell(transform.position); 
    }

  
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Swamp"))
            {
                isSlowed = true;
        }
        else if(col.gameObject.CompareTag("FightEncounter"))
        {
      
            if (currentPosition == lastEncounterPosition)
            {
               lastEncounterPosition = currentPosition;
               isPlayerPaused = FightManager.Instance.CheckForEncounter();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Swamp"))
        {
            isSlowed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("FightEncounter"))
        {
            CheckForEncounter();
        }
    }
    private void CheckForEncounter()
    {
        FightManager.Instance.CheckForEncounter(); 
    }
}
