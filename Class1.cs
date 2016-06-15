using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace ConsoleApplication1
{
    class Class1
    {
        delegate int mydel(int intMyNum);

        static void Main(string[] args)
        {
            //assign lambada expression to a delegate

            //mydel mydelegate = myexp => myexp / 10;

            //int inrRes = mydelegate(110);

            //Console.WriteLine("Output {0}", inrRes);
            b obj = new b();
            string m="";
            obj.IsPasswordValid("ICMDEV", "1233joseph", out m);


        }
    }
    class b
    {
        public bool IsPasswordValid(string userID, string password, out string errorMessage)
        {
            string normalPWDRule = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?!.*(.)\1\1)[\W\w]{8,16}$";
            string seqRule = "012|123|234|345|456|567|678|789|" + userID.ToLower().Trim();
            string monthRule = "january|february|march|april|may|june|july|august|september|october|november|december";

            //Added by ABHIJIT(3/20/2015) to FIX INADEQUATE PASSWORD POLICIES issue : 500 most used words should not be a password
            string worstPasswords1 = "123456|porsche|firebird|prince|rosebud|password|guitar|butter|beach|jaguar|12345678|chelsea|united|amateur|great|1234|black|turtle|7777777|cool|pussy|diamond|steelers|muffin|cooper|12345|nascar|tiffany|redsox|1313|dragon|jackson|zxcvbn|star|scorpio|qwerty|cameron|tomcat|testing|mountain|696969|654321|golf|shannon|madison|mustang|computer|bond007|murphy|987654|letmein|amanda|bear|frank|brazil|michael|money|gateway|eagle1|naked|football|phoenix|gators|11111|squirt|shadow|mickey|angel|mother|stars|monkey|bailey|junior|nathan";
            string worstPasswords2 = "apple|abc123|knight|thx1138|raiders|alexis|pass|iceman|porno|steve|aaaa|fuckme|tigers|badboy|forever|bonnie|6969|purple|debbie|angela|peaches|jordan|andrea|spider|viper|jasmine|harley|horny|melissa|ou812|kevin|ranger|dakota|booger|jake|matt|iwantu|aaaaaa|1212|lovers|qwertyui|jennifer|player|flyers|suckit|danielle|baseball|wizard|tiger|hannah|lauren|master|xxxxxxxx|doctor|dave|japan|hunter|sunshine|fish|gregory|beaver|fuck|morgan|porn|buddy|4321|2000|starwars|matrix|whatever|4128|test|boomer|teens|young|runner|batman|cowboys";
            string worstPasswords3 = "scooby|nicholas|swimming|trustno1|edward|jason|lucky|dolphin|thomas|charles|walter|helpme|gordon|tigger|girls|cumshot|jackie|casper|robert|booboo|boston|monica|stupid|access|coffee|braves|midnight|shit|love|xxxxxx|yankee|college|saturn|buster|bulldog|lover|baby|gemini|1234567|ncc1701|barney|cunt|apples|soccer|rabbit|victor|brian|august|hockey|peanut|tucker|mark|3333|killer|john|princess|startrek|canada|george|johnny|mercedes|sierra|blazer|sexy|gandalf|5150|leather|cumming|andrew|spanky|doggie|232323|hunting|charlie|winter";
            string worstPasswords4 ="zzzzzz|4444|kitty|superman|brandy|gunner|beavis|rainbow|asshole|compaq|horney|bigcock|112233|fuckyou|carlos|bubba|happy|arthur|dallas|tennis|2112|sophie|cream|jessica|james|fred|ladies|calvin|panties|mike|johnson|naughty|shaved|pepper|brandon|xxxxx|giants|surfer|1111|fender|tits|booty|samson|austin|anthony|member|blonde|kelly|william|blowme|boobs|fucked|paul|daniel|ferrari|donald|golden|mine|golfer|cookie|bigdaddy|king|summer|chicken|bronco|fire|racing|heather|maverick|penis|sandra|5555|hammer|chicago|voyager|pookie|eagle";
            string worstPasswords5 = "yankees|joseph|rangers|packers|henta|joshua|diablo|birdie|einstein|newyork|maggie|sexsex|trouble|dolphins|little|biteme|hardcore|white|redwings|enter|666666|topgun|chevy|smith|ashley|willie|bigtits|winston|sticky|thunder|welcome|bitches|warrior|cocacola|cowboy|chris|green|sammy|animal|silver|panther|super|slut|broncos|richard|yamaha|qazwsx|8675309|private|fucker|justin|magic|zxcvbnm|skippy|orange|banana|lakers|nipples|marvin|merlin|driver|rachel|power|blondes|michelle|marine|slayer|victoria|enjoy|corvette|angels|scott|asdfgh";
            string worstPasswords6 = "girl|bigdog|fishing|2222|vagina|apollo|cheese|david|asdf|toyota|parker|matthew|maddog|video|travis|qwert|121212|hooters|london|hotdog|time|patrick|wilson|7777|paris|sydney|martin|butthead|marlboro|rock|women|freedom|dennis|srinivas|xxxx|voodoo|ginger|fucking|internet|extreme|magnum|blowjob|captain|action|redskins|juice|nicole|bigdick|carter|erotic|abgrtyu|sparky|chester|jasper|dirty|777777|yellow|smokey|monster|ford|dreams|camaro|xavier|teresa|freddy|maxwell|secret|steven|jeremy|arsenal|music|dick|viking|11111111|access14|rush2112";
            string worstPasswords7 = "falcon|snoopy|bill|wolf|russia|taylor|blue|crystal|nipple|scorpion|111111|eagles|peter|iloveyou|rebecca|131313|winner|pussies|alex|tester|123123|samantha|cock|florida|mistress|bitch|house|beer|eric|phantom|hello|miller|rocket|legend|billy|scooter|flower|theman|movie|6666|please|jack|oliver|success|albert";

            Regex passwordCheck = new Regex(normalPWDRule);
            Regex seqCheck = new Regex(seqRule);
            Regex monthCheck = new Regex(monthRule);
            Regex CommonWordsCheck1 = new Regex(worstPasswords1);
            Regex CommonWordsCheck2 = new Regex(worstPasswords2);
            Regex CommonWordsCheck3 = new Regex(worstPasswords3);
            Regex CommonWordsCheck4 = new Regex(worstPasswords4);
            Regex CommonWordsCheck5 = new Regex(worstPasswords5);
            Regex CommonWordsCheck6 = new Regex(worstPasswords6);
            Regex CommonWordsCheck7 = new Regex(worstPasswords7);

            errorMessage = "Invalid password, please ensure that your password conform to the rules below";

            //Added by ABHIJIT(3/20/2015) to FIX INADEQUATE PASSWORD POLICIES issue : 500 most used words should not be a password
            if (CommonWordsCheck1.IsMatch(password.ToLower(), 0))
            {
                return false;
            }
            if (CommonWordsCheck2.IsMatch(password.ToLower(), 0))
            {
                return false;
            }
            if (CommonWordsCheck3.IsMatch(password.ToLower(), 0))
            {
                return false;
            }
             if (CommonWordsCheck4.IsMatch(password.ToLower(), 0))
             {
                 return false;
             }
             if (CommonWordsCheck5.IsMatch(password.ToLower(), 0))
             {
                 return false;
             }
             if (CommonWordsCheck6.IsMatch(password.ToLower(), 0))
             {
                 return false;
             }
             if (CommonWordsCheck7.IsMatch(password.ToLower(), 0))
             {
                 return false;
             }
            return true;
        }
    }

        
    
}
