# GameEngineInLab

Ethan Harder - 100877874


#Submission 2_ Factory
<img width="637" height="503" alt="image" src="https://github.com/user-attachments/assets/c329fc09-0b9c-4fa8-b8a2-b561b3da57db" />






# Submission 1_ Singleton
<img width="692" height="620" alt="image" src="https://github.com/user-attachments/assets/4416bddd-b304-4847-851d-4da17d0d3666" />


My project (Name pending as Project:Phosphorus) is a farming game concept with a weather system.
In this game, the weather changes regularly, and your farm plots can only grow when the weather permits them to!

Plots gather water (by random tick) when its raining or storming, and store that water.
When its sunny, the plots will use that water to turn into growth of a plant!



<img width="570" height="350" alt="image" src="https://github.com/user-attachments/assets/ad2516f8-77c5-4d00-a611-3497662abcdb" />

Because Weather would likely persist regardless of where or when the player is active (hey, even if you are inside, weather still exists), a Weather system persisting for the entire game seemed appropriate. additioanlly, my plots all need to know about the weather, so having such a simple access point to the weather is conventient.

(I agknowledge that the implenentation of how the plots check the weather every frame could be improved. perhaps with a command pattern *nudge nudge wink wink*)
