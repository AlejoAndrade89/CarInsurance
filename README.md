🚗 CarInsurance Web Application <br>


📄 Project Overview
CarInsurance is a web application designed to allow users to calculate car insurance quotes based on various personal and vehicle-related factors. Through an intuitive form, users can input details such as their age, the year and model of their car, and any traffic violations (like speeding tickets or DUI offenses). Based on this information, the system automatically generates a monthly insurance quote estimate.

✨ Features
* 💡 Create a Quote: Users can input their personal and vehicle details to receive a customized insurance quote.
* 👀 View Quotes: Administrators can view all the quotes that have been generated, along with user details.
* ✏️ Edit & Delete Quotes: Users have the ability to edit or remove quotes as needed.
🛠️ Technologies Used
* C#: The primary programming language for implementing business logic and database interactions.
* ASP.NET MVC: Used as the main framework for building the web application.
* Entity Framework: ORM (Object-Relational Mapping) for managing database operations.
* Microsoft SQL Server: The database for storing user information and insurance quotes.
* HTML5 & CSS3: For creating the structure and styling of web pages.
* Bootstrap: A responsive front-end framework for styling and layout.
* jQuery & JavaScript: For client-side interactivity and form validation.
* IIS Express: Local development server for running and testing the application.
* Razor View Engine: For rendering dynamic views within the MVC framework.
⚙️ How It Works
The insurance quote is calculated based on the following criteria:

1.Base monthly cost: Starts at $50.
2.Age-based pricing:
* If the user is 18 or younger, add $100 to the base.
* If the user is between 19 and 25, add $50.
* If the user is 26 or older, add $25.
3.Car year:
* If the car is older than the year 2000, add $25.
* If the car is newer than the year 2015, add $25.
4.Car make and model:
* If the car is a Porsche, add $25.
* If the car is a Porsche 911 Carrera, add an additional $25.
  
5.Speeding tickets: Add $10 per ticket.<br>

6.DUI: If the user has a DUI, increase the total quote by 25%.<br>

7.Coverage type: If the user selects full coverage, increase the total quote by 50%.<br><br><br>

🛡️ Admin Panel
The admin panel allows administrators to manage all quotes:

* View a list of all issued quotes with user details.
* Access full details for each quote (name, email, car info, etc.).
* Edit or delete any quote from the list.
🚀 Getting Started
Prerequisites
* Visual Studio 2022 (or later)
* .NET Framework 4.x
* SQL Server (or SQL Server Express) <br><br>

Setup Instructions <br>
1.Clone the repository to your local machine: <br><br>
bash
Copy code
git clone https://github.com/AlejoAndrade89/CarInsurance.git<br>
2.Open the project in Visual Studio.<br>
3.Restore NuGet packages by right-clicking the solution and selecting Restore NuGet Packages.<br>
4.Configure the database connection string in web.config under the <connectionStrings> section.<br>
5.Run the database migrations (if applicable) or initialize the database using Entity Framework.<br>
6.Run the project: Press F5 or click Start in Visual Studio to launch the application using IIS Express.<br>


🧑‍💻 Contributing
We welcome contributions! To contribute:

Fork the repository.
1.Create a new branch (git checkout -b feature-branch).<br>
2.Make your changes and commit them (git commit -m 'Add new feature').<br>
3.Push the branch (git push origin feature-branch).<br>
4.Open a pull request, and we will review it.<br><br>

📧 Contact
If you have any questions or need further assistance, feel free to reach out:

Email: Andrade.ca89@gmail.com
GitHub: AlejoAndrade89

![image](https://github.com/user-attachments/assets/7d4d21c1-7ab5-4a0c-8b60-6ff1c91950d0)

📜 License
This project is licensed under the MIT License - see the LICENSE file for details.

