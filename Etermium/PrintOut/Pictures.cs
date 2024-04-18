﻿using System;
using System.Threading;

namespace Etermium.PrintOut;

/// <summary>
/// Class responsible for printing out ASCII art representing various creatures.
/// </summary>
public static class Pictures
{
    /// <summary>
    /// Prints out a picture of a bat.
    /// </summary>
    public static void BatPicture()
    {
        Console.WriteLine("\n\n		     ,*-~\"`^\"*u_                                _u*\"^`\"~-*,\r\n"
                          + "		  p!^       /  jPw                            w9j \\        ^!p\r\n"
                          + "		w^.._      /      \"\\_                      _/\"     \\        _.^w\r\n"
                          + "		     *_   /          \\_      _    _      _/         \\     _* \r\n"
                          + "		       q /           / \\q   ( `--` )   p/ \\          \\   p\r\n"
                          + "		       jj5****._    /    ^\\_) o  o (_/^    \\    _.****6jj\r\n"
                          + "		                *_ /      \"==) ;; (==\"      \\ _*\r\n"
                          + "		                 `/.w***,   /(    )\\   ,***w.\\\"\r\n"
                          + "		                  ^      ^c/ )    ( \\c^      ^\r\n"
                          + "		                          'V')_)(_('V'\r\n" +
                          "		                              `` ``");
    }

    /// <summary>
    /// Prints out a picture of a rat.
    /// </summary>
    public static void RatPicture()
    {
        Console.WriteLine("\n\n		                    _,,......_\r\n"
                          + "		                 ,-'          `'--.\r\n" +
                          "		              ,-'  _              '-.\r\n"
                          + "		     (`.    ,'   ,  `-.              `.\r\n"
                          + "		      \\ \\  -    / )    \\               \\\r\n"
                          + "		       `\\`-^^^, )/      |     /         :\r\n"
                          + "		         )^ ^ ^V/            /          '.\r\n"
                          + "		         |      )            |           `.\r\n"
                          + "		         9   9 /,--,\\    |._:`         .._`.\r\n"
                          + "		         |    /   /  `.  \\    `.      (   `.`.\r\n"
                          + "		         |   / \\  \\    \\  \\     `--\\   )    `.`.___\r\n"
                          + "		        .;;./  '   )   '   )       ///'       `-\"'\r\n"
                          + "		        `--'   7//\\    ///\\");
    }

    /// <summary>
    /// Prints out a picture of a wolf.
    /// </summary>
    public static void WolfPicture()
    {
        Console.WriteLine("\n	     	      	                                      __\r\n"
                          + "				                            .d$$b\r\n"
                          + "				                          .' TO$;\\\r\n"
                          + "				                         /  : TP._;\r\n"
                          + "				                        / _.;  :Tb|\r\n"
                          + "				                       /   /   ;j$j\r\n"
                          + "				                   _.-\"       d$$$$\r\n"
                          + "				                 .' ..       d$$$$;\r\n"
                          + "				                /  /P'      d$$$$P. |\\\r\n"
                          + "				               /   \"      .d$$$P' |\\^\"l\r\n"
                          + "				             .'           `T$P^\"\"\"\"\"  :\r\n"
                          + "				         ._.'      _.'                ;\r\n"
                          + "				      `-.-\".-'-' ._.       _.-\"    .-\"\r\n"
                          + "				    `.-\" _____  ._              .-\"\r\n"
                          + "				   -(.g$$$$$$$b.              .'\r\n"
                          + "				     \"\"^^T$$$P^)            .(:\r\n"
                          + "				       _/  -\"  /.'         /:/;\r\n"
                          + "				    ._.'-'`-'  \")/         /;/;\r\n"
                          + "				 `-.-\"..--\"\"   \" /         /  ;\r\n"
                          + "				.-\" ..--\"\"        -'          :\r\n"
                          + "				..--\"\"--.-\"         (\\      .-(\\\r\n"
                          + "				  ..--\"\"              `-\\(\\/;`\r\n"
                          + "				    _.                      :\r\n" + "				                            ;`-\r\n"
                          + "				                           :\\\r\n"
                          + "				                           ;  \n\n ");
    }

    /// <summary>
    /// Prints out a picture of a dragon.
    /// </summary>
    public static void DragonPicture()
    {
        Console.WriteLine(
            "\n\n                                                                 /===-_---~~~~~~~~~------____\r\n"
            + "		                                                |===-~___                _,-'\r\n"
            + "		                 -==\\\\                         `//~\\\\   ~~~~`---.___.-~~\r\n"
            + "		             ______-==|                         | |  \\\\           _-~`\r\n"
            + "		       __--~~~  ,-/-==\\\\                        | |   `\\        ,'\r\n"
            + "		    _-~       /'    |  \\\\                      / /      \\      /\r\n"
            + "		  .'        /       |   \\\\                   /' /        \\   /'\r\n"
            + "		 /  ____  /         |    \\`\\.__/-~~ ~ \\ _ _/'  /          \\/'\r\n"
            + "		/-'~    ~~~~~---__  |     ~-/~         ( )   /'        _--~`\r\n"
            + "		                  \\_|      /        _)   ;  ),   __--~~\r\n"
            + "		                    '~~--_/      _-~/-  / \\   '-~ \\\r\n"
            + "		                   {\\__--_/}    / \\\\_>- )<__\\      \\\r\n"
            + "		                   /'   (_/  _-~  | |__>--<__|      |\r\n"
            + "		                  |0  0 _/) )-~     | |__>--<__|     |\r\n"
            + "		                  / /~ ,_/       / /__>---<__/      |\r\n"
            + "		                 o o _//        /-~_>---<__-~      /\r\n"
            + "		                 (^(~          /~_>---<__-      _-~\r\n"
            + "		                ,/|           /__>--<__/     _-~\r\n"
            + "		             ,//('(          |__>--<__|     /                  .----_\r\n"
            + "		            ( ( '))          |__>--<__|    |                 /' _---_~\\\r\n"
            + "		         `-)) )) (           |__>--<__|    |               /'  /     ~\\`\\\r\n"
            + "		        ,/,'//( (             \\__>--<__\\    \\            /'  //        ||\r\n"
            + "		      ,( ( ((, ))              ~-__>--<_~-_  ~--____---~' _/'/        /'\r\n"
            + "		    `~/  )` ) ,/|                 ~-_~>--<_/-__       __-~ _/\r\n"
            + "		  ._-~//( )/ )) `                    ~~-'_/_/ /~~~~~~~__--~\r\n"
            + "		   ;'( ')/ ,)(                              ~~~~~~~~~~\r\n" + "		  ' ') '( (/\r\n"
            + "		    '   '  `");
    }
}