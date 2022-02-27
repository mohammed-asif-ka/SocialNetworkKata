# SocialNetworkKata
Posting: Alice can publish messages to a personal timeline

>> Alice -> I love the weather today
>> Bob -> Damn! We lost!
>> Bob -> Good game though.

Reading: Bob can view Alice’s timeline

> Bob reads Alice
> I love the weather today (5 minutes ago)
> Bob
> Good game though. (1 minute ago)
> Damn! We lost! (2 minutes ago)
> Alice
> I love the weather today (5 minutes ago)

Following: 

> Charlie -> I'm in New York today! Anyone wants to have a coffee?
> Charlie follows Alice
> Charlie wall
> Charlie - I'm in New York today! Anyone wants to have a coffee? (2 seconds ago)
> Alice - I love the weather today (5 minutes ago)

> Charlie follows Bob
> Charlie wall
> Charlie - I'm in New York today! Anyone wants to have a coffee? (15 seconds ago)
> Bob - Good game though. (1 minute ago)
> Bob - Damn! We lost! (2 minutes ago)
> Alice - I love the weather today (5 minutes ago)

Mentions:
> Bob -> @Alice/ What are your plans tonight?
> Alice wall
> Bob - What are your plans tonight? (1 minute ago)
> Alice - I love the weather today (6 minutes ago)

Direct message:
> Alice => Bob/I don't have any particular plan
> Bob messages
> Alice send : I don't have any particular plan(1 minute ago)

**General requirements**
//Application must use the console for input and output;
//User submits commands to the application:
//posting: <user name> -> <message>
//reading: <user name>
//following: <user name> follows <another user>
//wall: <user name> wall
