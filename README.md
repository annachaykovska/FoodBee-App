# FoodBee
#### By: Anna Chaykovska , Bennett Gunson , Daniel Ricasata, Anay Bhutoria, Meriam Senouci

<div align="center">
  <img height=256 src="https://raw.githubusercontent.com/annachaykovska/FoodBee-App/main/FoodBee/wwwroot/icon-512.png"/>
</div>


FoodBee is an application meant for helping patrons of food and beverage events navigate, search, and save their favourite local vendors. Featuring a venue map with navigation, search and the ability to bookmark enrtires, FoodBee allows users to quickly and efficiently find their way while on the go. FoodBee was developed in a web environment due to dsign constraints, however it is supposed to emulate a truly mobile experience. Event goers are more often than not going to these events with minimal towage, where a mobile smart phone is the most prominent use case. They need a platform which can be quickly referenced while walking, talking, eat or drinkin, so FoodBee takes that into account.

## Installation
To use the FoodBee demo application you can either clone and run the source youself. This requires Visual Studio and .NET 5.0, but to make life easier we have deployed the application using GitHub pages where you can access FoodBee from anywhere.

- Navigate to [FoodBee](https://annachaykovska.github.io/FoodBee-App) on your mobile device.
  - On IOS, open in Safari click the "Share/action icon"
  - On Android, open in Chrome and select the "3 dots"
- Select "Add to Home Screen"
- You should now see a FoodBee app icon on your device home screen

Now, you can open FoodBee as if it were a standalone mobile app.

## Design
As said above, FoodBee strives to be quick and efficient. We felt inspired by the organization of natural bee colonies, hence our name and design patterns. Festivals can be busy, crowded, and loud much like a beehive. Patrons don't want to waste their time clicking through pages just to find their favourite local brewery. 

## Implementation
Since FooBee was developed as a web-based system with the intention of being a mobile first experience, the implementation's full set of abilities is limited to what is possible within a browsr tab. You will find most features will be interactie and useable, however in addition to the development environment constraint and the fact this is a demonstration application, not all functionality has been implemented. 

### What Works
- Map: user can pan around the map and see their "current location"
- Searching: user can query vendors and products from a pre-loaded dataset.
- Filters: Food, Drink, Gluten Free, Lactose Free, No Nuts, Vedgan, Vegetarian
- Sorting: Cheapest, Closest (just orders based on ascending booth number), Newest (just returns the order from the dataset)
- Navigation: user can follow paths through vendors to products and vice-verse
- Bookmarking: user can save vendors and products using the bookmark button and they will show in their list of favourites (saves are only session based howver and are lost on a page refresh)

### What Doesn't Work
- Vendor booth numbers do not necessarily align with the numbering on the booth
- Users clicking "Go To Booth" buttons will see the map navigate to a static booth placed on the map, everytime.
- Tapping a booth on the map will also have the navigation point to the same (booth 813)
- Filters: 'Other', '$', '$$', '$$$', 'Alcoholic'
- Map Layers: just randomly spawns a differenly coloured map image with no correlation to what is selected
