# Golden Badge Challenge

This challenge is a collection of 3 console apps with connected repositories, each with their own specialization.

## Installation

The console apps all come with a .exe file for use, requiring no extra installations for use.

## Usage

The Komodo Cafe application, marked as Challenge One, comes with multiple options for the menu. Also include a dynamic numbering system so that menu options are never out of order.
```c#
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
```c#

//Adds a new claim
AddNewClaim(C2Claims claim );

//Gets the first claim on the list
GetFirstClaim();