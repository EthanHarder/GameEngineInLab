# GameEngineInLab

Ethan Harder - 100877874

# Submission 3_ Observer
<img width="757" height="571" alt="image" src="https://github.com/user-attachments/assets/fc481068-ca75-43a2-b0ad-2607ce5575a9" />

To update Project: Phosphorus, a lot of the old code has been refactored, as well as new plants and a new obstacle mechanic.

The Observer pattern helps primary in this new patch to reduce bad dependancies. The Weather singleton no longer has a connection to the UI. The PlayerController no longer has a connection to the UI.  
Weather changed to just an invoke:  
<img width="604" height="202" alt="image" src="https://github.com/user-attachments/assets/9eb7c99f-fa41-46fd-be2d-a54dca68948b" />  
As was the player changing seed type:  
<img width="527" height="240" alt="image" src="https://github.com/user-attachments/assets/f4607c51-e40e-458c-aa19-e5f4bc8463b5" />

HUD Changed to add listening to what it cares about. (Yeah, I agknowledge GameObject.Find("Player") isn't exactly beautiful). As for the other two, them being singletons is particularly helpful for the observer pattern; i can hook up to the static instance painlessly.
<img width="517" height="99" alt="image" src="https://github.com/user-attachments/assets/500b5f3d-828b-4fe6-98db-b2e8daba17a6" />

The weather changing also has been updated to an observer event. Now, my plots dont need to check which weather to act on every frame, they just pick a behaviour and wait until they observe the next new weather to change behaviour.
(I also added the beginnings of a state system to the plots, because i hated the old cluttered update function. Hopefully that doesnt mess with things down the line~).  
<img width="367" height="291" alt="image" src="https://github.com/user-attachments/assets/e818449e-573f-4be4-a2c5-8453f4be312c" />

I also realized I wanted to demonstrate when and why you need to detach a listener, so... we have a new crop!  
Starfruits have different behaviour based on the weather event when you eat them. If you eat a ripe starfruit while its sunny, you get a large Spicy speed bonus. These listeners destroy themselves, so we have them detach beforehand:  
<img width="521" height="117" alt="image" src="https://github.com/user-attachments/assets/f86cc781-4c27-409d-8939-ccc516f89aab" /><img width="462" height="162" alt="image" src="https://github.com/user-attachments/assets/b54d3ac6-2910-4efa-8905-e31efdd70755" />

Finally, I wanted to add some new kind of gameplay element, just so the updates werent mainly just refactoring. I also have a thing for games without enemies or combat, so here was my idea:  
Obstacles are the milestones of this game, and to break down an obstacle you need to be going fast enough.  
Some Test crops have been provided for you so you dont have to wait for one to grow. They also use the observer pattern (through a manager) to communicate to the HUD.
<img width="227" height="522" alt="image" src="https://github.com/user-attachments/assets/506057ff-7dfb-414b-8ee0-cdb7c6051e71" />






# Submission 2_ Factory
<img width="637" height="503" alt="image" src="https://github.com/user-attachments/assets/c329fc09-0b9c-4fa8-b8a2-b561b3da57db" />

To update Project: Phosphorus, different crops have been added!
You can also now select a seed with 'E', and then plant the seed with 'Space' while standing over a plot.

The factory design pattern is implemented to facilitate crops that require different spawning behaviours: 

-Pineapples spawn (one per crop) with a random size. 

-Blueberries spawn in a cluster per crop, with a random number. 

-Soybeans spawn. I couldn't think of anything clever about soybeans. We'll call it a default behaviour. 

To perform this, I have a new CropSpawner singleton, (basically a manager) with the enums for crops and a list of crop factories for each crop i would want to produce. When a plot finishes growing and wants to spawn a crop, it sends the crop type and location, and the CropSpawner passes that to the correct Factory to spawn the crop in the manner it needs. 

This way, the CropSpawner class is feature-complete (to an extent), and you only need to add more crop factories to the list if more crops are added. If I wanted to add, say, watermelons, I wouldnt need to add anything to the CropSpawner script. Additionally, all crop spawning logic is held in their own factories, so we can avoid one big switch statement on spawning behaviours.

the crops are all Crops, as in they inherit from a Crop abstract class.
Because there were concerns of minimal interactivity, i added the manual planting and also made the crops collectable. Blueberries and pineapples dont do anything yet, but Soybeans give you a permanent move speed boost.


<img width="1282" height="768" alt="image" src="https://github.com/user-attachments/assets/4a12be0b-7259-4164-9de2-e61ac7c6d6b4" />

The topmost benefit is that im offloading lots of logic away from my already bloated plot script, and let crops be completely unrelated (aside from a one-way reference to the croptype enum in CropSpawner).




# Submission 1_ Singleton
<img width="692" height="620" alt="image" src="https://github.com/user-attachments/assets/4416bddd-b304-4847-851d-4da17d0d3666" />


My project (Name pending as Project:Phosphorus) is a farming game concept with a weather system.
In this game, the weather changes regularly, and your farm plots can only grow when the weather permits them to!

Plots gather water (by random tick) when its raining or storming, and store that water.
When its sunny, the plots will use that water to turn into growth of a plant!



<img width="570" height="350" alt="image" src="https://github.com/user-attachments/assets/ad2516f8-77c5-4d00-a611-3497662abcdb" />

Because Weather would likely persist regardless of where or when the player is active (hey, even if you are inside, weather still exists), a Weather system persisting for the entire game seemed appropriate. additioanlly, my plots all need to know about the weather, so having such a simple access point to the weather is conventient.

(I agknowledge that the implenentation of how the plots check the weather every frame could be improved. perhaps with a command pattern *nudge nudge wink wink*)
