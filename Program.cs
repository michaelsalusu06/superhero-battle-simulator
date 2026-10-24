using System.Diagnostics;
using System.Reflection;

List<Superhero> roster = new List<Superhero>();
string create = "yes";

while(create == "yes")
{
    Superhero newHero = new Superhero();

    Console.Write("Enter superhero name ");
    string Name = Console.ReadLine();
    newHero.name = Name;

    while(true)
    {
        try
        {
            Console.Write("Enter superhero attack points ");
            int Atk = Convert.ToInt32(Console.ReadLine());
            newHero.attack = Atk;
            break;
        }

        catch(Exception e)
        {
            Console.WriteLine("Error. Please try to input a number");
        }
    }

    while(true)
    {
        try
        {
            Console.Write("Enter superhero health points ");
            int hp = Convert.ToInt32(Console.ReadLine());
            newHero.health = hp;
            break;
        }

        catch(Exception e)
        {
            Console.WriteLine("Error. Please try to input a number");
        }
    }

    while(true)
    {
        try
        {
           Console.WriteLine("Choose a Power Category:");
           Console.WriteLine("[0] Tech  [1] Magic  [2] Cosmic  [3] Mutation");
           Console.Write("Enter the number: ");
        
           int powerChoice = Convert.ToInt32(Console.ReadLine());
           newHero.Power = (PowerCategory)powerChoice;
           break; 
        }

        catch(Exception e)
        {
           Console.WriteLine("Error. Please enter a valid number from 0 to 3.");
        }
    }

    Console.WriteLine("Enter superhero's education background ");
    Console.Write("Enter superhero's academic degree: ");
    string degree = Console.ReadLine();
    
    Console.Write("Enter superhero's university: ");
    string uni = Console.ReadLine();
    newHero.Background = new AcademicBackgrounds(degree, uni);
    
    roster.Add(newHero);
    Console.Write("Create another hero? (yes/no): ");
    create = Console.ReadLine().ToLower();
}

if(roster.Count >= 2)
{
    Superhero player1 = roster[0];
    Superhero player2 = roster[1];
    Stack<string> battleLog = new Stack<string>();
    int round = 1;

    Console.WriteLine($"\n--- BATTLE START: {player1.name} VS {player2.name} ---");

    while(player1.health > 0 && player2.health > 0)
    {
        Console.WriteLine($"\n--- ROUND {round} ---");
        Console.WriteLine("Press Enter to clash!");
        Console.ReadLine();

        player1.Attack(player2);
        battleLog.Push($"Round {round}: {player1.name} ({player1.health} HP) vs {player2.name} ({player2.health} HP)");

        Console.WriteLine($"{player1.name} HP: {player1.health}");
        Console.WriteLine($"{player2.name} HP: {player2.health}");
        
        round++;
    }

    Console.WriteLine("\n--- BATTLE OVER ---");
    if(player1.health <= 0 && player2.health <= 0)
    {
        Console.WriteLine("It's a draw! Both heroes were knocked out.");
    }

    else if(player1.health > 0)
    {
        Console.WriteLine($"{player1.name} wins!");
    }

    else
    {
        Console.WriteLine($"{player2.name} wins!");
    }

    Console.WriteLine("\n--- BATTLE LOG (Reverse Order) ---");
    while (battleLog.Count > 0)
    {
        Console.WriteLine(battleLog.Pop());
    }
}

else
{
    Console.WriteLine("\nYou need at least 2 heroes in the roster to start a battle!");
}
class Superhero
{
    public string name {get; set;}
    public int attack {get; set;}
    public int health {get; set;}

    public AcademicBackgrounds Background {get; set;}
    public PowerCategory Power {get; set;}
    public void Attack(Superhero target)
    {
        int actualDamage = this.attack;
        int OtherDamage = target.attack;

        if(this.Power == PowerCategory.Tech && target.Power == PowerCategory.Mutation)
        {
            Console.WriteLine("Tech advantage! Damage increased by 10%, opponent's damage decreased by 10%");
            actualDamage = (int)(this.attack * 1.10);
            OtherDamage = (int)(target.attack * 0.90);
        }

        else if(this.Power == PowerCategory.Mutation && target.Power == PowerCategory.Tech)
        {
            Console.WriteLine("Mutation disadvantage! Damage reduced by 10%, opponent's damage increased by 10%");
            actualDamage = (int)(this.attack * 0.90); 
            OtherDamage = (int)(target.attack * 1.10);
        }

        else if(this.Power == PowerCategory.Magic && target.Power == PowerCategory.Cosmic)
        {
            Console.WriteLine("Magic disadvantage! Damage reduced by 10%, opponent's damage increased by 10%");
            actualDamage = (int)(this.attack * 0.90); 
            OtherDamage = (int)(target.attack * 1.10);
        }

        else if(this.Power == PowerCategory.Cosmic && target.Power == PowerCategory.Magic)
        {
            Console.WriteLine("Cosmic advantage! Damage increased by 10%, opponent's damage decreased by 10%");
            actualDamage = (int)(this.attack * 1.10); 
            OtherDamage = (int)(target.attack * 0.90);
        }

        target.health -= actualDamage;
        this.health -= OtherDamage;
        
        Console.WriteLine($"{this.name} attacks {target.name} for {actualDamage} damage!");
        Console.WriteLine($"{target.name} attacks {this.name} for {OtherDamage} damage!");
    }
}

public struct AcademicBackgrounds
{
    public string AcademicDegree;
    public string University;
    public AcademicBackgrounds(string AcademicDegree, string University) 
    {
        this.AcademicDegree = AcademicDegree;
        this.University = University;
    }
}
enum PowerCategory {Tech, Magic, Cosmic, Mutation};






