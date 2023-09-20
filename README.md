# unityProject_Prestige

This upload is my first real dive into game design.

The name of the game is Prestige and it is a 2D turn-based strategy game. In the current version gameplay is very limited.

HUD:  
  The player's health, icon, and remaining moves will be displayed in the top left of the screen.  
  
  <br>
  
  The enemy's health and icon will be displayed in the top right.  
  *the enemies moves are not displayed, but it is only two*  
  
  <br>
  
  There is also a turn counter in the center top of the screen

  Gameplay:  
    The player has a limited amount of action per turn. default: 5  
    In those moves the player is able to move or attack.  
    If the player selects a tile too far to reach with their remaining actions a warning will be displayed in the console line  
    The player has access to two attack, but they are both melee swings meaning that the player must be adjacent to the enemy to deal any damage  
    The only difference in these two attacks is the cost of moves and the damage.  
    The only way for the player to refill their action gauge is by ending their turn.  
    For the player to know if they are getting ready to attack or move, The tiles will be colored accordingly: Blue means movement, and Red means an attack.  

    <br>
    
    Once the player ends their turn, the enemy is able to perform their actions.  
    Currently the enemy only has the option to move and to attck an adjacent player.  
    

Controls:  
  Q - open action menu  
  E - end the player's turn  
  Z - heavy attack hotkey  
  X - light attack hotkey  
