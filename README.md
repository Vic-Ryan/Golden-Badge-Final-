# Golden Badge Challenge

This challenge is a collection of 3 console apps with connected repositories, each with their own specialization.

## Installation

The console apps all come with a .exe file for use, requiring no extra installations for use.

## Usage

The Komodo Cafe application, marked as Challenge One, comes with multiple options for the menu. Also include a dynamic numbering system so that menu options are never out of order.
```csharp
//Adds a new menu item
AddNewItem(C1Menu menuItem);

//Removes a menu item, UI updates numbers.
RemoveMenuItem();

//Gets every menu item
GetAllItems();

//Gets a specific menu item
GetItemByNumber();
```

The claims application, marked as Challenge Two, is able to help with claims for insurance, including a validation that automatically checks if its within the 30 day limit.
```csharp

//Adds a new claim
AddNewClaim(C2Claims claim );

//Gets the first claim on the list
GetFirstClaim();

//Removes claims, usually connected to GetFirstClaim
RemoveClaim();
```

The security badges application, marked as Challenge Three, works with a dictionary and is able to add and remove doors to security badges, as well as update, delete, and create new badges.
```csharp
//Adds a new badge 
AddNewBadge(C3Badge badge);

//Updates ther list of doors on a badge
UpdateDoorInformation(int badgeId, string doorAccess);

//Removes a badge
RemoveBadge();

//Remove Door information
//RemoveDoorInformation(int badgeId, string doorAccess);
```

## Contributions

Pull requests not welcome at this time, as this project is a Final Project for Elevenfifty Academy. 

Pull requests from teachers at Elevenfifty Academy welcome.

## Authors

Lead: Victor Ryan

With special thanks to Jacob Brown for answering questions and helping with slight formatting problems.

## License

For use in Elevenfifty Academy only