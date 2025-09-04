# DonationTracker
Shelter Donation Tracker
This is how the UI looks 
<img width="1317" height="631" alt="image" src="https://github.com/user-attachments/assets/174419ba-cb54-45c8-ae1f-0d498568be46" />
<img width="1281" height="645" alt="image" src="https://github.com/user-attachments/assets/7e4c64ac-0d4e-4da2-b347-4456f1c40ec3" />

**How It Works** 

The application has two main parts that run separately but work together:

The Backend (C# API): This is a server application that manages the donation data. It exposes a set of URLs (like /donations) that the frontend can call to get, add, update, or delete information. It runs in a terminal window.

The Frontend (HTML/JS): This is the user interface that you see and interact with in your web browser. It sends requests to the backend's API to perform actions and display the latest data.

**Step 1:** Prerequisites
Before you begin, make sure you have the .NET 8 SDK installed. This is the only tool you need to run the backend.

Download .NET 8 SDK: https://dotnet.microsoft.com/download/dotnet/8.0

You can check if it's installed correctly by opening your terminal (Command Prompt, PowerShell, or Terminal on Mac/Linux) and running:

dotnet --version

You should see a version number starting with 8.x.x.

**Step 2:** Set Up the Project Files
Create a new .Net Core Web API project DonationTracker.

Inside the DonationTracker folder, create the following three files:

Program.cs

index.html

Copy and paste the code from the corresponding files I've provided into each of these new files.

Your folder structure should look like this:

DonationTracker/
├── Program.cs
└── index.html

**Step 3:** Run the Backend Server
Now, let's start the C# backend.

Open the terminal.

Navigate into the DonationTracker folder  created.

cd path/to/your/DonationTracker

Run the application using the following command:

dotnet run

The terminal will show some output, and you should see a line similar to this, which confirms the server is running:

info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5000

Leave this terminal window open! The backend is now running and waiting for requests from the frontend.

**Step 4:** Run the Frontend Application
This is the easiest part.

Go to your DonationTracker folder in your file explorer.

Double-click the index.html file.

This will open the file in your default web browser. The application is now fully functional. The JavaScript in the index.html file will automatically connect to your running backend at http://localhost:5000.

You can now add, edit, and delete donations.

If this does not then right click on the ``index.html`` file and click Open with Live Server as shown
<img width="358" height="42" alt="image" src="https://github.com/user-attachments/assets/28d14ee6-62af-430f-8c31-a028555214f2" />

