# FGOCostCalculator
A program that calculates all possible party loadouts that use up 100% of your Total Party Cost for your respective Master Level in the mobile game Fate/Grand Order. It asks for your Master (player) Level, which determines how many Cost points are available to you at this time. Using that, it runs through every possible party with a Cost value that would equal *exactly* what your Cost level is and outputs it.

For example, let's say your Master Level is 125, which would make your Total Party Cost 110. In this case, this is one of the example loadouts the program would output:

##### Servants (playable units): 3 Five Star, 1 Four Star, 1 Three Star. Craft Essences (equipment): 2 Five Star, 1 Four Star, 2 Three Star.

- Five Star servants have 16 cost, Four Star servants have 12 cost, and Three Star servants have 7 cost. 3(16) + 12 + 7 = 67.
- Five Star CEs have 12 cost, Four Star CEs have 9 cost, and Three Star CEs have 5 cost. 2(12) + 9 + 2(5) = 43.

67 + 43 = 110. This loadout is one of many created by the program that makes maximum use of all Cost points allotted to you and doesn't waste any potential.

This program assumes a few things:
##### You are above Master Level 10
Players below Master Level 10 have a Total Party Cost of 38, which is actually too low to completely fill out every Servant and Craft Essence slot you have with even the lowest Cost units. It takes less than an hour of playtime to reach Master Level 10 anyway.
##### No One/Two Star Craft Essences are being used
One/Two Star CEs are useless for the most part, and the cost of a Three Star CE is low enough to use even at lower Master Levels. One/Two Star Servants are still very much useful, and the program does take those into account.
