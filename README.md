# BandTracker
##### by Kimberly Bordon

### Description

### Installation Instructions
> CREATE database band_tracker;
> USE band_tracker;
> CREATE TABLE venues (id serial PRIMARY KEY, name VARCHAR (255), capacity INT);
> CREATE TABLE bands (id serial PRIMARY KEY, name VARCHAR (255), popularity INT);
> CREATE TABLE gigs (band_id INT, venue_id INT);

### Technology Needed

### Specs
|Behavior|Input|Output|
|-|-|-|
|User can see homepage with splash page for links to either add or view a band or add or view a venue.| User goes to homepage URL in browser.| User sees homepage with two sections for band and venues that each have two links to add to or view those sections. |
| User can go to form page to add venue. | User clicks link in Venue section that says "Add." | User is taken to form to add a Venue. |
| User can fill out form with venue details to add a venue. | User fills out form and clicks submit. | User is taken to venues list that displays all venues, including venue that is newly added. |
| User can view a list of all venues currently added. | User clicks "View" link. | User is taken to page with list of of all venues. |
| User can click on a specific venue to see its details. | User clicks venue on list of venues. | User is taken to venue's detail page. |
| User can click  

### Known Bugs

### Contact Me

#### Legal

_Licensed under MIT license._
