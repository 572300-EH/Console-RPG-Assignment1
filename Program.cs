using System;
using System.Numerics;
using System.Runtime;
using System.Threading;
class Main_PROGRAM
{
    static void Main(string[] args, Shop_menu shop_menu)
    {
        string[] titlepic = new string[]
        {
           @"    ____              __            _        __                 ____                       ",
           @"   / __ )  ___   ____/ /   _____   (_)  ____/ /  ___           / __ )  ____ _   ____   ___ ",
           @"  / __  | / _ \ / __  /   / ___/  / /  / __  /  / _ \         / __  | / __ `/  / __ \ / _ \",
           @" / /_/ / /  __// /_/ /   (__  )  / /  / /_/ /  /  __/        / /_/ / / /_/ /  / / / //  __/",
           @"/_____/  \___/ \__,_/   /____/  /_/   \__,_/   \___/        /_____/  \__,_/  /_/ /_/ \___/",
        };
        bool silver_KEY = false;
        bool RINGRED = false;
        bool guardDefeated = false;
        bool PLAYERISBUSY = false;
        for (int i = 0; i < titlepic.Length; i++)//wowza big cool title image
        {
            Console.WriteLine(titlepic[i]);
        }
        Console.WriteLine(""); ;
        Console.WriteLine("");
        Robbie_player PLAYER = new Robbie_player();
        Console.WriteLine("You're Attack roll is " + PLAYER.PLAY_MAXDMGROLL);
        Console.WriteLine("You're Stamina is " + PLAYER.stamina);
        Console.WriteLine("You're Luck is " + PLAYER.luck);//boring printing
        Console.WriteLine("press any key to continue");
        Console.ReadKey(true);
        Room currentRoom = SetUpMap();
        string USER_CHOICE = "";

        while (USER_CHOICE != "q")
        {
            if (currentRoom.Title == "Cave Vendor")//we love shop menus
            {
                bool glasstock = true;
                string[] Vendor_sprite = new string[]
                    {
                    @"",
                    @"",
                    @"",
                    @"",
                    @""
                    };

                Console.WriteLine("press any key to continue");
                Console.ReadKey(true);
                string shop_prompt = "\n                                                Choose something to buy:";
                var SHOP_optionsList = new List<string>();
                var SHOP_descList = new List<string>();
                var SHOP_priceList = new List<string>();
                SHOP_optionsList.Add("Full Health"); SHOP_descList.Add("Heals you to full health."); SHOP_priceList.Add("Cost 15 Warm Memories");
                if (glasstock)
                {
                    SHOP_optionsList.Add("Glass Shard"); SHOP_descList.Add("very similar to the one glass shard already in your dagger (empowers your dagger by 1 stage / +2 dmg roll)"); SHOP_priceList.Add("Cost 30 Warm Memories");
                }

                if (SHOP_optionsList.Count > 0 && !PLAYERISBUSY)
                {
                    string[] SHOP_options = SHOP_optionsList.ToArray();
                    string[] SHOP_DESC = SHOP_descList.ToArray();
                    string[] SHOP_COST = SHOP_priceList.ToArray();
                    Shop_menu shop_Menu = new Shop_menu(shop_prompt, SHOP_options, SHOP_DESC, SHOP_COST, Vendor_sprite);
                    int selectedIndex = shop_menu.Run();
                    if (selectedIndex >= 0 && selectedIndex < SHOP_options.Length)
                    {
                       string SHOP_CHOICE = SHOP_options[selectedIndex].ToLower();
                    }


                }
                if (currentRoom.Title == "Guard's post" && !guardDefeated)//first enocunter
                {
                    PLAYERISBUSY = true;
                    Console.Clear();


                    bool PLAYERWON = Encounters.Guard_encounter(PLAYER);
                    if (PLAYERWON)
                    {
                        guardDefeated = true;
                        PLAYER.CURRENT_MONEY += Random_Rolls.RandRolls(20, 45);
                        silver_KEY = true;
                        Console.WriteLine("\nYou defeat the guard and gain " + PLAYER.CURRENT_MONEY + " Warm memories and a silver key!");
                        Console.ReadKey(true);

                        if (currentRoom.South != null)
                        {
                            currentRoom = currentRoom.South;//get a schmove                    }
                        }
                        else
                        {
                            if (currentRoom.South != null)
                            {
                                Dialouge.speech("You failed to beat the guard.");
                            }
                        }
                        PLAYERISBUSY = false;

                    }
                    else if (currentRoom.Title == "Guard's post" && guardDefeated)
                    {
                        Console.WriteLine("The armour is a pile on the floor, seems there is nothing left for you here.");
                    }
                }
                DescribeRoom(currentRoom, PLAYERISBUSY);

                if (currentRoom.Title == "Open Toybox" && RINGRED == false)
                {

                    PLAYER.PLAY_MAXDMGROLL += 2;
                    PLAYER.MAXHP -= 5;
                    PLAYER.CurrentHP -= 5;
                    RINGRED = true;
                }
                else if (currentRoom.Title == "Open Toybox" && RINGRED == true)
                {
                    Console.WriteLine("The chest is empty");
                }

                if (currentRoom.Title == "Large oak door")
                {
                    if (silver_KEY)
                    {
                        lockerMapcheck(currentRoom);
                    }
                }
                Console.WriteLine("press any key to continue");
                Console.ReadKey(true);
                string prompt = "\n                                                Choose your direction:";
                var optionsList = new List<string>();
                var destList = new List<string>();
                if (currentRoom.North != null) { optionsList.Add("North"); destList.Add(currentRoom.North.Title); }
                if (currentRoom.East != null) { optionsList.Add("East"); destList.Add(currentRoom.East.Title); }
                if (currentRoom.South != null) { optionsList.Add("South"); destList.Add(currentRoom.South.Title); }
                if (currentRoom.West != null) { optionsList.Add("West"); destList.Add(currentRoom.West.Title); }

                if (optionsList.Count > 0 && !PLAYERISBUSY)
                {
                    string[] options = optionsList.ToArray();
                    string[] destinations = destList.ToArray();
                    Travel_Menu travelMenu = new Travel_Menu(prompt, options, destinations, currentRoom.Title);
                    int selectedIndex = travelMenu.Run();

                    if (selectedIndex >= 0 && selectedIndex < options.Length)
                    {
                        string Chosen = options[selectedIndex].ToLower();//converting the index of which button you were on eg north = 0 and reversing it, so 0 = north. we do this so we can then see which direction you went as north isnt always 0
                        if (Chosen == "north") USER_CHOICE = "n";
                        else if (Chosen == "east") USER_CHOICE = "e";
                        else if (Chosen == "south") USER_CHOICE = "s";
                        else if (Chosen == "west") USER_CHOICE = "w";
                        else USER_CHOICE = Chosen;
                        if (currentRoom.Safety == false)//random encounter check and output
                        {
                            int rndenc = Random_Rolls.RandRolls(1, 10);
                            if (rndenc > 0)
                            {
                                PLAYERISBUSY = true;
                                bool PLAYERWON = Encounters.RandomEncounter(PLAYER);
                                if (PLAYERWON)
                                {
                                    PLAYER.CURRENT_MONEY += Random_Rolls.RandRolls(5, 15);

                                    Console.WriteLine("\nYou defeated the Enemy and gain " + PLAYER.CURRENT_MONEY + " Warm memories!");
                                    Console.ReadKey(true);
                                    PLAYERISBUSY = false;

                                }
                                else
                                {
                                    PLAYER.CURRENT_MONEY -= Random_Rolls.RandRolls(10, 20);
                                    PLAYERISBUSY = false;
                                }
                            }
                        }
                    }
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
                    default:
                        break;
                }
            }
        }

        static Room SetUpMap()
        {
            //rooms hold three inputs, the title, the description of said room and a safety level. if the safety is false, a random encounter can occur.
            Room Fields = new Room("Fabric Fields", "The world around you is fresh and a complete mystery. To the west you see a dim mostly vertical cave which is rocky\nenough to be climbed down without much danger to fall. To the east you see a town seemingly bustling with a bake sale\ngoing on, the huge flag proclaiming the event sways above a huge tower.", true);

            Room Cave = new Room("Deep Cave", "A steep vertical cave with a sort of stair-like pattern guiding you downward\nthrough its stone walls as you trudge through you see a room north to you and a huge wooden door to the east", false);

            Room Cave_Door = new Room("Large oak door", "As you walk towards the huge oak door the rotting wood and dust clatters off the metal as you give the door a nudge, the door repulses you, and taps on the keyhole with a hand molded out of wood.", false);



            Room Cavern_North = new Room("Dim Cavern", "The light dims from the lack of sunlight piercing through the entrance, your left in a small room with a Toybox to your\neast and a suit of knight armour standing at the back of the room to the north", false);

            Room Chest_Cavern = new Room("Chipped Toybox", "As you step closer to the Toybox you notice the pulsing wood and metal bending like a pair of lips, will you open it?", false);

            Room Cavern_store = new Room("Cave Vendor", "The sight looks familiar, the white wall and old benches, workers calling people up and injured folks being rushed around. but, now its just you. and the clerk.", true);

            Room Chest_OPEN = new Room("Open Toybox", "As you lift the pulsing wood the hinges wing open revealing a small rippling red ring, before you can process the sudden power in the Toybox the ring has latched onto your ring finger and stabbed down. you lose 5 max hp! you gain +2\n to your attack roll!", true);

            Room Chest_CLOSED = new Room("Do not open", "you walk by the Toybox not taking the risk a pulsing plank of wood presents, you walk onwards to the guard", true);

            Room Guard_Fencounter = new Room("Guard's post", "As you step closer to the pillar of armour, you see eyes and teeth swimming inside the darkness within like a lava lamp, as you are struck by this sight hands reach out from the darkness inside the chestplate and latch onto the plates puppetering the armour.", true);

            Room Town = new Room("Echo Ridge",
                                     "You decide to take the seemingly safer route and go to the lively town, as you trod closer the sound of harmonicas and\nflutes pierce the ambience of the woods being a energetic composition that draws you closer", true);//make new room/scene.

            Room Bakery = new Room("Nina's Bakery",
                                 "you go to the damn bakery what do you think.", true);
            //begin
            Fields.East = Town;
            Fields.West = Cave;
            //cave route
            Cave.North = Cavern_North;
            Cave.East = Cave_Door;


            Cave_Door.West = Cave;
            Cavern_North.South = Cave;
            Cavern_North.East = Chest_Cavern;
            Cavern_North.West = Cavern_store;
            Cavern_store.East = Cavern_North;
            //first cave split
            Chest_Cavern.North = Chest_OPEN;
            Chest_Cavern.South = Chest_CLOSED;
            //chest choice
            Chest_OPEN.East = Guard_Fencounter;
            Chest_CLOSED.East = Guard_Fencounter;
            Cavern_North.North = Guard_Fencounter;
            //guard point
            Guard_Fencounter.South = Cavern_North;
            //town route
            Town.West = Fields;
            Town.North = Bakery;
            Bakery.South = Town;


            return Fields;
        }

        static Room lockerMapcheck(Room Cave_Door)
        {

            Room Locker_Room = new Room("Locker Room", "You plunge the silver key into the keyhole, the key melted into the keyhole and froze solid using the hole as a mold.  as you step forward you see a locker room full of teenage Rugby players conversing before a game.", false);
            Cave_Door.North = Locker_Room;
            Locker_Room.South = Cave_Door;

            return Locker_Room;
        }


        static void DescribeRoom(Room room, bool isBusy)
        {
            Console.Clear();
            Console.WriteLine();
            Dialouge.speech(room.Title + "\n");
            Console.WriteLine("".PadLeft(room.Title.Length, '-'));//cool borders also the doc coded this wrong
            Dialouge.speech(room.Description + "\n");
            Console.WriteLine("".PadLeft(room.Title.Length, '-'));
            if (!isBusy)
            {
                Console.WriteLine("Exits: {0}{1}{2}{3}",
                        room.North == null ? "" : "North ",
                        room.East == null ? "" : "East ",
                        room.South == null ? "" : "South ",
                        room.West == null ? "" : "West ");
            }



        }

    }
}

