# Perseus: New Frontier #

“Some heroes wear space helmets” - Space Cowboy

#### CS413 ####


Group:
- Andrew Miliza
- Savannah Chappus
- Michael Vertin
- Nathan Hill


## Table of Contents ##
PROJECT DESCRIPTION\
GAMEPLAY CONCEPTS
1. Goal
2. Losing
3. User Skill
4. Level Progression

GAME MECHANICS  
1. General Overview
    1. Style and Genre
    2. Player Interaction
    3. Level Design
    4. Combat element
    5. Additional Elements
2. Layered Tetrad Analysis
3. Gameplay Objects and Items
    1. Heroes
    2. Enemy
    3. Projectile
    4. Colony

TECHNICAL INFORMATION -
1. Basic Technical Information
2. Gamestate Script Flowchart
3. Enemy Script Flowchart
4. Projectile Flowchart
5. Hero Flowchart

## PROJECT DESCRIPTION ##
This document is about the game Perseus: New Frontier. Perseus: New Frontier is a Tower Defense game. This game will have 3 different levels that will have 10 waves of enemies that will try and evade the player’s defenses and reach the Colony. When the Colony runs out of health you lose the game. You will have to place Heroes to defend the Colony and keep it from losing health. There will be 3 different Heroes and 4 different enemy types. 



## GAMEPLAY CONCEPTS ##
#### Goal ####
The goal of the game is to get to the end of wave ten and beat the last enemy with the most health left. Health is lost when an enemy reaches Colony. The more gold and health you have at the end the better you do.
#### Losing ####
You will lose the game when your Colony loses all HP before wave 10. The Colony loses health when an enemy gets to it.
#### User Skill ####
The game is a simple strategy game so you will need some basic strategy. You will gain money and you will need to know when to use it and when to save. You will use the mouse to place and upgrade units.
#### Level Progression ####
Each wave will gain more and more enemies of hard types and then wave ten will have all kinds of enemies. The first couple waves will be of a couple weaker enemies that you will get gold for so you can place more heroes. The harder the enemy the more gold you get so the more you can place and upgrade the heroes. The 3 different levels will have a different path for the enemies to go and make it harder depending on the level.

## General Overview ##
#### Style and Genre ####
This game is a third person “bird’s eye view” defense game. Each level appears below the player, and they are able to control and manipulate the structure of their base, including changing placement and type of characters used to defend the base.
#### Player Interaction ####
Prior to starting each level, the player is able to choose the type and placement of the heroes they want to use to defend their base. During game play, the player can activate characters and their respective abilities in order to defend against waves of enemies.

#### Level Design ####
The entire game happens on the same “screen” which features the players base and defenses at the bottom of the screen. The remainder of the screen is the active play area. The difficulty of the game depends on how many incoming waves of enemies approach the player’s base. There are 3 levels of difficulty in the game, structured as such:
1. 3 waves of basic enemies ( Alien 1 and a few of Alien 2 )
2. 5 waves of intermediate enemies ( Alien 1 & 2 & a few of Alien 3 )
3. 10 waves of advanced enemies ( all 4 types of Aliens )
#### Combat element ####
When the heroes are placed they will attack the enemies. Heroes will have a setting for whether to attack the first or last enemies or to attack the strongest one.
Additional Elements
There will be gold and health for the player to keep track of. The gold will allow the player to buy and upgrade heroes. The health is the life force of the player and determines how many enemies have gotten to the Colony and will also determine if the player has lost.

## Layered Tetrad Analysis ##
#### Inscribed Layer: ####
Aesthetics: Game screen will be three dimensional with a stationary camera looking down onto the game area. The colony object will be present with heroes to defend it and waves of enemies will charge the Colony. 

Mechanics: Players will place heroes prior to the start of the level to defend the colony. Once level has started and enemies are charging, heroes will attack charging enemies. Players will have the ability to activate heroes as well during levels. The colony can receive damage from the aliens

Narrative: Simple narrative:  You are the leader of a new space colony near Omicron Persei 8 and aliens are trying to destroy it. You call upon your greatest heroes to defend it at all costs.

Technology: The game is implemented using Unity and C#. All of the objects in the game utilize Unity’s built in GameObjects and development classes in order to make everything function.

#### Dynamic Layer: ####
Aesthetics: The entire game is seen on every level of the game since the game is played and viewed from a third person bird’s eye perspective.


Mechanics: During game play, the player is responsible for managing their status, including Colony health, hero health, and powerups. The heroes and the Colony can both receive damage from the enemies, and the player must strategically manage these things during the game.

Narrative: The narrative remains the same as the game progresses, but the enemies get progressively harder as the waves approach the Colony and similarly as the levels progress.

Technology: During game play, the technology is governed by collision detection and a series of flags that determine whether or not the enemies, heroes and/or the Colony has run out of health.

#### Cultural Layer: ####
Since the game will be for the time being, only developed up to prototype, we will leave the cultural layer fairly brief and general.

Aesthetics: The game employs a simple graphical style so as to remain minimalistic so as to not be overwhelming on small mobile screens. 

Mechanics: Since this game is strategy based, players will converse on potential “winning” strategies, including those which may yield the most gold, the most tradeoffs, or other such tropes.

Narrative: Fans will wonder why the aliens keep attacking, question what they are protecting, and ultimately, if the violence is worth it in the end. These discussions will start as whispers in dingy chat rooms and allies behind GameStop, but gradually roar into a culture movement. Once peak “McDonalds happy meal toy?” status is reached, fans will ultimately demand a  Perseus: New Frontier II, but will inevitably criticize it for not being as good as the first. 

Technology: There is no significant cultural benefit to the technology being used. 


## Gameplay Objects and Items ##

#### Heros ####

![heros](https://github.com/Amilizia12/413_Final_Project/assets/113862554/ad1fe652-149e-4437-bbc5-143dd21ec62a) \
This object costs gold to create, and protects the Colony. Heroes shoot projectiles at enemies within a range. 


#### Enemy ####

![enemies](https://github.com/Amilizia12/413_Final_Project/assets/113862554/7a407e7f-3b0d-4ddf-a874-0b9fffe286d3) \
This object moves across a predetermined path, intending to defeat the Colony. The player earns gold for defeating this. 

#### The Colony ####

![civilization](https://github.com/Amilizia12/413_Final_Project/assets/113862554/b7b74bab-9909-4145-a1cc-35b3f661b819) \
This is the target that heroes need to protect from enemies. When the Colony runs out of health, the player loses the game. 

#### Projectile ####
![projectile](https://github.com/Amilizia12/413_Final_Project/assets/113862554/fd7ca57d-e4d6-4c6f-8d03-9667772a9868) \

This object is used by Heroes to damage Enemies. The projectile will move toward a target, and can collide with an enemy before it exits the range of the hero. 

## TECHNICAL INFORMATION ##
Basic Technical Information \
Perseus: New Frontier will be implemented using Unity and C#. Objects of the heroes class will keep track of enemies within their designated range. Towers will periodically construct a projectile to target a specific enemy, determined by the targeting setting. Enemies move along a predetermined path, and damage the Colony when they reach the end of the path. Creating heroes requires gold, which is earned by defeating enemies.

### Enemy Script Flowchart ###
