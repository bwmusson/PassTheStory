# Pass The Story

End-of-term final group project for Advanced C# (ASP.NET) class. The rest of the group ended up not finishing the class, so this ended up being an unintentional solo project.

The idea was another student's, but I fleshed it out. Pass The Story is a collaborative storytelling platform in which a user submits a 1000 character or less prompt for a story, and then another user starts the story from there with another 1000 character or less submission. The application theoretically then assigns the next part of the story to a random user (who is not the prompter or the previous writer), to then add another part. I was not able to fully finish that functionality before the due date.

The application incorporates ASP.NET Identity for login functionality and Entity Framework 6 to connect to an SQLExpress database. Sample story data is taken from the WritingPrompts subreddit (http://www.reddit.com/r/WritingPrompts), and pictures are from Unsplash, for academic use. I did not have time to integrate the unit testing I wanted to add, either. Added in error handling to the Web project, to prevent the application error page from presenting to a user. There is also an API added which can present either a full list of all finished stories, or a random story containing a keyword.
