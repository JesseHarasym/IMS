# Inventory Manager

# An inventory management system for video games. Made with C#, WinForms and T-SQL

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Installing

What you will need to run this application

```
git clone https://github.com/JesseHarasym/InventoryManager.git
```

### Load Database

You will also need to load the database associated with this program. This is not provided with the repo and you will need to contact me for a copy.
After recieving the database simply unzip it into your Debug\Database folder and attach it to Visual Studios, and you should be set to start.

### Running

After installing all files and loading the database, you can simply:

```
F5 or Start in your IDE
```

The program should now run. You will see a page with login and create user, an example admin and user is as follows:

Admin
username: admin 
password: admin123

User:
username: jlem
password: aaaaaa

## How it works

After using the information to login or you create an account, you can do the following according to your user type:

### Admin:

- Add a product to the inventory list to be sold
- Edit an existing product in the inventory list
- Delete any product that currently exists in the product list
- Add Stock Quantity to an existing product item 
- See any relevant notification, such as products gone on clearance, products with low stock and orders that have been automatically cancelled due to no pickup
- Dismiss notifications in the notification center that are not needed
- See all inventory items that are Pre-Orders with a future release date
- See all orders that have been made by customers for Pre-Order items
- Confirm an order has been picked up by a user
- Cancel an order that has been made by any user
- Search all orders or inventory by all or any chosen table header
- Create an account that is also an administrator

### User:

- Create an order with your account information to be picked up at a chosen location. 
- Cancel any order that has not yet been picked up from the location.
- See any orders that are considered a Pre-Order with an extended pickup date.
- Search any order that you have created by any criteria with an input keyword, or search any of your orders by choosing a specified table header (ex: Product Name). 

## Built With

- C#
- WinForm
- T-SQL

