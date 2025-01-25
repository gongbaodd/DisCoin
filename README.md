# DisCoin: The Crypto Bubble Simulator

[Global Game Jam 2025](https://globalgamejam.org/games/2025/discoin-crypto-bubble-simulator-5)

[WebSite](https://dis-coin.vercel.app/)

Step into the dark world of crypto speculation as a "crypto bro" trying to ride the wave of disinformation and manipulate the market. In DisCoin, you'll select news stories, spin lies, approve, or dismiss them to sway public opinion, keeping your memecoin value afloat.

Your choices impact trust and the sanity of your user base. Will you push outrageous lies to skyrocket the price, or play it safe with smaller truths? With every click, the coin value fluctuates. Maintain the perfect bubble and rake in millions before running away, or watch it burst and face the consequences.

Featuring a glowing screen ambiance, GPU fans whirring, and frantic decision-making, DisCoin challenges you to keep the bubble alive—or pop it. Can you master the game of deception, or will your memecoin crash to zero?

## Read before you code

***Editor version 6.0.34f1***

In Unity Editor, Fix your aspect ratio to 960x600

[Project Link (needs invatation)](https://github.com/users/gongbaodd/projects/5)

[FrontEnd Project](https://vercel.com/gongbaodds-projects/dis-coin)

build your unity project to `/DisCoin-Unity/Build`

## gameplay

The starting scene(news feed scene, group chat and the news)

- first news, the trump meme coin
- one screen of a group chat, that a group of people want to start a meme coin `DisCoin`.
`we will start the DisCoin with $9, we sell 100 coins and keep 80 coins of yourself , when we get 1 million we run` the value should be configurable
The bubble will show some news, and the chatter will say `we should handle this....`
there will be a timer 
When the player click "okay" the decision scene will drop some decision dialogs

The decision scene, when a news bubble is choosen there will be multiple windows showing on the screen, you choose click "Okay" or close, the window will close itself as the news obsolete, will regard the player choose a desert solution.

The chart scene, shows the value of the coin, x-Time, y-Value,  Status bar showing the current value and your hold count, the hold count and the money you have.

```
class GameManager {
	currentCoinValue
	poolCount
	holdCount
	Map<Timestamp, value>
	timecap
	List<news>
	playerMoney
}

class CoinValue {
	time
	value
}

class News {
	id
	lifetime
	content
	effectPoints
	List<Decision>
	DesertReaction: List<Reaction>
}

class Decision {
	id
	newsID
	content
	List<Reaction>
	approvalPercentage
	disapprovalPercentage
	label: dismiss|dismay|distract|distort|truth
}

class Reaction {
	id
	content
	newsID
	DecisionID
	value: approval | disapproval | noEffect
}

$NewCoinValue = $CurrentCoinValue + $NewsEffectPoints*$ReactionValue

if $CurrentCoinValue < 0.01, game over, show a bubble burst animation, add a news that the player's story got public and got caught, calculate the time spent and allow players to share the k chart state
if $PlayerMoney + $holdCount*$CurrentCoinValue > 100,000, the player cash out the money, show an animation of people crying, the player fly away with cash, or a news paper `big scam<disCoin>`,  player can share the newspaper screenshot and the game link.

```

## sounds

the message bubble sound
the background sound
the GPU sound

## Sprites

A message app UI
A Chart UI, showing the current value and your hold count, the hold count and the money you have.
the computer sprite

## Narratives

the narratives should be save as JSON format in DisCoin-Unity\Assets\Resources\newsModels.json
the IDs are in DisCoin-Unity\Documents\UUIDs.md

## assets

https://win98icons.alexmeub.com/

## undecided

threshold on the money and the choose the Decision with what kind of approvalPercentage

3 narritives a screen, each one have 1 min life span, 3 mins as a day
if we need the user play like 30min, we need at least 30 narritives

## Milestone and checklists

- Coder
    - Due to 2025/1/25/17:00
        - finish gameplay logic for the message screen & the decision screen
        - make a structual Game UI
    - Due to 2025/1/26/14:00
        - The k-Chart should be ready
- Designer
    - Due to 2025/1/25/17:00
        - finish all the sprite design, apply the sprites on the screens, message
    - Due to 2025/1/26/14:00
        - apply all the sprites on the game, finish UI
- Writer
    - Due to 2025/1/25/17:00
        - finish 10 narritives
    - Due to 2025/1/26/14:00
        - finish all the narritives
- Marketing
    - Due to 2025/1/25/17:00
        - helping the narritives
        - make team UI on the website
    - Due to 2025/1/26/14:00
        - should have tested the game with other teams
- Sound & VFX
    - Due to 2025/1/25/17:00
        - gather sounds and VFX to the project
    - Due to 2025/1/26/14:00
        - apply the sound and VFX

