# DisCoin: The Crypto Bubble Simulator

[Global Game Jam 2025](https://globalgamejam.org/games/2025/discoin-crypto-bubble-simulator-5)

[WebSite](https://dis-coin.vercel.app/)

Step into the dark world of crypto speculation as a "crypto bro" manufacturing a wave of disinformation to manipulate the market. In DisCoin, you'll select news stories, amplify or dismiss them, and spin lies to sway public opinion, rocketing your memecoin to the moon.

Dismiss stories, distort the truth, create distractions, and sow dismay to sway gullible masses. With every click, the coin value fluctuates. Maintain the perfect bubble and rake in millions before pulling the rug, or watch it burst and face the consequences.

Featuring glowing screen ambiance, the subtle whir of GPU fans, and frantic decision-making, DisCoin challenges you to keep the $BUBBLE alive—or pop it. Can you master the game of deception, or will your memecoin, and your reputation, crash to zero?


## Read before you code

***Editor version 6.0.34f1***

In Unity Editor, Fix your aspect ratio to 960x600

[Project Link (needs invitation)](https://github.com/users/gongbaodd/projects/5)

[FrontEnd Project](https://vercel.com/gongbaodds-projects/dis-coin)

Build your Unity project to `/DisCoin-Unity/Build`

## Gameplay

DisCoin is set in the player’s cozy room, and starts when they click the “Start” icon on the desktop. An instant messaging application pops up, where the player (an influencer with millions of followers) is recruited by a mysterious person to promote the latest memecoin.

Inspired by games like The Westport Independent, gameplay is driven by the player’s decisions among strategies of spreading disinformation, namely DISMISS, DISTRACT, DISTORT or DISMAY. By using the strategies employed by real world purveyors of disinformation, players can learn to spot such tactics in their daily lives.

The effectiveness of each strategy varies depending on the news—an unconvincing spin will be faced with the wrath of masses and a drop in the token’s price or vice versa. With 2,000,000 tokens that you bought at a 90% off discount before public sale, your goal is to push the price of $BUBBLE to $50.

Wen lambo? Soon!

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
	label: DISMISS | DISMAY | DISTRACT | DISTORT
}

class Reaction {
	id
	content
	newsID
	DecisionID
	value: approval | disapproval | noEffect
}

$NewCoinValue = $CurrentCoinValue + $NewsEffectPoints*$ReactionValue

if $CurrentCoinValue < 0.01, game over
if $CurrentCoinValue > 50, the player wins - or do they?

```

## Sounds

- GPU fan for ambience
- Keyboard typing
- Background music (credits to Nikita Dolgov)


## Sprites

- Desktop UI (functioning as the menu screen)
- Message app (the intro cutscene)
- Price graph UI showing $BUBBLE price in real-time
- Newsfeed and decision UI
- Emoji reactions to player decisions
- Endings


## Narratives

Narratives of the newsfeed, possible decisions and reactions are saved in .JSON format at DisCoin-Unity\Assets\Resources\newsModels.json


## Future features

- Showing the highest $BUBBLE price achieved by the player on ending screen
- Optimize decision and price logic
- Procedural generation of newsfeed and decisions


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

