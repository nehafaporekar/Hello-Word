﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace ConsoleApplication1
{
    class Program
    {
        //static void Main(string[] args)
        //{

        //    string psw = "";
        //    string msg;
        //    string uid = "UAT2";
        //    Console.WriteLine("Please enter the password \n");
        //    psw= Console.ReadLine();
        //    Program p = new Program();
        //    p.IsPasswordValid(psw,out msg);
        //    Console.WriteLine("\n You entered: " + psw);
        //    Console.WriteLine("\n Error Message: " + msg);
        //    Console.Read();
        //}

        
        public void IsPasswordValid(string password, out string errorMessage)
        {
            string normalPWDRule = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?!.*(.)\1\1)[\W\w]{8,16}$";
            string seqRule = "012|123|234|345|456|567|678|789|" + "UAT2".ToLower().Trim();
            string monthRule = "january|february|march|april|may|june|july|august|september|october|november|december";
            string worstPasswords = "123456|porsche|firebird|prince|rosebud|password|guitar|butter|beach|jaguar|12345678|chelsea|united|amateur|great|1234" +
                                    "|black|turtle|7777777|cool|pussy|diamond|steelers|muffin|cooper|12345|nascar|tiffany|redsox|1313" +
                                    "|dragon|jackson|zxcvbn|star|scorpio|qwerty|cameron|tomcat|testing|mountain|696969|654321|golf|shannon|madison" +
                                    "|mustang|computer|bond007|murphy|987654|letmein|amanda|bear|frank|brazil" +
                                    "|michael|money|gateway|eagle1|naked|football|phoenix|gators|11111|squirt|shadow|mickey|angel|mother|stars" +
                                    "|monkey|bailey|junior|nathan|apple|abc123|knight|thx1138|raiders|alexis|pass|iceman|porno|steve|aaaa" +
                                    "|fuckme|tigers|badboy|forever|bonnie|6969|purple|debbie|angela|peaches|jordan|andrea|spider|viper|jasmine|harley|horny|melissa|ou812|kevin|ranger|dakota|booger|jake|matt" +
                                    "|iwantu|aaaaaa|1212|lovers|qwertyui|jennifer|player|flyers|suckit|danielle" +
                                    "|baseball|wizard|tiger|hannah|lauren|master|xxxxxxxx|doctor|dave|japan|hunter|sunshine|fish|gregory|beaver" +
                                    "|fuck|morgan|porn|buddy|4321|2000|starwars|matrix|whatever|4128|test|boomer|teens|young|runner" +
                                    "|batman|cowboys|scooby|nicholas|swimming|trustno1|edward|jason|lucky|dolphin|thomas|charles|walter|helpme|gordon" +
                                    "|tigger|girls|cumshot|jackie|casper|robert|booboo|boston|monica|stupid|access|coffee|braves|midnight|shit|love|xxxxxx|yankee|college|saturn" +
                                    "|buster|bulldog|lover|baby|gemini|1234567|ncc1701|barney|cunt|apples|soccer|rabbit|victor|brian|august" +
                                    "|hockey|peanut|tucker|mark|3333|killer|john|princess|startrek|canada|george|johnny|mercedes|sierra|blazer|sexy|gandalf|5150|leather|cumming" +
                                    "|andrew|spanky|doggie|232323|hunting|charlie|winter|zzzzzz|4444|kitty|superman|brandy|gunner|beavis|rainbow" +
                                    "|asshole|compaq|horney|bigcock|112233|fuckyou|carlos|bubba|happy|arthur|dallas|tennis|2112|sophie|cream|jessica|james|fred|ladies|calvin" +
                                    "|panties|mike|johnson|naughty|shaved|pepper|brandon|xxxxx|giants|surfer|1111|fender|tits|booty|samson|austin|anthony|member|blonde|kelly" +
                                    "|william|blowme|boobs|fucked|paul|daniel|ferrari|donald|golden|mine|golfer|cookie|bigdaddy|0|king|summer|chicken|bronco|fire|racing" +
                                    "|heather|maverick|penis|sandra|5555|hammer|chicago|voyager|pookie|eagle|yankees|joseph|rangers|packers|henta" +
                                    "|joshua|diablo|birdie|einstein|newyork|maggie|sexsex|trouble|dolphins|little|biteme|hardcore|white|0|redwings" +
                                    "|enter|666666|topgun|chevy|smith|ashley|willie|bigtits|winston|sticky|thunder|welcome|bitches|warrior|cocacola|cowboy|chris|green|sammy|animal" +
                                    "|silver|panther|super|slut|broncos|richard|yamaha|qazwsx|8675309|private|fucker|justin|magic|zxcvbnm|skippy|orange|banana|lakers|nipples|marvin" +
                                    "|merlin|driver|rachel|power|blondes|michelle|marine|slayer|victoria|enjoy|corvette|angels|scott|asdfgh|girl|bigdog|fishing|2222|vagina|apollo" +
                                    "|cheese|david|asdf|toyota|parker|matthew|maddog|video|travis|qwert|121212|hooters|london|hotdog|time|patrick|wilson|7777|paris|sydney" +
                                    "|martin|butthead|marlboro|rock|women|freedom|dennis|srinivas|xxxx|voodoo|ginger|fucking|internet|extreme|magnum|blowjob|captain|action	redskins|juice" +
                                    "|nicole|bigdick|carter|erotic|abgrtyu|sparky|chester|jasper|dirty|777777|yellow|smokey|monster|ford|dreams|camaro|xavier|teresa|freddy|maxwell" +
                                    "|secret|steven|jeremy|arsenal|music|dick|viking|11111111|access14|rush2112|falcon|snoopy|bill|wolf|russia|taylor|blue|crystal|nipple|scorpion" +
                                    "|111111|eagles|peter|iloveyou|rebecca|131313|winner|pussies|alex|tester|123123|samantha|cock|florida|mistress|bitch|house|beer|eric|phantom" +
                                    "|hello|miller|rocket|legend|billy|scooter|flower|theman|movie|6666|please|jack|oliver|success|albert";
            Regex passwordCheck = new Regex(normalPWDRule);
            Regex seqCheck = new Regex(seqRule);
            Regex monthCheck = new Regex(monthRule);
            Regex CommonWordsCheck = new Regex(worstPasswords);

             errorMessage = "Invalid password, please ensure that your password conform to the rules below";

            //Added by Abhijit to FIX INADEQUATE PASSWORD POLICIES issue : 500 most used words should not be a password
             if (CommonWordsCheck.IsMatch(password.ToLower()))
            {
                 errorMessage = "1Normal Pwd rule failed";
               // return false;
            }

            //Added by Abhijit to FIX INADEQUATE PASSWORD POLICIES issue : ABSA keyword should not include in Password
            if (password.IndexOf("ABSA", StringComparison.OrdinalIgnoreCase) > 0)
            {
                 errorMessage = "2Normal Pwd rule failed";
               // return false;
            }

            if (!passwordCheck.IsMatch(password))
            {
                 errorMessage = "Normal Pwd rule failed";
              //  return false;
            }
            else if (passwordCheck.IsMatch(password) && seqCheck.IsMatch(password.ToLower()))
            {
                 errorMessage = "Sequence check 012|123|234... rule failed";
              //  return false;
            }
            else if (passwordCheck.IsMatch(password) && monthCheck.IsMatch(password.ToLower()))
            {
                 errorMessage = "Month Check rule failed";
            //    return false;
            }
            else if (passwordCheck.IsMatch(password) && seqCheck.IsMatch(password) && monthCheck.IsMatch(password.ToLower()))
            {
                errorMessage = "Normal Pwd rule failed";
                //     return false;
            }
            else
            { errorMessage = "Valid Password"; }
            //return true;
        }

    }
}
