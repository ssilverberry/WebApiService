# WebApiService
It is a simple web api service for my [xamarin-microcharts project](https://github.com/PaulHoriachiy/Xamarin-Microcharts).
It sends, gets requests and store data in Postgres databse. This service is able to do Get, Post, Put, Delete requests. Thanks to Post or Put request from client (android application in my case) it creates and store information in database. Using Delete request with object id you are able to remove needed object from database. 

For better experience in testing your API I would recommend Postman application, it is totally free and easy to-use.
For local server I used IIS server (not IIS Express).
