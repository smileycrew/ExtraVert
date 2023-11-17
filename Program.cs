using System.Linq.Expressions;

List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Flax",
        LightNeeds = 1,
        AskingPrice = 1.99M,
        City = "City 1",
        ZIP = 11111,
        Sold = false,
        AvailableUntil = new DateTime(2023, 11, 16)
    },
    new Plant()
    {
        Species = "Brodiaea Filifolia",
        LightNeeds = 2,
        AskingPrice = 2.99M,
        City = "City 2",
        ZIP = 22222,
        Sold = false,
        AvailableUntil = new DateTime(2023, 11, 18)
    },
    new Plant()
    {
        Species = "Blue Myrtle-Cactus",
        LightNeeds = 3,
        AskingPrice = 3.99M,
        City = "City 3",
        ZIP = 33333,
        Sold = false,
        AvailableUntil = new DateTime(2023, 11, 18)
    },
    new Plant()
    {
        Species = "Astragalus Jaegerianus",
        LightNeeds = 4,
        AskingPrice = 4.99M,
        City = "City 4",
        ZIP = 44444,
        Sold = false,
        AvailableUntil = new DateTime(2023, 11, 18)
    },
    new Plant()
    {
        Species = "Limnanthes Floccosa",
        LightNeeds = 5,
        AskingPrice = 5.99M,
        City = "City 5",
        ZIP = 55555,
        Sold = true,
        AvailableUntil = new DateTime(2023, 11, 18)
    },
    new Plant()
    {
        Species = "ugly plant",
        LightNeeds = 2,
        AskingPrice = 1.99M,
        City = "City 6",
        ZIP = 77777,
        Sold = false,
        AvailableUntil = new DateTime(2023, 11, 18)
    }
};

Random random = new Random();

int randomInteger = random.Next(1, plants.Count);

string greeting = @"Welcome to ExtraVert.";

Console.Clear();

Console.WriteLine(greeting);

string choice = null;

while (choice != "0")
{
    Console.WriteLine(@$"Choose one of the following options:
    0. Cancel
    1. Display all plants
    2. Post a plant to be adopted
    3. Adopt a plant
    4. Delist a plant
    5. Plant of the day
    6. Search plants by light needs
    7. View app statistics");

    choice = Console.ReadLine();


    if (choice == "0")
    {
        Console.WriteLine("Goodbye");
    }
    else if (choice == "1")
    {
        DisplayAllPlants();
    }
    else if (choice == "2")
    {
        PostAPlant();
    }
    else if (choice == "3")
    {
        AdoptAPlant();
    }
    else if (choice == "4")
    {
        DelistAPlant();
    }
    else if (choice == "5")
    {
        PlantOfTheDay();
    }
    else if (choice == "6")
    {
        SearchPlantsByLightNeeds();
    }
    else if (choice == "7")
    {
        AppStatistics();
    }
    else
    {
        Console.WriteLine(@$"Please enter a valid response...
        You entered {choice}");
        Console.WriteLine(@"Enter any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
}

void DisplayAllPlants()
{
    for (int i = 0; i < plants.Count; i++)
    {
        string plantDetails = PlantDetails(plants[i]);
        Console.WriteLine($"{i + 1}. {plantDetails}");
    }
}

void PostAPlant()
{
    DateTime now = DateTime.Now;

    Plant newPlant = new Plant()
    {
        Species = null,
        LightNeeds = 0,
        AskingPrice = 0M,
        City = null,
        ZIP = 0,
        Sold = false,
        AvailableUntil = now
    };

    Console.WriteLine("What species is the plant?");

    newPlant.Species = Console.ReadLine();

    Console.Clear();

    Console.WriteLine($"the species you chose was {newPlant.Species}");

    Console.WriteLine(@"How much light does it require?
    Please choose a number between 1-5");

    while (newPlant.LightNeeds < 1 || newPlant.LightNeeds > 5)
    {
        if (newPlant.LightNeeds < 0 || newPlant.LightNeeds > 5)
        {
            Console.WriteLine("Please enter a number from 1 to 5");
        }
        try
        {
            newPlant.LightNeeds = int.Parse(Console.ReadLine().Trim());
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a number from 1 to 5");
        }
    }

    Console.WriteLine($"the light needed is {newPlant.LightNeeds}");

    Console.WriteLine("What is the asking price?");

    while (newPlant.AskingPrice <= 0M)
    {
        if (newPlant.AskingPrice < 0)
        {
            Console.WriteLine("Asking price cannot be less than 0");
        }
        try
        {
            newPlant.AskingPrice = decimal.Parse(Console.ReadLine().Trim());
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a decimal");
        }
    }

    Console.WriteLine($"Asking price is {newPlant.AskingPrice}");

    Console.WriteLine("What city are you in?");

    while (newPlant.City == null)
    {
        newPlant.City = Console.ReadLine().Trim();
    }

    Console.WriteLine($"City that you are in is {newPlant.City}");

    while (newPlant.ZIP == 0)
    {
        try
        {
            Console.WriteLine("What zip code are you in?");
            int response = int.Parse(Console.ReadLine().Trim());

            if (response < 99999 && response > 10000)
            {
                Console.WriteLine("here");
                newPlant.ZIP = response;
            }
            else
            {
                Console.WriteLine("Try another zip code");
            }

        }
        catch (FormatException)
        {
            Console.WriteLine("You entered a string");
        }
    }

    while (newPlant.AvailableUntil == now)
    {
        Console.WriteLine("Please enter a year");
        int year = int.Parse(Console.ReadLine().Trim());

        while (year < now.Year)
        {
            Console.WriteLine("Please enter a new year");
            Console.WriteLine($"year you chose is {year} and year set is {now.Year}");
            year = int.Parse(Console.ReadLine().Trim());
        }

        Console.WriteLine("Please enter a month");
        int month = int.Parse(Console.ReadLine().Trim());

        while (year == now.Year && month < now.Month && month <= 12)
        {
            Console.WriteLine("Month already passed");
            Console.WriteLine($"month you chose is {month} and month set is {now.Month}");
            Console.WriteLine("Please enter a new month");
            month = int.Parse(Console.ReadLine().Trim());
        }

        Console.WriteLine("Please enter a day");
        int day = int.Parse(Console.ReadLine().Trim());

        while (month == now.Month && day <= now.Day)
        {
            Console.WriteLine("Day already passed");
            Console.WriteLine($"The day you chose is {day} and the month set is {now.Day}");
            Console.WriteLine("Please enter a new day");
            day = int.Parse(Console.ReadLine().Trim());
        }
        try
        {
            newPlant.AvailableUntil = new DateTime(year, month, day);
            Console.WriteLine($"new plant is available until {newPlant.AvailableUntil}");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Date is invalid");
        }
    }

    plants.Add(newPlant);

}

void AdoptAPlant()
{
    // made a new list to hold my available plants
    List<Plant> availablePlants = new List<Plant>();

    DateTime now = DateTime.Now;

    Console.Clear();

    Console.WriteLine("Choose one of the following:");
    // used a for loop to display the plants from the new filtered list
    foreach (Plant plant in plants)
    {
        if (!plant.Sold && plant.AvailableUntil > now)
            availablePlants.Add(plant);
    }

    for (int i = 0; i < availablePlants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {availablePlants[i].Species}");
    }

    Plant chosenPlant = null;

    while (chosenPlant == null)
    {
        try
        {
            int response = int.Parse(Console.ReadLine().Trim()) - 1;
            chosenPlant = availablePlants[response];
            chosenPlant.Sold = true;

            Console.WriteLine($"You chose to adopt {chosenPlant.Species}");
        }
        catch (FormatException)
        {
            Console.WriteLine("You typed in a string");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("You typed in a number our of range");
        }
    }
}

void DelistAPlant()
{
    Plant chosenPlant = null;

    while (chosenPlant == null)
    {
        for (int i = 0; i < plants.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {plants[i].Species}");
        }

        try
        {
            int response = int.Parse(Console.ReadLine().Trim()) - 1;
            chosenPlant = plants[response];
            Console.WriteLine($"You chose to remove {chosenPlant.Species} from the list.");
            plants.RemoveAt(response);
        }
        catch (FormatException)
        {
            Console.WriteLine("You entered a string");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("You chose an out of range number");
        }

    }
}

void PlantOfTheDay()
{
    Plant plantOfTheDay = plants[randomInteger];

    // plantOfTheDay = plants[randomInteger];

    while (plantOfTheDay.Sold)
    {
        randomInteger = random.Next(1, plants.Count);
    }

    string plantDetails = PlantDetails(plantOfTheDay);

    Console.WriteLine(@$"Plant of the day is...
    the {plantOfTheDay.Species}, it is currently in {plantOfTheDay.City}. It requires {plantOfTheDay.LightNeeds} out of 5 sunlight and it is being sold for ${plantOfTheDay.AskingPrice}.");
}

void SearchPlantsByLightNeeds()

{
    List<Plant> plantsByLightNeeds = new List<Plant>();
    int chosenInteger = 0;
    while (chosenInteger < 1 || chosenInteger > 5)
    {
        try
        {
            Console.WriteLine("How much light?");
            chosenInteger = int.Parse(Console.ReadLine().Trim());
        }
        catch (FormatException)
        {
            Console.WriteLine("You entered a string please try again");
        }
    }
    foreach (Plant plant in plants)
    {
        if (!plant.Sold && plant.LightNeeds == chosenInteger)
        {
            plantsByLightNeeds.Add(plant);
        }
    }
    foreach (Plant plant in plantsByLightNeeds)
    {
        Console.WriteLine($"{plant.Species} is sold? {plant.Sold} light needed? {plant.LightNeeds}");
    }
}

void AppStatistics()

{
    // display lowest price plant name
    Plant lowestPricedPlant = plants[0];
    // number of plants available (not sold AND still available)
    List<Plant> availablePlants = new List<Plant>();

    DateTime now = DateTime.Now;
    // name of plant with highest light needs
    Plant highestLightNeedPlant = plants[0];
    // average ligh needs
    int totalLightNeed = 0;
    // percentage of plants adopted
    List<Plant> adoptedPlants = new List<Plant>();

    for (int i = 0; i < plants.Count; i++)
    {
        Plant currentPlant = plants[i];
        if (currentPlant.LightNeeds > highestLightNeedPlant.LightNeeds)
        {
            highestLightNeedPlant = currentPlant;
        }
        if (currentPlant.AskingPrice < lowestPricedPlant.AskingPrice)
        {
            lowestPricedPlant = currentPlant;
        }
        if (!currentPlant.Sold && currentPlant.AvailableUntil > now)
        {
            availablePlants.Add(currentPlant);
        }
        totalLightNeed += currentPlant.LightNeeds;
        if (plants[i].Sold)
        {
            adoptedPlants.Add(plants[i]);
        }
    }

    double averageLightNeed = (double)totalLightNeed / plants.Count;

    double percentageOfAdoptedPlants = (double)adoptedPlants.Count / (double)plants.Count * 100;

    Console.WriteLine($"The lowest priced plant is {lowestPricedPlant.Species}");

    Console.WriteLine($"The number of plants available is {availablePlants.Count}");

    Console.WriteLine($"The plant with the most light needed is {highestLightNeedPlant.Species}");

    Console.WriteLine($"The average light need is {averageLightNeed}");

    Console.WriteLine($"The percentage of plants adopted is {percentageOfAdoptedPlants}");
}

string PlantDetails(Plant plant)
{
    string plantDetails = $"{plant.Species} in {plant.City} {(plant.Sold ? "was sold" : "is available")} for ${plant.AskingPrice}.";

    return plantDetails;
}