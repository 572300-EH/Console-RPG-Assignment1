using System;
using System.Numerics;
using System.Runtime;
using System.Threading;

class Robbie_player
{
    int _strength = 5 + Random_Rolls.RandRolls(1, 16);//we love rng
    int _stamina = 5 + Random_Rolls.RandRolls(1, 16);
    int _luck = 5 + Random_Rolls.RandRolls(1, 16);
    int _CurrentHP = 50;
    int _MAXHP = 50;
    int _CurrentMP = 50;
    int _MAXMP = 50;


    public int strength;
    public int stamina;
    public int luck;
    public int CurrentHP;
    public int MAXHP;
    public int CurrentMP;
    public int MAXMP;

    public Robbie_player()
    {
        strength = _strength;
        stamina = _stamina;
        luck = _luck; //securing the code?? -who is stealing 4 lines of code-
        CurrentHP = _CurrentHP;
        MAXHP = _MAXHP;
        CurrentMP = _CurrentMP;
        MAXMP = _MAXMP;
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
public class Dialouge
{
    public static void speech(string TEXT)
    {
        foreach (char C in TEXT)
        {
            Thread.Sleep(25);
            Console.Write(C);
        }
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

class Fighting_thing
{
    static void Guard_encounter()
    {
        Console.WriteLine("as you walk towards the guard two hands reach up from behind his helmet and lift up many eyes a spear is raised at you as you prepare to fight.");
        Console.ReadKey();

    }

    public static void Combat( Robbie_player player,bool random, string name, int strength, int stamina, int health, int luck)
    {
        string E_n = ""; //similar to the public class variables
        int E_str = 0;
        int E_stm = 0;
        int E_HP = 0;
        int E_luck = 0;
        if (random)
        {

        }
        else
        {
            E_n = name;
            E_str = strength;
            E_stm = stamina;
            E_HP = health;
            E_luck = luck;
        }
        while(E_HP>0)
        {
            Console.WriteLine("Remember only type the letters in the brackets to do that choice");
            Console.WriteLine("*******************");
            Console.WriteLine("|(a)ttack (s)pells|");
            Console.WriteLine("|(d)efend (r)un   |");
            Console.WriteLine("*******************");
            Console.WriteLine("Memory Power:" + player.CurrentMP +"Health Points" + player.CurrentHP);
            string Player_input = Console.ReadLine();
            Player_input = Player_input.ToLower();
            switch(Player_input)
            {
                case "a":
                    {
                        //beat up time
                        
                        int Player_DEALDMG = Random_Rolls.RandRolls(1, 7) * player.strength / 10;
                        int E_dodgechance = Random_Rolls.RandRolls(1, E_stm * 2);
                        if (E_dodgechance > E_stm * 1.5)
                        {
                            Player_DEALDMG = 0;
                        }


                        Console.WriteLine("You slash at the " + E_n);
                        if (Player_DEALDMG == 0)
                        {
                            Console.WriteLine("you missed!");
                        }
                        else
                        {
                            Console.WriteLine("you struck "+ E_n + "for "+ Player_DEALDMG);
                        }
                        break;
                    }
                case "s":
                    {
                        //magic

                        break;
                    }
                case "d":
                    {
                        //regen MP and take less dmg

                        break;
                    }
                case "r":
                    {
                        //skedadle

                        break;
                    }
            }
        }

    }

}


class Main_PROGRAM
{
    static void Main(string[] args)
    {
        int ENEMY_STRENGTH = 1;
        int ENEMY_STAMINA = 1;
        int ENEMY_LUCK = 1;
        int ENEMY_HEALTH = 1;
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

        Room Guard_Fencounter = new Room("Guard's post", "as you step closer to the knight armour you see many eyes and pairs of teeth floating around the armour like a lava lamp before you know it, the guards spear is pointed at you.");

        Room Town = new Room("Echo Ridge",
                                 "You decide to take the seemingly safer route and go to the lively town, as you trod closer the sound of harmonicas and\nflutes pierce the ambience of the woods being a energetic composition that draws you closer");//make new room/scene.

        Room Bakery = new Room("Nina's Bakery",
                             "you go to the damn bakery what do you think.");

        Fields.East = Town;
        Fields.West = Cave;
        Cave.North = Cavern_North;
        Cave.East = Cave_Door;
        Cave_Door.West = Cave;
        Cavern_North.South = Cave;
        Cavern_North.East = Chest_Cavern;
        Cavern_North.North = Guard_Fencounter;
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

