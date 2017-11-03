# BandTracker
##### by Kimberly Bordon

### Description

### Installation Instructions
> CREATE database band_tracker;
> USE band_tracker;
> CREATE TABLE venues (id serial PRIMARY KEY, name VARCHAR (255), city VARCHAR (255), capacity INT);
> CREATE TABLE bands (id serial PRIMARY KEY, name VARCHAR (255), popularity INT);
> CREATE TABLE gigs (band_id INT, venue_id INT);

### Technology Needed

### Specs
|Behavior|Input|Output|
|-|-|-|
|User can see homepage with splash page for links to either add or view a band or add or view a venue.| User goes to homepage URL in browser.| User sees homepage with two sections for band and venues that each have two links to add to or view those sections. |
| User can go to form page to add venue. | User clicks link in Venue section that says "Add." | User is taken to form to add a Venue. |
| User can fill out form with venue details to add a venue. | User enters: <br><br>The Gaslamp<br> out form and clicks submit. | User is taken to venues list that displays all venues, including venue that is newly added. |
| User can view a list of all venues currently added. | User clicks "View" link. | User is taken to page with list of of all venues. |
| User can click on a specific venue to see its details. | User clicks venue on list of venues. | User is taken to venue's detail page. |
| User can click

|The app will start user at the hair salon homepage to either add or view the current stylists.| The user goes to homepage.| The user is presented with homepage with title, and two links to either add or view current stylists.|
| Will allow user to see all the hair salon's current stylist. | The user clicks "View Stylists" link on the homepage. | The user is taken to new page that lists all stylists |
| Will allow user to go to form to enter a new stylist's information. | The user clicks "Add a Stylist" link on homepage. | The user is taken to a new page with a form to enter the new stylist. |
| Will allow user to fill form and add a stylist to list of stylist. | User enters: <br><br>Dylan Brook<br>503-444-6745<br><br> User clicks Submit | The user is taken to list of stylists, with newly added stylist. |
| Will allow user to select a stylist from the list, and see their information and clients. | User clicks a stylist name. | The user is taken to stylist's detail page, including list of client if they have any. |
| Will allow user to select a client from the stylist's list of current clients, and see their information. | User clicks a client's name. | The user is shown client's information. |
| Will allow user to add new clients to a stylist's client list. | User clicks "Add a Client" on stylist's detail page. | The user is taken to page with a client form. |
| Will allow user to fill out client information, and add client. | User enters:<br><br>Dahlia Miyazaki<br>503-859-3324<br><br> User clicks Submit | The user is taken to stylist's page of that client with client newly added to client list. |
| Will allow user to update a client's information details. | User clicks on edit link on the client's information, and enters new information.<br><br>User clicks Submit. | The client's information is updated, and the user is taken back to stylist page with new client information shown.|
| Will allow user to delete a client that no longer visits the salon. | User clicks on client's name on stylist's page. User clicks on "Delete" button on client's information page. | User is taken back to stylist page with list of clients without just removed client. |

### Known Bugs

### Contact Me

#### Legal

_Licensed under MIT license._
