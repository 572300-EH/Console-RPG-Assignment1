using System;

class Fighting_thing
{
    static void Guard_encounter()
    {
        Console.WriteLine("as you walk towards the guard two hands reach up from behind his helmet and lift up many eyes a spear is raised at you as you prepare to fight.");
        Console.ReadKey();

    }

    public static void Combat(Robbie_player player, bool random, string name, int strength, int stamina, int health, int luck, int max_dmgroll)
    {
        string E_n = ""; //similar to the public class variables
        int E_str= 0;
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
            E_str = strength;
            E_stm = stamina;
            E_HP = health;
            E_luck = luck;
            E_dmgroll = max_dmgroll;

        }
        while (E_HP > 0)
        {
            Console.WriteLine("Remember only type the letters in the brackets to do that choice");
            Console.WriteLine("*******************");
            Console.WriteLine("|(a)ttack (s)pells|");
            Console.WriteLine("|(d)efend (r)un   |");
            Console.WriteLine("*******************");
            Console.WriteLine("Memory Power:" + player.CurrentMP + "Health Points" + player.CurrentHP);
            string Player_input = Console.ReadLine();
            Player_input = Player_input.ToLower();
            switch (Player_input)
            {
                case "a":
                    {
                        //beat up time
                        double Player_DEALDMG = Random_Rolls.RandRolls(1, player.PLAY_MAXDMGROLL);
                        Player_DEALDMG = Math.Ceiling(Player_DEALDMG);
                        int CRITCHANCE = Random_Rolls.RandRolls(1, player.luck * 2);
                        if (CRITCHANCE > player.luck * 1.5)
                        {
                            Player_DEALDMG = Player_DEALDMG * 1.5 ;
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


                        Console.WriteLine("You slash at the " + E_n);
                        if (Player_DEALDMG == 0)
                        {
                            Console.WriteLine("you missed!");
                        }
                        else
                        {
                            Console.WriteLine("you struck " + E_n + "for " + Player_DEALDMG);
                            
                        }
                        
                        E_HP = E_HP - Player_DEALDMG;
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
                        int P_dodgechance = Random_Rolls.RandRolls(1,player.stamina * 2);
                        if (P_dodgechance > player.stamina * 1.5)
                        {
                            ENEMY_DMGDEAL = 0;
                        }


                        Console.WriteLine(E_n + "swings at you");
                        if (ENEMY_DMGDEAL == 0)
                        {
                            Console.WriteLine(E_n + "missed!");
                        }
                        else
                        {
                            Console.WriteLine("You are struck for " + ENEMY_DMGDEAL + " damage");
                        }
                        player.CurrentHP = player.CurrentHP - ENEMY_DMGDEAL;
                        
                        break;
                    }
                case "s":
                    {
                        //magic
                        Console.Clear();
                        Console.WriteLine("Remember only type the letters in the brackets to do that choice");
                        Console.WriteLine("******************************");
                        Console.WriteLine("|(m)ystic spike (a)stral mend|");
                        Console.WriteLine("|(c)osmic surge (b)ack      | ");
                        Console.WriteLine("******************************");
                        Console.WriteLine("Memory Power:" + player.CurrentMP + "Health Points" + player.CurrentHP);
                        Player_input = Console.ReadLine();
                        Player_input = Player_input.ToLower();
                        switch (Player_input)
                        {
                            case "b":
                                {
                                    break;
                                }
                        }
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
