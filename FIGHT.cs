using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

class Encounters
{
    public static bool Guard_encounter(Robbie_player player)
    {
        Dialouge.speech("as you walk towards the guard two hands reach up from behind his helmet and lift up many eyes a spear is raised at you as you prepare to fight. (press any key)");
        Console.ReadKey();
        Console.Clear();
        string[] GuardSprite = new string[19];
        {
            Console.WriteLine(@"     A           {}");
            Console.WriteLine(@"    / \         .--.");
            Console.WriteLine(@"    \ /        /.--.\");
            Console.WriteLine(@"     |         |====|");
            Console.WriteLine(@"     |         |`::`|");
            Console.WriteLine(@"     |     .-;`\..../`;-.");
            Console.WriteLine(@"    /\\/  /  |...::...|  \");
            Console.WriteLine(@"    |:'\ |   /'''::'''\   |");
            Console.WriteLine(@"     \ /\;-,/\   ::   /\--;");
            Console.WriteLine(@"     |\ <` >  >._::_.<,<__>");
            Console.WriteLine(@"     | `""`  /   ^^   \|  |");
            Console.WriteLine(@"     |       |        |\::/");
            Console.WriteLine(@"     |       |___/\___| '''");
            Console.WriteLine(@"     |        \_ || _/");
            Console.WriteLine(@"     |        <_ >< _>");
            Console.WriteLine(@"     |        |  ||  |");
            Console.WriteLine(@"     |        |  ||  |");
            Console.WriteLine(@"     |       _\.:||:./_");
            Console.WriteLine(@"     |      /____/\____\");

        }
        
        return Combat(player, false, "The Encased Audience",10,30,10,6,GuardSprite);

    }

    public static bool Combat(Robbie_player player, bool random, string name, int stamina, int health, int luck, int max_dmgroll, string
        [] sprite)
    {
        bool Battleconditons = true;
        string E_n = ""; //similar to the public class variables
        int E_stm= 0;
        double E_HP = 0;
        int E_luck= 0;
        int E_dmgroll= 0;
        string[] E_icon = sprite; 
        if (random)
        {

        }
        else
        {
            E_n = name;
            E_stm = stamina + 1;
            E_HP = health;
            E_luck = luck + 1;
            E_dmgroll = max_dmgroll + 1;
            E_icon = sprite;

        }
        int TURNCOUNT = 0;
        int Cturnsremaining = 0;
        double PowerUP = 0;
        while (Battleconditons)
        {
            bool turnEnded = false;
            bool Defended = false;
            double Total_DMG = 0;
            if (Cturnsremaining <= 0)//all the checks for the powerup
            {
                PowerUP = 0;
            }
            else if (Cturnsremaining > 0)
            {
                PowerUP = 2;
            }
            else
            {
                PowerUP = 0;
            }
           for (int i  = 0; i > sprite.Length; i++)
            {
                Console.WriteLine(sprite[i]);
            }
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Enemy:" + E_n);
            Console.WriteLine("Enemies damage roll is " + E_dmgroll + " the enemies HEALTH is " + E_HP);
            Console.WriteLine("----------------------------------------------------------------");
            Dialouge.speech("\nMemory Power: " + player.CurrentMP + " Health Points: " + player.CurrentHP);
            Console.WriteLine("\nTurn count: " + TURNCOUNT);
            Console.WriteLine("\nPower up turns left: " + Cturnsremaining);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            string prompt = "\nChoose your action:";
            string[] options = { "Attack", "Spells", "Defend", "Run" };
            Fight_Menu fightMenu = new Fight_Menu(prompt, options);
            Dialouge.speech("\nMemory Power: " + player.CurrentMP + " Health Points: " + player.CurrentHP);
            int Fightindex = fightMenu.Run();
            switch(Fightindex)
            {
                case 0:
                    {
                        //beat up time
                        double Player_DEALDMG = Random_Rolls.RandRolls(1, player.PLAY_MAXDMGROLL);
                        int CRITCHANCE = Random_Rolls.RandRolls(0, player.luck * 2);
                        if (CRITCHANCE > player.luck * 1.5)
                        {
                            Player_DEALDMG = Player_DEALDMG * 2;
                            Player_DEALDMG = Math.Ceiling(Player_DEALDMG);
                            Console.WriteLine("you have CRIT!");
                        }
                        else
                        {

                        }
                        int E_dodgechance = Random_Rolls.RandRolls(0, E_stm * 2);
                        if (E_dodgechance > E_stm * 1.5)
                        {
                            Player_DEALDMG = 0;
                        }


                        Dialouge.speech("\nYou slash at " + E_n);
                        if (Player_DEALDMG < 0)
                        {
                            Player_DEALDMG = 0;
                        }
                        if (Player_DEALDMG == 0)
                        {
                            Dialouge.speech("\nyou missed!");
                            turnEnded = true;
                            break;
                        }
                        else
                        {
                            if (PowerUP == 2)//check for if the powerup move is active and if so run differnt calculations(Who do i think i am saying big words?).
                            {
                                Console.WriteLine("\nyou deal " + Player_DEALDMG);
                                Total_DMG = Player_DEALDMG * 2;
                                Total_DMG = Math.Ceiling(Total_DMG);
                                Dialouge.speech("\nYour slash the empowered dagger at " + E_n + " for " + Total_DMG);
                            }
                            else
                            {
                                Console.WriteLine("\nyou deal " + Player_DEALDMG);
                                Total_DMG = Player_DEALDMG;
                                Total_DMG = Math.Round(Total_DMG);
                                Dialouge.speech("\nYour slash at " + E_n + " for " + Total_DMG);
                            }
                            E_HP = E_HP - Total_DMG;
                            turnEnded = true;
                        }
                        break;
                        
                    }
                case 1:
                    {
                        //magic(no way)
                        bool inspellmenu = true;
                        while (inspellmenu == true)
                        {
                            Console.Clear();
                            for (int i = 0; i > sprite.Length; i++)
                            {
                                Console.WriteLine(sprite[i]);
                            }
                            Console.WriteLine("----------------------------------------------------------------");
                            Console.WriteLine("");
                            Console.WriteLine("Enemy:" + E_n);
                            Console.WriteLine("Enemies damage roll is " + E_dmgroll + " the enemies HEALTH is " + E_HP);
                            Console.WriteLine("----------------------------------------------------------------");
                            Console.WriteLine("(m)costs 15 MP (a) costs 20 MP");
                            Console.WriteLine("        (c) costs 10 MP       ");
                            Dialouge.speech("\nMemory Power: " + player.CurrentMP + "\nHealth Points: " + player.CurrentHP + "\n");
                            Console.WriteLine("\nTurn count: " + TURNCOUNT);
                            Console.WriteLine("\nPower up turns left: " + Cturnsremaining);
                            Console.WriteLine();
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            prompt = "\nChoose your action:\nM = 15mp A = 20mp C = 10mp";
                            options = new string[] { "Mystic Spike", "Astral Mend", "Cosmic Surge", "Back" };
                            Spell_menu spell_menu = new Spell_menu(prompt, options);
                            Dialouge.speech("\nMemory Power: " + player.CurrentMP + " Health Points: " + player.CurrentHP);
                            int Spellindex = spell_menu.Run();
                            while (inspellmenu == true)
                                switch (Spellindex)
                                {
                                    case 0:
                                        {
                                            if (player.CurrentMP >= 15)//cost
                                            {
                                                player.CurrentMP = player.CurrentMP - 15;//all the damage code, yay
                                                double Player_DEALDMG = Random_Rolls.RandRolls(1, player.PLAY_MAXDMGROLL) * 2;
                                                Player_DEALDMG = Math.Ceiling(Player_DEALDMG);
                                                int CRITCHANCE = Random_Rolls.RandRolls(1, player.luck * 2);
                                                if (CRITCHANCE > player.luck * 1.5)
                                                {
                                                    Player_DEALDMG = Player_DEALDMG * 2;
                                                    Player_DEALDMG = Math.Ceiling(Player_DEALDMG);
                                                }
                                                else
                                                {

                                                }
                                                int E_dodgechance = Random_Rolls.RandRolls(1, E_stm * 2);
                                                if (E_dodgechance > E_stm * 1.5)
                                                {
                                                    Player_DEALDMG = 0;
                                                }


                                                Console.WriteLine("\nYou cast your magic at the " + E_n + "'s torso");
                                                if (Player_DEALDMG < 0)
                                                {
                                                    Player_DEALDMG = 0;
                                                }
                                                else if (Player_DEALDMG == 0)
                                                {
                                                    Console.WriteLine("\nyou missed!");
                                                }
                                                else
                                                {
                                                    if (PowerUP == 2)//check for if the powerup move is active and if so run differnt calculations.
                                                    {
                                                        Total_DMG = Player_DEALDMG * 2;
                                                        Total_DMG = Math.Ceiling(Total_DMG);
                                                        Dialouge.speech("\nYour empowered magic stabs " + E_n + " fiercly for " + Total_DMG);
                                                    }
                                                    else
                                                    {
                                                        Total_DMG = Player_DEALDMG;
                                                        Total_DMG = Math.Round(Total_DMG);
                                                        Dialouge.speech("\nYour magic pierces " + E_n + " for " + Total_DMG);
                                                    }

                                                }
                                                E_HP -= Total_DMG;

                                                inspellmenu = false;
                                                turnEnded = true;

                                            }
                                            else
                                            {
                                                Dialouge.speech("\nyou dont have enough MP to use this spell it costs 15 you have " + player.CurrentMP);
                                                Console.ReadKey();
                                                turnEnded = false;
                                            }
                                            break;
                                        }
                                    case 1:
                                        {
                                            if (player.CurrentMP >= 20)//cost of spell
                                            {
                                                player.CurrentMP -= 20;
                                                int Heal_AMOUNT = 3 + Random_Rolls.RandRolls(10, 15);
                                                Dialouge.speech("You believe that your body is healing the dopamine filling your mind patching your wounds,\n you heal " + Heal_AMOUNT);
                                                player.CurrentHP += Heal_AMOUNT;
                                                if (player.CurrentHP > 50)
                                                {
                                                    player.CurrentHP = 50;
                                                }
                                                inspellmenu = false;
                                                turnEnded = true;
                                                break;

                                            }



                                            else
                                            {
                                                Dialouge.speech("\nyou dont have enough MP to use this spell it costs 20 you have " + player.CurrentMP);
                                                Console.ReadKey();
                                                turnEnded = false;
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            if (player.CurrentMP >= 10)
                                            {
                                                player.CurrentMP = player.CurrentMP - 10;
                                                Dialouge.speech("\nYou manifest happy thoughts and power your dagger you will deal 2x damage for the next turn!");
                                                Cturnsremaining = 3;
                                                inspellmenu = false;
                                                turnEnded = true;
                                                break;
                                            }
                                            else
                                            {
                                                Dialouge.speech("\nyou dont have enough MP to use this spell it costs 10 you have " + player.CurrentMP);
                                                Console.ReadKey();
                                                turnEnded = false;
                                                break;
                                            }
                                        }
                                    case 3:
                                        {
                                            inspellmenu = false;
                                            break;
                                        }

                                }
                        }
                        break;
                    }
                            

                            
                        

                case 2:
                    {
                        //regen MP and take less dmg
                        Dialouge.speech("you brace yourself for an attack, you regain 10 mp and take 1.5x less damage this turn!");
                        player.CurrentMP = player.CurrentMP + 10;//cost of move
                        Defended = true;
                        if (player.CurrentMP > player.MAXMP)
                        {
                            player.CurrentMP = player.MAXMP;
                        }
                        turnEnded = true;
                        break;
                    }
                case 3:
                    {
                        //skedadle or run away
                        if (random == true)
                        {
                            int RUN_chance = Random_Rolls.RandRolls(1, 4);// rolls a 50/50 to see if you manage to get away
                            if (RUN_chance > 2)
                            {
                                Dialouge.speech("you manage to sprint away from the enemy");
                                Battleconditons = false;
                                Dialouge.speech("you get no rewards! coward.");
                            }
                            else
                            {
                                Dialouge.speech("as you try and run the enemy notices the attempt and.");
                                turnEnded = true;
                            }
                        }
                        break;
                    }
                default:
                    {
                        Dialouge.speech("\nthats not an avaliable action");
                        break;
                    }
            }
                    
                    
            if (E_HP <= 0)//enemy dead check before attack.n
                {
                  Dialouge.speech("\nyou have defeated the enemy");
                Battleconditons = false;
                return true; //wow great job
                }
            
            if (turnEnded && Battleconditons)//enemy attack
            {
                double ENEMY_DMGDEAL = Math.Ceiling((double)Random_Rolls.RandRolls(1, E_dmgroll));
                int CritCHANCE = Random_Rolls.RandRolls(0, E_luck * 2);
                if (CritCHANCE > E_luck * 1.5)
                {
                    ENEMY_DMGDEAL = ENEMY_DMGDEAL * 1.5;
                    ENEMY_DMGDEAL = Math.Ceiling(ENEMY_DMGDEAL);
                }
                else
                {

                }
                int P_dodgechance = Random_Rolls.RandRolls(0, player.stamina * 2);
                if (P_dodgechance > player.stamina * 1.5)
                {
                    ENEMY_DMGDEAL = 0;
                }
                if (Defended)
                {
                    ENEMY_DMGDEAL = Math.Floor(ENEMY_DMGDEAL / 1.5);
                }

                Dialouge.speech("\n" + E_n + " swings at you\n");
                if (ENEMY_DMGDEAL < 0)
                {
                    ENEMY_DMGDEAL = 0;
                }
                else if (ENEMY_DMGDEAL == 0)
                {
                    Dialouge.speech("\n" + E_n + " missed!\n");
                }
                else
                {
                    Dialouge.speech("\nYou are struck for " + ENEMY_DMGDEAL + " damage\n");
                }
                player.CurrentHP -= ENEMY_DMGDEAL;
                TURNCOUNT += 1;
                if (Cturnsremaining > 0)
                {
                    Cturnsremaining -= 1;
                }
                Console.WriteLine("\npress any key to continue");
                Console.ReadKey();
                Console.Clear();

            if (player.CurrentHP <= 0)//player loses
                {
                    Dialouge.speech("\nyou LOST!");
                    Battleconditons = false;
                    return false; //wow terrible job
                }
            }


        }
        return false;
    }

 }
