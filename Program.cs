using System;

class Robbie_player
{
    int _strength = 5 + Random_Rolls.RandRolls(1, 16);//we love rng
    int _stamina = 5 + Random_Rolls.RandRolls(1, 16);
    int _luck = 5 + Random_Rolls.RandRolls(1, 16);


    public int strength;
    public int stamina;
    public int luck;

    public Robbie_player()
    {
        strength = _strength;
        stamina = _stamina;
        luck = _luck; //securing the code?? -who is stealing 4 lines of code-
    }
}
public class Random_Rolls
{
    public static int RandRolls(int min, int max)//function of rng
    {
        Random rnd = new Random();
        return rnd.Next(min, max);
    }
}
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

class Main_PROGRAM
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Bedside Bane, you are Robbie and these are your stats.");
        Robbie_player PLAYER = new Robbie_player();
        Console.WriteLine("You're Strength is " + PLAYER.strength);
        Console.WriteLine("You're Stamina is " + PLAYER.stamina);
        Console.WriteLine("You're Luck is " + PLAYER.luck);//boring printing
        Room currentRoom = SetUpMap();
        string USER_CHOICE = "";

        while (USER_CHOICE != "q")
        {
            DescribeRoom(currentRoom);
            Console.Write("> ");
            USER_CHOICE = Console.ReadLine().ToLower();

            switch (USER_CHOICE)
            {
                case "n":
                    if (currentRoom.North != null)
                        currentRoom = currentRoom.North;
                    Console.Clear();
                    break;
                case "e":
                    if (currentRoom.East != null)
                        currentRoom = currentRoom.East;
                    Console.Clear();
                    break;
                case "s":
                    if (currentRoom.South != null)
                        currentRoom = currentRoom.South;
                    Console.Clear();
                    break;
                case "w":
                    if (currentRoom.West != null)
                        currentRoom = currentRoom.West;
                    Console.Clear();
                    break;
                case "q":
                    Console.WriteLine("Thanks for playing, goodbye.");
                    break;
                default:
                    Console.WriteLine("enter a valid option: (N,E,S,W,Q)");
                    break;
            }
        }
    }

    static Room SetUpMap()
    {
        Room Fields = new Room("Fabric Fields", "The world around you is fresh and a complete mystery. To the west you see a dim mostly vertical but rocky enough to be climbed down without much danger to fall. To the east you see a town seemingly bustling with a bake sale going on, the huge flag proclaiming the event sways above a huge tower.");

        Room Cave = new Room("Deep Cave", "A steep vertical cave with a sort of stair-like pattern guiding you downward through its stone walls as you trudge through you see a room north to you and a huge wooden door to the east");

        Room Cave_Door = new Room("Large oak door","As you walk towards the huge oak door the rotting wood and dust clatters off the metal as you give the door a nudge, the door repulses you, and messages to a keyhole.");

        Room Cavern_North = new Room("Dim Cavern", "The light dims from the lack of sunlight piercing through the entrance, your left in a ");

        Room Town = new Room("Echo Ridge",
                                 "You decide to take the seemingly safer route and go to the lively town, as you trod closer the sound of harmonicas and flutes pierce the ambience of the woods being a energetic composition that draws you closer");//make new room/scene.

        Room Bakery = new Room("Nina's Bakery",
                             "you go to the damn bakery what do you think.");

        Fields.East = Town;
        Fields.West = Cave;
        Town.West = Fields;
        Town.North = Bakery;
        Bakery.South = Town;
        

        return Fields;
    }
    static void DescribeRoom(Room room)
    {
        Console.WriteLine();
        Console.WriteLine(room.Title);
        Console.WriteLine("".PadLeft(room.Title.Length, '-'));//cool borders
        Console.WriteLine(room.Description);
        Console.WriteLine("".PadLeft(room.Title.Length, '-'));

        Console.WriteLine("Exits: {0}{1}{2}{3}",
                room.North == null ? "" : "North ",
                room.East == null ? "" : "East ",
                room.South == null ? "" : "South ",
                room.West == null ? "" : "West ");
    }

}

