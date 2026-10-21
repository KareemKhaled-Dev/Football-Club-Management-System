namespace Football_Club__Management_System
{
    class Player
    {
        public int Id;
        public string Name;
        public int PlayerAge;
        public int PlayerGoals;
        
public Player(int id, string name, int playerAge, int playerGoals)
        {
            Id = id;
            Name = name;
            PlayerAge = playerAge;
            PlayerGoals = playerGoals;
        }
    }
    class Club
    {
        public string NameClub;
        public string CityClub;
        
      public  List<Player> players=new List<Player>();

        public Club(string nameClub, string cityClub)
        {
            NameClub = nameClub;
            CityClub = cityClub;
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
    }
    
    class ManagementClubs
    {
        public List<Club>clubs=new List<Club>();
        public void SearchPlayer(string PlayerName)
        {
            bool result =false;
            for(int i = 0; i < clubs.Count; i++)
            {
                for(int j = 0; j < clubs[i].players.Count;j++)
                {
                    if (clubs[i].players[j].Name== PlayerName)
                    {
                        Console.WriteLine($"{PlayerName} play in {clubs[i].NameClub} and goals scored {clubs[i].players[j].PlayerGoals}");
                        result = true;
                    }
                }
            }
            if (result == false)
            {
                Console.WriteLine($"{PlayerName} not play football ");
            }
        }
        public bool SearchId(int Id)
        {
            bool result =false;
            for(int i=0; i < clubs.Count; i++)
            {
                for( int j = 0;j< clubs[i].players.Count; j++)
                {
                    if (clubs[i].players[j].Id == Id)
                    {
                        
                        Console.WriteLine($"player ID {Id} already exist in {clubs[i].NameClub}");
                       result = true;
                        break;
                    }
                }
            }
            return result; ;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ManagementClubs manage= new ManagementClubs();
            bool result = false;
            char choose;
            do
            {
                Console.WriteLine("===============Menu Management========");
                Console.WriteLine("A - create a club ");
                Console.WriteLine("B - Adding aplayer to a club ");
                Console.WriteLine("C - Display All Clubs ");
                Console.WriteLine("D - Search aplayer ");
                Console.WriteLine("Q - Quit ");
                Console.Write("Enter your choose: ");
                choose = Convert.ToChar(Console.ReadLine().ToUpper());
                
                switch(choose)
                {
                    case 'A':
                        Console.Write("Enter Name Club: ");
                        string NameClub = Console.ReadLine();
                        Console.Write("Enter the cityClub: ");
                        string CityClub= Console.ReadLine();
                        Club club = new Club(NameClub, CityClub);
                        manage.clubs.Add(club);
                        Console.WriteLine($"{NameClub} Added");

                        break;
                    case 'B':
                        
                        Console.Write("Enter Id for player: ");
                        int id=Convert.ToInt32(Console.ReadLine());
                        if (manage.SearchId(id) == false)
                        {
                            Console.Write("Enter NamePlayer: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter Age For Player: ");
                            int age = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter goals Scored: ");
                            int goals = Convert.ToInt32(Console.ReadLine());
                            Player player = new Player(id, name, age, goals);
                            Console.Write("enter ClubName do you want add player it: ");
                            string ClubName = Console.ReadLine();
                            for (int i = 0; i < manage.clubs.Count; i++)
                            {
                                if (manage.clubs[i].NameClub == ClubName)
                                {

                                    manage.clubs[i].AddPlayer(player);
                                    Console.WriteLine($"the player add to {ClubName}");
                                    result = true;

                                    break;
                                }
                            }
                            if (result == false)
                            {
                                Console.WriteLine($"The {ClubName} is not fount between list clubs");
                            }
                        } 
                        result = false;
                        break;

                    case 'C':
                        for(int i = 0; i < manage.clubs.Count; i++)
                        {
                            Console.WriteLine($"Club: {manage.clubs[i].NameClub} | City: {manage.clubs[i].CityClub}");
                            result = true;
                        }
                        if (result == false)
                        {
                            Console.WriteLine("No found any club");
                        }
                        result = false;
                        break;

                    case 'D':
                        Console.WriteLine("enter player want to search for club");
                        string playerName= Console.ReadLine();
                        manage.SearchPlayer(playerName);

                        break;
                    case 'Q':
                        Console.WriteLine("Good job see you later");
                        break;
                }

            } while (choose != 'Q');
        }
    }
}
