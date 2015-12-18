using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkExp1
{
    public class user 
    {
        public user(string p_user, string p_password)
        {
            username = p_user;
            password = p_password;
        }
        public string username;
        public string password;

        public virtual string userPrompt()
        {
            return "Deafult User Prompt";
        }
    }

    public class admin : user
    {
        //string username;
        public admin(string p_adminUser, string p_adminPass) : base(p_adminUser, p_adminPass)
        {  
        }

        public override string userPrompt()
        {
            selfDestruct();
            return "I AM A ADMIN";
        }

        public void selfDestruct()
        {
            while (true) 
            {
                Console.WriteLine("Do you want to self destruct? Please enter y/n");
                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    Console.WriteLine("Shutting down");
                    Environment.Exit(0);
                }
                if (answer == "n")
                {
                    break;
                }
                continue;
            }

        }

    }

    public class guest : user
    {
        public guest(string p_guestUser, string p_guestPass) : base(p_guestUser, p_guestPass)
        {

        }
        public override string userPrompt()
        {
            return "I AM A GUEST";
        }
    }

    public class visitor : user
    {
        public visitor(string p_visitorUser, string p_visitorPass) : base(p_visitorUser, p_visitorPass)
        {

        }
        public override string userPrompt()
        {
            return "I AM A VISITOR";
        }
    }

    public class Fuel
    {
        public enum ReactionOuput
        {
            WEEABOO,
            DIPSHITTIUM,
            ASIANOMIUM,
            FAIL
        }

        public string fuelType;
        public string fuelInfo;
        public Fuel(string p_fuelType, string p_fuelInfo)
        {
            fuelType = p_fuelType;
            fuelInfo = p_fuelInfo;
        }
        public static ReactionOuput operator +(Fuel f, Reactant r)
        {
            if (f.fuelType == "Jamesonium (1)" && r.reactantType == "Antonium (3)")
            {
                return ReactionOuput.WEEABOO;
            }
            if (f.fuelType == "Vinceomium (3)" && r.reactantType == "Stephenomium (2)")
            {
                return ReactionOuput.ASIANOMIUM;
            }
            if (f.fuelType == "Davidium (2)" && r.reactantType == "Liaminium (1)")
            {
                return ReactionOuput.DIPSHITTIUM;
            }
            return ReactionOuput.FAIL;

        }
        public static ReactionOuput operator +(Reactant r, Fuel f)
        {
            return f + r;
        }
    }

    public class Jamesonium : Fuel 
    {
        public Jamesonium(string p_james, string p_jamesinfo) : base(p_james, p_jamesinfo) 
        {
            //james = p_james;
            //jamesinfo = p_jamesinfo;
        }
        //public string james;
        //public string jamesinfo;
    }

    public class Davidium  : Fuel
    {
        public Davidium(string p_david, string p_davidinfo)
            : base(p_david, p_davidinfo)
        {
            //david = p_david;
            //davidinfo = p_davidinfo;
        }
        //public string david;
        //public string davidinfo;
    }

    public class Vinceomium  : Fuel
    {
        public Vinceomium(string p_vince, string p_vinceinfo)
            : base(p_vince, p_vinceinfo)
        {
            //vince = p_vince;
            //vinceinfo = p_vinceinfo;
        }
        //public string vince;
        //public string vinceinfo;
    }

    public class Reactant
    {
        public string reactantType;
        public string reactantInfo;
        public Reactant(string p_reactantType, string p_reactantInfo)
        {
            reactantType = p_reactantType;
            reactantInfo = p_reactantInfo;
        }
    }

    class Program
    {
        static string react;
        static Reactant[] reactantDatabase;
        static Fuel[] fuelDatabase;
        //static admin Vince;
        static user[] userDatabase;

        static void Main(string[] args)
        {
            //Vince = new admin("vince","yes");

            userDatabase = new user[]{
                new admin("vince", "yes"),
                new guest("stephen", "no"),
                new visitor("joe", "david")
            };
            
            while (true)
            {
                Console.WriteLine("Please enter your username");
                string un = Console.ReadLine();
                Console.WriteLine("Now please enter your password");
                string pass = Console.ReadLine();

                int databaseLength = userDatabase.Length - 1;
                
                //authentication(un, pass, databaseLength);
                if (authentication(un, pass, databaseLength)) 
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
       
            Console.WriteLine("Welcome to DJJ Extreme Fission Reactor Ltd.");
            fuelDatabase = new Fuel[3]{
                new Jamesonium("Jamesonium (1)", "Description: This is a very weird fuel type."),
                new Davidium ("Davidium (2)", "Description: This is a very rude fuel type."),
                new Vinceomium ("Vinceomium (3)", "Description: This is a fuel type")
            };
            reactantDatabase = new Reactant[3]{
                new Reactant("Liaminium (1)", "Description: This reactant is the best around."),
                new Reactant("Stephenomium (2)", "Description: This reactant is okay."),
                new Reactant("Antonium (3)", "Description: This reactant is potato.")
            };

            while (true)
            {
                Console.WriteLine("What fuel would you like to use?");
                Console.WriteLine("{0} or {1} or {2}", fuelDatabase[0].fuelType, fuelDatabase[1].fuelType, fuelDatabase[2].fuelType);

                int choice = 0;
                Fuel fuelchoice;
                try
                {
                    choice = int.Parse(Console.ReadLine()) - 1;
                    fuelchoice = fuelDatabase[choice];
                }
                catch
                {
                    Console.WriteLine("WRONG INPUT RESTARTING");
                    continue;
                }


                //Fuel fuelchoice = fuelDatabase[choice];
                Console.WriteLine(fuelDatabase[choice].fuelInfo);
                Console.WriteLine("");
                
                Console.WriteLine("What reactant would you like to use?");
                Console.WriteLine("{0} or {1} or {2}", reactantDatabase[0].reactantType, reactantDatabase[1].reactantType, reactantDatabase[2].reactantType);
                int choice1;
                Reactant reactantchoice;
                try
                {
                    choice1 = int.Parse(Console.ReadLine()) - 1;
                    reactantchoice = reactantDatabase[choice1];
                }
                catch
                {
                    Console.WriteLine("WRONG INPUT RESTARTING");
                    continue;
                }

                //Reactant reactantchoice = reactantDatabase[ choice1];
                Console.WriteLine(reactantDatabase[choice1].reactantInfo);
                Console.WriteLine("");

                reaction( fuelchoice, reactantchoice);
            }
        }

        private static bool authentication(string un, string pass, int databaseLength)
        {
            for (int i = 0; i <= databaseLength; i++)
            {
                if (un == userDatabase[i].username && pass == userDatabase[i].password)
                {
                    Console.WriteLine("Access granted!");
                    Console.WriteLine(userDatabase[i].userPrompt());
                    return true;
                }
                else
                {
                    continue;
                }
            }
            Console.WriteLine("Acess Denied");
            return false;
        }
        /// <summary>
        /// this reacts one fuel and one reactant
        /// </summary>
        /// <param name="f is fuel"></param>
        /// <param name="r is reactant"></param>
        private static void reaction( Fuel f, Reactant r)
        {
            if (f + r == Fuel.ReactionOuput.WEEABOO)
            {
                react = "Weeaboo";
                Console.WriteLine("REACTION SUCCESS!");
                Console.WriteLine("You created: " + react);
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
                return;
            }
            if (f + r == Fuel.ReactionOuput.DIPSHITTIUM)
            {
                react = "Dipshittium";
                Console.WriteLine("REACTION SUCCESS!");
                Console.WriteLine("You created: " + react);
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
                return;
            }
            if (f + r == Fuel.ReactionOuput.ASIANOMIUM)
            {
                react = "Asianomium";
                Console.WriteLine("REACTION SUCCESS!");
                Console.WriteLine("You created: " + react);
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine("REACTION FAILED");
                Console.ReadLine();
                //return;
            }
        }
    }
}


/*switch (fuelChoice + reactantChoice)
{
    case 0 + 2:
        Console.WriteLine("You have created... Weeabooium");
        break;
    case 2 + 1:
        Console.WriteLine("You have created... Dipshittium");
        break;
    case 3 + 2:
        Console.WriteLine("You have created... Asianomium");
        break;
    default:
        Console.WriteLine("Reaction Failed!");
        break;
}
Console.ReadLine();
}*/