# Band Tracker
### A Band Tracker Application for Epicodus C# Advanced Databases Code Review _11.03.2017_

#### By Kimberly Bordon

## Description
_This is an application that exercises more advanced database queries using many-to-many relationships with C# and MySql. The application allows the user to enter, retrieve, edit, and delete data about a venue to a database, and they can also add, and retrieve information about a band. Additionally, they can retrieve data based on the many-to-many relationship between the stored venues and bands._

### Specs
|Behavior|Input|Output|
|-|-|-|
|User can see homepage with splash page for links to either add or view a band or add or view a venue.| User goes to homepage URL in browser.| User sees homepage with two sections for band and venues that each have two links to add to or view those sections. |
| User can go to form page to add venue. | User clicks link in Venue section that says "Add." | User is taken to form to add a Venue. |
| User can fill out form with venue details to add a venue. | User enters: <br>The Gaslamp<br><br> User clicks submit. | User is taken to venues list that displays all venues, including venue that is newly added. |
| User can view a list of all venues currently added. | User clicks "View" link. | User is taken to page with list of of all venues. |
| User can click on a specific venue to see its details. | User clicks venue on list of venues. | User is taken to venue's detail page. |
| User view list of bands that have played at a specific venue. | User clicks specific venue in venues list. | User is taken to detail page that displays list of bands that have played there. |
| User can add a band to venue's list of bands. | User selects a band from from the options that include those currently entered, and clicks add. | The detail page is updated with band added to the list. |
| User can update information of specific venue. | User clicks "EDIT" link on specific venue's page, and enters new information. <br><br>User clicks Submit. | The venue's information is updated, and the user is taken back to that venue's page with new information.|
| User can delete a venue that is no longer available. | User clicks on venue's specific page and clicks on "Delete" button. | User is taken back to page listing all venues, with the just deleted venue removed. |
| User can go to form page to add a band. | User clicks link in Band section that says "Add." | User is taken to form to add a Venue. |
| User can fill out form with band details to add a band. | User enters: <br>Imagine Dragons<br><br> User clicks submit. | User is taken to venues list that displays all venues, including venue that is newly added. |
| User can view all bands that have been entered. | User clicks "View" in Bands section of page. | User is taken to page that lists all bands. |
| User can see a page of band chosen at random. | User clicks "Discover a New Band." | User is taken to detail page of a random band. |
| User can see a specific band's information. | User clicks on band's name in bands list. | User is taken that band's detail page. |
| User can view list of venues that band has played. | User clicks specific band in band of list. | User is taken to detail page that displays list of venues they've played. |
| User can add a venue to bands's list of venues played. | User selects a venue from the options that include those currently entered, and clicks add. | The detail page is updated with venue added to the list. |

## Setup/Installation Requirements
* Enter the URL: https://github.com/kbordon/csharp-week4-code-review-bandtracker in your browser.
* Using your terminal or powershell, clone this repository by typing ```>git clone https://github.com/kbordon/csharp-week4-code-review-bandtracker.git```
    * Alternatively, you can use a browser to download the .zip file from the Github web interface at the URL: https://github.com/kbordon/csharp-week4-code-review-bandtracker.git
* To look at project code, navigate to the project folder csharp-week4-code-review-bandtracker, and use a text editor like Atom to open the README.md.
* For any use of the application, make sure you have [.NET Core 1.1 SDK (Software Development Kit)](https://download.microsoft.com/download/F/4/F/F4FCB6EC-5F05-4DF8-822C-FF013DF1B17F/dotnet-dev-win-x64.1.1.4.exe) and [.NET runtime](https://download.microsoft.com/download/6/F/B/6FB4F9D2-699B-4A40-A674-B7FF41E0E4D2/dotnet-win-x64.1.1.4.exe) both installed.
* To test the application:
  * First ensure you have the proper database setup by entering starting up MySql, and entering the following commands:
  ```SQL
  > CREATE database band_tracker_test;
  > USE band_tracker;
  > CREATE TABLE venues (id serial PRIMARY KEY, name VARCHAR (255), city VARCHAR (255), capacity INT);
  > CREATE TABLE bands (id serial PRIMARY KEY, name VARCHAR (255), popularity INT);
  > CREATE TABLE gigs (band_id INT, venue_id INT);
  ```
  * Using powershell or terminal, navigate to the folder named csharp-week4-code-review-bandtracker. Then enter the following commands:
  ```
  >cd csharp-week4-code-review-bandtracker
  >cd BandTracker.Tests
  >dotnet restore
  >dotnet test
  ```
  * You can view the tests code by using your powershell or terminal in the HairSalon.Tests folder, then typing ```>cd Model.Tests``` and then ```> atom .``` to open both the tests on the Stylist and Client classes. If you don't have Atom, use whichever text editor you have available.

* To run the application:
  * First, you must have the proper database setup by following these commands:
  ```SQL
  > CREATE database band_tracker;
  > USE band_tracker;
  > CREATE TABLE venues (id serial PRIMARY KEY, name VARCHAR (255), city VARCHAR (255), capacity INT);
  > CREATE TABLE bands (id serial PRIMARY KEY, name VARCHAR (255), popularity INT);
  > CREATE TABLE gigs (band_id INT, venue_id INT);
  ```
  * Using powershell or terminal, navigate to the folder named csharp-week4-code-review-bandtracker. Then enter the following commands:
  ```
  >cd csharp-week4-code-review-bandtracker
  >cd BandTracker
  >dotnet restore
  >dotnet run
  ```
  * Then, on your browser, go to the URL address: localhost:5000 or, whichever server your app might be running on.
  * Use the buttons, and forms to navigate the app.
  * Once you're finished, close the browser and turn off the server by entering <kbd>Ctrl</kbd> + <kbd>C</kbd> on your powershell or terminal.

## Known Bugs
* If entering a name that has a special character such as "$", word will be not be capitalized correctly (Example: "a$ap ferg" becomes "A$AP Ferg")
* Venues on a band's venue list, and vice-versa can be listed multiple times, which seems unnecessary. Would like to go back either make the query return only the first of each relationship, or attach additional information field, like date of the gig.

## Support and contact details

_If you have any questions, comments, or concerns, please contact Kimberly at [kbordon@gmail.com](mailto:kbordon@gmail.com)._

## Technologies Used

* Atom
* GitHub
* Gitbash
* C#
* CSS
* .NET framework
* MySql

### License

*This software is licensed under the MIT license.*

Copyright © 2017 **_Kimberly Bordon_**
