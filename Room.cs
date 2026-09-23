using System;

class Room //template of the rooms.
{
    public string Title;
    public string Description;
    public Room North;//exits!!!!!!
    public Room East;
    public Room South;
    public Room West;

    public Room(string TITLE, string DESCRIPTION)//construct, -im NOT calling "the constructor" 
    {
        Title = TITLE;
        Description = DESCRIPTION;
    }
}