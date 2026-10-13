using System;
using System.Numerics;
using System.Runtime;
using System.Threading;
class Main_PROGRAM
{
    static void Main(string[] args)
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
        int Encounterchance = 8;
        bool guardDefeated = false;
        bool rugbyDefeated = false;
        bool PLAYERISBUSY = false;
        bool glasstock0 = true;
        bool glasstock1 = true;
        bool glasstock2 = true;
        bool glasstock3 = true;
        for (int i = 0; i < titlepic.Length; i++)//wowza big cool title image
        {
            Console.WriteLine(titlepic[i]);
        }
        Console.WriteLine("\nPlay in fullscreen or increase the size of your window before continuing\n(in a fight the screen should fix itself if your window is the correct size when you change selection)");
        Console.WriteLine("");
        Console.WriteLine("Welcome" +
            " to Bedside Bane! this first page is info dumping and stat showing, to begin, all moves are done through buttons\n\nyou use the up and down arrow to change which button you have selected then use enter to choose that option.");
        Console.WriteLine("All moves in fights have explinations under them, though there are two very important things to note,\n\n1: your MP or Memory Points are what is NEEDED for spells always keep a close eye on them!");
        Console.WriteLine("2: damage works with a roll between your MINIMUM roll and your MAX,\n\nhaving a higher minimum means you always are rolling higher on average,\n\nwhilst a higher MAX damage means your range is increased.(you can roll higher numbers but you can still roll a 1)\n");
        Robbie_player PLAYER = new Robbie_player();
        PLAYER.CURRENT_MONEY += 5000;
        Console.WriteLine("You're MAX Attack roll is " + PLAYER.PLAY_MAXDMGROLL+ "\n");
        Console.WriteLine("You're MINIMUM Attack roll is " + PLAYER.PLAY_MINDMGROLL+ "\n");
        Console.WriteLine("You're Stamina is " + PLAYER.stamina + "\nThis is used to calculate dodging attacks.");
        Console.WriteLine("You're Luck is " + PLAYER.luck+ "\nThis is used to calculate chance to crit against enemies");//boring printing
        Console.WriteLine("press any key to continue");
        Console.ReadKey(true);
        Room currentRoom = SetUpMap();
        string USER_CHOICE = "";

        while (USER_CHOICE != "q")
        {
            if (currentRoom.Title == "Cave Vendor") // shop
            {
                string[] Vendor_sprite = new string[] 
                { @"                                                               .-""""-.",
                  @"                                                              /  \     \",
                  @"                                                              |  .'--. |",
                  @"                                                              | /_   _`|",
                  @"                                                              \( a \ a )",
                  @"                                                               |    > |",
                  @"                                                               |\  =  /",
                  @"                                                               | \___/|",
                  @"                                                           ___/:      :\__",
                  @"                                                         /`  < `\   /` >  `\",
                  @"                                                        /     `\ |__| /`    \",
                  @"                                                       ;   [MD] \|  |/ |I!   ;",
                  @"                                                   jgs |         |  | |""""""|  |",
                  @"                                                       |   |     \  / \___/  |",
                  @"                                                     ----------------------------------"
                };

                Console.WriteLine("press any key to continue");
                Console.ReadKey(true);

                string shop_prompt = "\n                                                Choose something to buy:";
                var SHOP_optionsList = new List<string>();
                var SHOP_descList = new List<string>();
                var SHOP_priceList = new List<string>();
                var SHOP_priceNum = new List<int>(); // numeric prices

                // Always-available option
                SHOP_optionsList.Add("Full Health");
                SHOP_descList.Add("Heals you to full health.");
                SHOP_priceList.Add("Cost 15 Warm Memories");
                SHOP_priceNum.Add(15);

                // Add shard options only if the stock for that shard exists and player's stage matches
                if (glasstock0 && PLAYER.POWERSTAGE == 0)
                {
                    SHOP_optionsList.Add("Blue Glass Shard");
                    SHOP_descList.Add("Empowers your dagger by 1 stage (+2 max dmg roll + 1 min dmg per roll)");
                    SHOP_priceList.Add("Cost 30 Warm Memories");
                    SHOP_priceNum.Add(30);
                }
                if (glasstock1 && PLAYER.POWERSTAGE == 1)
                {
                    SHOP_optionsList.Add("Green Glass Shard");
                    SHOP_descList.Add("Empowers your dagger by 1 stage (+2 max dmg roll + 1 min dmg per roll)");
                    SHOP_priceList.Add("Cost 40 Warm Memories");
                    SHOP_priceNum.Add(40);
                }
                if (glasstock2 && PLAYER.POWERSTAGE == 2)
                {
                    SHOP_optionsList.Add("Pink Glass Shard");
                    SHOP_descList.Add("Empowers your dagger by 1 stage (+2 max dmg roll + 1 min dmg per roll)");
                    SHOP_priceList.Add("Cost 50 Warm Memories");
                    SHOP_priceNum.Add(50);
                }
                if (glasstock3 && PLAYER.POWERSTAGE == 3)
                {
                    SHOP_optionsList.Add("Red Glass Shard");
                    SHOP_descList.Add("Empowers your dagger by 1 stage (+2 max dmg roll + 1 min dmg per roll)");
                    SHOP_priceList.Add("Cost 60 Warm Memories");
                    SHOP_priceNum.Add(60);
                }

                if (SHOP_optionsList.Count > 0 && !PLAYERISBUSY)
                {
                    string[] SHOP_options = SHOP_optionsList.ToArray();
                    string[] SHOP_DESC = SHOP_descList.ToArray();
                    string[] SHOP_COST = SHOP_priceList.ToArray();

                    Shop_menu shopMenu = new Shop_menu(shop_prompt, SHOP_options, SHOP_DESC, SHOP_COST, Vendor_sprite, PLAYER.CURRENT_MONEY);
                    int selectedIndex = shopMenu.Run();

                    if (selectedIndex >= 0 && selectedIndex < SHOP_options.Length)
                    {
                        string chosen = SHOP_options[selectedIndex];
                        int price = SHOP_priceNum[selectedIndex];

                        if (PLAYER.CURRENT_MONEY >= price)
                        {
                            PLAYER.CURRENT_MONEY -= price;
                            Dialouge.speech($"You pay {price} Warm Memories for {chosen}.");//cost and all the items below

                            switch (chosen)
                            {
                                case "Full Health":
                                    PLAYER.CurrentHP = PLAYER.MAXHP;
                                    Dialouge.speech("You are healed to full health.");
                                    Thread.Sleep(50);
                                    Dialouge.speech("You inhale deeply, the warm air flows freely and smoothly through you. even through this hellhole, you feel slightly better.");
                                    break;
                                case "Blue Glass Shard":
                                    PLAYER.POWERSTAGE = 1;
                                    PLAYER.PLAY_MAXDMGROLL += 2;
                                    PLAYER.PLAY_MINDMGROLL += 1;
                                    glasstock0 = false;
                                    Dialouge.speech("You slot the Blue Glass Shard into your dagger.\n");
                                    Thread.Sleep(50);
                                    Dialouge.speech("The shard glows a fluresciant blue as a memory suddenly floods back, you are in a hospital bed\nlooking around you notice your leg in\nthick casts and completely unresponsive to your attempts at movement.\nBefore you can process what your seeing, you are sucked out of the memory left with 3 holes left in your dagger.");
                                    Console.ReadKey(true);
                                    break;
                                case "Green Glass Shard":
                                    PLAYER.POWERSTAGE = 2;
                                    PLAYER.PLAY_MAXDMGROLL += 2;
                                    PLAYER.PLAY_MINDMGROLL += 1;
                                    glasstock1 = false;
                                    Dialouge.speech("You slot the Green Glass Shard into your dagger.\n");
                                    Thread.Sleep(50);
                                    Dialouge.speech("As you push the shard inside, you hear a click and a vivid memory floods your mind, your on a pitch with a ball under your arm, your sprinting for what feels like your life.\n as you sprint you feel a jolt right into your back, your legs give out, and the memory fades.\nyou stare down at a dagger with two holes left clattered on the table.");
                                    Console.ReadKey(true);
                                    break;
                                case "Pink Glass Shard":
                                    PLAYER.POWERSTAGE = 3;
                                    PLAYER.PLAY_MAXDMGROLL += 2;
                                    PLAYER.PLAY_MINDMGROLL += 1;
                                    glasstock2 = false;
                                    Dialouge.speech("You slot the Pink Glass Shard into your dagger.\n");
                                    Thread.Sleep(50);
                                    Dialouge.speech("Your eyes drift shut as the memory slowly washes into your mind. As they reopen you are sat in the bleachers, watching two teams playing Rugby.\nnot knowing why your heart pains and feels like its spinning in your chest.\nYour eyes reset back to the dagger on the shop table, only one left. ");
                                    break;
                                case "Red Glass Shard":
                                    PLAYER.POWERSTAGE = 4;
                                    PLAYER.PLAY_MAXDMGROLL += 2;
                                    PLAYER.PLAY_MINDMGROLL += 1;
                                    glasstock3 = false;
                                    Dialouge.speech("You slot the Red Glass Shard into your dagger.\n");
                                    Thread.Sleep(200);
                                    Dialouge.speech("The Red shard slots in, the gold handle feels heavier than ever in your hands.\nyou cant tell if its the glass or your arm. as you stare through the mosiac pattern you see yourself.\nThe Green shard shows the sprint, the Blue shows the hospital, the pink shows you watching, and the Red shows you, laying in bed trapped here.");
                                    break;
                                default:
                                    Dialouge.speech("Unhandled shop item.");
                                    break;
                            }
                        }
                        else
                        {
                            Dialouge.speech("You don't have enough Warm Memories to buy that.");
                        }

                        Console.ReadKey(true);
                    }
                }
            }
            if (currentRoom.Title == "Big boss" && !rugbyDefeated)//DEMO BOSS
            {
                PLAYERISBUSY = true;
                Console.Clear();


                bool PLAYERWON = Encounters.Rugby_Encounter(PLAYER);
                if (PLAYERWON)
                {
                    guardDefeated = true;
                    PLAYER.CURRENT_MONEY += Random_Rolls.RandRolls(50, 75);
                    silver_KEY = true;
                    Console.WriteLine("\nYou WON! Your total Warm Memories are:  " + PLAYER.CURRENT_MONEY + " !");
                    Console.ReadKey(true);

                    if (currentRoom.North != null)
                    {
                        currentRoom = currentRoom.North; //END OF DEMO!!!
                    }
                }
                else
                {
                    Dialouge.speech("You failed to beat the Boss.");
                }

                PLAYERISBUSY = false;
            }
            else if (currentRoom.Title == "Big boss" && !rugbyDefeated)
            {
                Console.WriteLine("The past is better left behind.");
            }
            if (currentRoom.Title == "Guard's post" && !guardDefeated)//first encounter
            {
                PLAYERISBUSY = true;
                Console.Clear();


                bool PLAYERWON = Encounters.Guard_encounter(PLAYER);
                if (PLAYERWON)
                {
                    guardDefeated = true;
                    PLAYER.CURRENT_MONEY += Random_Rolls.RandRolls(20, 45);
                    silver_KEY = true;
                    Console.WriteLine("\nYou defeat the guard! Your total Warm Memories are:  " + PLAYER.CURRENT_MONEY + " and you got a Silver Key!");
                    Console.WriteLine("You hear wood tapping in the distance.");
                    Console.ReadKey(true);

                    if (currentRoom.South != null)
                    {
                        currentRoom = currentRoom.South; // move back to the cavern
                    }
                }   
                else
                {
                    Dialouge.speech("You failed to beat the guard.");
                }

                PLAYERISBUSY = false;
            }
            else if (currentRoom.Title == "Guard's post" && guardDefeated)
            {
                Console.WriteLine("The armour is a pile on the floor, seems there is nothing left for you here.");
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
                        if (rndenc > Encounterchance)
                        {
                            Encounterchance = 8;
                            PLAYERISBUSY = true;
                            bool PLAYERWON = Encounters.RandomEncounter(PLAYER);
                            if (PLAYERWON)
                            {
                                PLAYER.CURRENT_MONEY += Random_Rolls.RandRolls(5, 15);

                                Console.WriteLine("\nYou defeated the Enemy! your new total Warm Memories are:  " + PLAYER.CURRENT_MONEY);
                                Console.ReadKey(true);
                                PLAYERISBUSY = false;

                            }
                            else
                            {
                                PLAYER.CURRENT_MONEY -= Random_Rolls.RandRolls(10, 20);
                                PLAYERISBUSY = false;
                            }
                        }
                        else
                        {
                            Encounterchance--;
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

        static Room SetUpMap()
        {
            //rooms hold three inputs, the title, the description of said room and a safety level. if the safety is false, a random encounter can occur.
            Room Fields = new Room("Fabric Fields", "The world around you is fresh and a complete mystery. To the west you see a dim mostly vertical cave which is rocky\nenough to be climbed down without much danger to fall. To the east you see a town seemingly bustling with a bake sale\ngoing on, the huge flag proclaiming the event sways above a huge tower.", true);

            Room Cave = new Room("Deep Cave", "A steep vertical cave with a sort of stair-like pattern guiding you downward\nthrough its stone walls as you trudge through you see a room north to you and a huge wooden door to the east", false);

            Room Cave_Door = new Room("Large oak door", "As you walk towards the huge oak door the rotting wood and dust clatters off the metal as you give the door a nudge, the door repulses you, and taps on the keyhole with a hand molded out of wood.", false);



            Room Cavern_North = new Room("Dim Cavern", "The light dims from the lack of sunlight piercing through the entrance, your left in a small room with a Toybox to your\neast and a suit of knight armour standing at the back of the room to the north", false);

            Room Chest_Cavern = new Room("Chipped Toybox", "As you step closer to the Toybox you notice the pulsing wood and metal bending like a pair of lips, will you open it?", false);

            Room Cavern_store = new Room("Cave Vendor", "The sight looks familiar, the white wall and old benches, workers calling people up and\n injured folks being rushed around. but, now its just you. and the clerk.", true);

            Room Chest_OPEN = new Room("Open Toybox", "As you lift the pulsing wood the hinges wing open revealing a small rippling red ring, before you can process the sudden power in the Toybox the ring has latched onto your ring finger and stabbed down. you lose 5 max hp! you gain +2\n to your attack roll!", true);

            Room Chest_CLOSED = new Room("Do not open", "you walk by the Toybox not taking the risk a pulsing plank of wood presents, you walk onwards to the guard", true);

            Room Guard_Fencounter = new Room("Guard's post", "As you step closer to the pillar of armour, you see eyes and teeth swimming inside the darkness within like a lava lamp, as you are struck by this sight hands reach out from the darkness inside the chestplate and latch onto the plates puppetering the armour.", true);

            Room Town = new Room("Echo Ridge",
                                     "You decide to take the seemingly safer route and go to the lively town, as you trod closer the sound of harmonicas and\nflutes pierce the ambience of the woods being a energetic composition that draws you closer", true);//make new room/scene.

            Room Bakery = new Room("Nina's Bakery","You open the door and hear a small bell, the aroma of wheat and chocolate invade your senses.\nyou look up and see.. your Auntie?", true);

            Room Bakery_Counter = new Room("Bakery Desk", "You march towards the counter, far to shook to be off guard. as you get to the counter Nina doesnt speak, only motioning to a slip of paper.", true);

            Room Bakery_Paper = new Room("Slip of paper", "You slowly pickup the slip, the handwriting is familiar. your eyes slowly scroll over the sheet as you read.\n(sorry not finishes just yet)", true);
            Room Trytotalk = new Room("Try to talk to Nina", "As you try  and make small talk about how long its been your brain fuzzes,\nNina trys to speak back, but its just your voice repeated back. You dont remeber her voice.", true);

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
            Bakery.North = Bakery_Counter;
            Bakery_Counter.North = Bakery_Paper;
            Bakery_Counter.South = Town;
            Bakery_Paper.South = Town;
            Trytotalk.South = Bakery_Counter;

            return Fields;
        }

        static Room lockerMapcheck(Room Cave_Door)
        {

            Room Locker_Room = new Room("Locker Room", "You plunge the silver key into the keyhole, the key melted into the keyhole and froze solid using the hole as a mold.  as you step forward you see a locker room full of teenage Rugby players conversing before a game.", true);
            Room Demo_boss = new Room("Big boss","You step forward through the locker room but a hulking beast of a player dressing fully in rugby gear blocks you.", true);
            Room ENDOFDEMO = new Room("DEMOEND", "the demo is now finished, Thanks for playing!", true);
            Cave_Door.North = Locker_Room;
            Locker_Room.North = Demo_boss;                                     
            Locker_Room.South = Cave_Door;
            Demo_boss.North = ENDOFDEMO;

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

