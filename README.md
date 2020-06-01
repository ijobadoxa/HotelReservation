# Hotel
- Working with reservations in hotels. 
- Define status of entered reservation - calculate is it possible to accept reservation.
    
## HappyFlow
- User define hotel size
- User enter start and end date of reservation
- User get message about status of reservation (accept or decline)

## Algorithm for checking reservations
- Checking is available space for entered reservation in every room in hotel.
- If there is available space put reservation in first available room and send user information that is reservation is accepted.
- If there is not availble space try to move some reservation form  one room for that period to other room in hotel.
- If reservation can be moved to another room in hotel, move reservation to new room and put temporary reservation in room and send user information that is reservation is accepted..
- If reservation can not be moved to another room in hotel nd send user information that is reservation is decline.

## Depedency -> libs
- .NET Framework, Version=v4.7.2
- MSTest.TestAdapter, Version=2.1.1
- MSTest.TestFramework, Version=2.1.1