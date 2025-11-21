Part 1 of the POE
Overview
This project is a prototype for a web-based Lecturer Claims Management System designed to simplify the submission, verification, and processing of lecturer claims.It was developed using ASP.NET MVC (C#) to model the user interface, workflows, and navigation before implementing full functionality in Part 2.the goal of Part 1 was to design the front-end structure and logical flow of the system, focusing on user experience, layout consistency, and role-based dashboards.

Objectives
To create a user-friendly prototype interface for the claims management system.
To design separate views and navigation for:
Lecturers submit claims and view their claim history.
Programme coordinators view review, approve, or reject claims.
Academic managers view to process approved claims and generate reports.

Technologies Used
C#
ASP.NET MVC
Visual Studio

Limitations 
No real database data handled with in-memory lists.Buttons and forms simulated; no backend logic.File uploads and totals not stored persistently.
Basic styling no external CSS or javaScript frameworks.


Part 2 of the POE
Overview
The Monthly Contract Claim Management System is a web-based ASP.NET MVC application designed to streamline and automate the process of submitting, approving, and processing lecturer claims within an academic environment.
The system provides separate dashboards for Lecturers, Coordinators, and Managers, ensuring transparency, accountability, and efficient claim handling from submission to final approval.

Objectives
Simplify the claim submission and review process.
Maintain accurate claim records and history tracking.
Support multiple user roles with specific responsibilities.
Enable document upload, download, and reporting.

Workflow
Lecturer
Submits a new claim form with relevant details hours worked, hourly rate, claim title, user name, claim month, description).Uploads supporting documents PDF, DOCX, JPG, PNG and has a file size limit.Can filter, view, and download previous claims.
Automatically calculates claim total hours × hourly rate.Claim status updates pending ,approved or rejected.

Programme Coordinators
Reviews lecturer claims and verifies them.Approves or rejects claims.Tracks recent activity and view claim history.Generates monthly reports and analytics.

Academic Managers
Final stage of claim processing.Views all approved claims for processing.Marks claims as processed and records history.Views uploaded documents and generates downloadable reports.

Features
-Claim Submission Form:Lecturer name, date, title, description, hours, rate, and file upload.
-Auto-calculated total amount.
-Claim History Tracking
-Logs every action submitted, approved, rejected, processed with timestamps and performer.
-Dashboards per Role
-Lecturer: Quick access, claim summary, recent activity.
-Coordinator: Manage lecturers, verify pending claims, generate reports.
-Manager: Process final claims, view reports, and feedback actions.
-Filtering and Search:Filter claims by date and status.
-Document Management: Upload and view claim-related documents.

Technologies used
Razor Views 
HTML, CSS, Bootstrap style inline
ASP.NET Core MVC.NET 9
Database	Microsoft SQL Server with Entity Framework Core
Language	C#
Entity Framework Core for the first migrations
IDE	Visual Studio 
File Handling	IWebHostEnvironment for uploads

How to Use
Directed to the Lecturer Dashboard.
Submit new claims via Create New Claim.
Coordinator reviews claims approves or rejects.
Manager finalizes processes approved claims.
History updates and reports can be downloaded.

Unit Testing Overview
Add claim
Process claim
Claim approval 
Claim rejection
Encryption and decryption 

Database Setup Instructions
In visual studio open tools then package manager console
Then run the command "add-migration create"
Then update database

Database design
Consisted of two tables
-Claims
ClaimID,lecturer name,claim title ,description,claim month,hours worked,hourly rate,amount,status,document path,last updated,updated by. 

-ClaimHistories
HistoryID,claimID,performed by,timestamp	
