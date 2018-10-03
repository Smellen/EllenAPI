# EllenAPI
An API that queries the SteamAPI to calculate the average game completion for a player. Other endpoints will be added in the future.

# Calculating the average game completion
To calculate the game completion several calls are made to the Steam API.
1. Find all owned games by the user.
2. Reduce this list down by only looking at games that have playtime. 
3. For each played game try and get the user stats for that game.
  i. Not all games have steam achievements so these games are not counted.
4.If no achievements are unlocked that game is not counted.
5. The final calculation is the total number of achievements for all valid games divided by the total unlocked achievements.


# TODO List 
_(In no particular order):_
1. ~~Pass in the Steam user ID as an optional parameter and set my own personal user ID as a default example Steam ID.~~
2. Complete unit tests of Steam API Service and Steam Domain Service.
3. After domain layer completion seperate out controller layer into correct endpoints. Not all endpoints belong in a Steam controller.
4. Unit Test the controller layer.
5. Cache the calls to Steam API.
6. API versioning.
7. ~~Logging.~~
8. ~~Health check endpoint.~~
9. Put the logs in a proper place.
