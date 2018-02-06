# LUIS Demo
This project's code is meant to be deployed alongisde an Azure web bot. 

## Intent
The only extra intent (past the stock trained intents) is "GetPost". Get post displays all the entities from within the code. 

![alt text](https://github.com/wobey/LUIS_Demo/blob/master/demo1.png)

## Entry
LUIS has been trained to recognize four entry types:
1. Temperature (the temperature at the time the Reddit post was made),
2. TitleKeyword (the keyword to search in the Reddit title),
3. TableType (the database table to query),
4. DBTime (the time of the Reddit post or Weather condition).

![alt text](https://github.com/wobey/LUIS_Demo/blob/master/demo2.png)

## Future Ambition
The next steps of this bot will allow it to query a database and return relevant information to the user. The intents and entries seen above are based on an existing bot that I made. It attempts to correlate Seattle Reddit posts with the current weather condition, and inserts them into a database:
* https://github.com/wobey/Web-Scraper
