using UnityEngine;

public class Soybean : Crop
{
    protected override void PlayerCollect(GameObject player)
    {
        player.GetComponent<PlayerController>().speed++;
        
        base.PlayerCollect(player);
        
    }
}
