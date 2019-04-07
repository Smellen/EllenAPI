# EllenAPI
An API that queries the SteamAPI to calculate the average game completion for a player. Other endpoints will be added in the future.

The Steam Web API Documentation: https://steamcommunity.com/dev 

# Calculating the average game completion
To calculate the game completion several calls are made to the Steam API.
1. Find all owned games by the user.
2. Reduce this list down by only looking at games that have playtime. 
3. For each played game try and get the user stats for that game.
    1. Not all games have steam achievements so these games are not counted.
    2. If no achievements are unlocked that game is also not counted.
4. The final calculation is the total number of achievements for all valid games divided by the total unlocked achievements.


# TODO List 
_(In no particular order):_
1. ~~Pass in the Steam user ID as an optional parameter and set my own personal user ID as a default example Steam ID.~~
2. Complete unit tests of Steam API Service and Steam Domain Service.
3. Improve testing all around.
4. Cache the calls to Steam API.
5. API versioning.
6. ~~Logging.~~
7. ~~Health check endpoint.~~
8. Put the logs in a proper place.
9. Find out why there are missing achievements are. Steam API cache? Incorrect looping through games? 
10. Start again but in .NET core.
11. Generate CSV file with each played game and a total count of achievement and total count of unlocked achivements.
