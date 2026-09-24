using System;
using System.Numerics;
using System.Runtime;
using System.Threading;
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
            USER_CHOICE = Console.ReadLine().ToLower();//movement
            Console.WriteLine(currentRoom.Title);
            
            
            if (currentRoom.Title == "Golden Chest")//chest checker
            {
                Console.Clear();
                Console.WriteLine("would you like to open the chest?(y or n)");
                string OPEN_CHEST = Console.ReadLine();
                OPEN_CHEST = OPEN_CHEST.ToLower();
                switch(OPEN_CHEST)
                {
                    case "y":
                        {
                            currentRoom = currentRoom.North;
                            PLAYER.MAXHP = PLAYER.MAXHP - 5;
                            PLAYER.strength = PLAYER.strength + 10;
                            break;
                        }
                    case "n":
                        {
                            currentRoom = currentRoom.South;
                            break;
                        }
                
                }
            }
            else
            {

            }

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
                        Console.WriteLine("are you sure?(y,n)");
                        string quit_game = Console.ReadLine();
                        quit_game = quit_game.ToLower();
                        if (quit_game == "y")
                        {
                            Console.WriteLine("Thanks for playing, goodbye.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("well, its not a yes so, your staying");
                            USER_CHOICE = "";
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                case "check":
                    {
                        Console.WriteLine("Your strength is " + PLAYER.strength + " Your stamina is " + PLAYER.stamina + " Your luck is " + PLAYER.luck);

                        break;
                    }
                
                    default:
                        Console.WriteLine("enter a valid option: (N,E,S,W,Q)");
                        break;
                }
        }
    }

    static Room SetUpMap()
    {
        Room Fields = new Room("Fabric Fields", "The world around you is fresh and a complete mystery. To the west you see a dim mostly vertical cave which is rocky\nenough to be climbed down without much danger to fall. To the east you see a town seemingly bustling with a bake sale\ngoing on, the huge flag proclaiming the event sways above a huge tower.");

        Room Cave = new Room("Deep Cave", "A steep vertical cave with a sort of stair-like pattern guiding you downward\nthrough its stone walls as you trudge through you see a room north to you and a huge wooden door to the east");

        Room Cave_Door = new Room("Large oak door", "As you walk towards the huge oak door the rotting wood and dust clatters off the metal as you give the door a nudge, the door repulses you, and messages to a keyhole with a hand molded out of wood.");

        Room Cavern_North = new Room("Dim Cavern", "The light dims from the lack of sunlight piercing through the entrance, your left in a small room with a chest to your\neast and a suit of knight armour standing at the back of the room to the north");

        Room Chest_Cavern = new Room("Golden Chest", "As you step closer to the chest you notice the pulsing wood and metal bending like a pair of lips, will you open it?");

        Room Chest_OPEN = new Room("Red ring", "As you lift the pulsing wood the hinges wing open revealing a small rippling red ring, before you can process the sudden power in the chest the ring has latched onto your ring finger and stabbed down. you lose 5 max hp! you gain +10\nstrength!");

        Room Chest_CLOSED = new Room("Do not open", "you walk by the chest not taking the risk a pulsing plank of wood presents you walk onwards to the guard");

        Room Guard_Fencounter = new Room("Guard's post", "as you step closer to the knight armour you see many eyes and pairs of teeth floating around the armour like a lava lamp before you know it, the guards spear is pointed at you.");

        Room Town = new Room("Echo Ridge",
                                 "You decide to take the seemingly safer route and go to the lively town, as you trod closer the sound of harmonicas and\nflutes pierce the ambience of the woods being a energetic composition that draws you closer");//make new room/scene.

        Room Bakery = new Room("Nina's Bakery",
                             "you go to the damn bakery what do you think.");
        //begin
        Fields.East = Town;
        Fields.West = Cave;
        //cave route
        Cave.North = Cavern_North;
        Cave.East = Cave_Door;
        Cave_Door.West = Cave;
        Cavern_North.South = Cave;
        Cavern_North.East = Chest_Cavern;
        //first cave split
        Chest_Cavern.North = Chest_OPEN;
        Chest_Cavern.South = Chest_CLOSED;
        //chest choice
        Chest_OPEN.East = Guard_Fencounter;
        Chest_CLOSED.East = Guard_Fencounter;
        Cavern_North.North = Guard_Fencounter;
        //town route
        Town.West = Fields;
        Town.North = Bakery;
        Bakery.South = Town;


        return Fields;
    }
    static void DescribeRoom(Room room)
    {
        Console.WriteLine();
        Dialouge.speech(room.Title+"\n");
        Console.WriteLine("".PadLeft(room.Title.Length, '-'));//cool borders also the doc coded this wrong
        Dialouge.speech(room.Description+"\n");
        Console.WriteLine("".PadLeft(room.Title.Length, '-'));

        Console.WriteLine("Exits: {0}{1}{2}{3}",
                room.North == null ? "" : "North ",
                room.East == null ? "" : "East ",
                room.South == null ? "" : "South ",
                room.West == null ? "" : "West ");
    }


}

