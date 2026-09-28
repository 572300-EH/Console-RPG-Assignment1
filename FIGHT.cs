using System;
using System.Numerics;

class Fighting_thing
{
    static void Guard_encounter()
    {
        Console.WriteLine("as you walk towards the guard two hands reach up from behind his helmet and lift up many eyes a spear is raised at you as you prepare to fight.");
        Console.ReadKey();

    }

    public static void Combat(Robbie_player player, bool random, string name, int stamina, int health, int luck, int max_dmgroll)
    {
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
        while (E_HP > 0)
        {
            double PowerUP = 0;
            double damagebuff = 0;
            double Total_DMG = 0;
            Console.WriteLine("Remember only type the letters in the brackets to do that choice");
            Console.WriteLine("*******************");
            Console.WriteLine("|(a)ttack (s)pells|");
            Console.WriteLine("|(d)efend (r)un   |");
            Console.WriteLine("*******************");
            Dialouge.speech("\nMemory Power:" + player.CurrentMP + "Health Points" + player.CurrentHP);
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
                            Player_DEALDMG = Player_DEALDMG * 1.5 ;
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


                        Dialouge.speech("\nYou slash at the " + E_n);
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
                            Dialouge.speech("\nyou struck " + E_n + "for " + Player_DEALDMG);
                            
                        }
                        if (PowerUP == 2)
                        {
                            damagebuff = Player_DEALDMG * 2;
                            damagebuff = Math.Ceiling(damagebuff);
                        }
                        Total_DMG = Player_DEALDMG + damagebuff;
                        E_HP = E_HP - Total_DMG;
                        //you get beat up time
                        double ENEMY_DMGDEAL = Random_Rolls.RandRolls(1, E_dmgroll);
                        ENEMY_DMGDEAL = Math.Ceiling(ENEMY_DMGDEAL);
                        CRITCHANCE = Random_Rolls.RandRolls(0, E_luck * 2);
                        if (CRITCHANCE > E_luck * 1.5)
                        {
                            ENEMY_DMGDEAL = ENEMY_DMGDEAL * 1.5;
                            ENEMY_DMGDEAL = Math.Ceiling(ENEMY_DMGDEAL);
                        }
                        else
                        {

                        }
                        int P_dodgechance = Random_Rolls.RandRolls(0,player.stamina * 2);
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
                            Dialouge.speech("\nMemory Power:" + player.CurrentMP + "Health Points" + player.CurrentHP);
                            string Spell_input = Console.ReadLine();
                            Spell_input = Player_input.ToLower();

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
                                        Console.WriteLine("\nyour magic speared " + E_n + "for " + Player_DEALDMG);

                                    }
                                    if (PowerUP == 2)
                                    {
                                        damagebuff = Player_DEALDMG * 2;
                                        damagebuff = Math.Ceiling(damagebuff);
                                    }
                                    Total_DMG = Player_DEALDMG + damagebuff;
                                    E_HP = E_HP - Total_DMG;
                                    //you get beat up time

                                    double ENEMY_DMGDEAL = Random_Rolls.RandRolls(1, E_dmgroll);
                                    ENEMY_DMGDEAL = Math.Ceiling(ENEMY_DMGDEAL);
                                    CRITCHANCE = Random_Rolls.RandRolls(1, E_luck * 2);
                                    if (CRITCHANCE > E_luck * 1.5)
                                    {
                                        ENEMY_DMGDEAL = ENEMY_DMGDEAL * 1.5;
                                        ENEMY_DMGDEAL = Math.Ceiling(ENEMY_DMGDEAL);
                                    }
                                    else
                                    {

                                    }
                                    int P_dodgechance = Random_Rolls.RandRolls(1, player.stamina * 2);
                                    if (P_dodgechance > player.stamina * 1.5)
                                    {
                                        ENEMY_DMGDEAL = 0;
                                    }


                                    Console.WriteLine(E_n + "swings at you\n");
                                    if (ENEMY_DMGDEAL < 0)
                                    {
                                        ENEMY_DMGDEAL = 0;
                                    }
                                    else if (ENEMY_DMGDEAL == 0)
                                    {
                                        Console.WriteLine(E_n + "missed!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nYou are struck for " + ENEMY_DMGDEAL + " damage");
                                    }
                                    player.CurrentHP = player.CurrentHP - ENEMY_DMGDEAL;

                                    inspellmenu = false;
                                }
                                else
                                {

                                }
                            }
                            else if (Spell_input == "a")
                            {
                                if (player.CurrentMP >= 20)
                                {
                                    player.CurrentMP = player.CurrentMP - 20;
                                    int Heal_AMOUNT = 3 + Random_Rolls.RandRolls(0, 15);
                                    player.CurrentHP = player.CurrentHP + Heal_AMOUNT;
                                    if (player.CurrentHP > 50)
                                    {
                                        player.CurrentHP = 50;
                                    }
                                    inspellmenu = false;

                                }
                                else if (Spell_input == "c")
                                {
                                    if (player.CurrentMP >= 10)
                                    {
                                        player.CurrentMP = player.CurrentMP - 10;
                                        PowerUP = 2;
                                        inspellmenu = false;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("invalid input");
                                }
                            }
                            
                        }
                        break;
                    }
                    
                case "d":
                    {
                        //regen MP and take less dmg
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
