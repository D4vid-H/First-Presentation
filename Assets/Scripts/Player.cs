using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ControllerCharacters
{
    private ControllerCharacters m_controllerCharacter;
    private HealtController m_healtController;

    private void Awake()
    {
        m_controllerCharacter = new ControllerCharacters();        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    

}
