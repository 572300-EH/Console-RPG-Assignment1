using System;
using System.Numerics;

class Encounters
{
    public static void Guard_encounter(Robbie_player player)
    {
        Dialouge.speech("as you walk towards the guard two hands reach up from behind his helmet and lift up many eyes a spear is raised at you as you prepare to fight. (press any key)");
        Console.ReadKey();
        Console.Clear();
        Combat(player, false, "Full audience",10,30,10,6);

    }

    public static void Combat(Robbie_player player, bool random, string name, int stamina, int health, int luck, int max_dmgroll)
    {
        bool Battleconditons = true;
        string E_n = ""; //similar to the public class variables
        int E_stm= 0;
        double E_HP = 0;
        int E_luck= 0;
        int E_dmgroll= 0;
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


        }
        int TURNCOUNT = 0;
        while (Battleconditons == true || E_HP > 0) 
        {
            bool turnEnded = false;
            bool Defended = false;
            bool CACTIVE = false;
            int CTURNACTIVE = 0;
            double PowerUP = 0;
            double damagebuff = 0;
            double Total_DMG = 0;
            if (CTURNACTIVE + 3 == TURNCOUNT)
            {
                CACTIVE = false;
            }
            else
            {
                CACTIVE = true;
            }
            Console.WriteLine("Remember only type the letters in the brackets to do that choice");
            Console.WriteLine("Enemy:" + E_n);
            Console.WriteLine("Enemies damage roll is " + E_dmgroll + " the enemies HEALTH is " + E_HP);
            Console.WriteLine("*******************");
            Console.WriteLine("|(a)ttack (s)pells|");
            Console.WriteLine("|(d)efend (r)un   |");
            Console.WriteLine("*******************");
            Dialouge.speech("\nMemory Power: " + player.CurrentMP + " Health Points: " + player.CurrentHP);
            Console.WriteLine();
            string Player_input = Console.ReadLine();
            Player_input = Player_input.ToLower();
            switch (Player_input)
            {
                case "a":
                    {
                        //beat up time
                        double Player_DEALDMG = Random_Rolls.RandRolls(0, player.PLAY_MAXDMGROLL);
                        Player_DEALDMG = Math.Ceiling(Player_DEALDMG);
                        int CRITCHANCE = Random_Rolls.RandRolls(0, player.luck * 2);
                        if (CRITCHANCE > player.luck * 1.5)
                        {
                            Player_DEALDMG = Player_DEALDMG * 1.5;
                            Player_DEALDMG = Math.Ceiling(Player_DEALDMG);
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
                        }
                        else
                        {
                            Dialouge.speech("\nyou struck " + E_n + " for " + Total_DMG + " damage\n");

                        }
                        if (PowerUP == 2)
                        {
                            damagebuff = Player_DEALDMG * 2;
                            damagebuff = Math.Ceiling(damagebuff);
                        }
                        Total_DMG = Player_DEALDMG + damagebuff;
                        E_HP = E_HP - Total_DMG;
                        turnEnded = true;
                        break;
                    }
                case "s":
                    {
                        //magic
                        bool inspellmenu = true;
                        while (inspellmenu == true)
                        {
                            Console.Clear();
                            Console.WriteLine("Remember only type the letters in the brackets to do that choice");
                            Console.WriteLine("******************************");
                            Console.WriteLine("|(m)ystic spike (a)stral mend|");
                            Console.WriteLine("|(c)osmic surge (b)ack      | ");
                            Console.WriteLine("******************************");
                            Console.WriteLine("(m)costs 15 MP (a) costs 20 MP");
                            Console.WriteLine("        (c) costs 10 MP       ");
                            Dialouge.speech("\nMemory Power: " + player.CurrentMP + "\nHealth Points: " + player.CurrentHP + "\n");
                            Console.WriteLine();
                            string Spell_input = Console.ReadLine();
                            Spell_input = Spell_input.ToLower();

                            if (Spell_input == "b")
                            {
                                inspellmenu = false;
                            }
                            else if (Spell_input == "m")
                            {
                                if (player.CurrentMP >= 15)
                                {
                                    player.CurrentMP = player.CurrentMP - 15;
                                    double Player_DEALDMG = Random_Rolls.RandRolls(1, player.PLAY_MAXDMGROLL) * 1.5;
                                    Player_DEALDMG = Math.Ceiling(Player_DEALDMG);
                                    int CRITCHANCE = Random_Rolls.RandRolls(1, player.luck * 2);
                                    if (CRITCHANCE > player.luck * 1.5)
                                    {
                                        Player_DEALDMG = Player_DEALDMG * 1.5;
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
                                        Console.WriteLine("\nyour magic speared " + E_n + " for " + Player_DEALDMG + " damage\n");

                                    }
                                    if (PowerUP == 2)
                                    {
                                        damagebuff = Player_DEALDMG * 2;
                                        damagebuff = Math.Ceiling(damagebuff);
                                    }
                                    Total_DMG = Player_DEALDMG + damagebuff;
                                    Total_DMG = Math.Round(Total_DMG);
                                    E_HP -= Total_DMG;

                                    inspellmenu = false;
                                    turnEnded = true;
                                }
                                else
                                {
                                    Dialouge.speech("\nyou dont have enough MP to use this spell it costs 15 you have "+ player.CurrentMP);
                                    Console.ReadKey();
                                    turnEnded = false;
                                }
                            }
                            else if (Spell_input == "a")
                            {
                                if (player.CurrentMP >= 20)
                                {
                                    player.CurrentMP -= 20;
                                    int Heal_AMOUNT = 3 + Random_Rolls.RandRolls(0, 15);
                                    Dialouge.speech("You believe that your body is healing the dopamine filling your mind patching your wounds,\n you heal " + Heal_AMOUNT);
                                    player.CurrentHP += Heal_AMOUNT;
                                    if (player.CurrentHP > 50)
                                    {
                                        player.CurrentHP = 50;
                                    }
                                    inspellmenu = false;
                                    turnEnded = true;

                                }
                                else
                                {
                                    Dialouge.speech("\nyou dont have enough MP to use this spell it costs 20 you have " + player.CurrentMP);
                                    Console.ReadKey();
                                    turnEnded = false;
                                }
                            }
                            else if (Spell_input == "c")
                            {
                                if (player.CurrentMP >= 10)
                                {
                                    player.CurrentMP = player.CurrentMP - 10;
                                    Dialouge.speech("\nYou manifest happy thoughts and power your dagger you will deal 2x damage for three turns!");
                                    CTURNACTIVE = TURNCOUNT;
                                    if (CACTIVE == true)
                                    {
                                        PowerUP = 2;
                                    }
                                    else
                                    {
                                        PowerUP = 0;
                                    }
                                    inspellmenu = false;
                                    turnEnded = true;
                                }
                                else
                                {
                                    Dialouge.speech("\nyou dont have enough MP to use this spell it costs 10 you have " + player.CurrentMP);
                                    Console.ReadKey();
                                    turnEnded = false;
                                }
                            }

                        }
                        break;
                    }
                case "d":
                    {
                        //regen MP and take less dmg
                        Dialouge.speech("you brace yourself for an attack, you regain 10 mp and take 1.5x less damage this turn!");
                        player.CurrentMP = player.CurrentMP + 10;
                        if (player.CurrentMP > player.MAXMP)
                        {
                            player.CurrentMP = player.MAXMP;
                        }
                        double ENEMY_DMGDEAL = Random_Rolls.RandRolls(1, E_dmgroll);
                        ENEMY_DMGDEAL = Math.Ceiling(ENEMY_DMGDEAL);
                        int CRITCHANCE = Random_Rolls.RandRolls(0, E_luck * 2);
                        if (CRITCHANCE > E_luck * 1.5)
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


                        Dialouge.speech(E_n + "swings at you\n");
                        if (ENEMY_DMGDEAL < 0)
                        {
                            ENEMY_DMGDEAL = 0;
                        }
                        else if (ENEMY_DMGDEAL == 0)
                        {
                            Dialouge.speech(E_n + "missed!");
                        }
                        else
                        {
                            Dialouge.speech("\nYou are struck for " + ENEMY_DMGDEAL + " damage");
                        }
                        ENEMY_DMGDEAL = ENEMY_DMGDEAL / 1.5;
                        ENEMY_DMGDEAL = Math.Floor(ENEMY_DMGDEAL);
                        player.CurrentHP = player.CurrentHP - ENEMY_DMGDEAL;
                        turnEnded = true;
                        break;
                    }
                case "r":
                    {
                        //skedadle
                        if (random == true)
                        {
                            int RUN_chance = Random_Rolls.RandRolls(1, 4);
                            if (RUN_chance > 2)
                            {
                                Dialouge.speech("you manage to sprint away from the enemy");
                                Battleconditons = false;
                                Dialouge.speech("you get no rewards! coward.");
                            }
                            else
                            {
                                Dialouge.speech("as you try and run the enemy notices the attempt and.");
                                double ENEMY_DMGDEAL = Random_Rolls.RandRolls(1, E_dmgroll);
                                ENEMY_DMGDEAL = Math.Ceiling(ENEMY_DMGDEAL);
                                int CRITCHANCE = Random_Rolls.RandRolls(0, E_luck * 2);
                                if (CRITCHANCE > E_luck * 1.5)
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


                                Dialouge.speech(E_n + "swings at you\n");
                                if (ENEMY_DMGDEAL < 0)
                                {
                                    ENEMY_DMGDEAL = 0;
                                }
                                else if (ENEMY_DMGDEAL == 0)
                                {
                                    Dialouge.speech(E_n + "missed!");
                                }
                                else
                                {
                                    Dialouge.speech("\nYou are struck for " + ENEMY_DMGDEAL + " damage");
                                }
                                player.CurrentHP = player.CurrentHP - ENEMY_DMGDEAL;
                                turnEnded = false;
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
                    
                    
            if (E_HP <= 0)
                {
                  Dialouge.speech("\nyou have defeated the enemy");
                  break;
                }
            
            if (turnEnded && Battleconditons)
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
                Console.WriteLine("\npress any key to continue");
                Console.ReadKey();
                Console.Clear();

            if (player.CurrentHP <= 0)
                {
                    Dialouge.speech("\nyou LOST!");
                    Battleconditons = false;
                }
            }


        }

    }

 }
